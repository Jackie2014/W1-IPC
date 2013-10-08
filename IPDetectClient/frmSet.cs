using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IPDectect.Client.Common;
using IPDectect.Client.Business;

namespace IPDectect.Client
{
    public partial class frmSet : Form
    {
        Point _lastClick;
        public frmSet()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSet_Load(object sender, EventArgs e)
        {
            try
            {
                SetUIData();
            }
            catch (Exception ex)
            { }
        }

        private void SetUIData()
        {
            var modReg = new ModifyRegistry();
            string startKey = modReg.Read(Constants.Register_Key_Start);
            this.chkAutoRun.Checked = !String.IsNullOrEmpty(startKey);

            SettingBiz settingBiz = new SettingBiz();
            var setData = settingBiz.GetSettings();

            this.checkBox1.Checked = setData.EnableStartupRun;
            this.numericUpDown1.Value = setData.StartupRunTimes;

            this.checkBox2.Checked = setData.EnableAutoRun;
            this.numericUpDown2.Value = setData.ExecuteInterval;
            this.numericUpDown3.Value = setData.AutoRequestServerTimes;

            this.checkBox3.Checked = setData.EnableMannulRun;
            this.numericUpDown4.Value = setData.MannulRequestServerTimes;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            _lastClick = new Point(e.X, e.Y); 
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - _lastClick.X;
                this.Top += e.Y - _lastClick.Y;
            };
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string content = String.Format("{0}\f{1}\f{2}\f{3}\f{4}\f{5}\f{6}",
                    this.checkBox1.Checked, Convert.ToInt32(this.numericUpDown1.Value),
                    this.checkBox2.Checked, Convert.ToInt32(this.numericUpDown2.Value),  Convert.ToInt32(this.numericUpDown3.Value),
                    this.checkBox3.Checked,  Convert.ToInt32(this.numericUpDown4.Value));
                DataManager.Save(Constants.SEPARATE_StartRunSet, content);

                if (checkBox3.Checked)
                {
                    frmMain.myTimer.Interval = Convert.ToInt32(this.numericUpDown2.Value) * (1000 * 60 * 60);
                }

                var modReg = new ModifyRegistry();

                if (this.chkAutoRun.Checked)
                {
                    string autoRunKeyContent = modReg.Read(Constants.Register_Key_Start);
                    if (String.IsNullOrEmpty(autoRunKeyContent))
                    {
                        modReg.Write(Constants.Register_Key_Start, "\"" + Application.ExecutablePath + "\" -autorun");
                    }
                }
                else
                {
                    modReg.DeleteKey(Constants.Register_Key_Start);
                }

                MessageBox.Show("保存成功.","成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败." + ex.Message, "错误");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
