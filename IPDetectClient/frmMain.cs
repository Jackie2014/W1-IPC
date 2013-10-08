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
    public partial class frmMain : Form
    {
        private Point _lastClick;
        internal static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        private delegate void IPRetriveProgress(int percent, string message = null);
        private delegate void LogQueryStatus(int status, string message);
        private event IPRetriveProgress OnIPRetriveProgress;
        private event LogQueryStatus OnLogQueryStatus;
        private static string _progessbarStatusDisplay = "当前进行项: {0}...";
        private static int _lastClientIPUID = 0;
        private List<ClientIPResponse> _clientIPLogs = new List<ClientIPResponse>();
        private List<ClientIPResponse> _clientIPLogsNotMatched = new List<ClientIPResponse>();
        private bool _isAutoRun = false;
        public frmMain(bool isAutoRun = false)
        {
            _isAutoRun = isAutoRun;
            InitializeComponent();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            OnIPRetriveProgress += new IPRetriveProgress(UpdateUIProgress);
            OnLogQueryStatus += new LogQueryStatus(frmMain_OnLogQueryStatus);

            try
            {
                SettingBiz biz = new SettingBiz();
                myTimer.Tick += new EventHandler(TimerEventProcessor);
                myTimer.Interval = biz.GetSettings().ExecuteInterval * (1000 * 60 * 60);
                myTimer.Start();

                if (isAutoRun)
                {
                    SettingBiz settingBiz = new SettingBiz();
                    var settingData = settingBiz.GetSettings();
                    SendRequestToRetrieveIP(settingData.StartupRunTimes);
                }
            }
            catch { }
        }

        private static void TimerEventProcessor(Object myObject,EventArgs myEventArgs)
        {
            try
            {
                // execute ip check
                SettingBiz settingBiz = new SettingBiz();
                var settingData = settingBiz.GetSettings();

                // repeat run
                MonitorBiz monBiz = new MonitorBiz();
                if (settingData.EnableMannulRun && settingData.MannulRequestServerTimes > 0)
                {
                    SendRequestToRetrieveIP(settingData.MannulRequestServerTimes);
                }
            }
            catch { }
        }

        private static void SendRequestToRetrieveIP(int repeatNum)
        {
            MonitorBiz monBiz = new MonitorBiz();
            MonitorData data = monBiz.ReadRetriveCondition();

            if (data != null && !String.IsNullOrEmpty(data.ClientRecordor)
                && !String.IsNullOrEmpty(data.ClientCity)
                && !String.IsNullOrEmpty(data.ExpectedOperator)
                && repeatNum > 0)
            {
                // client internal ip
                data.ClientPrivateIP = NetworkHelper.GetLocalIPAddress();

                for (int i = repeatNum; i > 0; i--)
                {
                    monBiz.RetriveClientIP(data);
                }
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                if (_isAutoRun)
                {
                    this.WindowState = FormWindowState.Minimized;
                    this.Hide();
                }
                this.ShowIcon = false;
                top_lblCurrentIPRetrive.Image = this.imageList1.Images[0];
                //this.pictureBox2.Image = this.imageList1.Images[0];
                List<RegionModel> provinces1 = RegionDataProvider.GetProvinces();
                List<RegionModel> provinces2 = RegionDataProvider.GetProvinces();
                provinces1.Insert(0, RegionDataProvider.EMPTY_ITEM);
                provinces2.Insert(0, RegionDataProvider.EMPTY_ITEM);

                this.cmbProvince1.DataSource = provinces1;
                this.cmbProvince1.DisplayMember = "Name";
                this.cmbProvince1.ValueMember = "Code";

                this.cmbProvince2.DataSource = provinces2;
                this.cmbProvince2.DisplayMember = "Name";
                this.cmbProvince2.ValueMember = "Code";

                this.cmbOperators.SelectedIndex = 0;

                #region restor retrive condition from previous saving

                MonitorBiz biz = new MonitorBiz();
                MonitorData condition = biz.ReadRetriveCondition();

                if (condition != null)
                {
                    this.txtRecordor.Text = condition.ClientRecordor;

                    //运营商省
                    if (!String.IsNullOrEmpty(condition.ExpectedOperatorProvice))
                    {
                        foreach (var item in cmbProvince1.Items)
                        {
                            RegionModel dataItem = item as RegionModel;
                            if (condition.ExpectedOperatorProvice == dataItem.Name)
                            {
                                cmbProvince1.SelectedItem = item;
                                break;
                            }
                        }
                    }

                    //运营商市
                    if (!String.IsNullOrEmpty(condition.ExpectedOperatorCity))
                    {
                        foreach (var item in cmbCity1.Items)
                        {
                            RegionModel dataItem = item as RegionModel;
                            if (condition.ExpectedOperatorCity == dataItem.Name)
                            {
                                cmbCity1.SelectedItem = item;
                                break;
                            }
                        }
                    }

                    //运营商名称
                    if (!String.IsNullOrEmpty(condition.ExpectedOperator))
                    {
                        bool isInList = false;
                        foreach (var item in this.cmbOperators.Items)
                        {
                            if (condition.ExpectedOperator == item as string)
                            {
                                cmbOperators.SelectedItem = item;
                                isInList = true;
                                break;
                            }
                        }

                        if (!isInList)
                        {
                            txtOperatorOther.Visible = true;
                            cmbOperators.SelectedIndex = 4; // other
                            txtOperatorOther.Text = condition.ExpectedOperator;
                        }
                    }

                    // 客户省
                    if (!String.IsNullOrEmpty(condition.ClientProvince))
                    {
                        foreach (var item in cmbProvince2.Items)
                        {
                            RegionModel dataItem = item as RegionModel;
                            if (condition.ClientProvince == dataItem.Name)
                            {
                                cmbProvince2.SelectedItem = item;
                                break;
                            }
                        }
                    }

                    //客户市
                    if (!String.IsNullOrEmpty(condition.ClientCity))
                    {
                        foreach (var item in cmbCity2.Items)
                        {
                            RegionModel dataItem = item as RegionModel;
                            if (condition.ClientCity == dataItem.Name)
                            {
                                cmbCity2.SelectedItem = item;
                                break;
                            }
                        }
                    }

                    //客户区县
                    if (!String.IsNullOrEmpty(condition.ClientDistinct))
                    {
                        foreach (var item in cmbDistinct.Items)
                        {
                            RegionModel dataItem = item as RegionModel;
                            if (condition.ClientDistinct == dataItem.Name)
                            {
                                cmbDistinct.SelectedItem = item;
                                break;
                            }
                        }
                    }

                    //客户详细地址
                    this.txtDetailAddress.Text = condition.ClientDetailAddress;
                }

                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }

        private void cmbProvince1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selectedProvice = null;

                if (this.cmbProvince1.SelectedValue != null)
                {
                    //if (this.cmbProvince1.SelectedValue is RegionModel) return;

                    selectedProvice = this.cmbProvince1.SelectedValue.ToString();
                }

                if (!String.IsNullOrEmpty(selectedProvice))
                {
                    List<RegionModel> cities = RegionDataProvider.GetChildren(selectedProvice);
                    cities.Insert(0, RegionDataProvider.EMPTY_ITEM);
                    this.cmbCity1.DataSource = cities;
                    this.cmbCity1.DisplayMember = "Name";
                    this.cmbCity1.ValueMember = "Code";

                    // sync provice2 dropdownlist
                    //if (this.cmbProvince2.SelectedValue == "-1")
                    //{
                    //    this.cmbProvince2.SelectedValue = this.cmbProvince1.SelectedValue;
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }

        private void cmbProvince2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selectedProvice = null;

                if (this.cmbProvince2.SelectedValue != null)
                {
                    //if (this.cmbProvince2.SelectedValue is RegionModel) return;
                    selectedProvice = this.cmbProvince2.SelectedValue.ToString();
                }

                if (!String.IsNullOrEmpty(selectedProvice))
                {
                    List<RegionModel> cities = RegionDataProvider.GetChildren(selectedProvice);
                    cities.Insert(0, RegionDataProvider.EMPTY_ITEM);
                    this.cmbCity2.DataSource = cities;
                    this.cmbCity2.DisplayMember = "Name";
                    this.cmbCity2.ValueMember = "Code";

                    // sync provice1 dropdownlist
                    //if (this.cmbProvince1.SelectedValue == "-1")
                    //{
                    //    this.cmbProvince1.SelectedValue = this.cmbProvince2.SelectedValue;
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }

        private void cmbCity1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //if (this.cmbCity2.SelectedValue == "-1" && this.cmbProvince2.SelectedValue == this.cmbProvince1.SelectedValue)
                //{
                //    this.cmbCity2.SelectedValue = this.cmbCity1.SelectedValue;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }


        private void cmbCity2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selectedCity = null;

                if (this.cmbCity2.SelectedValue != null)
                {
                    //if (this.cmbCity2.SelectedValue is RegionModel) return;
                    selectedCity = this.cmbCity2.SelectedValue.ToString();
                }

                if (!String.IsNullOrEmpty(selectedCity))
                {
                    List<RegionModel> distincts = RegionDataProvider.GetChildren(selectedCity);
                    distincts.Insert(0, RegionDataProvider.EMPTY_ITEM);
                    this.cmbDistinct.DataSource = distincts;
                    this.cmbDistinct.DisplayMember = "Name";
                    this.cmbDistinct.ValueMember = "Code";

                    //if (this.cmbCity1.SelectedValue == "-1" && this.cmbProvince2.SelectedValue == this.cmbProvince1.SelectedValue)
                    //{
                    //    this.cmbCity1.SelectedValue = this.cmbCity2.SelectedValue;
                    //}
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }

        private void cmbOperators_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // other
                if (cmbOperators.SelectedIndex == 4)
                {
                    this.txtOperatorOther.Clear();
                    this.txtOperatorOther.Visible = true;
                }
                else
                {
                    this.txtOperatorOther.Clear();
                    this.txtOperatorOther.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }

        private void btnIPRetrive_Click(object sender, EventArgs e)
        {
            try
            {
                if (OnIPRetriveProgress != null)
                {
                    OnIPRetriveProgress(0);
                }
                //this.p2_lbl_progressStatus.Text = String.Format(_progessbarStatusDisplay, "检测本机出口IP");

                MonitorData data = new MonitorData();
                data.ClientRecordor = this.txtRecordor.Text.Trim();

                if ((this.cmbProvince1.SelectedItem as RegionModel).Code != "-1")
                {
                    data.ExpectedOperatorProvice = (this.cmbProvince1.SelectedItem as RegionModel).Name;
                }

                if ((this.cmbCity1.SelectedItem as RegionModel).Code != "-1")
                {
                    data.ExpectedOperatorCity = (this.cmbCity1.SelectedItem as RegionModel).Name;
                }

                if ((this.cmbProvince2.SelectedItem as RegionModel).Code != "-1")
                {
                    data.ClientProvince = (this.cmbProvince2.SelectedItem as RegionModel).Name;
                }

                if ((this.cmbCity2.SelectedItem as RegionModel).Code != "-1")
                {
                    data.ClientCity = (this.cmbCity2.SelectedItem as RegionModel).Name;
                }

                if ((this.cmbDistinct.SelectedItem as RegionModel).Code != "-1")
                {
                    data.ClientDistinct = (this.cmbDistinct.SelectedItem as RegionModel).Name;
                }

                data.ClientDetailAddress = this.txtDetailAddress.Text.Trim();

                if (cmbOperators.SelectedIndex == 4)
                {
                    data.ExpectedOperator = this.txtOperatorOther.Text.Trim();
                }
                else if (cmbOperators.SelectedIndex > 0)
                {
                    data.ExpectedOperator = this.cmbOperators.SelectedItem as string;
                }

                // client internal ip
                data.ClientPrivateIP = NetworkHelper.GetLocalIPAddress();

                // check required field
                bool inputRecorderInfo = false;
                bool inputOperatorInfo = false;
                bool inputClientAddress = false;

                if (!String.IsNullOrEmpty(data.ClientRecordor))
                {
                    inputRecorderInfo = true;
                }

                if (!String.IsNullOrEmpty(data.ExpectedOperatorProvice)
                   && !String.IsNullOrEmpty(data.ExpectedOperatorCity)
                   && !String.IsNullOrEmpty(data.ExpectedOperator))
                {
                    inputOperatorInfo = true;
                }

                if (!String.IsNullOrEmpty(data.ClientProvince)
                   && !String.IsNullOrEmpty(data.ClientCity)
                   && !String.IsNullOrEmpty(data.ClientDetailAddress))
                {
                    inputClientAddress = true;
                }

                // input is invalid
                if (!inputRecorderInfo || !inputOperatorInfo || !inputClientAddress)
                {
                    StringBuilder sbMessage = new StringBuilder();
                    if (!inputRecorderInfo)
                        sbMessage.Append("录入人");

                    if (!inputOperatorInfo)
                    {
                        if (sbMessage.Length > 0)
                        {
                            if (!inputClientAddress)
                            {
                                sbMessage.Append(",");
                            }
                            else
                            {
                                sbMessage.Append("和");
                            }
                        }

                        sbMessage.Append("所属宽带运营商");
                    }


                    if (!inputClientAddress)
                    {
                        if (sbMessage.Length > 0) sbMessage.Append("和");

                        sbMessage.Append("详细地址");
                    }

                    sbMessage.Insert(0, "请输入");
                    sbMessage.Append("信息。");
                    MessageBox.Show(sbMessage.ToString(), "警告");
                    return;
                }

                // save to local
                SaveRetriveCondition(data);

                // hide current panel and show ip retriving panel
                this.Panel_P1_IPRetrive.Visible = false;
                this.Panel_P2_IPRetriving.Visible = true;

                this.p2_progressBar.Visible = true;
                this.p2_lbl_progressStatus.Visible = true;
                this.p2_lbl_IsRetriving.Visible = true;
                this.p2_lbl_progress.Visible = true;
                this.ActiveControl = this.p2_label1;

                this.p2_btnSearchagain.Visible = false;
                this.p2_btnBack.Visible = false;
                this.p2_lblViewRouteDetail.Visible = false;

                // init UI data 
                this.p2_lblProvice_text.Text = data.ExpectedOperatorProvice;
                this.p2_lblCity_text.Text = data.ExpectedOperatorCity;
                this.p2_lblISP_text.Text = data.ExpectedOperator;
                this.p2_lbl_ip.Text = "";
                this.p2_lbl_ipbelongto.Text = "";

                CurrentRouteItems.Clear();
                Thread t = new Thread(new ParameterizedThreadStart(RetriveHandleStatus));

                // parameter
                ObjectEntity objEntity = new ObjectEntity();
                objEntity.Data = data;
                objEntity.UIControl = this;
                t.Start(objEntity);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }

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
                    mainForm.p2_lbl_ipbelongto.Text = String.Format("{0} {1} {2}",result.RealOperator, result.RealOperatorProvince, result.RealOperatorCity).Trim();

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

        List<RouteItem> _currentRouteItems = new List<RouteItem>();
        private List<RouteItem> CurrentRouteItems
        {
            get
            {
                return _currentRouteItems;
            }
            set
            {
                _currentRouteItems = value;
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

        private void SaveRetriveCondition(MonitorData data)
        {
            try
            {
                MonitorBiz biz = new MonitorBiz();
                biz.SaveRetriveConditionToLocal(data);
            }
            catch (Exception ex)
            {
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

        private void p3_btn_back_Click(object sender, EventArgs e)
        {
            this.Panel_P1_IPRetrive.Visible = false;
            this.Panel_P2_IPRetriving.Visible = true;
            this.Panel_P3_route.Visible = false;
            this.Panel_P4_logSearch.Visible = false;
        }

        private void BindLogGrid(int pageIndex, int pageSize, bool onlyNotMatched)
        {
            this.p4_dvLog.AutoGenerateColumns = false;

            int totalRows = onlyNotMatched ? _clientIPLogsNotMatched.Count : _clientIPLogs.Count;
            int totalPages = (totalRows + pageSize - 1) / pageSize;

            this.P4_lblExport.Enabled = totalRows > 0;


            if (pageIndex <= 0) pageIndex = 1;
            if (pageIndex >= totalPages) pageIndex = totalPages;

            // get current page data and bind it
            List<ClientIPViewModel> currentPageList = new List<ClientIPViewModel>();
            int startIndex = (pageIndex - 1) * pageSize;
            int index = 0;

            if (onlyNotMatched)
            {
                foreach (var item in _clientIPLogsNotMatched)
                {
                    index++;
                    if (index > startIndex)
                    {
                        ClientIPViewModel ipView = new ClientIPViewModel(item);
                        ipView.SeqNo = index;
                        currentPageList.Add(ipView);
                    }

                    if (index >= startIndex + pageSize)
                    {
                        break;
                    }
                }
            }
            else
            {
                foreach (var item in _clientIPLogs)
                {
                    index++;
                    if (index > startIndex)
                    {
                        ClientIPViewModel ipView = new ClientIPViewModel(item);
                        ipView.SeqNo = index;
                        currentPageList.Add(ipView);
                    }

                    if (index >= startIndex + pageSize)
                    {
                        break;
                    }
                }
            }

            this.p4_lbl_pageTotalRow.Text = String.Format("共 {0} 条", totalRows);
            this.p4_page_totalPages.Text = String.Format("of {0} 页", totalPages);
            this.p4_txt_currentpage.Text = pageIndex.ToString();

            if (pageIndex <= 1)
            {
                pageIndex = 1;
                this.p4_pic1.Enabled = false;
                this.p4_pic2.Enabled = false;
            }
            else
            {
                this.p4_pic1.Enabled = true;
                this.p4_pic2.Enabled = true;
            }

            if (pageIndex >= totalPages)
            {
                pageIndex = totalPages;
                this.p4_pic3.Enabled = false;
                this.p4_pic3.Enabled = false;
            }
            else
            {
                this.p4_pic3.Enabled = true;
                this.p4_pic3.Enabled = true;
            }

            this.p4_txt_currentpage.Text = pageIndex.ToString();
            this.p4_dvLog.DataSource = currentPageList;
        }

        private void p4_txt_currentpage_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }

        private void p4_chk_onlyNotMatched_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                BindLogGrid(1, Constants.PAGE_SIZE, p4_chk_onlyNotMatched.Checked);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }

        private void p4_btn_GoToPage_Click(object sender, EventArgs e)
        {
            try
            {
                int pageIndex = Convert.ToInt32(this.p4_txt_currentpage.Text.Trim());
                BindLogGrid(pageIndex, Constants.PAGE_SIZE, this.p4_chk_onlyNotMatched.Checked);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }

        private void frmMain_MouseDown(object sender, MouseEventArgs e)
        {
            _lastClick = new Point(e.X, e.Y); 
        }

        private void frmMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - _lastClick.X;
                this.Top += e.Y - _lastClick.Y;
            };
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            //this.Close();
            this.WindowState = FormWindowState.Minimized;
            this.Hide();
        }

        private void P4_lblExport_Click(object sender, EventArgs e)
        {
            try
            {
                string saveFileName = "";
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "CSV文件(逗号分割)|*.csv|文本文件|*.txt";
                saveFileDialog1.Title = "查询日志导出文件";
                saveFileDialog1.ShowDialog();

                if (String.IsNullOrEmpty(saveFileDialog1.FileName))
                {
                    return;
                }
                else
                {
                    saveFileName = saveFileDialog1.FileName;
                }

                List<ClientIPViewModel> exportList = new List<ClientIPViewModel>();
                int index = 1;
                if (p4_chk_onlyNotMatched.Checked)
                {
                    foreach (var item in _clientIPLogsNotMatched)
                    {
                        ClientIPViewModel ipView = new ClientIPViewModel(item);
                        ipView.SeqNo = index;
                        exportList.Add(ipView);
                        index++;
                    }
                }
                else
                {
                    foreach (var item in _clientIPLogs)
                    {
                        ClientIPViewModel ipView = new ClientIPViewModel(item);
                        ipView.SeqNo = index;
                        exportList.Add(ipView);
                        index++;
                    }
                }

                var csvExport = new CSVExport<ClientIPViewModel>(exportList);

                Dictionary<string, string> headerNames = new Dictionary<string, string>();
                //{ "No.", "查询时间", "录入人", "待验证运营商", "详细地址", "IP", "查询结果", "判断结果" }
                headerNames.Add("SeqNo", "No.");
                headerNames.Add("QueryDate", "查询时间");
                headerNames.Add("Recordor", "录入人");
                headerNames.Add("ExpectedISP", "待验证运营商");
                headerNames.Add("Address", "详细地址");
                headerNames.Add("IP", "IP");
                headerNames.Add("RealISP", "查询结果");
                headerNames.Add("StatusDisplay", "判断结果");

                csvExport.ExportToFile(saveFileName, headerNames);

                MessageBox.Show("查询日志已成功导出到 " + saveFileName + "。", "导出成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }

        private void p4_pic1_Click(object sender, EventArgs e)
        {
            try
            {
                BindLogGrid(1, Constants.PAGE_SIZE, this.p4_chk_onlyNotMatched.Checked);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                int pageIndex = Convert.ToInt32(this.p4_txt_currentpage.Text.Trim());
                BindLogGrid(pageIndex - 1, Constants.PAGE_SIZE, this.p4_chk_onlyNotMatched.Checked);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            try
            {
                int pageIndex = Convert.ToInt32(this.p4_txt_currentpage.Text.Trim());
                BindLogGrid(pageIndex + 1, Constants.PAGE_SIZE, this.p4_chk_onlyNotMatched.Checked);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            try
            {
                BindLogGrid(int.MaxValue, Constants.PAGE_SIZE, this.p4_chk_onlyNotMatched.Checked);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }

        private void p2_lblViewRouteDetail_Click(object sender, EventArgs e)
        {
            try
            {
                this.Panel_P1_IPRetrive.Visible = false;
                this.Panel_P2_IPRetriving.Visible = false;
                this.Panel_P3_route.Visible = true;
                this.Panel_P4_logSearch.Visible = false;

                this.CancelButton = this.p3_btn_back;
        
                this.p3_dvRoute.AutoGenerateColumns = false;
                this.p3_dvRoute.DataSource = this.CurrentRouteItems;
                this.p3_dvRoute.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }

        private void top_lblLogQuery_Click(object sender, EventArgs e)
        {
            try
            {
                top_lblCurrentIPRetrive.Image = null;
                top_lblHelp.Image = null;
                top_lblLogQuery.Image = imageList1.Images[0];

                this.Panel_P1_IPRetrive.Visible = false;
                this.Panel_P2_IPRetriving.Visible = false;
                this.Panel_P3_route.Visible = false;
                
                this.p4_chk_onlyNotMatched.Checked = false;
                this.P4_lblExport.Enabled = false;
                this.AcceptButton = this.p4_btn_GoToPage;

                this.Panel_P4_logSearch.Visible = true;

                if (OnLogQueryStatus != null)
                {
                    frmMain_OnLogQueryStatus(0, "正在查询中，请稍后...");
                }

                Thread t = new Thread(RetriveLog);
                t.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }

        private void RetriveLog()
        {
            try
            {
                MonitorBiz biz = new MonitorBiz();
                _clientIPLogs = biz.LogQuery();

                foreach (var item in _clientIPLogs)
                {
                    //public enum IPMonitorStatus
                    //{
                    //    Pending = 0,
                    //    Normal = 1,
                    //    Unknown = 2,
                    //    Exception = 3
                    //}
                    if ("3".Equals(item.Status))
                    {
                        _clientIPLogsNotMatched.Add(item);
                    }
                }

                BindLogGrid(1, Constants.PAGE_SIZE, false);
                if (OnLogQueryStatus != null)
                {
                    frmMain_OnLogQueryStatus(1, null);
                }
            }
            catch (Exception ex)
            {
                if (OnLogQueryStatus != null)
                {
                    frmMain_OnLogQueryStatus(2, ex.Message);
                }
            }
        }

        private void frmMain_OnLogQueryStatus(int status, string message)
        {
            //initialize the loading lable
            if (status == 0)
            {
                this.p4_lblLoading.Visible = true;
                this.p4_lblLoading.Text = message;
                this.p4_lblLoading.Cursor = Cursors.Hand;
            }
            else if (status == 1)
            {
                // search is completed
                this.Panel_P4_logSearch.Visible = true;
                this.p4_lblLoading.Visible = false;
            }
            else if (status == 2)
            {
                // error happens
                this.p4_lblLoading.Visible = true;
                this.p4_lblLoading.Text = message;
                this.p4_lblLoading.Cursor = Cursors.Default;
            }
        }

        private void top_lblHelp_Click(object sender, EventArgs e)
        {
            try
            {
                //top_lblCurrentIPRetrive.Image = null;
                //top_lblLogQuery.Image = null;
                //top_lblHelp.Image = imageList1.Images[0];
                frmHelp helpForm = new frmHelp();

                helpForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }

        private void top_lblCurrentIPRetrive_Click(object sender, EventArgs e)
        {
            top_lblCurrentIPRetrive.Image = imageList1.Images[0];
            top_lblHelp.Image = null;
            top_lblLogQuery.Image = null;

            NavigateToIPRetriveHome();
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Minimized;
                this.Hide();
            }
            else if (this.WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.Activate();
            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //myMenu.Show();
            }

            //if (e.Button == MouseButtons.Left)
            //{
            //    this.Show();
            //    this.WindowState = FormWindowState.Normal;
            //    this.Activate();
            //}
        }

        private void contextMenu_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToolStripMenuItem_Set_Click(object sender, EventArgs e)
        {
            var frmSet = new frmSet();
            frmSet.Show();
        }
    }
}
