namespace QLNS.Forms.Statistic
{
    partial class FormInventoryStatistic
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
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label lblThreshold;
        private System.Windows.Forms.NumericUpDown nudThreshold;
        private System.Windows.Forms.CheckBox chkLowStockOnly;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.Panel panelSummary;
        private System.Windows.Forms.Label lblTotalBooks;
        private System.Windows.Forms.Label lblTotalStock;
        private System.Windows.Forms.Label lblTotalValue;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartInventory;

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();

            this.panelTop = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.chkLowStockOnly = new System.Windows.Forms.CheckBox();
            this.nudThreshold = new System.Windows.Forms.NumericUpDown();
            this.lblThreshold = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.panelSummary = new System.Windows.Forms.Panel();
            this.lblTotalValue = new System.Windows.Forms.Label();
            this.lblTotalStock = new System.Windows.Forms.Label();
            this.lblTotalBooks = new System.Windows.Forms.Label();
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            this.chartInventory = new System.Windows.Forms.DataVisualization.Charting.Chart();

            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panelSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartInventory)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelTop.Controls.Add(this.btnRefresh);
            this.panelTop.Controls.Add(this.chkLowStockOnly);
            this.panelTop.Controls.Add(this.nudThreshold);
            this.panelTop.Controls.Add(this.lblThreshold);
            this.panelTop.Controls.Add(this.cboCategory);
            this.panelTop.Controls.Add(this.lblCategory);
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
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "🔄 Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // chkLowStockOnly
            // 
            this.chkLowStockOnly.AutoSize = true;
            this.chkLowStockOnly.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkLowStockOnly.Location = new System.Drawing.Point(550, 62);
            this.chkLowStockOnly.Name = "chkLowStockOnly";
            this.chkLowStockOnly.Size = new System.Drawing.Size(165, 19);
            this.chkLowStockOnly.TabIndex = 5;
            this.chkLowStockOnly.Text = "⚠️ Chỉ hiện sách sắp hết";
            this.chkLowStockOnly.UseVisualStyleBackColor = true;
            this.chkLowStockOnly.CheckedChanged += new System.EventHandler(this.chkLowStockOnly_CheckedChanged);
            // 
            // nudThreshold
            // 
            this.nudThreshold.Enabled = false;
            this.nudThreshold.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudThreshold.Location = new System.Drawing.Point(450, 60);
            this.nudThreshold.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.nudThreshold.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudThreshold.Name = "nudThreshold";
            this.nudThreshold.Size = new System.Drawing.Size(80, 23);
            this.nudThreshold.TabIndex = 4;
            this.nudThreshold.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // lblThreshold
            // 
            this.lblThreshold.AutoSize = true;
            this.lblThreshold.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblThreshold.Location = new System.Drawing.Point(350, 62);
            this.lblThreshold.Name = "lblThreshold";
            this.lblThreshold.Size = new System.Drawing.Size(94, 15);
            this.lblThreshold.TabIndex = 3;
            this.lblThreshold.Text = "Ngưỡng cảnh báo:";
            // 
            // cboCategory
            // 
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(110, 59);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(200, 23);
            this.cboCategory.TabIndex = 2;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCategory.Location = new System.Drawing.Point(20, 62);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(56, 15);
            this.lblCategory.TabIndex = 1;
            this.lblCategory.Text = "Thể loại:";
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
            this.lblTitle.Text = "📦 THỐNG KÊ TỒN KHO";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 100);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.dgvInventory);
            this.splitContainer.Panel1.Controls.Add(this.panelSummary);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.chartInventory);
            this.splitContainer.Size = new System.Drawing.Size(1200, 600);
            this.splitContainer.SplitterDistance = 750;
            this.splitContainer.TabIndex = 1;
            // 
            // panelSummary
            // 
            this.panelSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.panelSummary.Controls.Add(this.lblTotalValue);
            this.panelSummary.Controls.Add(this.lblTotalStock);
            this.panelSummary.Controls.Add(this.lblTotalBooks);
            this.panelSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSummary.Location = new System.Drawing.Point(0, 0);
            this.panelSummary.Name = "panelSummary";
            this.panelSummary.Size = new System.Drawing.Size(750, 60);
            this.panelSummary.TabIndex = 1;
            // 
            // lblTotalBooks
            // 
            this.lblTotalBooks.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalBooks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblTotalBooks.Location = new System.Drawing.Point(15, 15);
            this.lblTotalBooks.Name = "lblTotalBooks";
            this.lblTotalBooks.Size = new System.Drawing.Size(220, 30);
            this.lblTotalBooks.TabIndex = 0;
            this.lblTotalBooks.Text = "Tổng Số Đầu Sách: 0";
            this.lblTotalBooks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalStock
            // 
            this.lblTotalStock.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblTotalStock.Location = new System.Drawing.Point(250, 15);
            this.lblTotalStock.Name = "lblTotalStock";
            this.lblTotalStock.Size = new System.Drawing.Size(200, 30);
            this.lblTotalStock.TabIndex = 1;
            this.lblTotalStock.Text = "Tổng Số Lượng: 0";
            this.lblTotalStock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalValue
            // 
            this.lblTotalValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.lblTotalValue.Location = new System.Drawing.Point(465, 15);
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.Size = new System.Drawing.Size(270, 30);
            this.lblTotalValue.TabIndex = 2;
            this.lblTotalValue.Text = "Giá Trị Tồn Kho: 0 ₫";
            this.lblTotalValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvInventory
            // 
            this.dgvInventory.AllowUserToAddRows = false;
            this.dgvInventory.AllowUserToDeleteRows = false;
            this.dgvInventory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInventory.BackgroundColor = System.Drawing.Color.White;
            this.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInventory.Location = new System.Drawing.Point(0, 60);
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.ReadOnly = true;
            this.dgvInventory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInventory.Size = new System.Drawing.Size(750, 540);
            this.dgvInventory.TabIndex = 0;
            // 
            // chartInventory
            // 
            chartArea1.Name = "ChartArea1";
            this.chartInventory.ChartAreas.Add(chartArea1);
            this.chartInventory.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartInventory.Legends.Add(legend1);
            this.chartInventory.Location = new System.Drawing.Point(0, 0);
            this.chartInventory.Name = "chartInventory";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Tồn Kho";
            this.chartInventory.Series.Add(series1);
            this.chartInventory.Size = new System.Drawing.Size(446, 600);
            this.chartInventory.TabIndex = 0;
            this.chartInventory.Text = "chart1";
            // 
            // FormInventoryStatistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.panelTop);
            this.Name = "FormInventoryStatistic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống Kê Tồn Kho";
            this.Load += new System.EventHandler(this.FormInventoryStatistic_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudThreshold)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.panelSummary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartInventory)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}
