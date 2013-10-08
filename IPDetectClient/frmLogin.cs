using IPDectect.Client.Business;
using IPDectect.Client.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Text;
using System.Web;
using System.Windows.Forms;
using IPDectect.Client.Models;

namespace IPDectect.Client
{
    public partial class frmLogin : Form
    {
        Point _lastClick;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                // check whether the privious token is saved
                string rememberMeInfo = DataManager.Read(Constants.SEPARATE_REMEMBER_ME);

                if (!String.IsNullOrEmpty(rememberMeInfo))
                {
                    string[] arr = rememberMeInfo.Split(new char[] { '\f' });
                    if (arr.Length == 3)
                    {
                        this.txtUserName.Text = arr[0];
                        this.txtPassword.Text = arr[1];
                        this.chkRememberMe.Checked = true;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = this.txtUserName.Text.Trim();
                string password = this.txtPassword.Text;

                if (String.IsNullOrEmpty(userName) || String.IsNullOrEmpty(password))
                {
                    MessageBox.Show("请输入用户名和密码！", "警告",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }

                if (UserBiz.Login(userName, password))
                {
                    try
                    {
                        if (chkRememberMe.Checked)
                        {
                            //username\fpassword\frememberme
                            string content = String.Format("{0}\f{1}\f{2}", userName, password, "true");
                            DataManager.Save(Constants.SEPARATE_REMEMBER_ME, content);
                        }
                        else
                        {
                            DataManager.Save(Constants.SEPARATE_REMEMBER_ME, String.Empty);
                        }
                    }
                    catch
                    {
                    }

                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("用户名或密码输入错误，请重新输入。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.Retry;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Retry;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            _lastClick = new Point(e.X, e.Y); 
        }

        private void frmLogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) 
            {
                this.Left += e.X - _lastClick.X;
                this.Top += e.Y - _lastClick.Y;
            };
        }
    }
}
