namespace QLNS.Forms
{
    partial class FormStaff
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvStaff = new System.Windows.Forms.DataGridView();
            this.panelForm = new System.Windows.Forms.Panel();
            this.tableLayoutPanelForm = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.txtTenNV = new System.Windows.Forms.TextBox();
            this.cboGioiTinh = new System.Windows.Forms.ComboBox();
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtChucVu = new System.Windows.Forms.TextBox();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).BeginInit();
            this.panelForm.SuspendLayout();
            this.tableLayoutPanelForm.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panelTop, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvStaff, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelForm, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panelButtons, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1000, 600);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelTop
            // 
            this.cboFilterChucVu = new System.Windows.Forms.ComboBox();
            this.cboFilterGioiTinh = new System.Windows.Forms.ComboBox();
            this.lblFilterChucVu = new System.Windows.Forms.Label();
            this.lblFilterGioiTinh = new System.Windows.Forms.Label();
            this.panelTop.Controls.Add(this.btnTimKiem);
            this.panelTop.Controls.Add(this.txtTimKiem);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Controls.Add(this.cboFilterChucVu);
            this.panelTop.Controls.Add(this.cboFilterGioiTinh);
            this.panelTop.Controls.Add(this.lblFilterChucVu);
            this.panelTop.Controls.Add(this.lblFilterGioiTinh);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop.Location = new System.Drawing.Point(13, 13);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(974, 54);
            this.panelTop.TabIndex = 0;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(161)))), ((int)(((byte)(251)))));
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(320, 12);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(90, 30);
            this.btnTimKiem.TabIndex = 2;
            this.btnTimKiem.Text = "🔍 Tìm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtTimKiem.Location = new System.Drawing.Point(80, 14);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(230, 26);
            this.txtTimKiem.TabIndex = 1;
            this.txtTimKiem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTimKiem_KeyPress);
            // 
            // lblFilterChucVu
            // 
            this.lblFilterChucVu.AutoSize = true;
            this.lblFilterChucVu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblFilterChucVu.Location = new System.Drawing.Point(430, 18);
            this.lblFilterChucVu.Name = "lblFilterChucVu";
            this.lblFilterChucVu.Size = new System.Drawing.Size(68, 18);
            this.lblFilterChucVu.Text = "Chức vụ:";
            // 
            // cboFilterChucVu
            // 
            this.cboFilterChucVu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterChucVu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cboFilterChucVu.Location = new System.Drawing.Point(505, 14);
            this.cboFilterChucVu.Name = "cboFilterChucVu";
            this.cboFilterChucVu.Size = new System.Drawing.Size(150, 26);
            this.cboFilterChucVu.TabIndex = 3;
            this.cboFilterChucVu.SelectedIndexChanged += new System.EventHandler(this.cboFilterChucVu_SelectedIndexChanged);
            // 
            // lblFilterGioiTinh
            // 
            this.lblFilterGioiTinh.AutoSize = true;
            this.lblFilterGioiTinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblFilterGioiTinh.Location = new System.Drawing.Point(675, 18);
            this.lblFilterGioiTinh.Name = "lblFilterGioiTinh";
            this.lblFilterGioiTinh.Size = new System.Drawing.Size(72, 18);
            this.lblFilterGioiTinh.Text = "Giới tính:";
            // 
            // cboFilterGioiTinh
            // 
            this.cboFilterGioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterGioiTinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cboFilterGioiTinh.Items.AddRange(new object[] { "Tất cả", "Nam", "Nữ" });
            this.cboFilterGioiTinh.Location = new System.Drawing.Point(753, 14);
            this.cboFilterGioiTinh.Name = "cboFilterGioiTinh";
            this.cboFilterGioiTinh.Size = new System.Drawing.Size(100, 26);
            this.cboFilterGioiTinh.TabIndex = 4;
            this.cboFilterGioiTinh.SelectedIndexChanged += new System.EventHandler(this.cboFilterGioiTinh_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(10, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tìm Kiếm:";
            // 
            // dgvStaff
            // 
            this.dgvStaff.AllowUserToAddRows = false;
            this.dgvStaff.AllowUserToDeleteRows = false;
            this.dgvStaff.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStaff.BackgroundColor = System.Drawing.Color.White;
            this.dgvStaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStaff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStaff.Location = new System.Drawing.Point(13, 73);
            this.dgvStaff.MultiSelect = false;
            this.dgvStaff.Name = "dgvStaff";
            this.dgvStaff.ReadOnly = true;
            this.dgvStaff.RowHeadersWidth = 51;
            this.dgvStaff.RowTemplate.Height = 24;
            this.dgvStaff.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStaff.Size = new System.Drawing.Size(974, 224);
            this.dgvStaff.TabIndex = 1;
            this.dgvStaff.SelectionChanged += new System.EventHandler(this.dgvStaff_SelectionChanged);
            // 
            // panelForm
            // 
            this.panelForm.Controls.Add(this.tableLayoutPanelForm);
            this.panelForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelForm.Location = new System.Drawing.Point(13, 303);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(974, 224);
            this.panelForm.TabIndex = 2;
            // 
            // tableLayoutPanelForm
            // 
            this.tableLayoutPanelForm.ColumnCount = 4;
            this.tableLayoutPanelForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanelForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanelForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelForm.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanelForm.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanelForm.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanelForm.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanelForm.Controls.Add(this.label6, 2, 1);
            this.tableLayoutPanelForm.Controls.Add(this.label7, 2, 2);
            this.tableLayoutPanelForm.Controls.Add(this.txtMaNV, 1, 0);
            this.tableLayoutPanelForm.Controls.Add(this.txtTenNV, 1, 1);
            this.tableLayoutPanelForm.Controls.Add(this.cboGioiTinh, 1, 2);
            this.tableLayoutPanelForm.Controls.Add(this.txtDienThoai, 3, 0);
            this.tableLayoutPanelForm.Controls.Add(this.txtDiaChi, 3, 1);
            this.tableLayoutPanelForm.Controls.Add(this.txtChucVu, 3, 2);
            this.tableLayoutPanelForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelForm.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelForm.Name = "tableLayoutPanelForm";
            this.tableLayoutPanelForm.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanelForm.RowCount = 3;
            this.tableLayoutPanelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tableLayoutPanelForm.Size = new System.Drawing.Size(974, 224);
            this.tableLayoutPanelForm.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(13, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã NV:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(13, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tên NV:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(13, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Giới Tính:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(490, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Điện Thoại:";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(490, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Địa Chỉ:";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label7.Location = new System.Drawing.Point(490, 169);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "Chức Vụ:";
            // 
            // txtMaNV
            // 
            this.txtMaNV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtMaNV.Location = new System.Drawing.Point(133, 30);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(351, 26);
            this.txtMaNV.TabIndex = 6;
            // 
            // txtTenNV
            // 
            this.txtTenNV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtTenNV.Location = new System.Drawing.Point(133, 97);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Size = new System.Drawing.Size(351, 26);
            this.txtTenNV.TabIndex = 7;
            // 
            // cboGioiTinh
            // 
            this.cboGioiTinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboGioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGioiTinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cboGioiTinh.FormattingEnabled = true;
            this.cboGioiTinh.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.cboGioiTinh.Location = new System.Drawing.Point(133, 165);
            this.cboGioiTinh.Name = "cboGioiTinh";
            this.cboGioiTinh.Size = new System.Drawing.Size(351, 28);
            this.cboGioiTinh.TabIndex = 8;
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDienThoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtDienThoai.Location = new System.Drawing.Point(610, 30);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(351, 26);
            this.txtDienThoai.TabIndex = 9;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiaChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtDiaChi.Location = new System.Drawing.Point(610, 97);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(351, 26);
            this.txtDiaChi.TabIndex = 10;
            // 
            // txtChucVu
            // 
            this.txtChucVu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChucVu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtChucVu.Location = new System.Drawing.Point(610, 166);
            this.txtChucVu.Name = "txtChucVu";
            this.txtChucVu.Size = new System.Drawing.Size(351, 26);
            this.txtChucVu.TabIndex = 11;
            // 
            // panelButtons - Now contains TabControl
            // 
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButtons.Location = new System.Drawing.Point(13, 533);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(974, 54);
            this.panelButtons.TabIndex = 3;
            // 
            // tabBasic
            // 
            this.tabBasic = new System.Windows.Forms.TabPage();
            this.tabBasic.Location = new System.Drawing.Point(4, 25);
            this.tabBasic.Name = "tabBasic";
            this.tabBasic.Padding = new System.Windows.Forms.Padding(3);
            this.tabBasic.Size = new System.Drawing.Size(966, 25);
            this.tabBasic.TabIndex = 0;
            this.tabBasic.Text = "📋 Cơ Bản";
            this.tabBasic.UseVisualStyleBackColor = true;
            // 
            // tabAdvanced
            // 
            this.tabAdvanced = new System.Windows.Forms.TabPage();
            this.tabAdvanced.Location = new System.Drawing.Point(4, 25);
            this.tabAdvanced.Name = "tabAdvanced";
            this.tabAdvanced.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdvanced.Size = new System.Drawing.Size(966, 25);
            this.tabAdvanced.TabIndex = 1;
            this.tabAdvanced.Text = "⚙️ Nâng Cao";
            this.tabAdvanced.UseVisualStyleBackColor = true;
            // 
            // tabControlButtons
            // 
            this.tabControlButtons = new System.Windows.Forms.TabControl();
            this.tabControlButtons.Controls.Add(this.tabBasic);
            this.tabControlButtons.Controls.Add(this.tabAdvanced);
            this.tabControlButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlButtons.Location = new System.Drawing.Point(0, 0);
            this.tabControlButtons.Name = "tabControlButtons";
            this.tabControlButtons.SelectedIndex = 0;
            this.tabControlButtons.Size = new System.Drawing.Size(974, 54);
            this.tabControlButtons.TabIndex = 0;
            // 
            // Add tabControlButtons to panelButtons
            // 
            this.panelButtons.Controls.Add(this.tabControlButtons);
            // 
            // btnGanTaiKhoan
            // 
            this.btnGanTaiKhoan = new System.Windows.Forms.Button();
            this.btnGanTaiKhoan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnGanTaiKhoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGanTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnGanTaiKhoan.ForeColor = System.Drawing.Color.White;
            this.btnGanTaiKhoan.Location = new System.Drawing.Point(20, -3);
            this.btnGanTaiKhoan.Name = "btnGanTaiKhoan";
            this.btnGanTaiKhoan.Size = new System.Drawing.Size(130, 28);
            this.btnGanTaiKhoan.TabIndex = 0;
            this.btnGanTaiKhoan.Text = "🔑 Gán TK";
            this.btnGanTaiKhoan.UseVisualStyleBackColor = false;
            this.btnGanTaiKhoan.Click += new System.EventHandler(this.btnGanTaiKhoan_Click);
            // 
            // btnResetPass
            // 
            this.btnResetPass = new System.Windows.Forms.Button();
            this.btnResetPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnResetPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnResetPass.ForeColor = System.Drawing.Color.White;
            this.btnResetPass.Location = new System.Drawing.Point(170, -3);
            this.btnResetPass.Name = "btnResetPass";
            this.btnResetPass.Size = new System.Drawing.Size(130, 28);
            this.btnResetPass.TabIndex = 1;
            this.btnResetPass.Text = "🔄 Reset MK";
            this.btnResetPass.UseVisualStyleBackColor = false;
            this.btnResetPass.Click += new System.EventHandler(this.btnResetPass_Click);
            // 
            // btnKhoaTK
            // 
            this.btnKhoaTK = new System.Windows.Forms.Button();
            this.btnKhoaTK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnKhoaTK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKhoaTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnKhoaTK.ForeColor = System.Drawing.Color.White;
            this.btnKhoaTK.Location = new System.Drawing.Point(320, -3);
            this.btnKhoaTK.Name = "btnKhoaTK";
            this.btnKhoaTK.Size = new System.Drawing.Size(130, 28);
            this.btnKhoaTK.TabIndex = 2;
            this.btnKhoaTK.Text = "🔒 Khóa TK";
            this.btnKhoaTK.UseVisualStyleBackColor = false;
            this.btnKhoaTK.Click += new System.EventHandler(this.btnKhoaTK_Click);
            // 
            // btnMoKhoaTK
            // 
            this.btnMoKhoaTK = new System.Windows.Forms.Button();
            this.btnMoKhoaTK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnMoKhoaTK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoKhoaTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnMoKhoaTK.ForeColor = System.Drawing.Color.White;
            this.btnMoKhoaTK.Location = new System.Drawing.Point(470, -3);
            this.btnMoKhoaTK.Name = "btnMoKhoaTK";
            this.btnMoKhoaTK.Size = new System.Drawing.Size(130, 28);
            this.btnMoKhoaTK.TabIndex = 3;
            this.btnMoKhoaTK.Text = "🔓 Mở Khóa";
            this.btnMoKhoaTK.UseVisualStyleBackColor = false;
            this.btnMoKhoaTK.Click += new System.EventHandler(this.btnMoKhoaTK_Click);
            // 
            // btnXoaTK
            // 
            this.btnXoaTK = new System.Windows.Forms.Button();
            this.btnXoaTK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnXoaTK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnXoaTK.ForeColor = System.Drawing.Color.White;
            this.btnXoaTK.Location = new System.Drawing.Point(620, -3);
            this.btnXoaTK.Name = "btnXoaTK";
            this.btnXoaTK.Size = new System.Drawing.Size(130, 28);
            this.btnXoaTK.TabIndex = 4;
            this.btnXoaTK.Text = "🗑️ Xóa TK";
            this.btnXoaTK.UseVisualStyleBackColor = false;
            this.btnXoaTK.Click += new System.EventHandler(this.btnXoaTK_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(77)))), ((int)(((byte)(221)))));
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(620, -3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(130, 28);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "✏️ Chi Tiết";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(88)))), ((int)(((byte)(155)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(170, -3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(130, 28);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "🗑️ Xóa";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(138)))), ((int)(((byte)(114)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(470, -3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 28);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "❌ Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(77)))), ((int)(((byte)(221)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(320, -3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(130, 28);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "💾 Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(161)))), ((int)(((byte)(251)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(20, -3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(130, 28);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "➕ Thêm";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // Add buttons to tabBasic
            // 
            this.tabBasic.Controls.Add(this.btnEdit);
            this.tabBasic.Controls.Add(this.btnDelete);
            this.tabBasic.Controls.Add(this.btnCancel);
            this.tabBasic.Controls.Add(this.btnSave);
            this.tabBasic.Controls.Add(this.btnAdd);
            // 
            // Add buttons to tabAdvanced
            // 
            this.tabAdvanced.Controls.Add(this.btnGanTaiKhoan);
            this.tabAdvanced.Controls.Add(this.btnResetPass);
            this.tabAdvanced.Controls.Add(this.btnKhoaTK);
            this.tabAdvanced.Controls.Add(this.btnMoKhoaTK);
            this.tabAdvanced.Controls.Add(this.btnXoaTK);
            // 
            // FormStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormStaff";
            this.Text = "Quản Lý Nhân Viên";
            this.Load += new System.EventHandler(this.FormStaff_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).EndInit();
            this.panelForm.ResumeLayout(false);
            this.tableLayoutPanelForm.ResumeLayout(false);
            this.tableLayoutPanelForm.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.tabControlButtons.ResumeLayout(false);
            this.tabBasic.ResumeLayout(false);
            this.tabAdvanced.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvStaff;
        private System.Windows.Forms.Panel panelForm;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelForm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.TextBox txtTenNV;
        private System.Windows.Forms.ComboBox cboGioiTinh;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtChucVu;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TabControl tabControlButtons;
        private System.Windows.Forms.TabPage tabBasic;
        private System.Windows.Forms.TabPage tabAdvanced;
        private System.Windows.Forms.Button btnGanTaiKhoan;
        private System.Windows.Forms.Button btnResetPass;
        private System.Windows.Forms.Button btnKhoaTK;
        private System.Windows.Forms.Button btnMoKhoaTK;
        private System.Windows.Forms.Button btnXoaTK;
        private System.Windows.Forms.ComboBox cboFilterChucVu;
        private System.Windows.Forms.ComboBox cboFilterGioiTinh;
        private System.Windows.Forms.Label lblFilterChucVu;
        private System.Windows.Forms.Label lblFilterGioiTinh;
    }
}