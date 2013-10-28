using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using IPDectect.Client.Models;
using IPDectect.Client.Common;
using System.Net;
using System.Threading;
using IPDectect.Client.Business;

namespace IPDectect.Client
{
    public partial class frmScan : Form
    {
        private delegate void IPScanProgress(int currentValue, int maxValue, string message,bool append);
        private event IPScanProgress OnIPScanProgress;

        private const string MESSAGE_OUTPUT1 = "{0}-正在扫描IP: {1}, 第{2}个/共{3}个。\r\n";
        private const string MESSAGE_OUTPUT2 = "{0}-扫描结果: {1}。其中TCP Ping({2}ms) - {3}；TTL Ping - {4}。\r\n";
        private StringBuilder sbScanResult = new StringBuilder();
        
        public frmScan()
        {
            InitializeComponent();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void frmScan_Load(object sender, EventArgs e)
        {
            OnIPScanProgress += new IPScanProgress(UpdateUIProgress);
        }

        private void btnScan_Click(object sender, EventArgs e)
        {

            var ipSettings = CIDRSettingBiz.GetCIDRSettings();
    
            sbScanResult = new StringBuilder();
            //var ip1 = IPAddress.Parse("58.251.93.95");
            //var ip2 = IPAddress.Parse("58.251.93.255");

            var ip1 = IPAddress.Parse(ipSettings[0].IPStart);
            var ip2 = IPAddress.Parse(ipSettings[0].IPStart);
            var ipRange = IPScan.GetIPRange(ip1, ip2);
            List<IPScan> ipList = new List<IPScan>();
            foreach (string ipstr in ipRange)
            {
                IPScan scan = new IPScan();
                scan.IP = ipstr;
                scan.TTLFaZhiSet = ipSettings[0].TTLFaZhi;
                scan.TCPFaZhiSet = ipSettings[0].TCPFaZhi;
                scan.TCPPortSet = ipSettings[0].TCPPort;
                ipList.Add(scan);
            }

            // start scan
            //foreach (var ip in ipList)
            //{
                Thread t = new Thread(new ParameterizedThreadStart(IPScanProcess));

                // parameter
                t.Start(ipList);
            //}
        }

        private void IPScanProcess(object oipList)
        {
            try
            {
                DateTime begin = DateTime.Now;
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
                            OnIPScanProgress(i, ipCount, s ,false);
                        }

                        ipList[i].StartIPScan();

                        if (OnIPScanProgress != null)
                        {
                            string scanResult = "异常";

                            if (ipList[i].TCPPingResult == "正常" && ipList[i].PingResult == "正常")
                            {
                                scanResult = "正常";
                                validCount++;
                            }
                            //{0}-扫描结果: TCP Ping({1}ms) - {2}；ICMP Ping - {3}。\r\n
                            string s = String.Format(MESSAGE_OUTPUT2, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), scanResult,ipList[i].TCPPingTimes, ipList[i].TCPPingResult, ipList[i].PingResult);
                            OnIPScanProgress(i + 1, ipCount, s , false);

                            if (ipCount == i + 1)
                            {
                                long totalTimes = Convert.ToInt64((DateTime.Now - begin).TotalSeconds);
                                OnIPScanProgress(i + 1, ipCount, String.Format("{0}-扫描完毕，共扫描{1}个IP,其中{2}个正常，{3}个异常，总耗时 {4} 秒。\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), ipCount, validCount, ipCount - validCount, totalTimes), false);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateUIProgress(int currentValue, int maxValue, string message, bool append)
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
