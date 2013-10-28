namespace IPDectect.Client
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.Panel_P1_IPRetrive = new System.Windows.Forms.Panel();
            this.btnIPRetrive = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbDistinct = new System.Windows.Forms.ComboBox();
            this.txtOperatorOther = new System.Windows.Forms.TextBox();
            this.txtDetailAddress = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbCity2 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbProvince2 = new System.Windows.Forms.ComboBox();
            this.cmbOperators = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbCity1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbProvince1 = new System.Windows.Forms.ComboBox();
            this.txtRecordor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Panel_P2_IPRetriving = new System.Windows.Forms.Panel();
            this.p2_lblViewRouteDetail = new System.Windows.Forms.Label();
            this.p2_lblISP_text = new System.Windows.Forms.Label();
            this.p2_lblCity_text = new System.Windows.Forms.Label();
            this.p2_lblProvice_text = new System.Windows.Forms.Label();
            this.p2_btnBack = new System.Windows.Forms.Button();
            this.p2_btnSearchagain = new System.Windows.Forms.Button();
            this.p2_lbl_progress = new System.Windows.Forms.Label();
            this.p2_lbl_ipbelongto = new System.Windows.Forms.Label();
            this.p2_label6 = new System.Windows.Forms.Label();
            this.p2_lbl_progressStatus = new System.Windows.Forms.Label();
            this.p2_progressBar = new System.Windows.Forms.ProgressBar();
            this.p2_lbl_IsRetriving = new System.Windows.Forms.Label();
            this.p2_lbl_ip = new System.Windows.Forms.Label();
            this.p2_label5 = new System.Windows.Forms.Label();
            this.p2_label4 = new System.Windows.Forms.Label();
            this.p2_label3 = new System.Windows.Forms.Label();
            this.p2_label2 = new System.Windows.Forms.Label();
            this.p2_label1 = new System.Windows.Forms.Label();
            this.Panel_P3_route = new System.Windows.Forms.Panel();
            this.p3_dvRoute = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IPBelongToProvince = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IPBelongToCity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.最快响应时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.平均响应时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.最慢响应时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IP地址 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IP归属 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RouteDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParentUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IPBelongTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p3_btn_back = new System.Windows.Forms.Button();
            this.Panel_P4_logSearch = new System.Windows.Forms.Panel();
            this.p4_dvLog = new System.Windows.Forms.DataGridView();
            this.SeqNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Recorder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpectedISP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RealISP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p4_pic1 = new System.Windows.Forms.PictureBox();
            this.p4_txt_currentpage = new System.Windows.Forms.TextBox();
            this.p4_pic3 = new System.Windows.Forms.PictureBox();
            this.p4_pic4 = new System.Windows.Forms.PictureBox();
            this.p4_pic2 = new System.Windows.Forms.PictureBox();
            this.P4_lblExport = new System.Windows.Forms.Label();
            this.p4_btn_GoToPage = new System.Windows.Forms.Button();
            this.p4_chk_onlyNotMatched = new System.Windows.Forms.CheckBox();
            this.p4_page_totalPages = new System.Windows.Forms.Label();
            this.p4_lbl_pageTotalRow = new System.Windows.Forms.Label();
            this.p4_lblLoading = new System.Windows.Forms.Label();
            this.panel_top = new System.Windows.Forms.Panel();
            this.top_lblIPScan = new System.Windows.Forms.Label();
            this.top_lblHelp = new System.Windows.Forms.Label();
            this.top_lblLogQuery = new System.Windows.Forms.Label();
            this.top_lblCurrentIPRetrive = new System.Windows.Forms.Label();
            this.pictureBoxClose = new System.Windows.Forms.PictureBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_Set = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenu_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel_p5_adminScan = new System.Windows.Forms.Panel();
            this.p5_dgvIPRangeList = new System.Windows.Forms.DataGridView();
            this.btnScan = new System.Windows.Forms.Button();
            this.txtScanResult = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.Seq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rowSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IPStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IPEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TTLLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TCPTimeLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TCPPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Panel_P1_IPRetrive.SuspendLayout();
            this.Panel_P2_IPRetriving.SuspendLayout();
            this.Panel_P3_route.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.p3_dvRoute)).BeginInit();
            this.Panel_P4_logSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.p4_dvLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p4_pic1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p4_pic3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p4_pic4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p4_pic2)).BeginInit();
            this.panel_top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel_p5_adminScan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.p5_dgvIPRangeList)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel_P1_IPRetrive
            // 
            this.Panel_P1_IPRetrive.BackColor = System.Drawing.Color.Transparent;
            this.Panel_P1_IPRetrive.Controls.Add(this.btnIPRetrive);
            this.Panel_P1_IPRetrive.Controls.Add(this.label8);
            this.Panel_P1_IPRetrive.Controls.Add(this.cmbDistinct);
            this.Panel_P1_IPRetrive.Controls.Add(this.txtOperatorOther);
            this.Panel_P1_IPRetrive.Controls.Add(this.txtDetailAddress);
            this.Panel_P1_IPRetrive.Controls.Add(this.label7);
            this.Panel_P1_IPRetrive.Controls.Add(this.cmbCity2);
            this.Panel_P1_IPRetrive.Controls.Add(this.label6);
            this.Panel_P1_IPRetrive.Controls.Add(this.cmbProvince2);
            this.Panel_P1_IPRetrive.Controls.Add(this.cmbOperators);
            this.Panel_P1_IPRetrive.Controls.Add(this.label5);
            this.Panel_P1_IPRetrive.Controls.Add(this.cmbCity1);
            this.Panel_P1_IPRetrive.Controls.Add(this.label4);
            this.Panel_P1_IPRetrive.Controls.Add(this.cmbProvince1);
            this.Panel_P1_IPRetrive.Controls.Add(this.txtRecordor);
            this.Panel_P1_IPRetrive.Controls.Add(this.label3);
            this.Panel_P1_IPRetrive.Controls.Add(this.label2);
            this.Panel_P1_IPRetrive.Controls.Add(this.label1);
            this.Panel_P1_IPRetrive.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Panel_P1_IPRetrive.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Panel_P1_IPRetrive.Location = new System.Drawing.Point(1, 57);
            this.Panel_P1_IPRetrive.Name = "Panel_P1_IPRetrive";
            this.Panel_P1_IPRetrive.Size = new System.Drawing.Size(598, 317);
            this.Panel_P1_IPRetrive.TabIndex = 22;
            // 
            // btnIPRetrive
            // 
            this.btnIPRetrive.BackColor = System.Drawing.Color.Transparent;
            this.btnIPRetrive.BackgroundImage = global::IPDectect.Client.Properties.Resources.btn3_正常;
            this.btnIPRetrive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIPRetrive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIPRetrive.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnIPRetrive.ForeColor = System.Drawing.SystemColors.Window;
            this.btnIPRetrive.Location = new System.Drawing.Point(237, 249);
            this.btnIPRetrive.Name = "btnIPRetrive";
            this.btnIPRetrive.Size = new System.Drawing.Size(120, 40);
            this.btnIPRetrive.TabIndex = 32;
            this.btnIPRetrive.Text = "开始查询";
            this.btnIPRetrive.UseVisualStyleBackColor = false;
            this.btnIPRetrive.Click += new System.EventHandler(this.btnIPRetrive_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(543, 170);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 20);
            this.label8.TabIndex = 34;
            this.label8.Text = "区";
            // 
            // cmbDistinct
            // 
            this.cmbDistinct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDistinct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbDistinct.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbDistinct.ForeColor = System.Drawing.Color.Black;
            this.cmbDistinct.FormattingEnabled = true;
            this.cmbDistinct.Location = new System.Drawing.Point(442, 167);
            this.cmbDistinct.Name = "cmbDistinct";
            this.cmbDistinct.Size = new System.Drawing.Size(100, 28);
            this.cmbDistinct.TabIndex = 29;
            // 
            // txtOperatorOther
            // 
            this.txtOperatorOther.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOperatorOther.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOperatorOther.ForeColor = System.Drawing.Color.Black;
            this.txtOperatorOther.Location = new System.Drawing.Point(286, 114);
            this.txtOperatorOther.MaxLength = 30;
            this.txtOperatorOther.Name = "txtOperatorOther";
            this.txtOperatorOther.Size = new System.Drawing.Size(129, 27);
            this.txtOperatorOther.TabIndex = 24;
            this.txtOperatorOther.Visible = false;
            // 
            // txtDetailAddress
            // 
            this.txtDetailAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDetailAddress.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDetailAddress.ForeColor = System.Drawing.Color.Black;
            this.txtDetailAddress.Location = new System.Drawing.Point(181, 202);
            this.txtDetailAddress.MaxLength = 100;
            this.txtDetailAddress.Name = "txtDetailAddress";
            this.txtDetailAddress.Size = new System.Drawing.Size(361, 27);
            this.txtDetailAddress.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(416, 171);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 20);
            this.label7.TabIndex = 33;
            this.label7.Text = "市";
            // 
            // cmbCity2
            // 
            this.cmbCity2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCity2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCity2.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbCity2.ForeColor = System.Drawing.Color.Black;
            this.cmbCity2.FormattingEnabled = true;
            this.cmbCity2.Location = new System.Drawing.Point(315, 167);
            this.cmbCity2.Name = "cmbCity2";
            this.cmbCity2.Size = new System.Drawing.Size(100, 28);
            this.cmbCity2.TabIndex = 28;
            this.cmbCity2.SelectedIndexChanged += new System.EventHandler(this.cmbCity2_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(280, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 20);
            this.label6.TabIndex = 31;
            this.label6.Text = "省";
            // 
            // cmbProvince2
            // 
            this.cmbProvince2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProvince2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbProvince2.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbProvince2.ForeColor = System.Drawing.Color.Black;
            this.cmbProvince2.FormattingEnabled = true;
            this.cmbProvince2.Location = new System.Drawing.Point(180, 167);
            this.cmbProvince2.Name = "cmbProvince2";
            this.cmbProvince2.Size = new System.Drawing.Size(100, 28);
            this.cmbProvince2.TabIndex = 26;
            this.cmbProvince2.SelectedIndexChanged += new System.EventHandler(this.cmbProvince2_SelectedIndexChanged);
            // 
            // cmbOperators
            // 
            this.cmbOperators.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOperators.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbOperators.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbOperators.ForeColor = System.Drawing.Color.Black;
            this.cmbOperators.FormattingEnabled = true;
            this.cmbOperators.Items.AddRange(new object[] {
            "--运营商--",
            "中国联通",
            "中国电信",
            "中国移动",
            "其他"});
            this.cmbOperators.Location = new System.Drawing.Point(180, 112);
            this.cmbOperators.Name = "cmbOperators";
            this.cmbOperators.Size = new System.Drawing.Size(100, 28);
            this.cmbOperators.TabIndex = 23;
            this.cmbOperators.SelectedIndexChanged += new System.EventHandler(this.cmbOperators_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(416, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 20);
            this.label5.TabIndex = 27;
            this.label5.Text = "市";
            // 
            // cmbCity1
            // 
            this.cmbCity1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCity1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCity1.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbCity1.ForeColor = System.Drawing.Color.Black;
            this.cmbCity1.FormattingEnabled = true;
            this.cmbCity1.Location = new System.Drawing.Point(315, 76);
            this.cmbCity1.Name = "cmbCity1";
            this.cmbCity1.Size = new System.Drawing.Size(100, 28);
            this.cmbCity1.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(281, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 20);
            this.label4.TabIndex = 25;
            this.label4.Text = "省";
            // 
            // cmbProvince1
            // 
            this.cmbProvince1.BackColor = System.Drawing.SystemColors.Window;
            this.cmbProvince1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProvince1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbProvince1.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbProvince1.ForeColor = System.Drawing.Color.Black;
            this.cmbProvince1.FormattingEnabled = true;
            this.cmbProvince1.Location = new System.Drawing.Point(180, 76);
            this.cmbProvince1.Name = "cmbProvince1";
            this.cmbProvince1.Size = new System.Drawing.Size(100, 28);
            this.cmbProvince1.TabIndex = 21;
            this.cmbProvince1.SelectedIndexChanged += new System.EventHandler(this.cmbProvince1_SelectedIndexChanged);
            // 
            // txtRecordor
            // 
            this.txtRecordor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRecordor.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRecordor.ForeColor = System.Drawing.Color.Black;
            this.txtRecordor.Location = new System.Drawing.Point(180, 24);
            this.txtRecordor.MaxLength = 30;
            this.txtRecordor.Name = "txtRecordor";
            this.txtRecordor.Size = new System.Drawing.Size(100, 27);
            this.txtRecordor.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(30, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 22);
            this.label3.TabIndex = 20;
            this.label3.Text = "详   细   地   址：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(28, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 22);
            this.label2.TabIndex = 19;
            this.label2.Text = "所属宽带运营商：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(32, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 22);
            this.label1.TabIndex = 17;
            this.label1.Text = "录      入      人：";
            // 
            // Panel_P2_IPRetriving
            // 
            this.Panel_P2_IPRetriving.BackColor = System.Drawing.Color.Transparent;
            this.Panel_P2_IPRetriving.Controls.Add(this.p2_lblViewRouteDetail);
            this.Panel_P2_IPRetriving.Controls.Add(this.p2_lblISP_text);
            this.Panel_P2_IPRetriving.Controls.Add(this.p2_lblCity_text);
            this.Panel_P2_IPRetriving.Controls.Add(this.p2_lblProvice_text);
            this.Panel_P2_IPRetriving.Controls.Add(this.p2_btnBack);
            this.Panel_P2_IPRetriving.Controls.Add(this.p2_btnSearchagain);
            this.Panel_P2_IPRetriving.Controls.Add(this.p2_lbl_progress);
            this.Panel_P2_IPRetriving.Controls.Add(this.p2_lbl_ipbelongto);
            this.Panel_P2_IPRetriving.Controls.Add(this.p2_label6);
            this.Panel_P2_IPRetriving.Controls.Add(this.p2_lbl_progressStatus);
            this.Panel_P2_IPRetriving.Controls.Add(this.p2_progressBar);
            this.Panel_P2_IPRetriving.Controls.Add(this.p2_lbl_IsRetriving);
            this.Panel_P2_IPRetriving.Controls.Add(this.p2_lbl_ip);
            this.Panel_P2_IPRetriving.Controls.Add(this.p2_label5);
            this.Panel_P2_IPRetriving.Controls.Add(this.p2_label4);
            this.Panel_P2_IPRetriving.Controls.Add(this.p2_label3);
            this.Panel_P2_IPRetriving.Controls.Add(this.p2_label2);
            this.Panel_P2_IPRetriving.Controls.Add(this.p2_label1);
            this.Panel_P2_IPRetriving.Location = new System.Drawing.Point(1, 57);
            this.Panel_P2_IPRetriving.Name = "Panel_P2_IPRetriving";
            this.Panel_P2_IPRetriving.Size = new System.Drawing.Size(599, 317);
            this.Panel_P2_IPRetriving.TabIndex = 35;
            // 
            // p2_lblViewRouteDetail
            // 
            this.p2_lblViewRouteDetail.AutoSize = true;
            this.p2_lblViewRouteDetail.BackColor = System.Drawing.Color.Transparent;
            this.p2_lblViewRouteDetail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.p2_lblViewRouteDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.p2_lblViewRouteDetail.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.p2_lblViewRouteDetail.ForeColor = System.Drawing.SystemColors.Highlight;
            this.p2_lblViewRouteDetail.Location = new System.Drawing.Point(32, 278);
            this.p2_lblViewRouteDetail.Name = "p2_lblViewRouteDetail";
            this.p2_lblViewRouteDetail.Size = new System.Drawing.Size(151, 19);
            this.p2_lblViewRouteDetail.TabIndex = 304;
            this.p2_lblViewRouteDetail.Text = "查看详细路由信息>>";
            this.p2_lblViewRouteDetail.Click += new System.EventHandler(this.p2_lblViewRouteDetail_Click);
            // 
            // p2_lblISP_text
            // 
            this.p2_lblISP_text.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.p2_lblISP_text.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p2_lblISP_text.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.p2_lblISP_text.ForeColor = System.Drawing.Color.Black;
            this.p2_lblISP_text.Location = new System.Drawing.Point(439, 24);
            this.p2_lblISP_text.Name = "p2_lblISP_text";
            this.p2_lblISP_text.Size = new System.Drawing.Size(95, 25);
            this.p2_lblISP_text.TabIndex = 303;
            // 
            // p2_lblCity_text
            // 
            this.p2_lblCity_text.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.p2_lblCity_text.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p2_lblCity_text.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.p2_lblCity_text.ForeColor = System.Drawing.Color.Black;
            this.p2_lblCity_text.Location = new System.Drawing.Point(313, 24);
            this.p2_lblCity_text.Name = "p2_lblCity_text";
            this.p2_lblCity_text.Size = new System.Drawing.Size(95, 25);
            this.p2_lblCity_text.TabIndex = 302;
            // 
            // p2_lblProvice_text
            // 
            this.p2_lblProvice_text.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.p2_lblProvice_text.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p2_lblProvice_text.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.p2_lblProvice_text.ForeColor = System.Drawing.Color.Black;
            this.p2_lblProvice_text.Location = new System.Drawing.Point(188, 24);
            this.p2_lblProvice_text.Name = "p2_lblProvice_text";
            this.p2_lblProvice_text.Size = new System.Drawing.Size(95, 25);
            this.p2_lblProvice_text.TabIndex = 301;
            // 
            // p2_btnBack
            // 
            this.p2_btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.p2_btnBack.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.p2_btnBack.FlatAppearance.BorderSize = 0;
            this.p2_btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.p2_btnBack.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.p2_btnBack.ForeColor = System.Drawing.Color.Black;
            this.p2_btnBack.Image = global::IPDectect.Client.Properties.Resources.btn5_正常;
            this.p2_btnBack.Location = new System.Drawing.Point(179, 171);
            this.p2_btnBack.Name = "p2_btnBack";
            this.p2_btnBack.Size = new System.Drawing.Size(121, 41);
            this.p2_btnBack.TabIndex = 17;
            this.p2_btnBack.Text = "返   回";
            this.p2_btnBack.UseVisualStyleBackColor = true;
            this.p2_btnBack.Click += new System.EventHandler(this.p2_btnBack_Click);
            // 
            // p2_btnSearchagain
            // 
            this.p2_btnSearchagain.BackColor = System.Drawing.Color.Transparent;
            this.p2_btnSearchagain.BackgroundImage = global::IPDectect.Client.Properties.Resources.btn3_正常;
            this.p2_btnSearchagain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.p2_btnSearchagain.FlatAppearance.BorderSize = 0;
            this.p2_btnSearchagain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.p2_btnSearchagain.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.p2_btnSearchagain.ForeColor = System.Drawing.Color.White;
            this.p2_btnSearchagain.Location = new System.Drawing.Point(34, 171);
            this.p2_btnSearchagain.Name = "p2_btnSearchagain";
            this.p2_btnSearchagain.Size = new System.Drawing.Size(120, 40);
            this.p2_btnSearchagain.TabIndex = 16;
            this.p2_btnSearchagain.Text = "再次查询";
            this.p2_btnSearchagain.UseVisualStyleBackColor = false;
            this.p2_btnSearchagain.Click += new System.EventHandler(this.p2_btnSearchagain_Click);
            // 
            // p2_lbl_progress
            // 
            this.p2_lbl_progress.AutoSize = true;
            this.p2_lbl_progress.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.p2_lbl_progress.ForeColor = System.Drawing.SystemColors.Highlight;
            this.p2_lbl_progress.Location = new System.Drawing.Point(281, 205);
            this.p2_lbl_progress.Name = "p2_lbl_progress";
            this.p2_lbl_progress.Size = new System.Drawing.Size(47, 20);
            this.p2_lbl_progress.TabIndex = 15;
            this.p2_lbl_progress.Text = "1 / 10";
            // 
            // p2_lbl_ipbelongto
            // 
            this.p2_lbl_ipbelongto.AutoSize = true;
            this.p2_lbl_ipbelongto.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.p2_lbl_ipbelongto.ForeColor = System.Drawing.SystemColors.Highlight;
            this.p2_lbl_ipbelongto.Location = new System.Drawing.Point(113, 107);
            this.p2_lbl_ipbelongto.Name = "p2_lbl_ipbelongto";
            this.p2_lbl_ipbelongto.Size = new System.Drawing.Size(118, 19);
            this.p2_lbl_ipbelongto.TabIndex = 13;
            this.p2_lbl_ipbelongto.Text = "中国联通 重庆市";
            // 
            // p2_label6
            // 
            this.p2_label6.AutoSize = true;
            this.p2_label6.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.p2_label6.ForeColor = System.Drawing.Color.Black;
            this.p2_label6.Location = new System.Drawing.Point(28, 105);
            this.p2_label6.Name = "p2_label6";
            this.p2_label6.Size = new System.Drawing.Size(82, 20);
            this.p2_label6.TabIndex = 12;
            this.p2_label6.Text = "IP归属地：";
            // 
            // p2_lbl_progressStatus
            // 
            this.p2_lbl_progressStatus.AutoSize = true;
            this.p2_lbl_progressStatus.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.p2_lbl_progressStatus.ForeColor = System.Drawing.Color.Black;
            this.p2_lbl_progressStatus.Location = new System.Drawing.Point(71, 238);
            this.p2_lbl_progressStatus.Name = "p2_lbl_progressStatus";
            this.p2_lbl_progressStatus.Size = new System.Drawing.Size(92, 20);
            this.p2_lbl_progressStatus.TabIndex = 11;
            this.p2_lbl_progressStatus.Text = "当前进行项: ";
            // 
            // p2_progressBar
            // 
            this.p2_progressBar.Location = new System.Drawing.Point(75, 183);
            this.p2_progressBar.Name = "p2_progressBar";
            this.p2_progressBar.Size = new System.Drawing.Size(460, 11);
            this.p2_progressBar.Step = 5;
            this.p2_progressBar.TabIndex = 10;
            // 
            // p2_lbl_IsRetriving
            // 
            this.p2_lbl_IsRetriving.AutoSize = true;
            this.p2_lbl_IsRetriving.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.p2_lbl_IsRetriving.ForeColor = System.Drawing.Color.Black;
            this.p2_lbl_IsRetriving.Location = new System.Drawing.Point(229, 141);
            this.p2_lbl_IsRetriving.Name = "p2_lbl_IsRetriving";
            this.p2_lbl_IsRetriving.Size = new System.Drawing.Size(141, 20);
            this.p2_lbl_IsRetriving.TabIndex = 9;
            this.p2_lbl_IsRetriving.Text = "正在查询，请稍后...";
            // 
            // p2_lbl_ip
            // 
            this.p2_lbl_ip.AutoSize = true;
            this.p2_lbl_ip.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.p2_lbl_ip.ForeColor = System.Drawing.SystemColors.Highlight;
            this.p2_lbl_ip.Location = new System.Drawing.Point(113, 69);
            this.p2_lbl_ip.Name = "p2_lbl_ip";
            this.p2_lbl_ip.Size = new System.Drawing.Size(129, 19);
            this.p2_lbl_ip.TabIndex = 8;
            this.p2_lbl_ip.Text = "202.111.222.120";
            // 
            // p2_label5
            // 
            this.p2_label5.AutoSize = true;
            this.p2_label5.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.p2_label5.ForeColor = System.Drawing.Color.Black;
            this.p2_label5.Location = new System.Drawing.Point(28, 67);
            this.p2_label5.Name = "p2_label5";
            this.p2_label5.Size = new System.Drawing.Size(82, 20);
            this.p2_label5.TabIndex = 7;
            this.p2_label5.Text = "您的IP是：";
            // 
            // p2_label4
            // 
            this.p2_label4.AutoSize = true;
            this.p2_label4.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.p2_label4.ForeColor = System.Drawing.Color.Black;
            this.p2_label4.Location = new System.Drawing.Point(534, 26);
            this.p2_label4.Name = "p2_label4";
            this.p2_label4.Size = new System.Drawing.Size(54, 20);
            this.p2_label4.TabIndex = 6;
            this.p2_label4.Text = "运营商";
            // 
            // p2_label3
            // 
            this.p2_label3.AutoSize = true;
            this.p2_label3.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.p2_label3.ForeColor = System.Drawing.Color.Black;
            this.p2_label3.Location = new System.Drawing.Point(408, 26);
            this.p2_label3.Name = "p2_label3";
            this.p2_label3.Size = new System.Drawing.Size(24, 20);
            this.p2_label3.TabIndex = 4;
            this.p2_label3.Text = "市";
            // 
            // p2_label2
            // 
            this.p2_label2.AutoSize = true;
            this.p2_label2.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.p2_label2.ForeColor = System.Drawing.Color.Black;
            this.p2_label2.Location = new System.Drawing.Point(282, 26);
            this.p2_label2.Name = "p2_label2";
            this.p2_label2.Size = new System.Drawing.Size(24, 20);
            this.p2_label2.TabIndex = 2;
            this.p2_label2.Text = "省";
            // 
            // p2_label1
            // 
            this.p2_label1.AutoSize = true;
            this.p2_label1.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.p2_label1.ForeColor = System.Drawing.Color.Black;
            this.p2_label1.Location = new System.Drawing.Point(28, 26);
            this.p2_label1.Name = "p2_label1";
            this.p2_label1.Size = new System.Drawing.Size(159, 20);
            this.p2_label1.TabIndex = 0;
            this.p2_label1.Text = "您输入的查询信息是：";
            // 
            // Panel_P3_route
            // 
            this.Panel_P3_route.BackColor = System.Drawing.Color.Transparent;
            this.Panel_P3_route.Controls.Add(this.p3_dvRoute);
            this.Panel_P3_route.Controls.Add(this.p3_btn_back);
            this.Panel_P3_route.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Panel_P3_route.Location = new System.Drawing.Point(1, 57);
            this.Panel_P3_route.Name = "Panel_P3_route";
            this.Panel_P3_route.Size = new System.Drawing.Size(598, 317);
            this.Panel_P3_route.TabIndex = 15;
            // 
            // p3_dvRoute
            // 
            this.p3_dvRoute.AllowUserToAddRows = false;
            this.p3_dvRoute.AllowUserToDeleteRows = false;
            this.p3_dvRoute.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle25.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.p3_dvRoute.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle25;
            this.p3_dvRoute.ColumnHeadersHeight = 40;
            this.p3_dvRoute.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.IPBelongToProvince,
            this.IPBelongToCity,
            this.最快响应时间,
            this.平均响应时间,
            this.最慢响应时间,
            this.IP地址,
            this.IP归属,
            this.RouteDate,
            this.ParentUID,
            this.IPBelongTo});
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle27.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle27.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle27.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.p3_dvRoute.DefaultCellStyle = dataGridViewCellStyle27;
            this.p3_dvRoute.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.p3_dvRoute.Location = new System.Drawing.Point(0, 2);
            this.p3_dvRoute.Name = "p3_dvRoute";
            this.p3_dvRoute.ReadOnly = true;
            this.p3_dvRoute.RowHeadersVisible = false;
            dataGridViewCellStyle28.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle28.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle28.ForeColor = System.Drawing.Color.White;
            this.p3_dvRoute.RowsDefaultCellStyle = dataGridViewCellStyle28;
            this.p3_dvRoute.RowTemplate.Height = 23;
            this.p3_dvRoute.Size = new System.Drawing.Size(598, 269);
            this.p3_dvRoute.TabIndex = 2;
            // 
            // No
            // 
            this.No.DataPropertyName = "SeqNo";
            dataGridViewCellStyle26.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.No.DefaultCellStyle = dataGridViewCellStyle26;
            this.No.Frozen = true;
            this.No.HeaderText = "No.";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.Width = 30;
            // 
            // IPBelongToProvince
            // 
            this.IPBelongToProvince.DataPropertyName = "IPBelongToProvince";
            this.IPBelongToProvince.HeaderText = "IPBelongToProvince";
            this.IPBelongToProvince.Name = "IPBelongToProvince";
            this.IPBelongToProvince.ReadOnly = true;
            this.IPBelongToProvince.Visible = false;
            this.IPBelongToProvince.Width = 5;
            // 
            // IPBelongToCity
            // 
            this.IPBelongToCity.DataPropertyName = "IPBelongToCity";
            this.IPBelongToCity.HeaderText = "IPBelongToCity";
            this.IPBelongToCity.Name = "IPBelongToCity";
            this.IPBelongToCity.ReadOnly = true;
            this.IPBelongToCity.Visible = false;
            this.IPBelongToCity.Width = 5;
            // 
            // 最快响应时间
            // 
            this.最快响应时间.DataPropertyName = "T1";
            this.最快响应时间.HeaderText = "最快响应时间";
            this.最快响应时间.Name = "最快响应时间";
            this.最快响应时间.ReadOnly = true;
            this.最快响应时间.Width = 88;
            // 
            // 平均响应时间
            // 
            this.平均响应时间.DataPropertyName = "T2";
            this.平均响应时间.HeaderText = "平均响应时间";
            this.平均响应时间.Name = "平均响应时间";
            this.平均响应时间.ReadOnly = true;
            this.平均响应时间.Width = 88;
            // 
            // 最慢响应时间
            // 
            this.最慢响应时间.DataPropertyName = "T3";
            this.最慢响应时间.HeaderText = "最慢响应时间";
            this.最慢响应时间.Name = "最慢响应时间";
            this.最慢响应时间.ReadOnly = true;
            this.最慢响应时间.Width = 88;
            // 
            // IP地址
            // 
            this.IP地址.DataPropertyName = "RouteIP";
            this.IP地址.HeaderText = "IP地址";
            this.IP地址.Name = "IP地址";
            this.IP地址.ReadOnly = true;
            this.IP地址.Width = 105;
            // 
            // IP归属
            // 
            this.IP归属.DataPropertyName = "IPBelongToDisplay";
            this.IP归属.HeaderText = "IP归属";
            this.IP归属.Name = "IP归属";
            this.IP归属.ReadOnly = true;
            this.IP归属.Width = 110;
            // 
            // RouteDate
            // 
            this.RouteDate.DataPropertyName = "RouteDate";
            this.RouteDate.HeaderText = "时间";
            this.RouteDate.Name = "RouteDate";
            this.RouteDate.ReadOnly = true;
            // 
            // ParentUID
            // 
            this.ParentUID.DataPropertyName = "ParentUID";
            this.ParentUID.FillWeight = 5F;
            this.ParentUID.HeaderText = "ParentUID";
            this.ParentUID.Name = "ParentUID";
            this.ParentUID.ReadOnly = true;
            this.ParentUID.Visible = false;
            this.ParentUID.Width = 5;
            // 
            // IPBelongTo
            // 
            this.IPBelongTo.DataPropertyName = "IPBelongTo";
            this.IPBelongTo.HeaderText = "IPBelongTo";
            this.IPBelongTo.Name = "IPBelongTo";
            this.IPBelongTo.ReadOnly = true;
            this.IPBelongTo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.IPBelongTo.Visible = false;
            this.IPBelongTo.Width = 5;
            // 
            // p3_btn_back
            // 
            this.p3_btn_back.BackgroundImage = global::IPDectect.Client.Properties.Resources.btn2_正常;
            this.p3_btn_back.Cursor = System.Windows.Forms.Cursors.Hand;
            this.p3_btn_back.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.p3_btn_back.FlatAppearance.BorderSize = 0;
            this.p3_btn_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.p3_btn_back.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.p3_btn_back.ForeColor = System.Drawing.Color.Black;
            this.p3_btn_back.Location = new System.Drawing.Point(253, 280);
            this.p3_btn_back.Name = "p3_btn_back";
            this.p3_btn_back.Size = new System.Drawing.Size(80, 25);
            this.p3_btn_back.TabIndex = 1;
            this.p3_btn_back.Text = "返  回";
            this.p3_btn_back.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.p3_btn_back.UseVisualStyleBackColor = true;
            this.p3_btn_back.Click += new System.EventHandler(this.p3_btn_back_Click);
            // 
            // Panel_P4_logSearch
            // 
            this.Panel_P4_logSearch.BackColor = System.Drawing.Color.Transparent;
            this.Panel_P4_logSearch.Controls.Add(this.p4_dvLog);
            this.Panel_P4_logSearch.Controls.Add(this.p4_pic1);
            this.Panel_P4_logSearch.Controls.Add(this.p4_txt_currentpage);
            this.Panel_P4_logSearch.Controls.Add(this.p4_pic3);
            this.Panel_P4_logSearch.Controls.Add(this.p4_pic4);
            this.Panel_P4_logSearch.Controls.Add(this.p4_pic2);
            this.Panel_P4_logSearch.Controls.Add(this.P4_lblExport);
            this.Panel_P4_logSearch.Controls.Add(this.p4_btn_GoToPage);
            this.Panel_P4_logSearch.Controls.Add(this.p4_chk_onlyNotMatched);
            this.Panel_P4_logSearch.Controls.Add(this.p4_page_totalPages);
            this.Panel_P4_logSearch.Controls.Add(this.p4_lbl_pageTotalRow);
            this.Panel_P4_logSearch.Controls.Add(this.p4_lblLoading);
            this.Panel_P4_logSearch.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Panel_P4_logSearch.Location = new System.Drawing.Point(1, 57);
            this.Panel_P4_logSearch.Name = "Panel_P4_logSearch";
            this.Panel_P4_logSearch.Size = new System.Drawing.Size(598, 317);
            this.Panel_P4_logSearch.TabIndex = 35;
            // 
            // p4_dvLog
            // 
            this.p4_dvLog.AllowUserToAddRows = false;
            this.p4_dvLog.AllowUserToDeleteRows = false;
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle29.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle29.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle29.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle29.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle29.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.p4_dvLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle29;
            this.p4_dvLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SeqNo,
            this.CreatedDate,
            this.Recorder,
            this.ExpectedISP,
            this.Address,
            this.ClientIP,
            this.RealISP,
            this.Status});
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle30.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle30.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle30.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle30.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle30.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.p4_dvLog.DefaultCellStyle = dataGridViewCellStyle30;
            this.p4_dvLog.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.p4_dvLog.Location = new System.Drawing.Point(1, 24);
            this.p4_dvLog.Name = "p4_dvLog";
            this.p4_dvLog.ReadOnly = true;
            this.p4_dvLog.RowHeadersVisible = false;
            this.p4_dvLog.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Gray;
            this.p4_dvLog.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.p4_dvLog.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.p4_dvLog.RowTemplate.Height = 23;
            this.p4_dvLog.RowTemplate.ReadOnly = true;
            this.p4_dvLog.ShowEditingIcon = false;
            this.p4_dvLog.Size = new System.Drawing.Size(596, 265);
            this.p4_dvLog.TabIndex = 1;
            // 
            // SeqNo
            // 
            this.SeqNo.DataPropertyName = "SeqNo";
            this.SeqNo.Frozen = true;
            this.SeqNo.HeaderText = "No.";
            this.SeqNo.Name = "SeqNo";
            this.SeqNo.ReadOnly = true;
            this.SeqNo.Width = 30;
            // 
            // CreatedDate
            // 
            this.CreatedDate.DataPropertyName = "QueryDate";
            this.CreatedDate.HeaderText = "查询时间";
            this.CreatedDate.Name = "CreatedDate";
            this.CreatedDate.ReadOnly = true;
            this.CreatedDate.Width = 130;
            // 
            // Recorder
            // 
            this.Recorder.DataPropertyName = "Recordor";
            this.Recorder.HeaderText = "录入人";
            this.Recorder.Name = "Recorder";
            this.Recorder.ReadOnly = true;
            this.Recorder.Width = 65;
            // 
            // ExpectedISP
            // 
            this.ExpectedISP.DataPropertyName = "ExpectedISP";
            this.ExpectedISP.HeaderText = "待验证运营商";
            this.ExpectedISP.Name = "ExpectedISP";
            this.ExpectedISP.ReadOnly = true;
            this.ExpectedISP.Width = 90;
            // 
            // Address
            // 
            this.Address.DataPropertyName = "Address";
            this.Address.HeaderText = "详细地址";
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            this.Address.Width = 180;
            // 
            // ClientIP
            // 
            this.ClientIP.DataPropertyName = "IP";
            this.ClientIP.HeaderText = "IP";
            this.ClientIP.Name = "ClientIP";
            this.ClientIP.ReadOnly = true;
            this.ClientIP.Width = 103;
            // 
            // RealISP
            // 
            this.RealISP.DataPropertyName = "RealISP";
            this.RealISP.HeaderText = "查询结果";
            this.RealISP.Name = "RealISP";
            this.RealISP.ReadOnly = true;
            this.RealISP.Width = 90;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "StatusDisplay";
            this.Status.HeaderText = "判断结果";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 70;
            // 
            // p4_pic1
            // 
            this.p4_pic1.BackColor = System.Drawing.Color.Transparent;
            this.p4_pic1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.p4_pic1.Image = global::IPDectect.Client.Properties.Resources.分页_1;
            this.p4_pic1.Location = new System.Drawing.Point(443, 292);
            this.p4_pic1.Name = "p4_pic1";
            this.p4_pic1.Size = new System.Drawing.Size(18, 18);
            this.p4_pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.p4_pic1.TabIndex = 17;
            this.p4_pic1.TabStop = false;
            this.p4_pic1.Click += new System.EventHandler(this.p4_pic1_Click);
            // 
            // p4_txt_currentpage
            // 
            this.p4_txt_currentpage.AcceptsReturn = true;
            this.p4_txt_currentpage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p4_txt_currentpage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.p4_txt_currentpage.Location = new System.Drawing.Point(482, 291);
            this.p4_txt_currentpage.MaxLength = 4;
            this.p4_txt_currentpage.Name = "p4_txt_currentpage";
            this.p4_txt_currentpage.Size = new System.Drawing.Size(28, 23);
            this.p4_txt_currentpage.TabIndex = 8;
            this.p4_txt_currentpage.Text = "1";
            this.p4_txt_currentpage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.p4_txt_currentpage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.p4_txt_currentpage_KeyPress);
            // 
            // p4_pic3
            // 
            this.p4_pic3.BackColor = System.Drawing.Color.Transparent;
            this.p4_pic3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.p4_pic3.Image = global::IPDectect.Client.Properties.Resources.分页_3;
            this.p4_pic3.Location = new System.Drawing.Point(558, 292);
            this.p4_pic3.Name = "p4_pic3";
            this.p4_pic3.Size = new System.Drawing.Size(18, 18);
            this.p4_pic3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.p4_pic3.TabIndex = 19;
            this.p4_pic3.TabStop = false;
            this.p4_pic3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // p4_pic4
            // 
            this.p4_pic4.BackColor = System.Drawing.Color.Transparent;
            this.p4_pic4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.p4_pic4.Image = global::IPDectect.Client.Properties.Resources.分页_4;
            this.p4_pic4.Location = new System.Drawing.Point(577, 292);
            this.p4_pic4.Name = "p4_pic4";
            this.p4_pic4.Size = new System.Drawing.Size(18, 18);
            this.p4_pic4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.p4_pic4.TabIndex = 20;
            this.p4_pic4.TabStop = false;
            this.p4_pic4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // p4_pic2
            // 
            this.p4_pic2.BackColor = System.Drawing.Color.Transparent;
            this.p4_pic2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.p4_pic2.Image = global::IPDectect.Client.Properties.Resources.分页_2;
            this.p4_pic2.Location = new System.Drawing.Point(462, 292);
            this.p4_pic2.Name = "p4_pic2";
            this.p4_pic2.Size = new System.Drawing.Size(18, 18);
            this.p4_pic2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.p4_pic2.TabIndex = 18;
            this.p4_pic2.TabStop = false;
            this.p4_pic2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // P4_lblExport
            // 
            this.P4_lblExport.AutoSize = true;
            this.P4_lblExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.P4_lblExport.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.P4_lblExport.Location = new System.Drawing.Point(0, 5);
            this.P4_lblExport.Name = "P4_lblExport";
            this.P4_lblExport.Size = new System.Drawing.Size(74, 17);
            this.P4_lblExport.TabIndex = 16;
            this.P4_lblExport.Text = "导出日志>>";
            this.P4_lblExport.Click += new System.EventHandler(this.P4_lblExport_Click);
            // 
            // p4_btn_GoToPage
            // 
            this.p4_btn_GoToPage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.p4_btn_GoToPage.Location = new System.Drawing.Point(540, 322);
            this.p4_btn_GoToPage.Name = "p4_btn_GoToPage";
            this.p4_btn_GoToPage.Size = new System.Drawing.Size(1, 1);
            this.p4_btn_GoToPage.TabIndex = 15;
            this.p4_btn_GoToPage.Text = "GoToPage";
            this.p4_btn_GoToPage.UseVisualStyleBackColor = true;
            this.p4_btn_GoToPage.Click += new System.EventHandler(this.p4_btn_GoToPage_Click);
            // 
            // p4_chk_onlyNotMatched
            // 
            this.p4_chk_onlyNotMatched.AutoSize = true;
            this.p4_chk_onlyNotMatched.ForeColor = System.Drawing.Color.Black;
            this.p4_chk_onlyNotMatched.Location = new System.Drawing.Point(5, 292);
            this.p4_chk_onlyNotMatched.Name = "p4_chk_onlyNotMatched";
            this.p4_chk_onlyNotMatched.Size = new System.Drawing.Size(147, 21);
            this.p4_chk_onlyNotMatched.TabIndex = 10;
            this.p4_chk_onlyNotMatched.Text = "只看查询结果不匹配的";
            this.p4_chk_onlyNotMatched.UseVisualStyleBackColor = true;
            this.p4_chk_onlyNotMatched.CheckedChanged += new System.EventHandler(this.p4_chk_onlyNotMatched_CheckedChanged);
            // 
            // p4_page_totalPages
            // 
            this.p4_page_totalPages.AutoSize = true;
            this.p4_page_totalPages.ForeColor = System.Drawing.Color.Black;
            this.p4_page_totalPages.Location = new System.Drawing.Point(509, 293);
            this.p4_page_totalPages.Name = "p4_page_totalPages";
            this.p4_page_totalPages.Size = new System.Drawing.Size(54, 17);
            this.p4_page_totalPages.TabIndex = 9;
            this.p4_page_totalPages.Text = "of 13 页";
            // 
            // p4_lbl_pageTotalRow
            // 
            this.p4_lbl_pageTotalRow.AutoSize = true;
            this.p4_lbl_pageTotalRow.ForeColor = System.Drawing.Color.Black;
            this.p4_lbl_pageTotalRow.Location = new System.Drawing.Point(382, 292);
            this.p4_lbl_pageTotalRow.Name = "p4_lbl_pageTotalRow";
            this.p4_lbl_pageTotalRow.Size = new System.Drawing.Size(68, 17);
            this.p4_lbl_pageTotalRow.TabIndex = 3;
            this.p4_lbl_pageTotalRow.Text = "共 1234 条";
            // 
            // p4_lblLoading
            // 
            this.p4_lblLoading.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.p4_lblLoading.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.p4_lblLoading.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.p4_lblLoading.Location = new System.Drawing.Point(0, 0);
            this.p4_lblLoading.Name = "p4_lblLoading";
            this.p4_lblLoading.Size = new System.Drawing.Size(597, 316);
            this.p4_lblLoading.TabIndex = 21;
            this.p4_lblLoading.Text = "正在查询中，请稍后...";
            this.p4_lblLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_top
            // 
            this.panel_top.BackColor = System.Drawing.Color.Transparent;
            this.panel_top.BackgroundImage = global::IPDectect.Client.Properties.Resources._1;
            this.panel_top.Controls.Add(this.top_lblIPScan);
            this.panel_top.Controls.Add(this.top_lblHelp);
            this.panel_top.Controls.Add(this.top_lblLogQuery);
            this.panel_top.Controls.Add(this.top_lblCurrentIPRetrive);
            this.panel_top.Location = new System.Drawing.Point(0, 35);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(599, 22);
            this.panel_top.TabIndex = 36;
            // 
            // top_lblIPScan
            // 
            this.top_lblIPScan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.top_lblIPScan.AutoSize = true;
            this.top_lblIPScan.BackColor = System.Drawing.Color.Transparent;
            this.top_lblIPScan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.top_lblIPScan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.top_lblIPScan.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.top_lblIPScan.ForeColor = System.Drawing.SystemColors.ControlText;
            this.top_lblIPScan.Location = new System.Drawing.Point(273, 1);
            this.top_lblIPScan.Margin = new System.Windows.Forms.Padding(0);
            this.top_lblIPScan.Name = "top_lblIPScan";
            this.top_lblIPScan.Size = new System.Drawing.Size(69, 20);
            this.top_lblIPScan.TabIndex = 3;
            this.top_lblIPScan.Text = "地址扫描";
            this.top_lblIPScan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.top_lblIPScan.Click += new System.EventHandler(this.menuScan_Click);
            // 
            // top_lblHelp
            // 
            this.top_lblHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.top_lblHelp.AutoSize = true;
            this.top_lblHelp.BackColor = System.Drawing.Color.Transparent;
            this.top_lblHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.top_lblHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.top_lblHelp.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.top_lblHelp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.top_lblHelp.Location = new System.Drawing.Point(545, 1);
            this.top_lblHelp.Margin = new System.Windows.Forms.Padding(0);
            this.top_lblHelp.Name = "top_lblHelp";
            this.top_lblHelp.Size = new System.Drawing.Size(39, 20);
            this.top_lblHelp.TabIndex = 2;
            this.top_lblHelp.Text = "帮助";
            this.top_lblHelp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.top_lblHelp.Click += new System.EventHandler(this.top_lblHelp_Click);
            // 
            // top_lblLogQuery
            // 
            this.top_lblLogQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.top_lblLogQuery.AutoSize = true;
            this.top_lblLogQuery.BackColor = System.Drawing.Color.Transparent;
            this.top_lblLogQuery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.top_lblLogQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.top_lblLogQuery.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.top_lblLogQuery.ForeColor = System.Drawing.SystemColors.ControlText;
            this.top_lblLogQuery.Location = new System.Drawing.Point(443, 1);
            this.top_lblLogQuery.Margin = new System.Windows.Forms.Padding(0);
            this.top_lblLogQuery.Name = "top_lblLogQuery";
            this.top_lblLogQuery.Size = new System.Drawing.Size(69, 20);
            this.top_lblLogQuery.TabIndex = 1;
            this.top_lblLogQuery.Text = "查询日志";
            this.top_lblLogQuery.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.top_lblLogQuery.Click += new System.EventHandler(this.top_lblLogQuery_Click);
            // 
            // top_lblCurrentIPRetrive
            // 
            this.top_lblCurrentIPRetrive.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.top_lblCurrentIPRetrive.AutoSize = true;
            this.top_lblCurrentIPRetrive.BackColor = System.Drawing.Color.Transparent;
            this.top_lblCurrentIPRetrive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.top_lblCurrentIPRetrive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.top_lblCurrentIPRetrive.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.top_lblCurrentIPRetrive.Location = new System.Drawing.Point(351, 1);
            this.top_lblCurrentIPRetrive.Margin = new System.Windows.Forms.Padding(0);
            this.top_lblCurrentIPRetrive.Name = "top_lblCurrentIPRetrive";
            this.top_lblCurrentIPRetrive.Size = new System.Drawing.Size(82, 20);
            this.top_lblCurrentIPRetrive.TabIndex = 0;
            this.top_lblCurrentIPRetrive.Text = "当前IP查询";
            this.top_lblCurrentIPRetrive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.top_lblCurrentIPRetrive.Click += new System.EventHandler(this.top_lblCurrentIPRetrive_Click);
            // 
            // pictureBoxClose
            // 
            this.pictureBoxClose.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxClose.Image = global::IPDectect.Client.Properties.Resources.关闭_正常;
            this.pictureBoxClose.Location = new System.Drawing.Point(568, 3);
            this.pictureBoxClose.Name = "pictureBoxClose";
            this.pictureBoxClose.Size = new System.Drawing.Size(30, 30);
            this.pictureBoxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxClose.TabIndex = 37;
            this.pictureBoxClose.TabStop = false;
            this.pictureBoxClose.Click += new System.EventHandler(this.pictureBoxClose_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "btn4-选中.png");
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "IP地址定位助手";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Set,
            this.contextMenu_Exit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 48);
            // 
            // ToolStripMenuItem_Set
            // 
            this.ToolStripMenuItem_Set.Name = "ToolStripMenuItem_Set";
            this.ToolStripMenuItem_Set.Size = new System.Drawing.Size(100, 22);
            this.ToolStripMenuItem_Set.Text = "设置";
            this.ToolStripMenuItem_Set.Click += new System.EventHandler(this.ToolStripMenuItem_Set_Click);
            // 
            // contextMenu_Exit
            // 
            this.contextMenu_Exit.Name = "contextMenu_Exit";
            this.contextMenu_Exit.Size = new System.Drawing.Size(100, 22);
            this.contextMenu_Exit.Text = "退出";
            this.contextMenu_Exit.Click += new System.EventHandler(this.contextMenu_Exit_Click);
            // 
            // panel_p5_adminScan
            // 
            this.panel_p5_adminScan.Controls.Add(this.p5_dgvIPRangeList);
            this.panel_p5_adminScan.Controls.Add(this.btnScan);
            this.panel_p5_adminScan.Controls.Add(this.txtScanResult);
            this.panel_p5_adminScan.Controls.Add(this.progressBar1);
            this.panel_p5_adminScan.ForeColor = System.Drawing.Color.Transparent;
            this.panel_p5_adminScan.Location = new System.Drawing.Point(1, 57);
            this.panel_p5_adminScan.Name = "panel_p5_adminScan";
            this.panel_p5_adminScan.Size = new System.Drawing.Size(598, 317);
            this.panel_p5_adminScan.TabIndex = 4;
            // 
            // p5_dgvIPRangeList
            // 
            this.p5_dgvIPRangeList.AllowUserToAddRows = false;
            this.p5_dgvIPRangeList.AllowUserToDeleteRows = false;
            this.p5_dgvIPRangeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.p5_dgvIPRangeList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seq,
            this.rowSelect,
            this.IPStart,
            this.IPEnd,
            this.TTLLimit,
            this.TCPTimeLimit,
            this.TCPPort});
            this.p5_dgvIPRangeList.Location = new System.Drawing.Point(1, -4);
            this.p5_dgvIPRangeList.Name = "p5_dgvIPRangeList";
            this.p5_dgvIPRangeList.RowHeadersVisible = false;
            this.p5_dgvIPRangeList.RowTemplate.Height = 23;
            this.p5_dgvIPRangeList.ShowCellErrors = false;
            this.p5_dgvIPRangeList.Size = new System.Drawing.Size(593, 129);
            this.p5_dgvIPRangeList.TabIndex = 22;
            this.p5_dgvIPRangeList.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.p5_dgvIPRangeList_CellValidating);
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
            this.btnScan.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnScan.Location = new System.Drawing.Point(233, 267);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(120, 40);
            this.btnScan.TabIndex = 21;
            this.btnScan.Text = "TCP/TTL 扫描";
            this.btnScan.UseVisualStyleBackColor = false;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // txtScanResult
            // 
            this.txtScanResult.BackColor = System.Drawing.SystemColors.InfoText;
            this.txtScanResult.ForeColor = System.Drawing.SystemColors.Info;
            this.txtScanResult.Location = new System.Drawing.Point(5, 164);
            this.txtScanResult.MaxLength = 327670;
            this.txtScanResult.Multiline = true;
            this.txtScanResult.Name = "txtScanResult";
            this.txtScanResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtScanResult.Size = new System.Drawing.Size(593, 94);
            this.txtScanResult.TabIndex = 20;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(9, 146);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(585, 11);
            this.progressBar1.TabIndex = 19;
            // 
            // Seq
            // 
            this.Seq.DataPropertyName = "Seq";
            this.Seq.Frozen = true;
            this.Seq.HeaderText = "No.";
            this.Seq.MaxInputLength = 4;
            this.Seq.Name = "Seq";
            this.Seq.ReadOnly = true;
            this.Seq.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Seq.Width = 40;
            // 
            // rowSelect
            // 
            this.rowSelect.Frozen = true;
            this.rowSelect.HeaderText = "选择";
            this.rowSelect.MinimumWidth = 50;
            this.rowSelect.Name = "rowSelect";
            this.rowSelect.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.rowSelect.Visible = false;
            this.rowSelect.Width = 50;
            // 
            // IPStart
            // 
            this.IPStart.DataPropertyName = "IPStart";
            this.IPStart.Frozen = true;
            this.IPStart.HeaderText = "IP开始";
            this.IPStart.MaxInputLength = 15;
            this.IPStart.MinimumWidth = 110;
            this.IPStart.Name = "IPStart";
            this.IPStart.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.IPStart.Width = 120;
            // 
            // IPEnd
            // 
            this.IPEnd.DataPropertyName = "IPEnd";
            this.IPEnd.Frozen = true;
            this.IPEnd.HeaderText = "IP结束";
            this.IPEnd.MaxInputLength = 15;
            this.IPEnd.MinimumWidth = 110;
            this.IPEnd.Name = "IPEnd";
            this.IPEnd.Width = 120;
            // 
            // TTLLimit
            // 
            this.TTLLimit.DataPropertyName = "TTLFaZhi";
            this.TTLLimit.Frozen = true;
            this.TTLLimit.HeaderText = "TTL阀值";
            this.TTLLimit.MaxInputLength = 4;
            this.TTLLimit.MinimumWidth = 60;
            this.TTLLimit.Name = "TTLLimit";
            // 
            // TCPTimeLimit
            // 
            this.TCPTimeLimit.DataPropertyName = "TCPFaZhi";
            this.TCPTimeLimit.Frozen = true;
            this.TCPTimeLimit.HeaderText = "TCP响应时间阀值";
            this.TCPTimeLimit.MaxInputLength = 4;
            this.TCPTimeLimit.MinimumWidth = 100;
            this.TCPTimeLimit.Name = "TCPTimeLimit";
            this.TCPTimeLimit.Width = 110;
            // 
            // TCPPort
            // 
            this.TCPPort.DataPropertyName = "TCPPort";
            this.TCPPort.Frozen = true;
            this.TCPPort.HeaderText = "TCP端口";
            this.TCPPort.MaxInputLength = 4;
            this.TCPPort.MinimumWidth = 60;
            this.TCPPort.Name = "TCPPort";
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnIPRetrive;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BackgroundImage = global::IPDectect.Client.Properties.Resources.back_1;
            this.ClientSize = new System.Drawing.Size(600, 375);
            this.Controls.Add(this.panel_p5_adminScan);
            this.Controls.Add(this.Panel_P1_IPRetrive);
            this.Controls.Add(this.Panel_P2_IPRetriving);
            this.Controls.Add(this.Panel_P3_route);
            this.Controls.Add(this.Panel_P4_logSearch);
            this.Controls.Add(this.pictureBoxClose);
            this.Controls.Add(this.panel_top);
            this.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IP地址定位助手";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseMove);
            this.Panel_P1_IPRetrive.ResumeLayout(false);
            this.Panel_P1_IPRetrive.PerformLayout();
            this.Panel_P2_IPRetriving.ResumeLayout(false);
            this.Panel_P2_IPRetriving.PerformLayout();
            this.Panel_P3_route.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.p3_dvRoute)).EndInit();
            this.Panel_P4_logSearch.ResumeLayout(false);
            this.Panel_P4_logSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.p4_dvLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p4_pic1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p4_pic3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p4_pic4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p4_pic2)).EndInit();
            this.panel_top.ResumeLayout(false);
            this.panel_top.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel_p5_adminScan.ResumeLayout(false);
            this.panel_p5_adminScan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.p5_dgvIPRangeList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Panel_P1_IPRetrive;
        private System.Windows.Forms.Button btnIPRetrive;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbDistinct;
        private System.Windows.Forms.TextBox txtOperatorOther;
        private System.Windows.Forms.TextBox txtDetailAddress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbCity2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbProvince2;
        private System.Windows.Forms.ComboBox cmbOperators;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbCity1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbProvince1;
        private System.Windows.Forms.TextBox txtRecordor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel Panel_P2_IPRetriving;
        private System.Windows.Forms.Label p2_lbl_ip;
        private System.Windows.Forms.Label p2_label5;
        private System.Windows.Forms.Label p2_label4;
        private System.Windows.Forms.Label p2_label3;
        private System.Windows.Forms.Label p2_label2;
        private System.Windows.Forms.Label p2_label1;
        private System.Windows.Forms.Label p2_lbl_IsRetriving;
        private System.Windows.Forms.ProgressBar p2_progressBar;
        private System.Windows.Forms.Label p2_lbl_progressStatus;
        private System.Windows.Forms.Label p2_lbl_ipbelongto;
        private System.Windows.Forms.Label p2_label6;
        private System.Windows.Forms.Panel Panel_P3_route;
        private System.Windows.Forms.Button p3_btn_back;
        private System.Windows.Forms.DataGridView p3_dvRoute;
        private System.Windows.Forms.Label p2_lbl_progress;
        private System.Windows.Forms.Button p2_btnBack;
        private System.Windows.Forms.Button p2_btnSearchagain;
        private System.Windows.Forms.Panel Panel_P4_logSearch;
        private System.Windows.Forms.DataGridView p4_dvLog;
        private System.Windows.Forms.Label p2_lblISP_text;
        private System.Windows.Forms.Label p2_lblCity_text;
        private System.Windows.Forms.Label p2_lblProvice_text;
        private System.Windows.Forms.Label p4_lbl_pageTotalRow;
        private System.Windows.Forms.Label p4_page_totalPages;
        private System.Windows.Forms.TextBox p4_txt_currentpage;
        private System.Windows.Forms.CheckBox p4_chk_onlyNotMatched;
        private System.Windows.Forms.Button p4_btn_GoToPage;
        private System.Windows.Forms.Panel panel_top;
        private System.Windows.Forms.Label top_lblCurrentIPRetrive;
        private System.Windows.Forms.Label top_lblHelp;
        private System.Windows.Forms.Label top_lblLogQuery;
        private System.Windows.Forms.PictureBox pictureBoxClose;
        private System.Windows.Forms.Label P4_lblExport;
        private System.Windows.Forms.PictureBox p4_pic4;
        private System.Windows.Forms.PictureBox p4_pic3;
        private System.Windows.Forms.PictureBox p4_pic2;
        private System.Windows.Forms.PictureBox p4_pic1;
        private System.Windows.Forms.Label p2_lblViewRouteDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn IPBelongToProvince;
        private System.Windows.Forms.DataGridViewTextBoxColumn IPBelongToCity;
        private System.Windows.Forms.DataGridViewTextBoxColumn 最快响应时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn 平均响应时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn 最慢响应时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn IP地址;
        private System.Windows.Forms.DataGridViewTextBoxColumn IP归属;
        private System.Windows.Forms.DataGridViewTextBoxColumn RouteDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParentUID;
        private System.Windows.Forms.DataGridViewTextBoxColumn IPBelongTo;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SeqNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Recorder;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpectedISP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn RealISP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.Label p4_lblLoading;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem contextMenu_Exit;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Set;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label top_lblIPScan;
        private System.Windows.Forms.Panel panel_p5_adminScan;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.DataGridView p5_dgvIPRangeList;
        public System.Windows.Forms.TextBox txtScanResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn Seq;
        private System.Windows.Forms.DataGridViewCheckBoxColumn rowSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn IPStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn IPEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn TTLLimit;
        private System.Windows.Forms.DataGridViewTextBoxColumn TCPTimeLimit;
        private System.Windows.Forms.DataGridViewTextBoxColumn TCPPort;
    }
}