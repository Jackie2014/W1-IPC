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

            OnIPScanProgress += new IPScanProgress(UpdateUIProgressForIPScan);

            try
            {
                top_lblCurrentIPRetrive_Click(null, null);
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
                
                this.top_lblIPScan.Visible = Constants.IsAdministrator;
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
                this.Panel_P2_IPRetriving.BringToFront();
                //this.Panel_P1_IPRetrive.Visible = false;
                //this.Panel_P2_IPRetriving.Visible = true;

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
            top_lblIPScan.Image = null;

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
