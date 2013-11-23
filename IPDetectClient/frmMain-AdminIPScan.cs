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
        private const string MESSAGE_OUTPUT1 = "{0}-正在扫描IP: {1}, 第{2}个/共{3}个。\r\n";
        private const string MESSAGE_OUTPUT2 = "{0}-扫描结果: {1}。其中TCP Ping({2}ms) - {3}；TTL Ping - {4}。\r\n";
        private StringBuilder sbScanResult = new StringBuilder();
        private long LastUploadIPNum = 0;
        private int LastIPCountInLastThread = 100;
        private long NextScanStartIPNum = 0;
        private const int SCAN_COUNT_PER_THREAD = 100;
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

        private void btnScan_Click(object sender, EventArgs e)
        {
            if (IsScaning())
            {
                MessageBox.Show("当前IP地址已经在扫描中，无须再点击!", "警告");
                return;
            }

            this.txtScanResult.Clear();
            HaveScanedIPTotal = 0;
            ScanStartTime = DateTime.Now;
            this.CIDRSettingsForScan.Clear();

            int threadLimit = Convert.ToInt32(this.tab5_threadLimit.Value);
            IPScanTreads = new Thread[threadLimit];

            var ipSettingsAll = this.p5_dgvIPRangeList.DataSource as List<CIDRSettingModel>;

            var ipSettings = new  List<CIDRSettingModel>();
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
                MessageBox.Show("请选择需要扫描的IP地址!","警告");
                return;
            }

            sbScanResult = new StringBuilder();

            if (CIDRSettingsForScan == null || CIDRSettingsForScan.Count == 0)
            {
                return;
            }

            Thread thread = new Thread(new ThreadStart(MultiThreadExecute));
            thread.Start();
        }

        private void MultiThreadExecute()
        {
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
                var uploadList = new List<IPScanResult>();

                if (oipList != null && oipList is List<IPScan>)
                {
                    List<IPScan> ipList = oipList as List<IPScan>;
                    int ipCount = ipList.Count;
                    int validCount = 0;
                    for (int i = 0; i < ipCount; i++)
                    {
                        if (OnIPScanProgress != null)
                        {
                            //{0}-正在扫描IP: {1}, 第{2}个/共{3}个。
                            string s = String.Format(MESSAGE_OUTPUT1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), ipList[i].IP, i + 1, ipCount);
                            OnIPScanProgress(i, ipCount, s);
                        }

                        ipList[i].StartIPScan();

                        IPScanResult r = new IPScanResult
                        {
                            IP = ipList[i].IP,
                            TTLResult = ipList[i].PingResult,
                            TCPResult = ipList[i].TCPPingResult,
                            TCPTime = ipList[i].TCPPingTimes,
                            TCPFaZhi = ipList[i].TCPFaZhiSet
                        };
                      
                        uploadList.Add(r);
                        HaveScanedIPTotal++;

                        if (OnIPScanProgress != null)
                        {
                            string scanResult = "异常";

                            if (ipList[i].TCPPingResult == "正常" && ipList[i].PingResult == "正常")
                            {
                                scanResult = "正常";
                                validCount++;
                            }
                            //{0}-扫描结果: TCP Ping({1}ms) - {2}；ICMP Ping - {3}。\r\n
                            string s = String.Format(MESSAGE_OUTPUT2, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), scanResult, ipList[i].TCPPingTimes, ipList[i].TCPPingResult, ipList[i].PingResult);
                            OnIPScanProgress(i + 1, ipCount, s);

                            if (ipCount == i + 1)
                            {
                                long totalTimes = Convert.ToInt64((DateTime.Now - begin).TotalSeconds);
                                OnIPScanProgress(i + 1, ipCount, String.Format("{0}-扫描完毕，共扫描{1}个IP,其中{2}个正常，{3}个异常，总耗时 {4} 秒。\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), ipCount, validCount, ipCount - validCount, totalTimes));
                            }
                        }
                    }

                }

                // 計算TCP 響應時間的平均值
                int tcpResponseTimeAvg = 0;
                int tcpResponseTimeTotal = 0;
                int tcpNormalCount = 0;
                foreach (var item in uploadList)
                {
                    if (item.TCPResult == "正常" && item.TCPTime > 0)
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
                    foreach (var item in uploadList)
                    {
                        if (item.TCPResult == "正常" && item.TCPTime > 0)
                        {
                            if (AbsolutValue(item.TCPTime, tcpResponseTimeAvg) > item.TCPFaZhi)
                            {
                                item.TCPResult = "异常";
                            }
                        }
                    }
                }

                string uploadResponse = CIDRSettingBiz.UploadIPScanResults(uploadList);

                if (!String.IsNullOrEmpty(uploadResponse))
                {
                    OnIPScanProgress(uploadList.Count, uploadList.Count, uploadResponse + "\r\n");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        //private void p5_dgvIPRangeList_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        //{
        //    DataGridView dgv = (DataGridView)sender;
        //    if (dgv[0, e.RowIndex].Value == "2")
        //    {
        //        e.Cancel = true;
        //    }
        //    else
        //    {
        //        e.Cancel = false;
        //    }
        //}


        private void p5_dgvIPRangeList_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //int cellIndex = e.ColumnIndex;
            //int rowIndex = e.RowIndex;
            //int cell = 0;
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
            Thread result = null;
            for(int i = 0; i < IPScanTreads.Length;i++)
            {
                if (IPScanTreads[i] == null || !IPScanTreads[i].IsAlive)
                {
                    IPScanTreads[i] = new Thread(new ParameterizedThreadStart(IPScanProcess));
                    result = IPScanTreads[i];
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
