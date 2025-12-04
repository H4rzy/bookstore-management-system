namespace QLNS.UI.Forms.BookDetails
{
    partial class FormBooks
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
            this.panelTreeViews = new System.Windows.Forms.Panel();
            this.groupBoxNXB = new System.Windows.Forms.GroupBox();
            this.treeNXB = new System.Windows.Forms.TreeView();
            this.groupBoxTheLoai = new System.Windows.Forms.GroupBox();
            this.treeTheLoai = new System.Windows.Forms.TreeView();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dgvSach = new System.Windows.Forms.DataGridView();
            this.panelForm = new System.Windows.Forms.Panel();
            this.tableLayoutPanelForm = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMaSach = new System.Windows.Forms.TextBox();
            this.txtTenSach = new System.Windows.Forms.TextBox();
            this.txtTacGia = new System.Windows.Forms.TextBox();
            this.cboTheLoai = new System.Windows.Forms.ComboBox();
            this.cboNXB = new System.Windows.Forms.ComboBox();
            this.numDonGiaNhap = new System.Windows.Forms.NumericUpDown();
            this.numDonGiaBan = new System.Windows.Forms.NumericUpDown();
            this.numSoLuongTon = new System.Windows.Forms.NumericUpDown();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelTreeViews.SuspendLayout();
            this.groupBoxNXB.SuspendLayout();
            this.groupBoxTheLoai.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSach)).BeginInit();
            this.panelForm.SuspendLayout();
            this.tableLayoutPanelForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDonGiaNhap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDonGiaBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuongTon)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.tableLayoutPanel1.Controls.Add(this.panelTreeViews, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelTop, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvSach, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelForm, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panelButtons, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1280, 720);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelTreeViews
            // 
            this.panelTreeViews.Controls.Add(this.groupBoxNXB);
            this.panelTreeViews.Controls.Add(this.groupBoxTheLoai);
            this.panelTreeViews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTreeViews.Location = new System.Drawing.Point(1053, 13);
            this.panelTreeViews.Name = "panelTreeViews";
            this.panelTreeViews.Padding = new System.Windows.Forms.Padding(8);
            this.tableLayoutPanel1.SetRowSpan(this.panelTreeViews, 4);
            this.panelTreeViews.Size = new System.Drawing.Size(214, 694);
            this.panelTreeViews.TabIndex = 1;
            // 
            // groupBoxNXB
            // 
            this.groupBoxNXB.Controls.Add(this.treeNXB);
            this.groupBoxNXB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxNXB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxNXB.Location = new System.Drawing.Point(8, 302);
            this.groupBoxNXB.Name = "groupBoxNXB";
            this.groupBoxNXB.Padding = new System.Windows.Forms.Padding(8);
            this.groupBoxNXB.Size = new System.Drawing.Size(198, 384);
            this.groupBoxNXB.TabIndex = 1;
            this.groupBoxNXB.TabStop = false;
            this.groupBoxNXB.Text = "🏢 Nhà Xuất Bản";
            // 
            // treeNXB
            // 
            this.treeNXB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeNXB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeNXB.HideSelection = false;
            this.treeNXB.Location = new System.Drawing.Point(8, 25);
            this.treeNXB.Name = "treeNXB";
            this.treeNXB.Size = new System.Drawing.Size(182, 351);
            this.treeNXB.TabIndex = 0;
            this.treeNXB.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeNXB_AfterSelect);
            // 
            // groupBoxTheLoai
            // 
            this.groupBoxTheLoai.Controls.Add(this.treeTheLoai);
            this.groupBoxTheLoai.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxTheLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxTheLoai.Location = new System.Drawing.Point(8, 8);
            this.groupBoxTheLoai.Name = "groupBoxTheLoai";
            this.groupBoxTheLoai.Padding = new System.Windows.Forms.Padding(8);
            this.groupBoxTheLoai.Size = new System.Drawing.Size(198, 294);
            this.groupBoxTheLoai.TabIndex = 0;
            this.groupBoxTheLoai.TabStop = false;
            this.groupBoxTheLoai.Text = "📚 Thể Loại";
            // 
            // treeTheLoai
            // 
            this.treeTheLoai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeTheLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeTheLoai.HideSelection = false;
            this.treeTheLoai.Location = new System.Drawing.Point(8, 25);
            this.treeTheLoai.Name = "treeTheLoai";
            this.treeTheLoai.Size = new System.Drawing.Size(182, 261);
            this.treeTheLoai.TabIndex = 0;
            this.treeTheLoai.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeTheLoai_AfterSelect);
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.panelSearch);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop.Location = new System.Drawing.Point(13, 13);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1034, 64);
            this.panelTop.TabIndex = 0;
            // 
            // panelSearch
            // 
            this.panelSearch.Controls.Add(this.btnTimKiem);
            this.panelSearch.Controls.Add(this.txtTimKiem);
            this.panelSearch.Controls.Add(this.label10);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Location = new System.Drawing.Point(0, 0);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(1034, 60);
            this.panelSearch.TabIndex = 0;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(161)))), ((int)(((byte)(251)))));
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(910, 13);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(110, 35);
            this.btnTimKiem.TabIndex = 2;
            this.btnTimKiem.Text = "🔍 Tìm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Location = new System.Drawing.Point(120, 17);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(780, 26);
            this.txtTimKiem.TabIndex = 1;
            this.txtTimKiem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTimKiem_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(10, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 20);
            this.label10.TabIndex = 0;
            this.label10.Text = "Tìm Kiếm:";
            // 
            // dgvSach
            // 
            this.dgvSach.AllowUserToAddRows = false;
            this.dgvSach.AllowUserToDeleteRows = false;
            this.dgvSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSach.BackgroundColor = System.Drawing.Color.White;
            this.dgvSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSach.Location = new System.Drawing.Point(13, 83);
            this.dgvSach.MultiSelect = false;
            this.dgvSach.Name = "dgvSach";
            this.dgvSach.ReadOnly = true;
            this.dgvSach.RowHeadersWidth = 51;
            this.dgvSach.RowTemplate.Height = 24;
            this.dgvSach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSach.Size = new System.Drawing.Size(1034, 276);
            this.dgvSach.TabIndex = 1;
            this.dgvSach.SelectionChanged += new System.EventHandler(this.dgvSach_SelectionChanged);
            // 
            // panelForm
            // 
            this.panelForm.Controls.Add(this.tableLayoutPanelForm);
            this.panelForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelForm.Location = new System.Drawing.Point(13, 365);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(1034, 276);
            this.panelForm.TabIndex = 2;
            // 
            // tableLayoutPanelForm
            // 
            this.tableLayoutPanelForm.ColumnCount = 4;
            this.tableLayoutPanelForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanelForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanelForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelForm.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanelForm.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanelForm.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanelForm.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanelForm.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanelForm.Controls.Add(this.label6, 2, 1);
            this.tableLayoutPanelForm.Controls.Add(this.label7, 2, 2);
            this.tableLayoutPanelForm.Controls.Add(this.label8, 2, 3);
            this.tableLayoutPanelForm.Controls.Add(this.txtMaSach, 1, 0);
            this.tableLayoutPanelForm.Controls.Add(this.txtTenSach, 1, 1);
            this.tableLayoutPanelForm.Controls.Add(this.txtTacGia, 1, 2);
            this.tableLayoutPanelForm.Controls.Add(this.cboTheLoai, 1, 3);
            this.tableLayoutPanelForm.Controls.Add(this.cboNXB, 3, 0);
            this.tableLayoutPanelForm.Controls.Add(this.numDonGiaNhap, 3, 1);
            this.tableLayoutPanelForm.Controls.Add(this.numDonGiaBan, 3, 2);
            this.tableLayoutPanelForm.Controls.Add(this.numSoLuongTon, 3, 3);
            this.tableLayoutPanelForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelForm.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelForm.Name = "tableLayoutPanelForm";
            this.tableLayoutPanelForm.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanelForm.RowCount = 4;
            this.tableLayoutPanelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelForm.Size = new System.Drawing.Size(1034, 276);
            this.tableLayoutPanelForm.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(13, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Sách:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(13, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên Sách:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(13, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tác Giả:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(13, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Thể Loại:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(515, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "NXB:";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(515, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Đơn Giá Nhập:";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label7.Location = new System.Drawing.Point(515, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Đơn Giá Bán:";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label8.Location = new System.Drawing.Point(515, 224);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 20);
            this.label8.TabIndex = 7;
            this.label8.Text = "Số Lượng Tồn:";
            // 
            // txtMaSach
            // 
            this.txtMaSach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtMaSach.Location = new System.Drawing.Point(133, 29);
            this.txtMaSach.Name = "txtMaSach";
            this.txtMaSach.Size = new System.Drawing.Size(376, 26);
            this.txtMaSach.TabIndex = 8;
            // 
            // txtTenSach
            // 
            this.txtTenSach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtTenSach.Location = new System.Drawing.Point(133, 93);
            this.txtTenSach.Name = "txtTenSach";
            this.txtTenSach.Size = new System.Drawing.Size(376, 26);
            this.txtTenSach.TabIndex = 9;
            // 
            // txtTacGia
            // 
            this.txtTacGia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTacGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtTacGia.Location = new System.Drawing.Point(133, 157);
            this.txtTacGia.Name = "txtTacGia";
            this.txtTacGia.Size = new System.Drawing.Size(376, 26);
            this.txtTacGia.TabIndex = 10;
            // 
            // cboTheLoai
            // 
            this.cboTheLoai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTheLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTheLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cboTheLoai.FormattingEnabled = true;
            this.cboTheLoai.Location = new System.Drawing.Point(133, 220);
            this.cboTheLoai.Name = "cboTheLoai";
            this.cboTheLoai.Size = new System.Drawing.Size(376, 28);
            this.cboTheLoai.TabIndex = 11;
            // 
            // cboNXB
            // 
            this.cboNXB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboNXB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNXB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cboNXB.FormattingEnabled = true;
            this.cboNXB.Location = new System.Drawing.Point(645, 28);
            this.cboNXB.Name = "cboNXB";
            this.cboNXB.Size = new System.Drawing.Size(376, 28);
            this.cboNXB.TabIndex = 12;
            // 
            // numDonGiaNhap
            // 
            this.numDonGiaNhap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numDonGiaNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.numDonGiaNhap.Location = new System.Drawing.Point(645, 93);
            this.numDonGiaNhap.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numDonGiaNhap.Name = "numDonGiaNhap";
            this.numDonGiaNhap.Size = new System.Drawing.Size(376, 26);
            this.numDonGiaNhap.TabIndex = 13;
            this.numDonGiaNhap.ThousandsSeparator = true;
            // 
            // numDonGiaBan
            // 
            this.numDonGiaBan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numDonGiaBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.numDonGiaBan.Location = new System.Drawing.Point(645, 157);
            this.numDonGiaBan.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numDonGiaBan.Name = "numDonGiaBan";
            this.numDonGiaBan.Size = new System.Drawing.Size(376, 26);
            this.numDonGiaBan.TabIndex = 14;
            this.numDonGiaBan.ThousandsSeparator = true;
            // 
            // numSoLuongTon
            // 
            this.numSoLuongTon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numSoLuongTon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.numSoLuongTon.Location = new System.Drawing.Point(645, 221);
            this.numSoLuongTon.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numSoLuongTon.Name = "numSoLuongTon";
            this.numSoLuongTon.Size = new System.Drawing.Size(376, 26);
            this.numSoLuongTon.TabIndex = 15;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnLuu);
            this.panelButtons.Controls.Add(this.btnXoa);
            this.panelButtons.Controls.Add(this.btnHuy);
            this.panelButtons.Controls.Add(this.btnThem);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButtons.Location = new System.Drawing.Point(13, 647);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(1034, 60);
            this.panelButtons.TabIndex = 3;
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(77)))), ((int)(((byte)(221)))));
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(627, 9);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(30, 3, 30, 3);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.btnLuu.Size = new System.Drawing.Size(120, 35);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "💾 Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(88)))), ((int)(((byte)(155)))));
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(501, 9);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(30, 3, 30, 3);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.btnXoa.Size = new System.Drawing.Size(120, 35);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "🗑️ Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnHuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(138)))), ((int)(((byte)(114)))));
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(375, 9);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(30, 3, 30, 3);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.btnHuy.Size = new System.Drawing.Size(120, 35);
            this.btnHuy.TabIndex = 1;
            this.btnHuy.Text = "❌ Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(161)))), ((int)(((byte)(251)))));
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(249, 9);
            this.btnThem.Margin = new System.Windows.Forms.Padding(30, 3, 30, 3);
            this.btnThem.Name = "btnThem";
            this.btnThem.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.btnThem.Size = new System.Drawing.Size(120, 35);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "➕ Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // FormBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormBooks";
            this.Text = "Quản Lý Sách";
            this.Load += new System.EventHandler(this.FormBooks_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelTreeViews.ResumeLayout(false);
            this.groupBoxNXB.ResumeLayout(false);
            this.groupBoxTheLoai.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSach)).EndInit();
            this.panelForm.ResumeLayout(false);
            this.tableLayoutPanelForm.ResumeLayout(false);
            this.tableLayoutPanelForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDonGiaNhap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDonGiaBan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuongTon)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panelTreeViews;
        private System.Windows.Forms.GroupBox groupBoxTheLoai;
        private System.Windows.Forms.TreeView treeTheLoai;
        private System.Windows.Forms.GroupBox groupBoxNXB;
        private System.Windows.Forms.TreeView treeNXB;
        private System.Windows.Forms.DataGridView dgvSach;
        private System.Windows.Forms.Panel panelForm;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelForm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMaSach;
        private System.Windows.Forms.TextBox txtTenSach;
        private System.Windows.Forms.TextBox txtTacGia;
        private System.Windows.Forms.ComboBox cboTheLoai;
        private System.Windows.Forms.ComboBox cboNXB;
        private System.Windows.Forms.NumericUpDown numDonGiaNhap;
        private System.Windows.Forms.NumericUpDown numDonGiaBan;
        private System.Windows.Forms.NumericUpDown numSoLuongTon;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnThem;
    }
}