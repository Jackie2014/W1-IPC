using IPDectect.Client.Business;
using IPDectect.Client.Common;
using IPDectect.Client.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Net;
using IPDetectServer.Models;

namespace IPDectect.Client
{
    public partial class frmMain 
    {
        private delegate void IPScanProgress(int currentValue, int maxValue, string message);
        private event IPScanProgress OnIPScanProgress;
        private static Thread[] IPScanTreads = new Thread[5];
        //private static int CurrentIPScanIndex = 0;
        //private const string MESSAGE_OUTPUT1 = "{0}-正在扫描IP: {1}, 第{2}个/共{3}个。\r\n";
        //private const string MESSAGE_OUTPUT2 = "{0}-扫描结果: {1}。其中TCP Ping({2}ms) - {3}；TTL Ping - {4}。\r\n";
        private const string MESSAGE_OUTPUT = "{0}-扫描IP: {1}, 第{2}个/共{3}个。  {4} 扫描结果: {5}。其中TCP Ping({6}ms) - {7}；TTL Ping - {8}。\r\n";
        private StringBuilder sbScanResult = new StringBuilder();
        //private long LastUploadIPNum = 0;
       
        private long NextScanStartIPNum = 0;
        private const int SCAN_COUNT_PER_THREAD = 255;
        private int LastIPCountInLastThread = SCAN_COUNT_PER_THREAD;
        private bool IsCancelScanThread = false;
        private int HaveScanedIPTotal = 0;
        private List<CIDRSettingModel> CIDRSettingsForScan = new List<CIDRSettingModel>();
        private DateTime ScanStartTime = DateTime.Now;

