namespace QLNS.UI.Forms.ReceiptDetails
{
    partial class FormReceiptDetails
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
            this.panelFilter = new System.Windows.Forms.Panel();
            this.tableLayoutFilter = new System.Windows.Forms.TableLayoutPanel();
            this.lblHoaDon = new System.Windows.Forms.Label();
            this.cboHoaDon = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dgvChiTiet = new System.Windows.Forms.DataGridView();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.btnDeleteDetail = new System.Windows.Forms.Button();
            this.btnAddDetail = new System.Windows.Forms.Button();
            this.tableLayoutMain.SuspendLayout();
            this.panelFilter.SuspendLayout();
            this.tableLayoutFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutMain
            // 
            this.tableLayoutMain.ColumnCount = 1;
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutMain.Controls.Add(this.panelFilter, 0, 0);
            this.tableLayoutMain.Controls.Add(this.dgvChiTiet, 0, 1);
            this.tableLayoutMain.Controls.Add(this.panelButtons, 0, 2);
            this.tableLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutMain.Name = "tableLayoutMain";
            this.tableLayoutMain.RowCount = 3;
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutMain.Size = new System.Drawing.Size(1867, 985);
            this.tableLayoutMain.TabIndex = 0;
            // 
            // panelFilter
            // 
            this.panelFilter.BackColor = System.Drawing.Color.White;
            this.panelFilter.Controls.Add(this.tableLayoutFilter);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFilter.Location = new System.Drawing.Point(0, 0);
            this.panelFilter.Margin = new System.Windows.Forms.Padding(0);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.panelFilter.Size = new System.Drawing.Size(1867, 80);
            this.panelFilter.TabIndex = 0;
            // 
            // tableLayoutFilter
            // 
            this.tableLayoutFilter.ColumnCount = 3;
            this.tableLayoutFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 147F));
            this.tableLayoutFilter.Controls.Add(this.lblHoaDon, 0, 0);
            this.tableLayoutFilter.Controls.Add(this.cboHoaDon, 1, 0);
            this.tableLayoutFilter.Controls.Add(this.btnRefresh, 2, 0);
            this.tableLayoutFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutFilter.Location = new System.Drawing.Point(13, 12);
            this.tableLayoutFilter.Name = "tableLayoutFilter";
            this.tableLayoutFilter.RowCount = 1;
            this.tableLayoutFilter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutFilter.Size = new System.Drawing.Size(1841, 56);
            this.tableLayoutFilter.TabIndex = 0;
            // 
            // lblHoaDon
            // 
            this.lblHoaDon.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHoaDon.AutoSize = true;
            this.lblHoaDon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHoaDon.Location = new System.Drawing.Point(4, 16);
            this.lblHoaDon.Name = "lblHoaDon";
            this.lblHoaDon.Size = new System.Drawing.Size(124, 23);
            this.lblHoaDon.TabIndex = 0;
            this.lblHoaDon.Text = "Chọn hóa đơn:";
            // 
            // cboHoaDon
            // 
            this.cboHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboHoaDon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHoaDon.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboHoaDon.FormattingEnabled = true;
            this.cboHoaDon.Location = new System.Drawing.Point(144, 12);
            this.cboHoaDon.Name = "cboHoaDon";
            this.cboHoaDon.Size = new System.Drawing.Size(1547, 31);
            this.cboHoaDon.TabIndex = 1;
            this.cboHoaDon.SelectedIndexChanged += new System.EventHandler(this.cboHoaDon_SelectedIndexChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(179)))), ((int)(((byte)(113)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(1701, 6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(133, 43);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.AllowUserToAddRows = false;
            this.dgvChiTiet.AllowUserToDeleteRows = false;
            this.dgvChiTiet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTiet.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTiet.Location = new System.Drawing.Point(4, 84);
            this.dgvChiTiet.MultiSelect = false;
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.ReadOnly = true;
            this.dgvChiTiet.RowHeadersWidth = 51;
            this.dgvChiTiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTiet.Size = new System.Drawing.Size(1859, 835);
            this.dgvChiTiet.TabIndex = 1;
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelButtons.Controls.Add(this.lblTongTien);
            this.panelButtons.Controls.Add(this.btnDeleteDetail);
            this.panelButtons.Controls.Add(this.btnAddDetail);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButtons.Location = new System.Drawing.Point(0, 923);
            this.panelButtons.Margin = new System.Windows.Forms.Padding(0);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Padding = new System.Windows.Forms.Padding(13, 6, 13, 6);
            this.panelButtons.Size = new System.Drawing.Size(1867, 62);
            this.panelButtons.TabIndex = 2;
            // 
            // lblTongTien
            // 
            this.lblTongTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.lblTongTien.Location = new System.Drawing.Point(1467, 10);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(387, 43);
            this.lblTongTien.TabIndex = 2;
            this.lblTongTien.Text = "Tổng tiền: 0 VNĐ";
            this.lblTongTien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnDeleteDetail
            // 
            this.btnDeleteDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnDeleteDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteDetail.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnDeleteDetail.ForeColor = System.Drawing.Color.White;
            this.btnDeleteDetail.Location = new System.Drawing.Point(160, 10);
            this.btnDeleteDetail.Name = "btnDeleteDetail";
            this.btnDeleteDetail.Size = new System.Drawing.Size(133, 43);
            this.btnDeleteDetail.TabIndex = 1;
            this.btnDeleteDetail.Text = "Xóa chi tiết";
            this.btnDeleteDetail.UseVisualStyleBackColor = false;
            this.btnDeleteDetail.Click += new System.EventHandler(this.btnDeleteDetail_Click);
            // 
            // btnAddDetail
            // 
            this.btnAddDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnAddDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddDetail.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnAddDetail.ForeColor = System.Drawing.Color.White;
            this.btnAddDetail.Location = new System.Drawing.Point(13, 10);
            this.btnAddDetail.Name = "btnAddDetail";
            this.btnAddDetail.Size = new System.Drawing.Size(133, 43);
            this.btnAddDetail.TabIndex = 0;
            this.btnAddDetail.Text = "Thêm chi tiết";
            this.btnAddDetail.UseVisualStyleBackColor = false;
            this.btnAddDetail.Click += new System.EventHandler(this.btnAddDetail_Click);
            // 
            // FormReceiptDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1867, 985);
            this.Controls.Add(this.tableLayoutMain);
            this.Name = "FormReceiptDetails";
            this.Text = "Chi tiết hóa đơn";
            this.Load += new System.EventHandler(this.FormReceiptDetails_Load);
            this.tableLayoutMain.ResumeLayout(false);
            this.panelFilter.ResumeLayout(false);
            this.tableLayoutFilter.ResumeLayout(false);
            this.tableLayoutFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutMain;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutFilter;
        private System.Windows.Forms.Label lblHoaDon;
        private System.Windows.Forms.ComboBox cboHoaDon;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvChiTiet;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnAddDetail;
        private System.Windows.Forms.Button btnDeleteDetail;
        private System.Windows.Forms.Label lblTongTien;
    }
}
