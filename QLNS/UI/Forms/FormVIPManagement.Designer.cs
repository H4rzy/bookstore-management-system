namespace QLNS.UI.Forms
{
    partial class FormVIPManagement
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTotalCards = new System.Windows.Forms.Label();
            this.cboCustomerFilter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvVIPCards = new System.Windows.Forms.DataGridView();
            this.panelDetails = new System.Windows.Forms.Panel();
            this.tableLayoutPanelDetails = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxInfo = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelInfo = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMaTheVIP = new System.Windows.Forms.TextBox();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.dtpNgayCapPhat = new System.Windows.Forms.DateTimePicker();
            this.dtpNgayHetHan = new System.Windows.Forms.DateTimePicker();
            this.txtDiemTichLuy = new System.Windows.Forms.TextBox();
            this.txtChiTieu = new System.Windows.Forms.TextBox();
            this.txtTrangThai = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBoxVIP = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelVIP = new System.Windows.Forms.TableLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.lblHangVIP = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblExpiryStatus = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblNextRank = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnTruDiem = new System.Windows.Forms.Button();
            this.btnCongDiem = new System.Windows.Forms.Button();
            this.btnHuyThe = new System.Windows.Forms.Button();
            this.btnGiaHan = new System.Windows.Forms.Button();
            this.btnCapThe = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVIPCards)).BeginInit();
            this.panelDetails.SuspendLayout();
            this.tableLayoutPanelDetails.SuspendLayout();
            this.groupBoxInfo.SuspendLayout();
            this.tableLayoutPanelInfo.SuspendLayout();
            this.groupBoxVIP.SuspendLayout();
            this.tableLayoutPanelVIP.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panelTop, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvVIPCards, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelDetails, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panelButtons, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1000, 600);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.lblTotalCards);
            this.panelTop.Controls.Add(this.cboCustomerFilter);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop.Location = new System.Drawing.Point(13, 13);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(974, 44);
            this.panelTop.TabIndex = 0;
            // 
            // lblTotalCards
            // 
            this.lblTotalCards.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalCards.AutoSize = true;
            this.lblTotalCards.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalCards.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(161)))), ((int)(((byte)(251)))));
            this.lblTotalCards.Location = new System.Drawing.Point(850, 12);
            this.lblTotalCards.Name = "lblTotalCards";
            this.lblTotalCards.Size = new System.Drawing.Size(110, 19);
            this.lblTotalCards.TabIndex = 2;
            this.lblTotalCards.Text = "Tổng số thẻ: 0";
            // 
            // cboCustomerFilter
            // 
            this.cboCustomerFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomerFilter.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboCustomerFilter.FormattingEnabled = true;
            this.cboCustomerFilter.Location = new System.Drawing.Point(130, 8);
            this.cboCustomerFilter.Name = "cboCustomerFilter";
            this.cboCustomerFilter.Size = new System.Drawing.Size(700, 25);
            this.cboCustomerFilter.TabIndex = 1;
            this.cboCustomerFilter.SelectedIndexChanged += new System.EventHandler(this.cboCustomerFilter_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(10, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "🔍 Lọc theo KH:";
            // 
            // dgvVIPCards
            // 
            this.dgvVIPCards.AllowUserToAddRows = false;
            this.dgvVIPCards.AllowUserToDeleteRows = false;
            this.dgvVIPCards.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVIPCards.BackgroundColor = System.Drawing.Color.White;
            this.dgvVIPCards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVIPCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVIPCards.Location = new System.Drawing.Point(13, 63);
            this.dgvVIPCards.MultiSelect = false;
            this.dgvVIPCards.Name = "dgvVIPCards";
            this.dgvVIPCards.ReadOnly = true;
            this.dgvVIPCards.RowHeadersWidth = 51;
            this.dgvVIPCards.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVIPCards.Size = new System.Drawing.Size(974, 212);
            this.dgvVIPCards.TabIndex = 1;
            this.dgvVIPCards.SelectionChanged += new System.EventHandler(this.dgvVIPCards_SelectionChanged);
            // 
            // panelDetails
            // 
            this.panelDetails.Controls.Add(this.tableLayoutPanelDetails);
            this.panelDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDetails.Location = new System.Drawing.Point(13, 281);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Size = new System.Drawing.Size(974, 260);
            this.panelDetails.TabIndex = 2;
            // 
            // tableLayoutPanelDetails
            // 
            this.tableLayoutPanelDetails.ColumnCount = 2;
            this.tableLayoutPanelDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanelDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanelDetails.Controls.Add(this.groupBoxInfo, 0, 0);
            this.tableLayoutPanelDetails.Controls.Add(this.groupBoxVIP, 1, 0);
            this.tableLayoutPanelDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelDetails.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelDetails.Name = "tableLayoutPanelDetails";
            this.tableLayoutPanelDetails.RowCount = 1;
            this.tableLayoutPanelDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelDetails.Size = new System.Drawing.Size(974, 260);
            this.tableLayoutPanelDetails.TabIndex = 0;
            // 
            // groupBoxInfo
            // 
            this.groupBoxInfo.Controls.Add(this.tableLayoutPanelInfo);
            this.groupBoxInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.groupBoxInfo.Location = new System.Drawing.Point(3, 3);
            this.groupBoxInfo.Name = "groupBoxInfo";
            this.groupBoxInfo.Padding = new System.Windows.Forms.Padding(8);
            this.groupBoxInfo.Size = new System.Drawing.Size(529, 254);
            this.groupBoxInfo.TabIndex = 0;
            this.groupBoxInfo.TabStop = false;
            this.groupBoxInfo.Text = "📋 Thông Tin Thẻ VIP";
            // 
            // tableLayoutPanelInfo
            // 
            this.tableLayoutPanelInfo.ColumnCount = 4;
            this.tableLayoutPanelInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanelInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanelInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelInfo.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanelInfo.Controls.Add(this.txtMaTheVIP, 1, 0);
            this.tableLayoutPanelInfo.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanelInfo.Controls.Add(this.dtpNgayCapPhat, 3, 0);
            this.tableLayoutPanelInfo.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanelInfo.Controls.Add(this.txtMaKH, 1, 1);
            this.tableLayoutPanelInfo.Controls.Add(this.label7, 2, 1);
            this.tableLayoutPanelInfo.Controls.Add(this.dtpNgayHetHan, 3, 1);
            this.tableLayoutPanelInfo.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanelInfo.Controls.Add(this.txtTenKH, 1, 2);
            this.tableLayoutPanelInfo.Controls.Add(this.label8, 2, 2);
            this.tableLayoutPanelInfo.Controls.Add(this.txtDiemTichLuy, 3, 2);
            this.tableLayoutPanelInfo.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanelInfo.Controls.Add(this.txtDienThoai, 1, 3);
            this.tableLayoutPanelInfo.Controls.Add(this.label9, 2, 3);
            this.tableLayoutPanelInfo.Controls.Add(this.txtChiTieu, 3, 3);
            this.tableLayoutPanelInfo.Controls.Add(this.label10, 0, 4);
            this.tableLayoutPanelInfo.Controls.Add(this.txtTrangThai, 1, 4);
            this.tableLayoutPanelInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelInfo.Location = new System.Drawing.Point(8, 25);
            this.tableLayoutPanelInfo.Name = "tableLayoutPanelInfo";
            this.tableLayoutPanelInfo.RowCount = 5;
            this.tableLayoutPanelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelInfo.Size = new System.Drawing.Size(513, 221);
            this.tableLayoutPanelInfo.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(3, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã Thẻ:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(3, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Mã KH:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(3, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Tên KH:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(3, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "Điện thoại:";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(259, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 15);
            this.label6.TabIndex = 4;
            this.label6.Text = "Ngày cấp:";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(259, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 15);
            this.label7.TabIndex = 5;
            this.label7.Text = "Ngày hết hạn:";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(259, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 15);
            this.label8.TabIndex = 6;
            this.label8.Text = "Điểm:";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(259, 145);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 15);
            this.label9.TabIndex = 7;
            this.label9.Text = "Chi tiêu:";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(3, 191);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 15);
            this.label10.TabIndex = 8;
            this.label10.Text = "Trạng thái:";
            // 
            // txtMaTheVIP
            // 
            this.txtMaTheVIP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaTheVIP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMaTheVIP.Location = new System.Drawing.Point(103, 10);
            this.txtMaTheVIP.Name = "txtMaTheVIP";
            this.txtMaTheVIP.ReadOnly = true;
            this.txtMaTheVIP.Size = new System.Drawing.Size(150, 23);
            this.txtMaTheVIP.TabIndex = 9;
            // 
            // txtMaKH
            // 
            this.txtMaKH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaKH.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMaKH.Location = new System.Drawing.Point(103, 54);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.ReadOnly = true;
            this.txtMaKH.Size = new System.Drawing.Size(150, 23);
            this.txtMaKH.TabIndex = 10;
            // 
            // txtTenKH
            // 
            this.txtTenKH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenKH.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTenKH.Location = new System.Drawing.Point(103, 98);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.ReadOnly = true;
            this.txtTenKH.Size = new System.Drawing.Size(150, 23);
            this.txtTenKH.TabIndex = 11;
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDienThoai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDienThoai.Location = new System.Drawing.Point(103, 142);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.ReadOnly = true;
            this.txtDienThoai.Size = new System.Drawing.Size(150, 23);
            this.txtDienThoai.TabIndex = 12;
            // 
            // dtpNgayCapPhat
            // 
            this.dtpNgayCapPhat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpNgayCapPhat.Enabled = false;
            this.dtpNgayCapPhat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpNgayCapPhat.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayCapPhat.Location = new System.Drawing.Point(359, 10);
            this.dtpNgayCapPhat.Name = "dtpNgayCapPhat";
            this.dtpNgayCapPhat.Size = new System.Drawing.Size(151, 23);
            this.dtpNgayCapPhat.TabIndex = 13;
            // 
            // dtpNgayHetHan
            // 
            this.dtpNgayHetHan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpNgayHetHan.Enabled = false;
            this.dtpNgayHetHan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpNgayHetHan.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayHetHan.Location = new System.Drawing.Point(359, 54);
            this.dtpNgayHetHan.Name = "dtpNgayHetHan";
            this.dtpNgayHetHan.Size = new System.Drawing.Size(151, 23);
            this.dtpNgayHetHan.TabIndex = 14;
            // 
            // txtDiemTichLuy
            // 
            this.txtDiemTichLuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiemTichLuy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtDiemTichLuy.ForeColor = System.Drawing.Color.Blue;
            this.txtDiemTichLuy.Location = new System.Drawing.Point(359, 98);
            this.txtDiemTichLuy.Name = "txtDiemTichLuy";
            this.txtDiemTichLuy.ReadOnly = true;
            this.txtDiemTichLuy.Size = new System.Drawing.Size(151, 23);
            this.txtDiemTichLuy.TabIndex = 15;
            // 
            // txtChiTieu
            // 
            this.txtChiTieu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChiTieu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtChiTieu.ForeColor = System.Drawing.Color.Green;
            this.txtChiTieu.Location = new System.Drawing.Point(359, 142);
            this.txtChiTieu.Name = "txtChiTieu";
            this.txtChiTieu.ReadOnly = true;
            this.txtChiTieu.Size = new System.Drawing.Size(151, 23);
            this.txtChiTieu.TabIndex = 16;
            // 
            // txtTrangThai
            // 
            this.txtTrangThai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTrangThai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTrangThai.Location = new System.Drawing.Point(103, 187);
            this.txtTrangThai.Name = "txtTrangThai";
            this.txtTrangThai.ReadOnly = true;
            this.txtTrangThai.Size = new System.Drawing.Size(150, 23);
            this.txtTrangThai.TabIndex = 17;
            // 
            // groupBoxVIP
            // 
            this.groupBoxVIP.Controls.Add(this.tableLayoutPanelVIP);
            this.groupBoxVIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxVIP.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxVIP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.groupBoxVIP.Location = new System.Drawing.Point(538, 3);
            this.groupBoxVIP.Name = "groupBoxVIP";
            this.groupBoxVIP.Padding = new System.Windows.Forms.Padding(8);
            this.groupBoxVIP.Size = new System.Drawing.Size(433, 254);
            this.groupBoxVIP.TabIndex = 1;
            this.groupBoxVIP.TabStop = false;
            this.groupBoxVIP.Text = "⭐ Hạng VIP & Quyền Lợi";
            // 
            // tableLayoutPanelVIP
            // 
            this.tableLayoutPanelVIP.ColumnCount = 2;
            this.tableLayoutPanelVIP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanelVIP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelVIP.Controls.Add(this.label11, 0, 0);
            this.tableLayoutPanelVIP.Controls.Add(this.lblHangVIP, 1, 0);
            this.tableLayoutPanelVIP.Controls.Add(this.label12, 0, 1);
            this.tableLayoutPanelVIP.Controls.Add(this.lblDiscount, 1, 1);
            this.tableLayoutPanelVIP.Controls.Add(this.label13, 0, 2);
            this.tableLayoutPanelVIP.Controls.Add(this.lblExpiryStatus, 1, 2);
            this.tableLayoutPanelVIP.Controls.Add(this.label14, 0, 3);
            this.tableLayoutPanelVIP.Controls.Add(this.lblNextRank, 1, 3);
            this.tableLayoutPanelVIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelVIP.Location = new System.Drawing.Point(8, 25);
            this.tableLayoutPanelVIP.Name = "tableLayoutPanelVIP";
            this.tableLayoutPanelVIP.RowCount = 4;
            this.tableLayoutPanelVIP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelVIP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelVIP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelVIP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelVIP.Size = new System.Drawing.Size(417, 221);
            this.tableLayoutPanelVIP.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(3, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 19);
            this.label11.TabIndex = 0;
            this.label11.Text = "👑 Hạng:";
            // 
            // lblHangVIP
            // 
            this.lblHangVIP.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHangVIP.AutoSize = true;
            this.lblHangVIP.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblHangVIP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            this.lblHangVIP.Location = new System.Drawing.Point(123, 14);
            this.lblHangVIP.Name = "lblHangVIP";
            this.lblHangVIP.Size = new System.Drawing.Size(24, 25);
            this.lblHangVIP.TabIndex = 1;
            this.lblHangVIP.Text = "--";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(3, 72);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 19);
            this.label12.TabIndex = 2;
            this.label12.Text = "💰 Giảm giá:";
            // 
            // lblDiscount
            // 
            this.lblDiscount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblDiscount.ForeColor = System.Drawing.Color.Green;
            this.lblDiscount.Location = new System.Drawing.Point(123, 69);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(24, 25);
            this.lblDiscount.TabIndex = 3;
            this.lblDiscount.Text = "--";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(3, 127);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(79, 19);
            this.label13.TabIndex = 4;
            this.label13.Text = "📅 Hiệu lực:";
            // 
            // lblExpiryStatus
            // 
            this.lblExpiryStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblExpiryStatus.AutoSize = true;
            this.lblExpiryStatus.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblExpiryStatus.ForeColor = System.Drawing.Color.Green;
            this.lblExpiryStatus.Location = new System.Drawing.Point(123, 125);
            this.lblExpiryStatus.Name = "lblExpiryStatus";
            this.lblExpiryStatus.Size = new System.Drawing.Size(23, 20);
            this.lblExpiryStatus.TabIndex = 5;
            this.lblExpiryStatus.Text = "--";
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(3, 182);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 19);
            this.label14.TabIndex = 6;
            this.label14.Text = "🎯 Tiến độ:";
            // 
            // lblNextRank
            // 
            this.lblNextRank.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNextRank.AutoSize = true;
            this.lblNextRank.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNextRank.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblNextRank.Location = new System.Drawing.Point(123, 183);
            this.lblNextRank.Name = "lblNextRank";
            this.lblNextRank.Size = new System.Drawing.Size(14, 15);
            this.lblNextRank.TabIndex = 7;
            this.lblNextRank.Text = "--";
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnRefresh);
            this.panelButtons.Controls.Add(this.btnTruDiem);
            this.panelButtons.Controls.Add(this.btnCongDiem);
            this.panelButtons.Controls.Add(this.btnHuyThe);
            this.panelButtons.Controls.Add(this.btnGiaHan);
            this.panelButtons.Controls.Add(this.btnCapThe);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButtons.Location = new System.Drawing.Point(13, 547);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(974, 40);
            this.panelButtons.TabIndex = 3;
            // 
            // btnCapThe
            // 
            this.btnCapThe.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCapThe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(161)))), ((int)(((byte)(251)))));
            this.btnCapThe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapThe.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCapThe.ForeColor = System.Drawing.Color.White;
            this.btnCapThe.Location = new System.Drawing.Point(110, 3);
            this.btnCapThe.Name = "btnCapThe";
            this.btnCapThe.Size = new System.Drawing.Size(120, 34);
            this.btnCapThe.TabIndex = 0;
            this.btnCapThe.Text = "💳 Cấp Thẻ";
            this.btnCapThe.UseVisualStyleBackColor = false;
            this.btnCapThe.Click += new System.EventHandler(this.btnCapThe_Click);
            // 
            // btnGiaHan
            // 
            this.btnGiaHan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGiaHan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnGiaHan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGiaHan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGiaHan.ForeColor = System.Drawing.Color.White;
            this.btnGiaHan.Location = new System.Drawing.Point(240, 3);
            this.btnGiaHan.Name = "btnGiaHan";
            this.btnGiaHan.Size = new System.Drawing.Size(120, 34);
            this.btnGiaHan.TabIndex = 1;
            this.btnGiaHan.Text = "📆 Gia Hạn";
            this.btnGiaHan.UseVisualStyleBackColor = false;
            this.btnGiaHan.Click += new System.EventHandler(this.btnGiaHan_Click);
            // 
            // btnHuyThe
            // 
            this.btnHuyThe.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnHuyThe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnHuyThe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuyThe.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnHuyThe.ForeColor = System.Drawing.Color.White;
            this.btnHuyThe.Location = new System.Drawing.Point(370, 3);
            this.btnHuyThe.Name = "btnHuyThe";
            this.btnHuyThe.Size = new System.Drawing.Size(120, 34);
            this.btnHuyThe.TabIndex = 2;
            this.btnHuyThe.Text = "❌ Hủy Thẻ";
            this.btnHuyThe.UseVisualStyleBackColor = false;
            this.btnHuyThe.Click += new System.EventHandler(this.btnHuyThe_Click);
            // 
            // btnCongDiem
            // 
            this.btnCongDiem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCongDiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnCongDiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCongDiem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCongDiem.ForeColor = System.Drawing.Color.White;
            this.btnCongDiem.Location = new System.Drawing.Point(500, 3);
            this.btnCongDiem.Name = "btnCongDiem";
            this.btnCongDiem.Size = new System.Drawing.Size(120, 34);
            this.btnCongDiem.TabIndex = 3;
            this.btnCongDiem.Text = "➕ Cộng Điểm";
            this.btnCongDiem.UseVisualStyleBackColor = false;
            this.btnCongDiem.Click += new System.EventHandler(this.btnCongDiem_Click);
            // 
            // btnTruDiem
            // 
            this.btnTruDiem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTruDiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btnTruDiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTruDiem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTruDiem.ForeColor = System.Drawing.Color.White;
            this.btnTruDiem.Location = new System.Drawing.Point(630, 3);
            this.btnTruDiem.Name = "btnTruDiem";
            this.btnTruDiem.Size = new System.Drawing.Size(120, 34);
            this.btnTruDiem.TabIndex = 4;
            this.btnTruDiem.Text = "➖ Trừ Điểm";
            this.btnTruDiem.UseVisualStyleBackColor = false;
            this.btnTruDiem.Click += new System.EventHandler(this.btnTruDiem_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(760, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(120, 34);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "🔄 Làm Mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // FormVIPManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FormVIPManagement";
            this.Text = "Quản Lý Thẻ VIP";
            this.Load += new System.EventHandler(this.FormVIPManagement_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVIPCards)).EndInit();
            this.panelDetails.ResumeLayout(false);
            this.tableLayoutPanelDetails.ResumeLayout(false);
            this.groupBoxInfo.ResumeLayout(false);
            this.tableLayoutPanelInfo.ResumeLayout(false);
            this.tableLayoutPanelInfo.PerformLayout();
            this.groupBoxVIP.ResumeLayout(false);
            this.tableLayoutPanelVIP.ResumeLayout(false);
            this.tableLayoutPanelVIP.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTotalCards;
        private System.Windows.Forms.ComboBox cboCustomerFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvVIPCards;
        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDetails;
        private System.Windows.Forms.GroupBox groupBoxInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtMaTheVIP;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.DateTimePicker dtpNgayCapPhat;
        private System.Windows.Forms.DateTimePicker dtpNgayHetHan;
        private System.Windows.Forms.TextBox txtDiemTichLuy;
        private System.Windows.Forms.TextBox txtChiTieu;
        private System.Windows.Forms.TextBox txtTrangThai;
        private System.Windows.Forms.GroupBox groupBoxVIP;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelVIP;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblHangVIP;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblExpiryStatus;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblNextRank;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnTruDiem;
        private System.Windows.Forms.Button btnCongDiem;
        private System.Windows.Forms.Button btnHuyThe;
        private System.Windows.Forms.Button btnGiaHan;
        private System.Windows.Forms.Button btnCapThe;
    }
}
