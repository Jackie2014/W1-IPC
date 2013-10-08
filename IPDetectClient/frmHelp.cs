using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IPDectect.Client.Common;

namespace IPDectect.Client
{
    public partial class frmHelp : Form
    {
        Point _lastClick;
        public frmHelp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmHelp_Load(object sender, EventArgs e)
        {
            lblVersion.Text = "V" + Constants.GetAssembleVersion();
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
    }
}
