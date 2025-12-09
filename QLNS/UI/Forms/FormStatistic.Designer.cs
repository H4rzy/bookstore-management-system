namespace QLNS.Forms
{
    partial class FormStatistic
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

        private System.Windows.Forms.Panel panelNav;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnRevenueStats;
        private System.Windows.Forms.Button btnTopBooksStats;
        private System.Windows.Forms.Button btnInventoryStats;
        private System.Windows.Forms.Button btnCustomerStats;

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelNav = new System.Windows.Forms.Panel();
            this.btnCustomerStats = new System.Windows.Forms.Button();
            this.btnInventoryStats = new System.Windows.Forms.Button();
            this.btnTopBooksStats = new System.Windows.Forms.Button();
            this.btnRevenueStats = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelNav.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelNav
            // 
            this.panelNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.panelNav.Controls.Add(this.btnCustomerStats);
            this.panelNav.Controls.Add(this.btnInventoryStats);
            this.panelNav.Controls.Add(this.btnTopBooksStats);
            this.panelNav.Controls.Add(this.btnRevenueStats);
            this.panelNav.Controls.Add(this.lblTitle);
            this.panelNav.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelNav.Location = new System.Drawing.Point(0, 0);
            this.panelNav.Name = "panelNav";
            this.panelNav.Size = new System.Drawing.Size(220, 600);
            this.panelNav.TabIndex = 0;
            // 
            // btnCustomerStats
            // 
            this.btnCustomerStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnCustomerStats.FlatAppearance.BorderSize = 0;
            this.btnCustomerStats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomerStats.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCustomerStats.ForeColor = System.Drawing.Color.White;
            this.btnCustomerStats.Location = new System.Drawing.Point(0, 280);
            this.btnCustomerStats.Name = "btnCustomerStats";
            this.btnCustomerStats.Size = new System.Drawing.Size(220, 50);
            this.btnCustomerStats.TabIndex = 4;
            this.btnCustomerStats.Text = "📊 Phân tích khách hàng";
            this.btnCustomerStats.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomerStats.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnCustomerStats.UseVisualStyleBackColor = false;
            this.btnCustomerStats.Click += new System.EventHandler(this.btnCustomerStats_Click);
            // 
            // btnInventoryStats
            // 
            this.btnInventoryStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnInventoryStats.FlatAppearance.BorderSize = 0;
            this.btnInventoryStats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventoryStats.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnInventoryStats.ForeColor = System.Drawing.Color.White;
            this.btnInventoryStats.Location = new System.Drawing.Point(0, 230);
            this.btnInventoryStats.Name = "btnInventoryStats";
            this.btnInventoryStats.Size = new System.Drawing.Size(220, 50);
            this.btnInventoryStats.TabIndex = 3;
            this.btnInventoryStats.Text = "📦 Thống kê tồn kho";
            this.btnInventoryStats.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInventoryStats.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnInventoryStats.UseVisualStyleBackColor = false;
            this.btnInventoryStats.Click += new System.EventHandler(this.btnInventoryStats_Click);
            // 
            // btnTopBooksStats
            // 
            this.btnTopBooksStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnTopBooksStats.FlatAppearance.BorderSize = 0;
            this.btnTopBooksStats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTopBooksStats.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnTopBooksStats.ForeColor = System.Drawing.Color.White;
            this.btnTopBooksStats.Location = new System.Drawing.Point(0, 180);
            this.btnTopBooksStats.Name = "btnTopBooksStats";
            this.btnTopBooksStats.Size = new System.Drawing.Size(220, 50);
            this.btnTopBooksStats.TabIndex = 2;
            this.btnTopBooksStats.Text = "📚 Sách bán chạy";
            this.btnTopBooksStats.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTopBooksStats.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnTopBooksStats.UseVisualStyleBackColor = false;
            this.btnTopBooksStats.Click += new System.EventHandler(this.btnTopBooksStats_Click);
            // 
            // btnRevenueStats
            // 
            this.btnRevenueStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnRevenueStats.FlatAppearance.BorderSize = 0;
            this.btnRevenueStats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRevenueStats.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRevenueStats.ForeColor = System.Drawing.Color.White;
            this.btnRevenueStats.Location = new System.Drawing.Point(0, 130);
            this.btnRevenueStats.Name = "btnRevenueStats";
            this.btnRevenueStats.Size = new System.Drawing.Size(220, 50);
            this.btnRevenueStats.TabIndex = 1;
            this.btnRevenueStats.Text = "💰 Thống kê doanh thu";
            this.btnRevenueStats.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRevenueStats.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnRevenueStats.UseVisualStyleBackColor = false;
            this.btnRevenueStats.Click += new System.EventHandler(this.btnRevenueStats_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(220, 80);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "THỐNG KÊ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(220, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(980, 600);
            this.panelMain.TabIndex = 1;
            // 
            // FormStatistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 600);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelNav);
            this.Name = "FormStatistic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống Kê - Quản Lý Nhà Sách";
            this.panelNav.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}