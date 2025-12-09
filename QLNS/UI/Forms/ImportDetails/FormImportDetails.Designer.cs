namespace QLNS.UI.Forms.ImportDetails
{
    partial class FormImportDetails
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
            this.lblPhieuNhap = new System.Windows.Forms.Label();
            this.cboPhieuNhap = new System.Windows.Forms.ComboBox();
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
            this.tableLayoutMain.Controls.Add(this.panelFilter, 0, 1);
            this.tableLayoutMain.Controls.Add(this.dgvChiTiet, 0, 2);
            this.tableLayoutMain.Controls.Add(this.panelButtons, 0, 3);
            this.tableLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutMain.Name = "tableLayoutMain";
            this.tableLayoutMain.RowCount = 4;
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutMain.Size = new System.Drawing.Size(1867, 985);
            this.tableLayoutMain.TabIndex = 0;
            this.tableLayoutMain.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutMain_Paint);
            // 
            // panelFilter
            // 
            this.panelFilter.BackColor = System.Drawing.Color.White;
            this.panelFilter.Controls.Add(this.tableLayoutFilter);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFilter.Location = new System.Drawing.Point(0, 9);
            this.panelFilter.Margin = new System.Windows.Forms.Padding(0);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.panelFilter.Size = new System.Drawing.Size(1867, 80);
            this.panelFilter.TabIndex = 1;
            // 
            // tableLayoutFilter
            // 
            this.tableLayoutFilter.ColumnCount = 3;
            this.tableLayoutFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 187F));
            this.tableLayoutFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 147F));
            this.tableLayoutFilter.Controls.Add(this.lblPhieuNhap, 0, 0);
            this.tableLayoutFilter.Controls.Add(this.cboPhieuNhap, 1, 0);
            this.tableLayoutFilter.Controls.Add(this.btnRefresh, 2, 0);
            this.tableLayoutFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutFilter.Location = new System.Drawing.Point(13, 12);
            this.tableLayoutFilter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutFilter.Name = "tableLayoutFilter";
            this.tableLayoutFilter.RowCount = 1;
            this.tableLayoutFilter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutFilter.Size = new System.Drawing.Size(1841, 56);
            this.tableLayoutFilter.TabIndex = 0;
            // 
            // lblPhieuNhap
            // 
            this.lblPhieuNhap.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPhieuNhap.AutoSize = true;
            this.lblPhieuNhap.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPhieuNhap.Location = new System.Drawing.Point(4, 16);
            this.lblPhieuNhap.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPhieuNhap.Name = "lblPhieuNhap";
            this.lblPhieuNhap.Size = new System.Drawing.Size(151, 23);
            this.lblPhieuNhap.TabIndex = 0;
            this.lblPhieuNhap.Text = "Chọn phiếu nhập:";
            // 
            // cboPhieuNhap
            // 
            this.cboPhieuNhap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPhieuNhap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhieuNhap.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboPhieuNhap.FormattingEnabled = true;
            this.cboPhieuNhap.Location = new System.Drawing.Point(191, 12);
            this.cboPhieuNhap.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboPhieuNhap.Name = "cboPhieuNhap";
            this.cboPhieuNhap.Size = new System.Drawing.Size(1499, 31);
            this.cboPhieuNhap.TabIndex = 1;
            this.cboPhieuNhap.SelectedIndexChanged += new System.EventHandler(this.cboPhieuNhap_SelectedIndexChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(179)))), ((int)(((byte)(113)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(1701, 6);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.dgvChiTiet.Location = new System.Drawing.Point(4, 93);
            this.dgvChiTiet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvChiTiet.MultiSelect = false;
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.ReadOnly = true;
            this.dgvChiTiet.RowHeadersWidth = 51;
            this.dgvChiTiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTiet.Size = new System.Drawing.Size(1859, 826);
            this.dgvChiTiet.TabIndex = 2;
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
            this.panelButtons.TabIndex = 3;
            // 
            // lblTongTien
            // 
            this.lblTongTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblTongTien.Location = new System.Drawing.Point(1467, 10);
            this.lblTongTien.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
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
            this.btnDeleteDetail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.btnAddDetail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddDetail.Name = "btnAddDetail";
            this.btnAddDetail.Size = new System.Drawing.Size(133, 43);
            this.btnAddDetail.TabIndex = 0;
            this.btnAddDetail.Text = "Thêm chi tiết";
            this.btnAddDetail.UseVisualStyleBackColor = false;
            this.btnAddDetail.Click += new System.EventHandler(this.btnAddDetail_Click);
            // 
            // FormImportDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1867, 985);
            this.Controls.Add(this.tableLayoutMain);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormImportDetails";
            this.Text = "Chi tiết phiếu nhập";
            this.Load += new System.EventHandler(this.FormImportDetails_Load);
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
        private System.Windows.Forms.Label lblPhieuNhap;
        private System.Windows.Forms.ComboBox cboPhieuNhap;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvChiTiet;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnAddDetail;
        private System.Windows.Forms.Button btnDeleteDetail;
        private System.Windows.Forms.Label lblTongTien;
    }
}
