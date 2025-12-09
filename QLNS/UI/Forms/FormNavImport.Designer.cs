namespace QLNS.Forms
{
    partial class FormNavImport
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
            this.btnImportDetails = new FontAwesome.Sharp.IconButton();
            this.btnImportList = new FontAwesome.Sharp.IconButton();
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
            this.panelNav.Controls.Add(this.btnImportDetails);
            this.panelNav.Controls.Add(this.btnImportList);
            this.panelNav.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelNav.Location = new System.Drawing.Point(0, 0);
            this.panelNav.Margin = new System.Windows.Forms.Padding(0);
            this.panelNav.Name = "panelNav";
            this.panelNav.Size = new System.Drawing.Size(1400, 60);
            this.panelNav.TabIndex = 0;
            // 
            // btnImportDetails
            // 
            this.btnImportDetails.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnImportDetails.FlatAppearance.BorderSize = 0;
            this.btnImportDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportDetails.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportDetails.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnImportDetails.IconChar = FontAwesome.Sharp.IconChar.ClipboardList;
            this.btnImportDetails.IconColor = System.Drawing.Color.Gainsboro;
            this.btnImportDetails.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnImportDetails.IconSize = 32;
            this.btnImportDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImportDetails.Location = new System.Drawing.Point(371, 0);
            this.btnImportDetails.Name = "btnImportDetails";
            this.btnImportDetails.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnImportDetails.Size = new System.Drawing.Size(355, 60);
            this.btnImportDetails.TabIndex = 1;
            this.btnImportDetails.Text = "Chi tiết phiếu nhập";
            this.btnImportDetails.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImportDetails.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImportDetails.UseVisualStyleBackColor = true;
            this.btnImportDetails.Click += new System.EventHandler(this.btnImportDetails_Click);
            // 
            // btnImportList
            // 
            this.btnImportList.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnImportList.FlatAppearance.BorderSize = 0;
            this.btnImportList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportList.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportList.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnImportList.IconChar = FontAwesome.Sharp.IconChar.FileImport;
            this.btnImportList.IconColor = System.Drawing.Color.Gainsboro;
            this.btnImportList.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnImportList.IconSize = 32;
            this.btnImportList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImportList.Location = new System.Drawing.Point(0, 0);
            this.btnImportList.Name = "btnImportList";
            this.btnImportList.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnImportList.Size = new System.Drawing.Size(371, 60);
            this.btnImportList.TabIndex = 0;
            this.btnImportList.Text = "Danh sách phiếu nhập";
            this.btnImportList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImportList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImportList.UseVisualStyleBackColor = true;
            this.btnImportList.Click += new System.EventHandler(this.btnImportList_Click);
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
            // FormNavImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 800);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormNavImport";
            this.Text = "Quản lý nhập hàng";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelNav.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelNav;
        private FontAwesome.Sharp.IconButton btnImportList;
        private FontAwesome.Sharp.IconButton btnImportDetails;
        private System.Windows.Forms.Panel panelContent;
    }
}
