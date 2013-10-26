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

namespace IPDectect.Client
{
    public partial class frmMain 
    {

        private void RetriveHandleStatus(object obj)
        {
            try
            {
                if (obj != null)
                {
                    ObjectEntity objEntity = obj as ObjectEntity;
                    MonitorData data = objEntity.Data as MonitorData;
                    frmMain mainForm = objEntity.UIControl as frmMain;

                    MonitorBiz biz = new MonitorBiz();
                    var result = biz.RetriveClientIP(data);

                    SettingBiz settingBiz = new SettingBiz();
                    var settingData = settingBiz.GetSettings();

                    // repeat run
                    if (settingData.EnableMannulRun && settingData.MannulRequestServerTimes > 1)
                    {
                        for (int i = settingData.MannulRequestServerTimes; i > 1; i--)
                        {
                            result = biz.RetriveClientIP(data);
                        }
                    }

                    _lastClientIPUID = result.UID;
                    mainForm.p2_lbl_ip.Text = result.IP;
                    mainForm.p2_lbl_ipbelongto.Text = String.Format("{0} {1} {2}", result.RealOperator, result.RealOperatorProvince, result.RealOperatorCity).Trim();

                    // public ip is displaying set 5%
                    if (OnIPRetriveProgress != null)
                    {
                        OnIPRetriveProgress(5);
                    }

                    // trace route
                    RouteTrace();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }

        private void RouteTrace()
        {
            ProcessStartInfo si = new ProcessStartInfo("tracert.exe");
            si.Arguments = Constants.TraceRouteArguments;
            // Redirect both streams so we can write/read them. 
            si.RedirectStandardInput = true;
            si.RedirectStandardOutput = true;
            si.RedirectStandardError = true;
            si.CreateNoWindow = true;
            si.UseShellExecute = false;
            si.WindowStyle = ProcessWindowStyle.Hidden;

            Process cmd = new Process();
            cmd.StartInfo = si;
            cmd.EnableRaisingEvents = true;
            cmd.OutputDataReceived += new DataReceivedEventHandler(cmd_OutputDataReceived);
            cmd.ErrorDataReceived += new DataReceivedEventHandler(cmd_ErrorDataReceived);
            // Start the procses. 
            cmd.Start();
            cmd.BeginOutputReadLine();
        }

        private void cmd_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            try
            {
                if (e.Data == null)
                {
                    // submit route info to server.
                    if (this.CurrentRouteItems != null && this.CurrentRouteItems.Count > 0)
                    {
                        MonitorBiz routeBiz = new MonitorBiz();
                        CurrentRouteItems = routeBiz.SubmitRouteDataToServer(this.CurrentRouteItems, _lastClientIPUID);
                    }

                    if (OnIPRetriveProgress != null)
                    {
                        OnIPRetriveProgress(100);
                    }
                }

                if (String.IsNullOrEmpty(e.Data))
                {
                    return;
                }

                // step is 5
                if (OnIPRetriveProgress != null)
                {
                    int percent = this.CurrentProgressbarPercent;
                    int newPercent = percent;
                    if (percent < 90)
                    {
                        newPercent += 5;

                    }
                    else if (percent < 99)
                    {
                        newPercent += 1;
                    }
                    else
                    {
                        newPercent = 99;
                    }

                    OnIPRetriveProgress(newPercent, e.Data.Trim());
                }

                // get one route info item and add it to list
                //1     5 ms    25 ms    15 ms  220.179.33.11
                string receivedData = e.Data.Trim().Replace("    ", "|").Replace("  ", "|");
                //string[] segments = Regex.Split(e.Data.Trim(), "  ",RegexOptions.IgnorePatternWhitespace);
                string[] segments = receivedData.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                if (segments.Length == 5)
                {
                    //add to route items
                    RouteItem ri = new RouteItem();
                    ri.SeqNo = Convert.ToInt32(String.IsNullOrEmpty(segments[0]) ? "0" : segments[0].Trim());
                    ri.T1 = segments[1] == null ? null : segments[1].Trim();
                    ri.T2 = segments[2] == null ? null : segments[2].Trim();
                    ri.T3 = segments[3] == null ? null : segments[3].Trim();
                    ri.RouteIP = segments[4] == null ? null : segments[4].Trim();

                    ri.RouteDate = DateTime.Now;

                    CurrentRouteItems.Add(ri);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }

        private void cmd_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                //MessageBox.Show(e.Data, "错误");
            }
        }

        private int CurrentProgressbarPercent
        {
            get
            {
                int percent = 100 * p2_progressBar.Value / p2_progressBar.Maximum;
                return percent;
            }
        }

        private void UpdateUIProgress(int percent, string message = null)
        {
            this.p2_progressBar.Maximum = 100;
            this.p2_progressBar.Value = percent;

            // show status text
            if (percent <= 5)
            {
                this.p2_lbl_progress.Text = "1 / 10";
                this.p2_lbl_progressStatus.Text = String.Format(_progessbarStatusDisplay, "检测本机出口IP");
            }
            else if (percent > 5 && percent < 10)
            {
                this.p2_lbl_progress.Text = "2 / 10";
                this.p2_lbl_progressStatus.Text = String.Format(_progessbarStatusDisplay, "主控服务器加密解密数据准备");
            }
            else if (percent >= 10 && percent < 15)
            {
                this.p2_lbl_progress.Text = "3 / 10";
                this.p2_lbl_progressStatus.Text = String.Format(_progessbarStatusDisplay, "查找主控服务器");
            }
            else if (percent >= 15 && percent < 20)
            {
                this.p2_lbl_progress.Text = "4 / 10";
                this.p2_lbl_progressStatus.Text = String.Format(_progessbarStatusDisplay, "加密测试节点数据传输");
            }
            else if (percent >= 20 && percent < 25)
            {
                this.p2_lbl_progress.Text = "5 / 10";
                this.p2_lbl_progressStatus.Text = String.Format(_progessbarStatusDisplay, "机密测试节点状态验证");
            }
            else if (percent >= 25 && percent < 75)
            {
                this.p2_lbl_progress.Text = "6 / 10";
                this.p2_lbl_progressStatus.Text = String.Format(_progessbarStatusDisplay + "    {1}", "路由跟踪", message);
            }
            else if (percent >= 75 && percent < 80)
            {
                this.p2_lbl_progress.Text = "7 / 10";
                this.p2_lbl_progressStatus.Text = String.Format(_progessbarStatusDisplay, "查询结果保存分析");
            }
            else if (percent >= 80 && percent < 85)
            {
                this.p2_lbl_progress.Text = "8 / 10";
                this.p2_lbl_progressStatus.Text = String.Format(_progessbarStatusDisplay, "主控服务器加密解密数据准备");
            }
            else if (percent >= 85 && percent < 90)
            {
                this.p2_lbl_progress.Text = "9 / 10";
                this.p2_lbl_progressStatus.Text = String.Format(_progessbarStatusDisplay, "加密数据上传至服务器");
            }
            else
            {
                this.p2_progressBar.Value = 99;
                this.p2_lbl_progress.Text = "10 / 10";
                this.p2_lbl_progressStatus.Text = String.Format(_progessbarStatusDisplay, "加密数据清除");
            }

            if (percent >= 100)
            {
                // complete
                this.p2_progressBar.Visible = false;
                this.p2_lbl_progressStatus.Visible = false;
                this.p2_lbl_IsRetriving.Visible = false;
                this.p2_lbl_progress.Visible = false;

                this.p2_btnSearchagain.Visible = true;
                this.p2_btnBack.Visible = true;
                this.p2_lblViewRouteDetail.Visible = true;

                this.AcceptButton = this.p2_btnSearchagain;
                this.CancelButton = this.p2_btnBack;
            }
        }

        private void p2_btnBack_Click(object sender, EventArgs e)
        {
            NavigateToIPRetriveHome();
        }

        private void NavigateToIPRetriveHome()
        {
            this.AcceptButton = this.btnIPRetrive;
            this.Panel_P1_IPRetrive.Visible = true;
            this.Panel_P2_IPRetriving.Visible = false;
            this.Panel_P3_route.Visible = false;
            this.Panel_P4_logSearch.Visible = false;

            this.p2_progressBar.Value = 0;
            this.p2_lbl_progressStatus.Text = "";
            this.p2_lbl_progress.Text = "1 / 10";
        }

        private void p2_btnSearchagain_Click(object sender, EventArgs e)
        {
            btnIPRetrive_Click(null, null);
        }

        private void p2_link_viewroute_detail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                this.Panel_P1_IPRetrive.Visible = false;
                this.Panel_P2_IPRetriving.Visible = false;
                this.Panel_P3_route.Visible = true;
                this.Panel_P4_logSearch.Visible = false;

                this.CancelButton = this.p3_btn_back;
                //this.p3_dvRoute.DataSource = null;
                this.p3_dvRoute.AutoGenerateColumns = false;
                this.p3_dvRoute.DataSource = this.CurrentRouteItems;
                this.p3_dvRoute.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }
    }
}
