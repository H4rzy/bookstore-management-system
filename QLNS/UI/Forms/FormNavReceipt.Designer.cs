namespace QLNS.Forms
{
    partial class FormNavReceipt
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
            this.panelNav = new System.Windows.Forms.Panel();
            this.btnReceiptDetails = new FontAwesome.Sharp.IconButton();
            this.btnNewSale = new FontAwesome.Sharp.IconButton();
            this.btnReceiptList = new FontAwesome.Sharp.IconButton();
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1400, 800);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelNav
            // 
            this.panelNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.panelNav.Controls.Add(this.btnReceiptDetails);
            this.panelNav.Controls.Add(this.btnNewSale);
            this.panelNav.Controls.Add(this.btnReceiptList);
            this.panelNav.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelNav.Location = new System.Drawing.Point(0, 0);
            this.panelNav.Margin = new System.Windows.Forms.Padding(0);
            this.panelNav.Name = "panelNav";
            this.panelNav.Size = new System.Drawing.Size(1400, 60);
            this.panelNav.TabIndex = 0;
            // 
            // btnNewSale
            // 
            this.btnNewSale.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnNewSale.FlatAppearance.BorderSize = 0;
            this.btnNewSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewSale.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewSale.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnNewSale.IconChar = FontAwesome.Sharp.IconChar.CashRegister;
            this.btnNewSale.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnNewSale.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNewSale.IconSize = 32;
            this.btnNewSale.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewSale.Location = new System.Drawing.Point(362, 0);
            this.btnNewSale.Name = "btnNewSale";
            this.btnNewSale.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnNewSale.Size = new System.Drawing.Size(250, 60);
            this.btnNewSale.TabIndex = 2;
            this.btnNewSale.Text = "🛒 BÁN HÀNG";
            this.btnNewSale.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewSale.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNewSale.UseVisualStyleBackColor = true;
            this.btnNewSale.Click += new System.EventHandler(this.btnNewSale_Click);
            // 
            // btnReceiptDetails
            // 
            this.btnReceiptDetails.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnReceiptDetails.FlatAppearance.BorderSize = 0;
            this.btnReceiptDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceiptDetails.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReceiptDetails.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnReceiptDetails.IconChar = FontAwesome.Sharp.IconChar.ClipboardList;
            this.btnReceiptDetails.IconColor = System.Drawing.Color.Gainsboro;
            this.btnReceiptDetails.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnReceiptDetails.IconSize = 32;
            this.btnReceiptDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReceiptDetails.Location = new System.Drawing.Point(612, 0);
            this.btnReceiptDetails.Name = "btnReceiptDetails";
            this.btnReceiptDetails.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnReceiptDetails.Size = new System.Drawing.Size(328, 60);
            this.btnReceiptDetails.TabIndex = 1;
            this.btnReceiptDetails.Text = "Chi tiết hóa đơn";
            this.btnReceiptDetails.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReceiptDetails.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReceiptDetails.UseVisualStyleBackColor = true;
            this.btnReceiptDetails.Click += new System.EventHandler(this.btnReceiptDetails_Click);
            // 
            // btnReceiptList
            // 
            this.btnReceiptList.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnReceiptList.FlatAppearance.BorderSize = 0;
            this.btnReceiptList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceiptList.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReceiptList.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnReceiptList.IconChar = FontAwesome.Sharp.IconChar.FileInvoice;
            this.btnReceiptList.IconColor = System.Drawing.Color.Gainsboro;
            this.btnReceiptList.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnReceiptList.IconSize = 32;
            this.btnReceiptList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReceiptList.Location = new System.Drawing.Point(0, 0);
            this.btnReceiptList.Name = "btnReceiptList";
            this.btnReceiptList.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnReceiptList.Size = new System.Drawing.Size(362, 60);
            this.btnReceiptList.TabIndex = 0;
            this.btnReceiptList.Text = "Danh sách hóa đơn";
            this.btnReceiptList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReceiptList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReceiptList.UseVisualStyleBackColor = true;
            this.btnReceiptList.Click += new System.EventHandler(this.btnReceiptList_Click);
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 60);
            this.panelContent.Margin = new System.Windows.Forms.Padding(0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1400, 740);
            this.panelContent.TabIndex = 1;
            // 
            // FormNavReceipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 800);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormNavReceipt";
            this.Text = "Quản lý hóa đơn";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelNav.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelNav;
        private FontAwesome.Sharp.IconButton btnReceiptList;
        private FontAwesome.Sharp.IconButton btnNewSale;
        private FontAwesome.Sharp.IconButton btnReceiptDetails;
        private System.Windows.Forms.Panel panelContent;
    }
}
