namespace QLNS.UI.Forms
{
    partial class FormCapTheVIP
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboKhachHang = new System.Windows.Forms.ComboBox();
            this.lblCustomerInfo = new System.Windows.Forms.Label();
            this.lblPreviousVIP = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudSoThang = new System.Windows.Forms.NumericUpDown();
            this.lblPreview = new System.Windows.Forms.Label();
            this.lblCost = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoThang)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cboKhachHang, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblCustomerInfo, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblPreviousVIP, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.nudSoThang, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblPreview, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblCost, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.panelButtons, 0, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(15);
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(550, 320);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(18, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Khách Hàng:";
            // 
            // cboKhachHang
            // 
            this.cboKhachHang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboKhachHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cboKhachHang.FormattingEnabled = true;
            this.cboKhachHang.Location = new System.Drawing.Point(168, 21);
            this.cboKhachHang.Name = "cboKhachHang";
            this.cboKhachHang.Size = new System.Drawing.Size(364, 28);
            this.cboKhachHang.TabIndex = 1;
            this.cboKhachHang.SelectedIndexChanged += new System.EventHandler(this.cboKhachHang_SelectedIndexChanged);
            // 
            // lblCustomerInfo
            // 
            this.lblCustomerInfo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCustomerInfo.AutoSize = true;
            this.lblCustomerInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblCustomerInfo.ForeColor = System.Drawing.Color.Gray;
            this.lblCustomerInfo.Location = new System.Drawing.Point(168, 60);
            this.lblCustomerInfo.Name = "lblCustomerInfo";
            this.lblCustomerInfo.Size = new System.Drawing.Size(0, 18);
            this.lblCustomerInfo.TabIndex = 2;
            // 
            // lblPreviousVIP
            // 
            this.lblPreviousVIP.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPreviousVIP.AutoSize = true;
            this.lblPreviousVIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblPreviousVIP.ForeColor = System.Drawing.Color.Orange;
            this.lblPreviousVIP.Location = new System.Drawing.Point(168, 91);
            this.lblPreviousVIP.Name = "lblPreviousVIP";
            this.lblPreviousVIP.Size = new System.Drawing.Size(0, 17);
            this.lblPreviousVIP.TabIndex = 3;
            this.lblPreviousVIP.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(18, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Số Tháng:";
            // 
            // nudSoThang
            // 
            this.nudSoThang.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nudSoThang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.nudSoThang.Location = new System.Drawing.Point(168, 120);
            this.nudSoThang.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            this.nudSoThang.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudSoThang.Name = "nudSoThang";
            this.nudSoThang.Size = new System.Drawing.Size(120, 30);
            this.nudSoThang.TabIndex = 5;
            this.nudSoThang.Value = new decimal(new int[] { 12, 0, 0, 0 });
            this.nudSoThang.ValueChanged += new System.EventHandler(this.nudSoThang_ValueChanged);
            // 
            // lblPreview
            // 
            this.lblPreview.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPreview.AutoSize = true;
            this.lblPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblPreview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(161)))), ((int)(((byte)(251)))));
            this.lblPreview.Location = new System.Drawing.Point(168, 161);
            this.lblPreview.Name = "lblPreview";
            this.lblPreview.Size = new System.Drawing.Size(0, 18);
            this.lblPreview.TabIndex = 6;
            // 
            // lblCost
            // 
            this.lblCost.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCost.AutoSize = true;
            this.lblCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblCost.ForeColor = System.Drawing.Color.Green;
            this.lblCost.Location = new System.Drawing.Point(168, 191);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(0, 18);
            this.lblCost.TabIndex = 7;
            // 
            // panelButtons
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panelButtons, 2);
            this.panelButtons.Controls.Add(this.btnOK);
            this.panelButtons.Controls.Add(this.btnCancel);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButtons.Location = new System.Drawing.Point(18, 218);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(514, 84);
            this.panelButtons.TabIndex = 8;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(77)))), ((int)(((byte)(221)))));
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(147, 20);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 40);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "✅ OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(138)))), ((int)(((byte)(114)))));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(267, 20);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "❌ Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormCapTheVIP
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(550, 320);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCapTheVIP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "💳 Cấp Thẻ VIP Mới";
            this.Load += new System.EventHandler(this.FormCapTheVIP_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoThang)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboKhachHang;
        private System.Windows.Forms.Label lblCustomerInfo;
        private System.Windows.Forms.Label lblPreviousVIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudSoThang;
        private System.Windows.Forms.Label lblPreview;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}
