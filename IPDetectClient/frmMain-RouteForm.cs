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

        private void p2_lblViewRouteDetail_Click(object sender, EventArgs e)
        {
            try
            {
                this.Panel_P3_route.BringToFront();
                //this.Panel_P1_IPRetrive.Visible = false;
                //this.Panel_P2_IPRetriving.Visible = false;
                //this.Panel_P3_route.Visible = true;
                //this.Panel_P4_logSearch.Visible = false;

                //this.CancelButton = this.p3_btn_back;

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
            this.Panel_P2_IPRetriving.BringToFront();
            //this.Panel_P1_IPRetrive.Visible = false;
            //this.Panel_P2_IPRetriving.Visible = true;
            //this.Panel_P3_route.Visible = false;
            //this.Panel_P4_logSearch.Visible = false;
        }
    }
}
