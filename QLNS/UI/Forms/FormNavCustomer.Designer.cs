namespace QLNS.Forms
{
    partial class FormNavCustomer
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
            this.panelNav = new System.Windows.Forms.Panel();
            this.btnVIP = new FontAwesome.Sharp.IconButton();
            this.btnCustomers = new FontAwesome.Sharp.IconButton();
            this.panelContent = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelNav.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panelNav, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelContent, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1000, 600);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelNav
            // 
            this.panelNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.panelNav.Controls.Add(this.btnVIP);
            this.panelNav.Controls.Add(this.btnCustomers);
            this.panelNav.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelNav.Location = new System.Drawing.Point(0, 0);
            this.panelNav.Margin = new System.Windows.Forms.Padding(0);
            this.panelNav.Name = "panelNav";
            this.panelNav.Size = new System.Drawing.Size(1000, 60);
            this.panelNav.TabIndex = 0;
            // 
            // btnCustomers
            // 
            this.btnCustomers.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCustomers.FlatAppearance.BorderSize = 0;
            this.btnCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomers.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomers.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCustomers.IconChar = FontAwesome.Sharp.IconChar.Users;
            this.btnCustomers.IconColor = System.Drawing.Color.Gainsboro;
            this.btnCustomers.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCustomers.IconSize = 32;
            this.btnCustomers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomers.Location = new System.Drawing.Point(0, 0);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Padding = new System.Windows.Forms.Padding(15, 0, 20, 0);
            this.btnCustomers.Size = new System.Drawing.Size(250, 60);
            this.btnCustomers.TabIndex = 0;
            this.btnCustomers.Text = "  Khách Hàng";
            this.btnCustomers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCustomers.UseVisualStyleBackColor = true;
            this.btnCustomers.Click += new System.EventHandler(this.btnCustomers_Click);
            // 
            // btnVIP
            // 
            this.btnVIP.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnVIP.FlatAppearance.BorderSize = 0;
            this.btnVIP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVIP.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVIP.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnVIP.IconChar = FontAwesome.Sharp.IconChar.Crown;
            this.btnVIP.IconColor = System.Drawing.Color.Gainsboro;
            this.btnVIP.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnVIP.IconSize = 32;
            this.btnVIP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVIP.Location = new System.Drawing.Point(250, 0);
            this.btnVIP.Name = "btnVIP";
            this.btnVIP.Padding = new System.Windows.Forms.Padding(15, 0, 20, 0);
            this.btnVIP.Size = new System.Drawing.Size(250, 60);
            this.btnVIP.TabIndex = 1;
            this.btnVIP.Text = "  Quản Lý VIP";
            this.btnVIP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVIP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVIP.UseVisualStyleBackColor = true;
            this.btnVIP.Click += new System.EventHandler(this.btnVIP_Click);
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 60);
            this.panelContent.Margin = new System.Windows.Forms.Padding(0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1000, 540);
            this.panelContent.TabIndex = 1;
            // 
            // FormNavCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormNavCustomer";
            this.Text = "Quản Lý Khách Hàng";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelNav.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelNav;
        private FontAwesome.Sharp.IconButton btnCustomers;
        private FontAwesome.Sharp.IconButton btnVIP;
        private System.Windows.Forms.Panel panelContent;
    }
}
