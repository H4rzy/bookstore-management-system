namespace QLNS.Forms.Statistic
{
    partial class FormTopBooksStatistic
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
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label lblTopN;
        private System.Windows.Forms.NumericUpDown nudTopN;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.DataGridView dgvTopBooks;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTopBooks;

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();

            this.panelTop = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.nudTopN = new System.Windows.Forms.NumericUpDown();
            this.lblTopN = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.dgvTopBooks = new System.Windows.Forms.DataGridView();
            this.chartTopBooks = new System.Windows.Forms.DataVisualization.Charting.Chart();

            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTopN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopBooks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTopBooks)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelTop.Controls.Add(this.btnRefresh);
            this.panelTop.Controls.Add(this.cboCategory);
            this.panelTop.Controls.Add(this.lblCategory);
            this.panelTop.Controls.Add(this.nudTopN);
            this.panelTop.Controls.Add(this.lblTopN);
            this.panelTop.Controls.Add(this.dtpEndDate);
            this.panelTop.Controls.Add(this.lblEndDate);
            this.panelTop.Controls.Add(this.dtpStartDate);
            this.panelTop.Controls.Add(this.lblStartDate);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1200, 100);
            this.panelTop.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(1050, 55);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(120, 30);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "🔄 Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cboCategory
            // 
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(800, 59);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(200, 23);
            this.cboCategory.TabIndex = 8;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCategory.Location = new System.Drawing.Point(720, 62);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(56, 15);
            this.lblCategory.TabIndex = 7;
            this.lblCategory.Text = "Thể loại:";
            // 
            // nudTopN
            // 
            this.nudTopN.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudTopN.Location = new System.Drawing.Point(630, 59);
            this.nudTopN.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            this.nudTopN.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            this.nudTopN.Name = "nudTopN";
            this.nudTopN.Size = new System.Drawing.Size(70, 23);
            this.nudTopN.TabIndex = 6;
            this.nudTopN.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // lblTopN
            // 
            this.lblTopN.AutoSize = true;
            this.lblTopN.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTopN.Location = new System.Drawing.Point(570, 62);
            this.lblTopN.Name = "lblTopN";
            this.lblTopN.Size = new System.Drawing.Size(54, 15);
            this.lblTopN.TabIndex = 5;
            this.lblTopN.Text = "Hiển thị:";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(370, 59);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(150, 23);
            this.dtpEndDate.TabIndex = 4;
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEndDate.Location = new System.Drawing.Point(290, 62);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(64, 15);
            this.lblEndDate.TabIndex = 3;
            this.lblEndDate.Text = "Đến ngày:";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(100, 59);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(150, 23);
            this.dtpStartDate.TabIndex = 2;
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStartDate.Location = new System.Drawing.Point(20, 62);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(54, 15);
            this.lblStartDate.TabIndex = 1;
            this.lblStartDate.Text = "Từ ngày:";
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1200, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🏆 SÁCH BÁN CHẠY NHẤT";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 100);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.dgvTopBooks);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.chartTopBooks);
            this.splitContainer.Size = new System.Drawing.Size(1200, 600);
            this.splitContainer.SplitterDistance = 300;
            this.splitContainer.TabIndex = 1;
            // 
            // dgvTopBooks
            // 
            this.dgvTopBooks.AllowUserToAddRows = false;
            this.dgvTopBooks.AllowUserToDeleteRows = false;
            this.dgvTopBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTopBooks.BackgroundColor = System.Drawing.Color.White;
            this.dgvTopBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTopBooks.Location = new System.Drawing.Point(0, 0);
            this.dgvTopBooks.Name = "dgvTopBooks";
            this.dgvTopBooks.ReadOnly = true;
            this.dgvTopBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTopBooks.Size = new System.Drawing.Size(1200, 300);
            this.dgvTopBooks.TabIndex = 0;
            // 
            // chartTopBooks
            // 
            chartArea1.Name = "ChartArea1";
            this.chartTopBooks.ChartAreas.Add(chartArea1);
            this.chartTopBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartTopBooks.Legends.Add(legend1);
            this.chartTopBooks.Location = new System.Drawing.Point(0, 0);
            this.chartTopBooks.Name = "chartTopBooks";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series1.Legend = "Legend1";
            series1.Name = "Doanh Thu";
            this.chartTopBooks.Series.Add(series1);
            this.chartTopBooks.Size = new System.Drawing.Size(1200, 296);
            this.chartTopBooks.TabIndex = 0;
            this.chartTopBooks.Text = "chart1";
            // 
            // FormTopBooksStatistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.panelTop);
            this.Name = "FormTopBooksStatistic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sách Bán Chạy Nhất";
            this.Load += new System.EventHandler(this.FormTopBooksStatistic_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTopN)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopBooks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTopBooks)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}
