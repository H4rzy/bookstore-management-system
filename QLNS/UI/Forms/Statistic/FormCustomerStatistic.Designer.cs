namespace QLNS.Forms.Statistic
{
    partial class FormCustomerStatistic
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

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabTopCustomers;
        private System.Windows.Forms.TabPage tabVIPStats;
        private System.Windows.Forms.TabPage tabPurchaseHistory;
        
        // Tab 1 controls
        private System.Windows.Forms.Panel panelTopFilters;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label lblTopN;
        private System.Windows.Forms.NumericUpDown nudTopN;
        private System.Windows.Forms.Button btnRefreshTop;
        private System.Windows.Forms.DataGridView dgvTopCustomers;
        
        // Tab 2 controls
        private System.Windows.Forms.SplitContainer splitVIP;
        private System.Windows.Forms.DataGridView dgvVIPStats;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVIP;
        
        // Tab 3 controls
        private System.Windows.Forms.Panel panelHistoryFilters;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.Label lblHistoryStart;
        private System.Windows.Forms.DateTimePicker dtpHistoryStart;
        private System.Windows.Forms.Label lblHistoryEnd;
        private System.Windows.Forms.DateTimePicker dtpHistoryEnd;
        private System.Windows.Forms.Button btnSearchHistory;
        private System.Windows.Forms.DataGridView dgvPurchaseHistory;

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();

            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabTopCustomers = new System.Windows.Forms.TabPage();
            this.dgvTopCustomers = new System.Windows.Forms.DataGridView();
            this.panelTopFilters = new System.Windows.Forms.Panel();
            this.btnRefreshTop = new System.Windows.Forms.Button();
            this.nudTopN = new System.Windows.Forms.NumericUpDown();
            this.lblTopN = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.tabVIPStats = new System.Windows.Forms.TabPage();
            this.splitVIP = new System.Windows.Forms.SplitContainer();
            this.dgvVIPStats = new System.Windows.Forms.DataGridView();
            this.chartVIP = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPurchaseHistory = new System.Windows.Forms.TabPage();
            this.dgvPurchaseHistory = new System.Windows.Forms.DataGridView();
            this.panelHistoryFilters = new System.Windows.Forms.Panel();
            this.btnSearchHistory = new System.Windows.Forms.Button();
            this.dtpHistoryEnd = new System.Windows.Forms.DateTimePicker();
            this.lblHistoryEnd = new System.Windows.Forms.Label();
            this.dtpHistoryStart = new System.Windows.Forms.DateTimePicker();
            this.lblHistoryStart = new System.Windows.Forms.Label();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.lblCustomer = new System.Windows.Forms.Label();

            this.panelTop.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabTopCustomers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopCustomers)).BeginInit();
            this.panelTopFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTopN)).BeginInit();
            this.tabVIPStats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitVIP)).BeginInit();
            this.splitVIP.Panel1.SuspendLayout();
            this.splitVIP.Panel2.SuspendLayout();
            this.splitVIP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVIPStats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVIP)).BeginInit();
            this.tabPurchaseHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseHistory)).BeginInit();
            this.panelHistoryFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1200, 50);
            this.panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1200, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "👥 THỐNG KÊ KHÁCH HÀNG";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabTopCustomers);
            this.tabControl.Controls.Add(this.tabVIPStats);
            this.tabControl.Controls.Add(this.tabPurchaseHistory);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabControl.Location = new System.Drawing.Point(0, 50);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1200, 650);
            this.tabControl.TabIndex = 1;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabTopCustomers
            // 
            this.tabTopCustomers.Controls.Add(this.dgvTopCustomers);
            this.tabTopCustomers.Controls.Add(this.panelTopFilters);
            this.tabTopCustomers.Location = new System.Drawing.Point(4, 26);
            this.tabTopCustomers.Name = "tabTopCustomers";
            this.tabTopCustomers.Padding = new System.Windows.Forms.Padding(3);
            this.tabTopCustomers.Size = new System.Drawing.Size(1192, 620);
            this.tabTopCustomers.TabIndex = 0;
            this.tabTopCustomers.Text = "🏆 Top Khách Hàng";
            this.tabTopCustomers.UseVisualStyleBackColor = true;
            // 
            // dgvTopCustomers
            // 
            this.dgvTopCustomers.BackgroundColor = System.Drawing.Color.White;
            this.dgvTopCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTopCustomers.Location = new System.Drawing.Point(3, 63);
            this.dgvTopCustomers.Name = "dgvTopCustomers";
            this.dgvTopCustomers.Size = new System.Drawing.Size(1186, 554);
            this.dgvTopCustomers.TabIndex = 1;
            // 
            // panelTopFilters
            // 
            this.panelTopFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelTopFilters.Controls.Add(this.btnRefreshTop);
            this.panelTopFilters.Controls.Add(this.nudTopN);
            this.panelTopFilters.Controls.Add(this.lblTopN);
            this.panelTopFilters.Controls.Add(this.dtpEndDate);
            this.panelTopFilters.Controls.Add(this.lblEndDate);
            this.panelTopFilters.Controls.Add(this.dtpStartDate);
            this.panelTopFilters.Controls.Add(this.lblStartDate);
            this.panelTopFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopFilters.Location = new System.Drawing.Point(3, 3);
            this.panelTopFilters.Name = "panelTopFilters";
            this.panelTopFilters.Size = new System.Drawing.Size(1186, 60);
            this.panelTopFilters.TabIndex = 0;
            // 
            // btnRefreshTop
            // 
            this.btnRefreshTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnRefreshTop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshTop.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefreshTop.ForeColor = System.Drawing.Color.White;
            this.btnRefreshTop.Location = new System.Drawing.Point(800, 15);
            this.btnRefreshTop.Name = "btnRefreshTop";
            this.btnRefreshTop.Size = new System.Drawing.Size(120, 30);
            this.btnRefreshTop.TabIndex = 6;
            this.btnRefreshTop.Text = "🔄 Làm mới";
            this.btnRefreshTop.UseVisualStyleBackColor = false;
            this.btnRefreshTop.Click += new System.EventHandler(this.btnRefreshTop_Click);
            // 
            // nudTopN
            // 
            this.nudTopN.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudTopN.Location = new System.Drawing.Point(700, 20);
            this.nudTopN.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            this.nudTopN.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            this.nudTopN.Name = "nudTopN";
            this.nudTopN.Size = new System.Drawing.Size(70, 23);
            this.nudTopN.TabIndex = 5;
            this.nudTopN.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // lblTopN
            // 
            this.lblTopN.AutoSize = true;
            this.lblTopN.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTopN.Location = new System.Drawing.Point(630, 22);
            this.lblTopN.Name = "lblTopN";
            this.lblTopN.Size = new System.Drawing.Size(64, 15);
            this.lblTopN.TabIndex = 4;
            this.lblTopN.Text = "Hiển thị:";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(430, 20);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(150, 23);
            this.dtpEndDate.TabIndex = 3;
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEndDate.Location = new System.Drawing.Point(350, 22);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(64, 15);
            this.lblEndDate.TabIndex = 2;
            this.lblEndDate.Text = "Đến ngày:";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(160, 20);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(150, 23);
            this.dtpStartDate.TabIndex = 1;
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStartDate.Location = new System.Drawing.Point(90, 22);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(54, 15);
            this.lblStartDate.TabIndex = 0;
            this.lblStartDate.Text = "Từ ngày:";
            // 
            // tabVIPStats
            // 
            this.tabVIPStats.Controls.Add(this.splitVIP);
            this.tabVIPStats.Location = new System.Drawing.Point(4, 26);
            this.tabVIPStats.Name = "tabVIPStats";
            this.tabVIPStats.Padding = new System.Windows.Forms.Padding(3);
            this.tabVIPStats.Size = new System.Drawing.Size(1192, 620);
            this.tabVIPStats.TabIndex = 1;
            this.tabVIPStats.Text = "💎 Thống Kê VIP";
            this.tabVIPStats.UseVisualStyleBackColor = true;
            // 
            // splitVIP
            // 
            this.splitVIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitVIP.Location = new System.Drawing.Point(3, 3);
            this.splitVIP.Name = "splitVIP";
            // 
            // splitVIP.Panel1
            // 
            this.splitVIP.Panel1.Controls.Add(this.dgvVIPStats);
            // 
            // splitVIP.Panel2
            // 
            this.splitVIP.Panel2.Controls.Add(this.chartVIP);
            this.splitVIP.Size = new System.Drawing.Size(1186, 614);
            this.splitVIP.SplitterDistance = 650;
            this.splitVIP.TabIndex = 0;
            // 
            // dgvVIPStats
            // 
            this.dgvVIPStats.BackgroundColor = System.Drawing.Color.White;
            this.dgvVIPStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVIPStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVIPStats.Location = new System.Drawing.Point(0, 0);
            this.dgvVIPStats.Name = "dgvVIPStats";
            this.dgvVIPStats.Size = new System.Drawing.Size(650, 614);
            this.dgvVIPStats.TabIndex = 0;
            // 
            // chartVIP
            // 
            chartArea1.Name = "ChartArea1";
            this.chartVIP.ChartAreas.Add(chartArea1);
            this.chartVIP.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartVIP.Legends.Add(legend1);
            this.chartVIP.Location = new System.Drawing.Point(0, 0);
            this.chartVIP.Name = "chartVIP";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.Legend = "Legend1";
            series1.Name = "VIP Tiers";
            this.chartVIP.Series.Add(series1);
            this.chartVIP.Size = new System.Drawing.Size(532, 614);
            this.chartVIP.TabIndex = 0;
            this.chartVIP.Text = "chart1";
            // 
            // tabPurchaseHistory
            // 
            this.tabPurchaseHistory.Controls.Add(this.dgvPurchaseHistory);
            this.tabPurchaseHistory.Controls.Add(this.panelHistoryFilters);
            this.tabPurchaseHistory.Location = new System.Drawing.Point(4, 26);
            this.tabPurchaseHistory.Name = "tabPurchaseHistory";
            this.tabPurchaseHistory.Padding = new System.Windows.Forms.Padding(3);
            this.tabPurchaseHistory.Size = new System.Drawing.Size(1192, 620);
            this.tabPurchaseHistory.TabIndex = 2;
            this.tabPurchaseHistory.Text = "📜 Lịch Sử Mua Hàng";
            this.tabPurchaseHistory.UseVisualStyleBackColor = true;
            // 
            // dgvPurchaseHistory
            // 
            this.dgvPurchaseHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvPurchaseHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPurchaseHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPurchaseHistory.Location = new System.Drawing.Point(3, 63);
            this.dgvPurchaseHistory.Name = "dgvPurchaseHistory";
            this.dgvPurchaseHistory.Size = new System.Drawing.Size(1186, 554);
            this.dgvPurchaseHistory.TabIndex = 1;
            // 
            // panelHistoryFilters
            // 
            this.panelHistoryFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelHistoryFilters.Controls.Add(this.btnSearchHistory);
            this.panelHistoryFilters.Controls.Add(this.dtpHistoryEnd);
            this.panelHistoryFilters.Controls.Add(this.lblHistoryEnd);
            this.panelHistoryFilters.Controls.Add(this.dtpHistoryStart);
            this.panelHistoryFilters.Controls.Add(this.lblHistoryStart);
            this.panelHistoryFilters.Controls.Add(this.cboCustomer);
            this.panelHistoryFilters.Controls.Add(this.lblCustomer);
            this.panelHistoryFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHistoryFilters.Location = new System.Drawing.Point(3, 3);
            this.panelHistoryFilters.Name = "panelHistoryFilters";
            this.panelHistoryFilters.Size = new System.Drawing.Size(1186, 60);
            this.panelHistoryFilters.TabIndex = 0;
            // 
            // btnSearchHistory
            // 
            this.btnSearchHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSearchHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchHistory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearchHistory.ForeColor = System.Drawing.Color.White;
            this.btnSearchHistory.Location = new System.Drawing.Point(900, 15);
            this.btnSearchHistory.Name = "btnSearchHistory";
            this.btnSearchHistory.Size = new System.Drawing.Size(120, 30);
            this.btnSearchHistory.TabIndex = 6;
            this.btnSearchHistory.Text = "🔍 Tìm kiếm";
            this.btnSearchHistory.UseVisualStyleBackColor = false;
            this.btnSearchHistory.Click += new System.EventHandler(this.btnSearchHistory_Click);
            // 
            // dtpHistoryEnd
            // 
            this.dtpHistoryEnd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpHistoryEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHistoryEnd.Location = new System.Drawing.Point(700, 20);
            this.dtpHistoryEnd.Name = "dtpHistoryEnd";
            this.dtpHistoryEnd.Size = new System.Drawing.Size(150, 23);
            this.dtpHistoryEnd.TabIndex = 5;
            // 
            // lblHistoryEnd
            // 
            this.lblHistoryEnd.AutoSize = true;
            this.lblHistoryEnd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHistoryEnd.Location = new System.Drawing.Point(620, 22);
            this.lblHistoryEnd.Name = "lblHistoryEnd";
            this.lblHistoryEnd.Size = new System.Drawing.Size(64, 15);
            this.lblHistoryEnd.TabIndex = 4;
            this.lblHistoryEnd.Text = "Đến ngày:";
            // 
            // dtpHistoryStart
            // 
            this.dtpHistoryStart.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpHistoryStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHistoryStart.Location = new System.Drawing.Point(430, 20);
            this.dtpHistoryStart.Name = "dtpHistoryStart";
            this.dtpHistoryStart.Size = new System.Drawing.Size(150, 23);
            this.dtpHistoryStart.TabIndex = 3;
            // 
            // lblHistoryStart
            // 
            this.lblHistoryStart.AutoSize = true;
            this.lblHistoryStart.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHistoryStart.Location = new System.Drawing.Point(350, 22);
            this.lblHistoryStart.Name = "lblHistoryStart";
            this.lblHistoryStart.Size = new System.Drawing.Size(54, 15);
            this.lblHistoryStart.TabIndex = 2;
            this.lblHistoryStart.Text = "Từ ngày:";
            // 
            // cboCustomer
            // 
            this.cboCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.Location = new System.Drawing.Point(110, 20);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(200, 23);
            this.cboCustomer.TabIndex = 1;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCustomer.Location = new System.Drawing.Point(20, 22);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(81, 15);
            this.lblCustomer.TabIndex = 0;
            this.lblCustomer.Text = "Khách hàng:";
            // 
            // FormCustomerStatistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panelTop);
            this.Name = "FormCustomerStatistic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống Kê Khách Hàng";
            this.Load += new System.EventHandler(this.FormCustomerStatistic_Load);
            this.panelTop.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabTopCustomers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopCustomers)).EndInit();
            this.panelTopFilters.ResumeLayout(false);
            this.panelTopFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTopN)).EndInit();
            this.tabVIPStats.ResumeLayout(false);
            this.splitVIP.Panel1.ResumeLayout(false);
            this.splitVIP.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitVIP)).EndInit();
            this.splitVIP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVIPStats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVIP)).EndInit();
            this.tabPurchaseHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseHistory)).EndInit();
            this.panelHistoryFilters.ResumeLayout(false);
            this.panelHistoryFilters.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
    }
}
