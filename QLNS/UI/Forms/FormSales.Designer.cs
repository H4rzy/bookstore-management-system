namespace QLNS.UI.Forms
{
    partial class FormSales
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
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.lblInvoiceNumber = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.btnAddToCart = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.btnClearCart = new System.Windows.Forms.Button();
            this.btnRemoveFromCart = new System.Windows.Forms.Button();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCompleteSale = new System.Windows.Forms.Button();
            this.lblChange = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPayment = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tlpMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tlpMain.Controls.Add(this.pnlTop, 0, 0);
            this.tlpMain.Controls.Add(this.pnlLeft, 0, 1);
            this.tlpMain.Controls.Add(this.pnlRight, 1, 1);
            this.tlpMain.Controls.Add(this.pnlBottom, 0, 2);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tlpMain.Size = new System.Drawing.Size(1200, 700);
            this.tlpMain.TabIndex = 0;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tlpMain.SetColumnSpan(this.pnlTop, 2);
            this.pnlTop.Controls.Add(this.lblEmployee);
            this.pnlTop.Controls.Add(this.lblDateTime);
            this.pnlTop.Controls.Add(this.lblInvoiceNumber);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Controls.Add(this.cboCustomer);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTop.Location = new System.Drawing.Point(3, 3);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1194, 94);
            this.pnlTop.TabIndex = 0;
            // 
            // lblEmployee
            // 
            this.lblEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEmployee.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEmployee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblEmployee.Location = new System.Drawing.Point(850, 60);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(330, 23);
            this.lblEmployee.TabIndex = 4;
            this.lblEmployee.Text = "NV: ";
            this.lblEmployee.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDateTime
            // 
            this.lblDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDateTime.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDateTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblDateTime.Location = new System.Drawing.Point(850, 35);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(330, 23);
            this.lblDateTime.TabIndex = 3;
            this.lblDateTime.Text = "01/01/2024 00:00";
            this.lblDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblInvoiceNumber
            // 
            this.lblInvoiceNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInvoiceNumber.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblInvoiceNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.lblInvoiceNumber.Location = new System.Drawing.Point(850, 8);
            this.lblInvoiceNumber.Name = "lblInvoiceNumber";
            this.lblInvoiceNumber.Size = new System.Drawing.Size(330, 27);
            this.lblInvoiceNumber.TabIndex = 2;
            this.lblInvoiceNumber.Text = "Số HĐ: HD00001";
            this.lblInvoiceNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Khách hàng:";
            // 
            // cboCustomer
            // 
            this.cboCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomer.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.Location = new System.Drawing.Point(15, 40);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(400, 28);
            this.cboCustomer.TabIndex = 0;
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.White;
            this.pnlLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLeft.Controls.Add(this.dgvProducts);
            this.pnlLeft.Controls.Add(this.btnAddToCart);
            this.pnlLeft.Controls.Add(this.txtSearch);
            this.pnlLeft.Controls.Add(this.label2);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Location = new System.Drawing.Point(3, 103);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(10);
            this.pnlLeft.Size = new System.Drawing.Size(654, 414);
            this.pnlLeft.TabIndex = 1;
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProducts.BackgroundColor = System.Drawing.Color.White;
            this.dgvProducts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Location = new System.Drawing.Point(13, 75);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowHeadersVisible = false;
            this.dgvProducts.Size = new System.Drawing.Size(626, 275);
            this.dgvProducts.TabIndex = 3;
            this.dgvProducts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellDoubleClick);
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddToCart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnAddToCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddToCart.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnAddToCart.ForeColor = System.Drawing.Color.White;
            this.btnAddToCart.Location = new System.Drawing.Point(439, 360);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(200, 40);
            this.btnAddToCart.TabIndex = 2;
            this.btnAddToCart.Text = "➕ Thêm vào giỏ";
            this.btnAddToCart.UseVisualStyleBackColor = false;
            this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCart_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtSearch.Location = new System.Drawing.Point(13, 38);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(626, 27);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.label2.Location = new System.Drawing.Point(9, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "🔍 Tìm kiếm sách";
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.White;
            this.pnlRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRight.Controls.Add(this.btnClearCart);
            this.pnlRight.Controls.Add(this.btnRemoveFromCart);
            this.pnlRight.Controls.Add(this.dgvCart);
            this.pnlRight.Controls.Add(this.label3);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(663, 103);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(10);
            this.pnlRight.Size = new System.Drawing.Size(534, 414);
            this.pnlRight.TabIndex = 2;
            // 
            // btnClearCart
            // 
            this.btnClearCart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClearCart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnClearCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearCart.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClearCart.ForeColor = System.Drawing.Color.White;
            this.btnClearCart.Location = new System.Drawing.Point(13, 360);
            this.btnClearCart.Name = "btnClearCart";
            this.btnClearCart.Size = new System.Drawing.Size(150, 40);
            this.btnClearCart.TabIndex = 3;
            this.btnClearCart.Text = "🗑️ Xóa tất cả";
            this.btnClearCart.UseVisualStyleBackColor = false;
            this.btnClearCart.Click += new System.EventHandler(this.btnClearCart_Click);
            // 
            // btnRemoveFromCart
            // 
            this.btnRemoveFromCart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveFromCart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnRemoveFromCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveFromCart.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRemoveFromCart.ForeColor = System.Drawing.Color.White;
            this.btnRemoveFromCart.Location = new System.Drawing.Point(371, 360);
            this.btnRemoveFromCart.Name = "btnRemoveFromCart";
            this.btnRemoveFromCart.Size = new System.Drawing.Size(150, 40);
            this.btnRemoveFromCart.TabIndex = 2;
            this.btnRemoveFromCart.Text = "➖ Xóa món";
            this.btnRemoveFromCart.UseVisualStyleBackColor = false;
            this.btnRemoveFromCart.Click += new System.EventHandler(this.btnRemoveFromCart_Click);
            // 
            // dgvCart
            // 
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AllowUserToDeleteRows = false;
            this.dgvCart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCart.BackgroundColor = System.Drawing.Color.White;
            this.dgvCart.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCart.Location = new System.Drawing.Point(13, 38);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.RowHeadersVisible = false;
            this.dgvCart.Size = new System.Drawing.Size(506, 312);
            this.dgvCart.TabIndex = 1;
            this.dgvCart.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCart_CellEndEdit);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.label3.Location = new System.Drawing.Point(9, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "🛒 Giỏ hàng";
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tlpMain.SetColumnSpan(this.pnlBottom, 2);
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.btnCompleteSale);
            this.pnlBottom.Controls.Add(this.lblChange);
            this.pnlBottom.Controls.Add(this.label9);
            this.pnlBottom.Controls.Add(this.txtPayment);
            this.pnlBottom.Controls.Add(this.label8);
            this.pnlBottom.Controls.Add(this.lblTotal);
            this.pnlBottom.Controls.Add(this.label7);
            this.pnlBottom.Controls.Add(this.txtDiscount);
            this.pnlBottom.Controls.Add(this.label6);
            this.pnlBottom.Controls.Add(this.lblSubTotal);
            this.pnlBottom.Controls.Add(this.label4);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBottom.Location = new System.Drawing.Point(3, 523);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.pnlBottom.Size = new System.Drawing.Size(1194, 174);
            this.pnlBottom.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(840, 115);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(160, 45);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "❌ Hủy (ESC)";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCompleteSale
            // 
            this.btnCompleteSale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCompleteSale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnCompleteSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompleteSale.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnCompleteSale.ForeColor = System.Drawing.Color.White;
            this.btnCompleteSale.Location = new System.Drawing.Point(1010, 115);
            this.btnCompleteSale.Name = "btnCompleteSale";
            this.btnCompleteSale.Size = new System.Drawing.Size(170, 45);
            this.btnCompleteSale.TabIndex = 10;
            this.btnCompleteSale.Text = "✅ Thanh toán (F9)";
            this.btnCompleteSale.UseVisualStyleBackColor = false;
            this.btnCompleteSale.Click += new System.EventHandler(this.btnCompleteSale_Click);
            // 
            // lblChange
            // 
            this.lblChange.AutoSize = true;
            this.lblChange.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblChange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.lblChange.Location = new System.Drawing.Point(735, 125);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(66, 25);
            this.lblChange.TabIndex = 9;
            this.lblChange.Text = "0 VNĐ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label9.Location = new System.Drawing.Point(645, 128);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 20);
            this.label9.TabIndex = 8;
            this.label9.Text = "Tiền thối:";
            // 
            // txtPayment
            // 
            this.txtPayment.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPayment.Location = new System.Drawing.Point(490, 122);
            this.txtPayment.Name = "txtPayment";
            this.txtPayment.Size = new System.Drawing.Size(140, 29);
            this.txtPayment.TabIndex = 7;
            this.txtPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPayment.TextChanged += new System.EventHandler(this.txtPayment_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label8.Location = new System.Drawing.Point(355, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 20);
            this.label8.TabIndex = 6;
            this.label8.Text = "Khách thanh toán:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.lblTotal.Location = new System.Drawing.Point(155, 118);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(91, 32);
            this.lblTotal.TabIndex = 5;
            this.lblTotal.Text = "0 VNĐ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(18, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 25);
            this.label7.TabIndex = 4;
            this.label7.Text = "TỔNG TIỀN:";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDiscount.Location = new System.Drawing.Point(161, 69);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(140, 29);
            this.txtDiscount.TabIndex = 3;
            this.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label6.Location = new System.Drawing.Point(18, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "Giảm giá (VNĐ):";
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.AutoSize = true;
            this.lblSubTotal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSubTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.lblSubTotal.Location = new System.Drawing.Point(157, 20);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(66, 25);
            this.lblSubTotal.TabIndex = 1;
            this.lblSubTotal.Text = "0 VNĐ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label4.Location = new System.Drawing.Point(18, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Thành tiền:";
            // 
            // FormSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.tlpMain);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "FormSales";
            this.Text = "Bán Hàng (POS)";
            this.Load += new System.EventHandler(this.FormSales_Load);
            this.tlpMain.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.Label lblInvoiceNumber;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnAddToCart;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.Button btnRemoveFromCart;
        private System.Windows.Forms.Button btnClearCart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPayment;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblChange;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnCompleteSale;
        private System.Windows.Forms.Button btnCancel;
    }
}
