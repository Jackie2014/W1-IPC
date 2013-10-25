namespace IPDectect.Client
{
    partial class frmScan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnScan = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Seq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rowSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IPStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IPEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TTLLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TCPTimeLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.txtScanResult = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnScan
            // 
            this.btnScan.BackColor = System.Drawing.Color.Transparent;
            this.btnScan.BackgroundImage = global::IPDectect.Client.Properties.Resources.btn5_正常;
            this.btnScan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnScan.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnScan.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnScan.FlatAppearance.BorderSize = 0;
            this.btnScan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScan.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnScan.Location = new System.Drawing.Point(237, 323);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(120, 40);
            this.btnScan.TabIndex = 14;
            this.btnScan.Text = "TCP/TTL 扫描";
            this.btnScan.UseVisualStyleBackColor = false;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seq,
            this.rowSelect,
            this.IPStart,
            this.IPEnd,
            this.TotalIP,
            this.TTLLimit,
            this.TCPTimeLimit});
            this.dataGridView1.Location = new System.Drawing.Point(3, 44);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(593, 74);
            this.dataGridView1.TabIndex = 15;
            // 
            // Seq
            // 
            this.Seq.HeaderText = "No.";
            this.Seq.Name = "Seq";
            this.Seq.ReadOnly = true;
            this.Seq.Width = 40;
            // 
            // rowSelect
            // 
            this.rowSelect.HeaderText = "选择";
            this.rowSelect.Name = "rowSelect";
            this.rowSelect.Width = 50;
            // 
            // IPStart
            // 
            this.IPStart.HeaderText = "地址段开始";
            this.IPStart.Name = "IPStart";
            this.IPStart.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IPStart.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // IPEnd
            // 
            this.IPEnd.HeaderText = "地址段结束";
            this.IPEnd.Name = "IPEnd";
            // 
            // TotalIP
            // 
            this.TotalIP.HeaderText = "IP数量";
            this.TotalIP.Name = "TotalIP";
            this.TotalIP.ReadOnly = true;
            this.TotalIP.Width = 80;
            // 
            // TTLLimit
            // 
            this.TTLLimit.HeaderText = "TTL值限定";
            this.TTLLimit.Name = "TTLLimit";
            this.TTLLimit.Width = 110;
            // 
            // TCPTimeLimit
            // 
            this.TCPTimeLimit.HeaderText = "TCP时间限定";
            this.TCPTimeLimit.Name = "TCPTimeLimit";
            this.TCPTimeLimit.Width = 110;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(3, 153);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(585, 11);
            this.progressBar1.TabIndex = 16;
            // 
            // txtScanResult
            // 
            this.txtScanResult.BackColor = System.Drawing.SystemColors.InfoText;
            this.txtScanResult.ForeColor = System.Drawing.SystemColors.Info;
            this.txtScanResult.Location = new System.Drawing.Point(3, 170);
            this.txtScanResult.Multiline = true;
            this.txtScanResult.Name = "txtScanResult";
            this.txtScanResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtScanResult.Size = new System.Drawing.Size(593, 137);
            this.txtScanResult.TabIndex = 18;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::IPDectect.Client.Properties.Resources.关闭_正常;
            this.pictureBox1.Location = new System.Drawing.Point(568, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // frmScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::IPDectect.Client.Properties.Resources.back_1;
            this.ClientSize = new System.Drawing.Size(600, 375);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtScanResult);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnScan);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmScan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmScan";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmScan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Seq;
        private System.Windows.Forms.DataGridViewCheckBoxColumn rowSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn IPStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn IPEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn TTLLimit;
        private System.Windows.Forms.DataGridViewTextBoxColumn TCPTimeLimit;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox txtScanResult;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}