        private void menuScan_Click(object sender, EventArgs e)
        {
            try
            {
                top_lblCurrentIPRetrive.Image = null;
                top_lblHelp.Image = null;
                top_lblLogQuery.Image = null;
                top_lblIPScan.Image = imageList1.Images[0];

                this.p5_dgvIPRangeList.DefaultCellStyle.ForeColor = Color.Black;
                //top_lblCurrentIPRetrive.Image = imageList1.Images[0];
                //top_lblHelp.Image = null;
                //top_lblLogQuery.Image = null;

                //this.Panel_P1_IPRetrive.Visible = false;
                //this.Panel_P2_IPRetriving.Visible = false;
                //this.Panel_P3_route.Visible = false;
                //this.Panel_P4_logSearch.Visible = false;
                //this.panel_p5_adminScan.Visible = true;
                this.panel_p5_adminScan.BringToFront();

                var ipSettings = CIDRSettingBiz.GetCIDRSettings();

                int i = 1;
                foreach (var item in ipSettings)
                {
                    item.Seq = i;
                    i++;
                }

                p5_dgvIPRangeList.AutoGenerateColumns = false;
                this.p5_dgvIPRangeList.DataSource = ipSettings;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }

        private void btnScanStop_Click(object sender, EventArgs e)
        {
            try
            {
                this.btnScanStop.Enabled = false;
                this.btnScan.Enabled = true;
                IsCancelScanThread = true;
                // 终止所有线程
                foreach (var thread in IPScanTreads)
                {
                    if(thread != null && thread.IsAlive)
                    {
                        try
                        {
                            thread.Abort();
                            thread.Join();
                        }
                        catch { }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }
        private void btnScan_Click(object sender, EventArgs e)
        {
            try
            {
                this.CIDRSettingsForScan.Clear();
                var ipSettingsAll = this.p5_dgvIPRangeList.DataSource as List<CIDRSettingModel>;

                var ipSettings = new List<CIDRSettingModel>();
                if (ipSettingsAll != null)
                {
                    foreach (var item in ipSettingsAll)
                    {
                        if (item.Selected)
                        {
                            CIDRSettingsForScan.Add(item);
                        }
                    }
                }

                if (CIDRSettingsForScan == null || CIDRSettingsForScan.Count == 0)
                {
                    MessageBox.Show("请选择需要扫描的IP地址!", "警告");
                    return;
                }


                this.btnScan.Enabled = false;
                this.btnScanStop.Enabled = true;
                this.IsCancelScanThread = false;
                this.lblScanedIPCount.Text = "0";
                this.lblScanElasped.Text = "0";
     
                if (IsScaning())
                {
                    MessageBox.Show("当前IP地址已经在扫描中，无须再点击!", "警告");
                    return;
                }

                string startIP = DataManager.Read(Constants.SEPARATE_NextScanStartIP);
                if (!String.IsNullOrEmpty(startIP))
                {
                    string message = String.Format("上次扫描的最后IP地址是:{0},您需要从{0}继续吗?", startIP);
                    if (MessageBox.Show(message, "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        NextScanStartIPNum = IPConverter.ip2long(startIP) + 1;
                    }
                    else
                    {
                        NextScanStartIPNum = 0;
                        DataManager.Save(Constants.SEPARATE_NextScanStartIP, "");
                    }
                }

                this.txtScanResult.Clear();
                HaveScanedIPTotal = 0;
                ScanStartTime = DateTime.Now;
                int threadLimit = Convert.ToInt32(this.tab5_threadLimit.Value);
                IPScanTreads = new Thread[threadLimit];

                sbScanResult = new StringBuilder();

                if (CIDRSettingsForScan == null || CIDRSettingsForScan.Count == 0)
                {
                    return;
                }
                
                LastIPCountInLastThread = SCAN_COUNT_PER_THREAD;
                Thread thread = new Thread(new ThreadStart(MultiThreadExecute));
                thread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"错误");
            }
        }

        private void MultiThreadExecute()
        {
            if (IsCancelScanThread) return;

            if (CIDRSettingsForScan == null || CIDRSettingsForScan.Count == 0)
            {
                return;
            }

            Thread t = null;

            // 循环直到所有的IP都扫描完毕
            while (LastIPCountInLastThread == SCAN_COUNT_PER_THREAD)
            {
                //get a free thread
                t = GetThreadFromPool();
                if (t == null)
                {
                    if (IsCancelScanThread)
                        break;
                    // 如果没有空闲的线程，等待1秒
                    Thread.Sleep(1000);
                }
                else
                {
                    // get ip list per thread
                    var ipScanList = GetScanIPListPerThread();
                    t.Start(ipScanList);
                }
            };

            // 执行完毕
            //this.IsCancelScanThread = true;
            //this.btnScan.Enabled = true;
            //this.btnScanStop.Enabled = false;
        }

        private List<IPScan> GetScanIPListPerThread()
        {
            lock (this)
            {
                List<IPScan> result = new List<IPScan>();
                int ipCountIndex = 0;
                long ipNum = NextScanStartIPNum;
                foreach (var cidr in CIDRSettingsForScan)
                {
                    if(NextScanStartIPNum == 0)
                    {
                        NextScanStartIPNum = cidr.IPStartNum;
                        ipNum = NextScanStartIPNum;
                    }

                    if(NextScanStartIPNum >= cidr.IPStartNum && NextScanStartIPNum <= cidr.IPEndNum)
                    {
                        while (ipCountIndex < SCAN_COUNT_PER_THREAD
                            && ipNum <= cidr.IPEndNum)
                        {
                            IPScan scan = new IPScan();
                            scan.IP = IPConverter.long2ip(ipNum);
                            scan.TTLFaZhiSet = cidr.TTLFaZhi;
                            scan.TCPFaZhiSet = cidr.TCPFaZhi;
                            scan.TCPPortSet = cidr.TCPPort;

                            if (!String.IsNullOrEmpty(cidr.TTLExceptionKeys))
                            {
                                scan.ExceptionKeys = cidr.TTLExceptionKeys.Split(',');
                            }

                            result.Add(scan);

                            ipNum++;
                            ipCountIndex++;
                        }
                    }

                    if (ipCountIndex == SCAN_COUNT_PER_THREAD)
                    {
                        NextScanStartIPNum = ipNum;
                        break;
                    }
                    else
                    {
                        NextScanStartIPNum = 0;
                    }
                }

                LastIPCountInLastThread = result.Count;
                return result;
            }
        }

        private void IPScanProcess(object oipList)
        {
            try
            {
                DateTime begin = DateTime.Now;
                var scanList = new List<IPScanResult>();
                var exceptionIPList = new List<IPScanResult>();
                if (oipList != null && oipList is List<IPScan>)
                {
                    List<IPScan> ipList = oipList as List<IPScan>;
                    int ipCount = ipList.Count;
                    //int validCount = 0;
                    for (int i = 0; i < ipCount; i++)
                    {
                        DateTime dt1 = DateTime.Now;
                        ipList[i].StartIPScan();

                        IPScanResult r = new IPScanResult
                        {
                            IP = ipList[i].IP,
                            TTLResult = ipList[i].PingResult,
                            TCPResult = ipList[i].TCPPingResult,
                            TCPTime = ipList[i].TCPPingTimes,
                            TCPFaZhi = ipList[i].TCPFaZhiSet
                        };

                        scanList.Add(r);

                        HaveScanedIPTotal++;

                        if (OnIPScanProgress != null)
                        {
                            string scanResult = IPScan.RESULT_FAIL;

                            if ((ipList[i].TCPPingResult == IPScan.RESULT_SUCCESS || ipList[i].TCPPingResult == IPScan.RESULT_TIMEOUT)
                                && ipList[i].PingResult == IPScan.RESULT_SUCCESS)
                            {
                                scanResult = IPScan.RESULT_SUCCESS;
                                //validCount++;
                            }
                            //{0}-扫描结果: TCP Ping({1}ms) - {2}；ICMP Ping - {3}。\r\n
                            //  "{0}-扫描IP: {1}, 第{2}个/共{3}个。  {4} 扫描结果: {5}。其中TCP Ping({6}ms) - {7}；TTL Ping - {8}。\r\n";
                            string s = String.Format(MESSAGE_OUTPUT, dt1.ToString("yyyy-MM-dd HH:mm:ss"), ipList[i].IP,i + 1, ipCount,
                                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),scanResult, 
                                ipList[i].TCPPingTimes, ipList[i].TCPPingResult, ipList[i].PingResult);
                            OnIPScanProgress(i + 1, ipCount, s);
                        }
                    }
                }

                // 計算TCP 響應時間的平均值
                int tcpResponseTimeAvg = 0;
                int tcpResponseTimeTotal = 0;
                int tcpNormalCount = 0;
                foreach (var item in scanList)
                {
                    if (item.TCPResult == IPScan.RESULT_SUCCESS && item.TCPTime > 0)
                    {
                        tcpResponseTimeTotal += item.TCPTime;
                        tcpNormalCount++;
                    }
                }

                if (tcpResponseTimeTotal > 0 && tcpNormalCount > 0)
                {
                    tcpResponseTimeAvg = Convert.ToInt32(tcpResponseTimeTotal / tcpNormalCount);
                }

                // 判断TCP响应时间是否超过阀值,如果超过设为异常
                if (tcpResponseTimeAvg > 0)
                {
                    foreach (var item in scanList)
                    {
                        if (item.TCPResult == IPScan.RESULT_SUCCESS && item.TCPTime > 0)
                        {
                            if (AbsolutValue(item.TCPTime, tcpResponseTimeAvg) > item.TCPFaZhi)
                            {
                                item.TCPResult = IPScan.RESULT_FAIL;
                            }
                        }
                    }
                }

                foreach (var item in scanList)
                {
                    if (item.TCPResult == IPScan.RESULT_FAIL || item.TTLResult == IPScan.RESULT_FAIL)
                    {
                        exceptionIPList.Add(item);
                    }
                }

                string uploadResponse = CIDRSettingBiz.UploadIPScanResults(exceptionIPList);

                // 记录最后的IP地址,万一关机或意外，下次扫描从该IP继续，不要从头再开始
                try
                {
                    DataManager.Save(Constants.SEPARATE_NextScanStartIP, scanList[scanList.Count - 1].IP);
                }
                catch
                { }

                if (!String.IsNullOrEmpty(uploadResponse))
                {
                    OnIPScanProgress(scanList.Count, scanList.Count, uploadResponse + "\r\n");
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private int AbsolutValue(int v1, int v2)
        {
            if (v1 >= v2)
            {
                return v1 - v2;
            }
            else
            {
                return v2 - v1;
            }
        }
        private void UpdateUIProgressForIPScan(int currentValue, int maxValue, string message)
        {
            this.progressBar1.Maximum = maxValue;
            this.progressBar1.Value = currentValue;

            if (currentValue == maxValue)
            {
                sbScanResult = new StringBuilder();
            }
            else
            {
                sbScanResult.Insert(0, message);
            }
            this.txtScanResult.Text = sbScanResult.ToString();
            this.lblScanedIPCount.Text = this.HaveScanedIPTotal.ToString();
            TimeSpan ts = DateTime.Now - this.ScanStartTime;
            this.lblScanElasped.Text = String.Format("{0}:{1}:{2}", ts.Hours, ts.Minutes, ts.Seconds);
        }

        private bool IsScaning()
        {
            lock (this)
            {
                bool result = false;

                foreach (var t in IPScanTreads)
                {
                    if (t != null && t.IsAlive)
                    {
                        result = true;
                    }
                }

                return result;
            }
        }

        private Thread GetThreadFromPool()
        {
            if (IsCancelScanThread)
                return null;

            Thread result = null;
            for(int i = 0; i < IPScanTreads.Length;i++)
            {
                //if (IPScanTreads[i] == null)
                //{
                //    IPScanTreads[i] = new Thread(new ParameterizedThreadStart(IPScanProcess));
                //    result = IPScanTreads[i];
                //    break;
                //}
                //else if (IPScanTreads[i] != null && !IPScanTreads[i].IsAlive)
                //{
                //    result = IPScanTreads[i];
                //    break;
                //}

                if (IPScanTreads[i] == null || !IPScanTreads[i].IsAlive)
                {
                    IPScanTreads[i] = new Thread(new ParameterizedThreadStart(IPScanProcess));
                    result = IPScanTreads[i];
                    break;
                }
            }

            return result;
        }

        private void p5_chk_selectedAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.p5_dgvIPRangeList.Rows == null || this.p5_dgvIPRangeList.Rows.Count == 0)
            {
                return;
            }

            bool ischecked = this.p5_chk_selectedAll.Checked;
            
            for (int i=0; i<this.p5_dgvIPRangeList.Rows.Count; i++)
            {
                if (p5_dgvIPRangeList.Rows[i].Cells[1] != null)
                {

                    p5_dgvIPRangeList.Rows[i].Cells[1].Value = ischecked;
                }
            }
        }

        private void txtScanResult_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.A))
            {
                txtScanResult.SelectAll();
                e.Handled = true;
            }
        }

    }
}
