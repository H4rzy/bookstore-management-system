namespace QLNS.Forms
{
    partial class FormDashboard
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
            this.tableLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.tableLayoutStats = new System.Windows.Forms.TableLayoutPanel();
            this.panelBooksStat = new System.Windows.Forms.Panel();
            this.lblTotalBooks = new System.Windows.Forms.Label();
            this.lblBooksLabel = new System.Windows.Forms.Label();
            this.panelImportsStat = new System.Windows.Forms.Panel();
            this.lblTotalImports = new System.Windows.Forms.Label();
            this.lblImportsLabel = new System.Windows.Forms.Label();
            this.panelReceiptsStat = new System.Windows.Forms.Panel();
            this.lblTotalReceipts = new System.Windows.Forms.Label();
            this.lblReceiptsLabel = new System.Windows.Forms.Label();
            this.panelEmployeesStat = new System.Windows.Forms.Panel();
            this.lblTotalEmployees = new System.Windows.Forms.Label();
            this.lblEmployeesLabel = new System.Windows.Forms.Label();
            this.panelCustomersStat = new System.Windows.Forms.Panel();
            this.lblTotalCustomers = new System.Windows.Forms.Label();
            this.lblCustomersLabel = new System.Windows.Forms.Label();
            this.panelValueStat = new System.Windows.Forms.Panel();
            this.lblTotalValue = new System.Windows.Forms.Label();
            this.lblValueLabel = new System.Windows.Forms.Label();
            this.tableLayoutActivities = new System.Windows.Forms.TableLayoutPanel();
            this.panelRecentImports = new System.Windows.Forms.Panel();
            this.lblRecentImports = new System.Windows.Forms.Label();
            this.dgvRecentImports = new System.Windows.Forms.DataGridView();
            this.panelRecentReceipts = new System.Windows.Forms.Panel();
            this.lblRecentReceipts = new System.Windows.Forms.Label();
            this.dgvRecentReceipts = new System.Windows.Forms.DataGridView();
            this.panelRecentBooks = new System.Windows.Forms.Panel();
            this.lblRecentBooks = new System.Windows.Forms.Label();
            this.dgvRecentBooks = new System.Windows.Forms.DataGridView();
            this.tableLayoutMain.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.tableLayoutStats.SuspendLayout();
            this.panelBooksStat.SuspendLayout();
            this.panelImportsStat.SuspendLayout();
            this.panelReceiptsStat.SuspendLayout();
            this.panelEmployeesStat.SuspendLayout();
            this.panelCustomersStat.SuspendLayout();
            this.panelValueStat.SuspendLayout();
            this.tableLayoutActivities.SuspendLayout();
            this.panelRecentImports.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentImports)).BeginInit();
            this.panelRecentReceipts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentReceipts)).BeginInit();
            this.panelRecentBooks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentBooks)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutMain
            // 
            this.tableLayoutMain.ColumnCount = 1;
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutMain.Controls.Add(this.panelHeader, 0, 0);
            this.tableLayoutMain.Controls.Add(this.tableLayoutStats, 0, 1);
            this.tableLayoutMain.Controls.Add(this.tableLayoutActivities, 0, 2);
            this.tableLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutMain.Name = "tableLayoutMain";
            this.tableLayoutMain.RowCount = 3;
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutMain.Size = new System.Drawing.Size(1400, 800);
            this.tableLayoutMain.TabIndex = 0;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.panelHeader.Controls.Add(this.btnRefresh);
            this.panelHeader.Controls.Add(this.lblHeader);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1400, 70);
            this.panelHeader.TabIndex = 0;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(20, 15);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(209, 45);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "DASHBOARD";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(1260, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(120, 40);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "🔄 Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // tableLayoutStats
            // 
            this.tableLayoutStats.ColumnCount = 6;
            this.tableLayoutStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66F));
            this.tableLayoutStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.67F));
            this.tableLayoutStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.67F));
            this.tableLayoutStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.67F));
            this.tableLayoutStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.67F));
            this.tableLayoutStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66F));
            this.tableLayoutStats.Controls.Add(this.panelBooksStat, 0, 0);
            this.tableLayoutStats.Controls.Add(this.panelImportsStat, 1, 0);
            this.tableLayoutStats.Controls.Add(this.panelReceiptsStat, 2, 0);
            this.tableLayoutStats.Controls.Add(this.panelEmployeesStat, 3, 0);
            this.tableLayoutStats.Controls.Add(this.panelCustomersStat, 4, 0);
            this.tableLayoutStats.Controls.Add(this.panelValueStat, 5, 0);
            this.tableLayoutStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutStats.Location = new System.Drawing.Point(3, 73);
            this.tableLayoutStats.Name = "tableLayoutStats";
            this.tableLayoutStats.RowCount = 1;
            this.tableLayoutStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutStats.Size = new System.Drawing.Size(1394, 134);
            this.tableLayoutStats.TabIndex = 1;
            // 
            // panelBooksStat
            // 
            this.panelBooksStat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.panelBooksStat.Controls.Add(this.lblTotalBooks);
            this.panelBooksStat.Controls.Add(this.lblBooksLabel);
            this.panelBooksStat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBooksStat.Location = new System.Drawing.Point(5, 5);
            this.panelBooksStat.Margin = new System.Windows.Forms.Padding(5);
            this.panelBooksStat.Name = "panelBooksStat";
            this.panelBooksStat.Size = new System.Drawing.Size(222, 124);
            this.panelBooksStat.TabIndex = 0;
            // 
            // lblTotalBooks
            // 
            this.lblTotalBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalBooks.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            this.lblTotalBooks.ForeColor = System.Drawing.Color.White;
            this.lblTotalBooks.Location = new System.Drawing.Point(0, 30);
            this.lblTotalBooks.Name = "lblTotalBooks";
            this.lblTotalBooks.Size = new System.Drawing.Size(222, 94);
            this.lblTotalBooks.TabIndex = 1;
            this.lblTotalBooks.Text = "0";
            this.lblTotalBooks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBooksLabel
            // 
            this.lblBooksLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBooksLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblBooksLabel.ForeColor = System.Drawing.Color.White;
            this.lblBooksLabel.Location = new System.Drawing.Point(0, 0);
            this.lblBooksLabel.Name = "lblBooksLabel";
            this.lblBooksLabel.Size = new System.Drawing.Size(222, 30);
            this.lblBooksLabel.TabIndex = 0;
            this.lblBooksLabel.Text = "📚 TỔNG SÁCH";
            this.lblBooksLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelImportsStat
            // 
            this.panelImportsStat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.panelImportsStat.Controls.Add(this.lblTotalImports);
            this.panelImportsStat.Controls.Add(this.lblImportsLabel);
            this.panelImportsStat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelImportsStat.Location = new System.Drawing.Point(237, 5);
            this.panelImportsStat.Margin = new System.Windows.Forms.Padding(5);
            this.panelImportsStat.Name = "panelImportsStat";
            this.panelImportsStat.Size = new System.Drawing.Size(222, 124);
            this.panelImportsStat.TabIndex = 1;
            // 
            // lblTotalImports
            // 
            this.lblTotalImports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalImports.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            this.lblTotalImports.ForeColor = System.Drawing.Color.White;
            this.lblTotalImports.Location = new System.Drawing.Point(0, 30);
            this.lblTotalImports.Name = "lblTotalImports";
            this.lblTotalImports.Size = new System.Drawing.Size(222, 94);
            this.lblTotalImports.TabIndex = 1;
            this.lblTotalImports.Text = "0";
            this.lblTotalImports.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblImportsLabel
            // 
            this.lblImportsLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblImportsLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblImportsLabel.ForeColor = System.Drawing.Color.White;
            this.lblImportsLabel.Location = new System.Drawing.Point(0, 0);
            this.lblImportsLabel.Name = "lblImportsLabel";
            this.lblImportsLabel.Size = new System.Drawing.Size(222, 30);
            this.lblImportsLabel.TabIndex = 0;
            this.lblImportsLabel.Text = "📦 PHIẾU NHẬP";
            this.lblImportsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelReceiptsStat
            // 
            this.panelReceiptsStat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.panelReceiptsStat.Controls.Add(this.lblTotalReceipts);
            this.panelReceiptsStat.Controls.Add(this.lblReceiptsLabel);
            this.panelReceiptsStat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelReceiptsStat.Location = new System.Drawing.Point(469, 5);
            this.panelReceiptsStat.Margin = new System.Windows.Forms.Padding(5);
            this.panelReceiptsStat.Name = "panelReceiptsStat";
            this.panelReceiptsStat.Size = new System.Drawing.Size(222, 124);
            this.panelReceiptsStat.TabIndex = 2;
            // 
            // lblTotalReceipts
            // 
            this.lblTotalReceipts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalReceipts.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            this.lblTotalReceipts.ForeColor = System.Drawing.Color.White;
            this.lblTotalReceipts.Location = new System.Drawing.Point(0, 30);
            this.lblTotalReceipts.Name = "lblTotalReceipts";
            this.lblTotalReceipts.Size = new System.Drawing.Size(222, 94);
            this.lblTotalReceipts.TabIndex = 1;
            this.lblTotalReceipts.Text = "0";
            this.lblTotalReceipts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblReceiptsLabel
            // 
            this.lblReceiptsLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblReceiptsLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblReceiptsLabel.ForeColor = System.Drawing.Color.White;
            this.lblReceiptsLabel.Location = new System.Drawing.Point(0, 0);
            this.lblReceiptsLabel.Name = "lblReceiptsLabel";
            this.lblReceiptsLabel.Size = new System.Drawing.Size(222, 30);
            this.lblReceiptsLabel.TabIndex = 0;
            this.lblReceiptsLabel.Text = "🧾 HÓA ĐƠN";
            this.lblReceiptsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelEmployeesStat
            // 
            this.panelEmployeesStat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.panelEmployeesStat.Controls.Add(this.lblTotalEmployees);
            this.panelEmployeesStat.Controls.Add(this.lblEmployeesLabel);
            this.panelEmployeesStat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEmployeesStat.Location = new System.Drawing.Point(701, 5);
            this.panelEmployeesStat.Margin = new System.Windows.Forms.Padding(5);
            this.panelEmployeesStat.Name = "panelEmployeesStat";
            this.panelEmployeesStat.Size = new System.Drawing.Size(222, 124);
            this.panelEmployeesStat.TabIndex = 3;
            // 
            // lblTotalEmployees
            // 
            this.lblTotalEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalEmployees.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            this.lblTotalEmployees.ForeColor = System.Drawing.Color.White;
            this.lblTotalEmployees.Location = new System.Drawing.Point(0, 30);
            this.lblTotalEmployees.Name = "lblTotalEmployees";
            this.lblTotalEmployees.Size = new System.Drawing.Size(222, 94);
            this.lblTotalEmployees.TabIndex = 1;
            this.lblTotalEmployees.Text = "0";
            this.lblTotalEmployees.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEmployeesLabel
            // 
            this.lblEmployeesLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEmployeesLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblEmployeesLabel.ForeColor = System.Drawing.Color.White;
            this.lblEmployeesLabel.Location = new System.Drawing.Point(0, 0);
            this.lblEmployeesLabel.Name = "lblEmployeesLabel";
            this.lblEmployeesLabel.Size = new System.Drawing.Size(222, 30);
            this.lblEmployeesLabel.TabIndex = 0;
            this.lblEmployeesLabel.Text = "👥 NHÂN VIÊN";
            this.lblEmployeesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelCustomersStat
            // 
            this.panelCustomersStat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.panelCustomersStat.Controls.Add(this.lblTotalCustomers);
            this.panelCustomersStat.Controls.Add(this.lblCustomersLabel);
            this.panelCustomersStat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCustomersStat.Location = new System.Drawing.Point(933, 5);
            this.panelCustomersStat.Margin = new System.Windows.Forms.Padding(5);
            this.panelCustomersStat.Name = "panelCustomersStat";
            this.panelCustomersStat.Size = new System.Drawing.Size(222, 124);
            this.panelCustomersStat.TabIndex = 4;
            // 
            // lblTotalCustomers
            // 
            this.lblTotalCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalCustomers.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            this.lblTotalCustomers.ForeColor = System.Drawing.Color.White;
            this.lblTotalCustomers.Location = new System.Drawing.Point(0, 30);
            this.lblTotalCustomers.Name = "lblTotalCustomers";
            this.lblTotalCustomers.Size = new System.Drawing.Size(222, 94);
            this.lblTotalCustomers.TabIndex = 1;
            this.lblTotalCustomers.Text = "0";
            this.lblTotalCustomers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCustomersLabel
            // 
            this.lblCustomersLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCustomersLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblCustomersLabel.ForeColor = System.Drawing.Color.White;
            this.lblCustomersLabel.Location = new System.Drawing.Point(0, 0);
            this.lblCustomersLabel.Name = "lblCustomersLabel";
            this.lblCustomersLabel.Size = new System.Drawing.Size(222, 30);
            this.lblCustomersLabel.TabIndex = 0;
            this.lblCustomersLabel.Text = "👤 KHÁCH HÀNG";
            this.lblCustomersLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelValueStat
            // 
            this.panelValueStat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.panelValueStat.Controls.Add(this.lblTotalValue);
            this.panelValueStat.Controls.Add(this.lblValueLabel);
            this.panelValueStat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelValueStat.Location = new System.Drawing.Point(1165, 5);
            this.panelValueStat.Margin = new System.Windows.Forms.Padding(5);
            this.panelValueStat.Name = "panelValueStat";
            this.panelValueStat.Size = new System.Drawing.Size(224, 124);
            this.panelValueStat.TabIndex = 5;
            // 
            // lblTotalValue
            // 
            this.lblTotalValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalValue.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTotalValue.ForeColor = System.Drawing.Color.White;
            this.lblTotalValue.Location = new System.Drawing.Point(0, 30);
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.Size = new System.Drawing.Size(224, 94);
            this.lblTotalValue.TabIndex = 1;
            this.lblTotalValue.Text = "0 VNĐ";
            this.lblTotalValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblValueLabel
            // 
            this.lblValueLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblValueLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblValueLabel.ForeColor = System.Drawing.Color.White;
            this.lblValueLabel.Location = new System.Drawing.Point(0, 0);
            this.lblValueLabel.Name = "lblValueLabel";
            this.lblValueLabel.Size = new System.Drawing.Size(224, 30);
            this.lblValueLabel.TabIndex = 0;
            this.lblValueLabel.Text = "💰 GIÁ TRỊ KHO";
            this.lblValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutActivities
            // 
            this.tableLayoutActivities.ColumnCount = 3;
            this.tableLayoutActivities.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutActivities.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutActivities.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tableLayoutActivities.Controls.Add(this.panelRecentImports, 0, 0);
            this.tableLayoutActivities.Controls.Add(this.panelRecentReceipts, 1, 0);
            this.tableLayoutActivities.Controls.Add(this.panelRecentBooks, 2, 0);
            this.tableLayoutActivities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutActivities.Location = new System.Drawing.Point(3, 213);
            this.tableLayoutActivities.Name = "tableLayoutActivities";
            this.tableLayoutActivities.RowCount = 1;
            this.tableLayoutActivities.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutActivities.Size = new System.Drawing.Size(1394, 584);
            this.tableLayoutActivities.TabIndex = 2;
            // 
            // panelRecentImports
            // 
            this.panelRecentImports.Controls.Add(this.dgvRecentImports);
            this.panelRecentImports.Controls.Add(this.lblRecentImports);
            this.panelRecentImports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRecentImports.Location = new System.Drawing.Point(5, 5);
            this.panelRecentImports.Margin = new System.Windows.Forms.Padding(5);
            this.panelRecentImports.Name = "panelRecentImports";
            this.panelRecentImports.Size = new System.Drawing.Size(454, 574);
            this.panelRecentImports.TabIndex = 0;
            // 
            // lblRecentImports
            // 
            this.lblRecentImports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblRecentImports.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRecentImports.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblRecentImports.ForeColor = System.Drawing.Color.White;
            this.lblRecentImports.Location = new System.Drawing.Point(0, 0);
            this.lblRecentImports.Name = "lblRecentImports";
            this.lblRecentImports.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblRecentImports.Size = new System.Drawing.Size(454, 40);
            this.lblRecentImports.TabIndex = 0;
            this.lblRecentImports.Text = "📦 Phiếu Nhập Gần Đây";
            this.lblRecentImports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvRecentImports
            // 
            this.dgvRecentImports.AllowUserToAddRows = false;
            this.dgvRecentImports.AllowUserToDeleteRows = false;
            this.dgvRecentImports.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecentImports.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecentImports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecentImports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRecentImports.Location = new System.Drawing.Point(0, 40);
            this.dgvRecentImports.Name = "dgvRecentImports";
            this.dgvRecentImports.ReadOnly = true;
            this.dgvRecentImports.RowHeadersWidth = 51;
            this.dgvRecentImports.Size = new System.Drawing.Size(454, 534);
            this.dgvRecentImports.TabIndex = 1;
            // 
            // panelRecentReceipts
            // 
            this.panelRecentReceipts.Controls.Add(this.dgvRecentReceipts);
            this.panelRecentReceipts.Controls.Add(this.lblRecentReceipts);
            this.panelRecentReceipts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRecentReceipts.Location = new System.Drawing.Point(469, 5);
            this.panelRecentReceipts.Margin = new System.Windows.Forms.Padding(5);
            this.panelRecentReceipts.Name = "panelRecentReceipts";
            this.panelRecentReceipts.Size = new System.Drawing.Size(454, 574);
            this.panelRecentReceipts.TabIndex = 1;
            // 
            // lblRecentReceipts
            // 
            this.lblRecentReceipts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblRecentReceipts.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRecentReceipts.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblRecentReceipts.ForeColor = System.Drawing.Color.White;
            this.lblRecentReceipts.Location = new System.Drawing.Point(0, 0);
            this.lblRecentReceipts.Name = "lblRecentReceipts";
            this.lblRecentReceipts.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblRecentReceipts.Size = new System.Drawing.Size(454, 40);
            this.lblRecentReceipts.TabIndex = 0;
            this.lblRecentReceipts.Text = "🧾 Hóa Đơn Gần Đây";
            this.lblRecentReceipts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvRecentReceipts
            // 
            this.dgvRecentReceipts.AllowUserToAddRows = false;
            this.dgvRecentReceipts.AllowUserToDeleteRows = false;
            this.dgvRecentReceipts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecentReceipts.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecentReceipts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecentReceipts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRecentReceipts.Location = new System.Drawing.Point(0, 40);
            this.dgvRecentReceipts.Name = "dgvRecentReceipts";
            this.dgvRecentReceipts.ReadOnly = true;
            this.dgvRecentReceipts.RowHeadersWidth = 51;
            this.dgvRecentReceipts.Size = new System.Drawing.Size(454, 534);
            this.dgvRecentReceipts.TabIndex = 1;
            // 
            // panelRecentBooks
            // 
            this.panelRecentBooks.Controls.Add(this.dgvRecentBooks);
            this.panelRecentBooks.Controls.Add(this.lblRecentBooks);
            this.panelRecentBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRecentBooks.Location = new System.Drawing.Point(933, 5);
            this.panelRecentBooks.Margin = new System.Windows.Forms.Padding(5);
            this.panelRecentBooks.Name = "panelRecentBooks";
            this.panelRecentBooks.Size = new System.Drawing.Size(456, 574);
            this.panelRecentBooks.TabIndex = 2;
            // 
            // lblRecentBooks
            // 
            this.lblRecentBooks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblRecentBooks.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRecentBooks.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblRecentBooks.ForeColor = System.Drawing.Color.White;
            this.lblRecentBooks.Location = new System.Drawing.Point(0, 0);
            this.lblRecentBooks.Name = "lblRecentBooks";
            this.lblRecentBooks.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblRecentBooks.Size = new System.Drawing.Size(456, 40);
            this.lblRecentBooks.TabIndex = 0;
            this.lblRecentBooks.Text = "📚 Sách Mới Thêm";
            this.lblRecentBooks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvRecentBooks
            // 
            this.dgvRecentBooks.AllowUserToAddRows = false;
            this.dgvRecentBooks.AllowUserToDeleteRows = false;
            this.dgvRecentBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecentBooks.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecentBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecentBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRecentBooks.Location = new System.Drawing.Point(0, 40);
            this.dgvRecentBooks.Name = "dgvRecentBooks";
            this.dgvRecentBooks.ReadOnly = true;
            this.dgvRecentBooks.RowHeadersWidth = 51;
            this.dgvRecentBooks.Size = new System.Drawing.Size(456, 534);
            this.dgvRecentBooks.TabIndex = 1;
            // 
            // FormDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1400, 800);
            this.Controls.Add(this.tableLayoutMain);
            this.Name = "FormDashboard";
            this.Text = "Dashboard - Tổng quan hệ thống";
            this.Load += new System.EventHandler(this.FormDashboard_Load);
            this.tableLayoutMain.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.tableLayoutStats.ResumeLayout(false);
            this.panelBooksStat.ResumeLayout(false);
            this.panelImportsStat.ResumeLayout(false);
            this.panelReceiptsStat.ResumeLayout(false);
            this.panelEmployeesStat.ResumeLayout(false);
            this.panelCustomersStat.ResumeLayout(false);
            this.panelValueStat.ResumeLayout(false);
            this.tableLayoutActivities.ResumeLayout(false);
            this.panelRecentImports.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentImports)).EndInit();
            this.panelRecentReceipts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentReceipts)).EndInit();
            this.panelRecentBooks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentBooks)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutMain;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TableLayoutPanel tableLayoutStats;
        private System.Windows.Forms.Panel panelBooksStat;
        private System.Windows.Forms.Label lblTotalBooks;
        private System.Windows.Forms.Label lblBooksLabel;
        private System.Windows.Forms.Panel panelImportsStat;
        private System.Windows.Forms.Label lblTotalImports;
        private System.Windows.Forms.Label lblImportsLabel;
        private System.Windows.Forms.Panel panelReceiptsStat;
        private System.Windows.Forms.Label lblTotalReceipts;
        private System.Windows.Forms.Label lblReceiptsLabel;
        private System.Windows.Forms.Panel panelEmployeesStat;
        private System.Windows.Forms.Label lblTotalEmployees;
        private System.Windows.Forms.Label lblEmployeesLabel;
        private System.Windows.Forms.Panel panelCustomersStat;
        private System.Windows.Forms.Label lblTotalCustomers;
        private System.Windows.Forms.Label lblCustomersLabel;
        private System.Windows.Forms.Panel panelValueStat;
        private System.Windows.Forms.Label lblTotalValue;
        private System.Windows.Forms.Label lblValueLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutActivities;
        private System.Windows.Forms.Panel panelRecentImports;
        private System.Windows.Forms.DataGridView dgvRecentImports;
        private System.Windows.Forms.Label lblRecentImports;
        private System.Windows.Forms.Panel panelRecentReceipts;
        private System.Windows.Forms.DataGridView dgvRecentReceipts;
        private System.Windows.Forms.Label lblRecentReceipts;
        private System.Windows.Forms.Panel panelRecentBooks;
        private System.Windows.Forms.DataGridView dgvRecentBooks;
        private System.Windows.Forms.Label lblRecentBooks;
    }
}