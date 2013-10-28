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
        private delegate void IPScanProgress(int currentValue, int maxValue, string message, bool append);
        private event IPScanProgress OnIPScanProgress;
        private static Thread[] IPScanTreads = new Thread[10];
        private static int CurrentIPScanIndex = 0;
        private const string MESSAGE_OUTPUT1 = "{0}-正在扫描IP: {1}, 第{2}个/共{3}个。\r\n";
        private const string MESSAGE_OUTPUT2 = "{0}-扫描结果: {1}。其中TCP Ping({2}ms) - {3}；TTL Ping - {4}。\r\n";
        private StringBuilder sbScanResult = new StringBuilder();

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
                MessageBox.Show("当前IP地址已经在扫描中，无须再点击!");
                return;
            }

            this.txtScanResult.Clear();
            CurrentIPScanIndex = 0;
  
            var ipSettings = this.p5_dgvIPRangeList.DataSource as List<CIDRSettingModel>;

            sbScanResult = new StringBuilder();

            if (ipSettings == null || ipSettings.Count == 0)
            {
                return;
            }
            Thread thread = new Thread(new ParameterizedThreadStart(MultiThreadExecute));
            thread.Start(ipSettings);
       
        }

        private void MultiThreadExecute(object ips)
        {
            if (ips == null || !(ips is List<CIDRSettingModel>))
            {
                return;
            }

            var ipSettings = ips as List<CIDRSettingModel>;
            foreach (var item in ipSettings)
            {
                Thread t = GetThreadFromPool();
                if (t != null)
                {
                    var ip1 = IPAddress.Parse(ipSettings[CurrentIPScanIndex].IPStart);
                    var ip2 = IPAddress.Parse(ipSettings[CurrentIPScanIndex].IPEnd);
                    var ipRange = IPScan.GetIPRange(ip1, ip2);
                    List<IPScan> ipList = new List<IPScan>();
                    foreach (string ipstr in ipRange)
                    {
                        IPScan scan = new IPScan();
                        scan.IP = ipstr;
                        scan.TTLFaZhiSet = ipSettings[CurrentIPScanIndex].TTLFaZhi;
                        scan.TCPFaZhiSet = ipSettings[CurrentIPScanIndex].TCPFaZhi;
                        scan.TCPPortSet = ipSettings[CurrentIPScanIndex].TCPPort;
                        ipList.Add(scan);
                    }

                    // parameter
                    t.Start(ipList);
                    CurrentIPScanIndex++;
                }

                while(GetThreadFromPool() == null)
                {
                    Thread.Sleep(1000);
                };
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
                            OnIPScanProgress(i, ipCount, s, false);
                        }

                        ipList[i].StartIPScan();

                        IPScanResult r = new IPScanResult
                        {
                            IP = ipList[i].IP,
                            TTLResult = ipList[i].PingResult,
                            TCPResult = ipList[i].TCPPingResult,
                            TCPTime = ipList[i].TCPPingTimes
                        };
                      
                        uploadList.Add(r);

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
                            OnIPScanProgress(i + 1, ipCount, s, false);

                            if (ipCount == i + 1)
                            {
                                long totalTimes = Convert.ToInt64((DateTime.Now - begin).TotalSeconds);
                                OnIPScanProgress(i + 1, ipCount, String.Format("{0}-扫描完毕，共扫描{1}个IP,其中{2}个正常，{3}个异常，总耗时 {4} 秒。\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), ipCount, validCount, ipCount - validCount, totalTimes), false);
                            }
                        }
                    }

                }

                string uploadResponse = CIDRSettingBiz.UploadIPScanResults(uploadList);
                if (!String.IsNullOrEmpty(uploadResponse))
                {
                    OnIPScanProgress(uploadList.Count, uploadList.Count, uploadResponse + "\r\n", false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateUIProgressForIPScan(int currentValue, int maxValue, string message, bool append)
        {
            this.progressBar1.Maximum = maxValue;
            this.progressBar1.Value = currentValue;
            //this.lblScanMessage.Text = message;
            if (append)
            {
                sbScanResult.Append(message);
            }
            else
            {
                sbScanResult.Insert(0, message);
            }
            this.txtScanResult.Text = sbScanResult.ToString();
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
            int cellIndex = e.ColumnIndex;
            int rowIndex = e.RowIndex;
            int cell = 0;
        }

        private bool IsScaning()
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
    }
}
