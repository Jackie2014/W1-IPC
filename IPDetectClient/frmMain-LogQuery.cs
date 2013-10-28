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



        private void top_lblLogQuery_Click(object sender, EventArgs e)
        {
            try
            {
                top_lblCurrentIPRetrive.Image = null;
                top_lblHelp.Image = null;
                top_lblLogQuery.Image = imageList1.Images[0];
                top_lblIPScan.Image = null;

                this.Panel_P4_logSearch.BringToFront();
                //this.Panel_P1_IPRetrive.Visible = false;
                //this.Panel_P2_IPRetriving.Visible = false;
                //this.Panel_P3_route.Visible = false;
                //this.Panel_P4_logSearch.Visible = true;
                this.p4_chk_onlyNotMatched.Checked = false;
                this.P4_lblExport.Enabled = false;
                this.AcceptButton = this.p4_btn_GoToPage;

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
    }
}
