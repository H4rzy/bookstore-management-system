namespace QLNS
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnStatistics = new FontAwesome.Sharp.IconButton();
            this.BtnReceipt = new FontAwesome.Sharp.IconButton();
            this.BtnImport = new FontAwesome.Sharp.IconButton();
            this.BtnStaff = new FontAwesome.Sharp.IconButton();
            this.BtnCustomers = new FontAwesome.Sharp.IconButton();
            this.BtnBooks = new FontAwesome.Sharp.IconButton();
            this.BtnDashboard = new FontAwesome.Sharp.IconButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnHome = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTitleChildForm = new System.Windows.Forms.Label();
            this.iconCurrentChildForm = new FontAwesome.Sharp.IconPictureBox();
            this.btnMinimize = new FontAwesome.Sharp.IconButton();
            this.BtnMaximize = new FontAwesome.Sharp.IconButton();
            this.btnClose = new FontAwesome.Sharp.IconButton();
            this.panelShadow = new System.Windows.Forms.Panel();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).BeginInit();
            this.panelDesktop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.panel1.Controls.Add(this.BtnStatistics);
            this.panel1.Controls.Add(this.BtnReceipt);
            this.panel1.Controls.Add(this.BtnImport);
            this.panel1.Controls.Add(this.BtnStaff);
            this.panel1.Controls.Add(this.BtnCustomers);
            this.panel1.Controls.Add(this.BtnBooks);
            this.panel1.Controls.Add(this.BtnDashboard);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 646);
            this.panel1.TabIndex = 0;
            // 
            // BtnStatistics
            // 
            this.BtnStatistics.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnStatistics.FlatAppearance.BorderSize = 0;
            this.BtnStatistics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnStatistics.ForeColor = System.Drawing.Color.Gainsboro;
            this.BtnStatistics.IconChar = FontAwesome.Sharp.IconChar.Cog;
            this.BtnStatistics.IconColor = System.Drawing.Color.Gainsboro;
            this.BtnStatistics.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnStatistics.IconSize = 32;
            this.BtnStatistics.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnStatistics.Location = new System.Drawing.Point(0, 500);
            this.BtnStatistics.Name = "BtnStatistics";
            this.BtnStatistics.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.BtnStatistics.Size = new System.Drawing.Size(220, 60);
            this.BtnStatistics.TabIndex = 6;
            this.BtnStatistics.Text = "thống kê";
            this.BtnStatistics.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnStatistics.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnStatistics.UseVisualStyleBackColor = true;
            this.BtnStatistics.Click += new System.EventHandler(this.iconButton6_Click);
            // 
            // BtnReceipt
            // 
            this.BtnReceipt.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnReceipt.FlatAppearance.BorderSize = 0;
            this.BtnReceipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReceipt.ForeColor = System.Drawing.Color.Gainsboro;
            this.BtnReceipt.IconChar = FontAwesome.Sharp.IconChar.Receipt;
            this.BtnReceipt.IconColor = System.Drawing.Color.Gainsboro;
            this.BtnReceipt.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnReceipt.IconSize = 32;
            this.BtnReceipt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnReceipt.Location = new System.Drawing.Point(0, 440);
            this.BtnReceipt.Name = "BtnReceipt";
            this.BtnReceipt.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.BtnReceipt.Size = new System.Drawing.Size(220, 60);
            this.BtnReceipt.TabIndex = 7;
            this.BtnReceipt.Text = "Quản lý hóa đơn";
            this.BtnReceipt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnReceipt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnReceipt.UseVisualStyleBackColor = true;
            this.BtnReceipt.Click += new System.EventHandler(this.BtnReceipt_Click);
            // 
            // BtnImport
            // 
            this.BtnImport.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnImport.FlatAppearance.BorderSize = 0;
            this.BtnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnImport.ForeColor = System.Drawing.Color.Gainsboro;
            this.BtnImport.IconChar = FontAwesome.Sharp.IconChar.BoxesPacking;
            this.BtnImport.IconColor = System.Drawing.Color.Gainsboro;
            this.BtnImport.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnImport.IconSize = 32;
            this.BtnImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnImport.Location = new System.Drawing.Point(0, 380);
            this.BtnImport.Name = "BtnImport";
            this.BtnImport.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.BtnImport.Size = new System.Drawing.Size(220, 60);
            this.BtnImport.TabIndex = 5;
            this.BtnImport.Text = "Quản lý nhập hàng";
            this.BtnImport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnImport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnImport.UseVisualStyleBackColor = true;
            this.BtnImport.Click += new System.EventHandler(this.iconButton5_Click);
            // 
            // BtnStaff
            // 
            this.BtnStaff.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnStaff.FlatAppearance.BorderSize = 0;
            this.BtnStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnStaff.ForeColor = System.Drawing.Color.Gainsboro;
            this.BtnStaff.IconChar = FontAwesome.Sharp.IconChar.User;
            this.BtnStaff.IconColor = System.Drawing.Color.Gainsboro;
            this.BtnStaff.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnStaff.IconSize = 32;
            this.BtnStaff.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnStaff.Location = new System.Drawing.Point(0, 320);
            this.BtnStaff.Name = "BtnStaff";
            this.BtnStaff.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.BtnStaff.Size = new System.Drawing.Size(220, 60);
            this.BtnStaff.TabIndex = 4;
            this.BtnStaff.Text = "Quản lý nhân viên";
            this.BtnStaff.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnStaff.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnStaff.UseVisualStyleBackColor = true;
            this.BtnStaff.Click += new System.EventHandler(this.iconButton4_Click);
            // 
            // BtnCustomers
            // 
            this.BtnCustomers.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnCustomers.FlatAppearance.BorderSize = 0;
            this.BtnCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCustomers.ForeColor = System.Drawing.Color.Gainsboro;
            this.BtnCustomers.IconChar = FontAwesome.Sharp.IconChar.Person;
            this.BtnCustomers.IconColor = System.Drawing.Color.Gainsboro;
            this.BtnCustomers.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnCustomers.IconSize = 32;
            this.BtnCustomers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCustomers.Location = new System.Drawing.Point(0, 260);
            this.BtnCustomers.Name = "BtnCustomers";
            this.BtnCustomers.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.BtnCustomers.Size = new System.Drawing.Size(220, 60);
            this.BtnCustomers.TabIndex = 3;
            this.BtnCustomers.Text = "Quản lý khách hàng";
            this.BtnCustomers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCustomers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnCustomers.UseVisualStyleBackColor = true;
            this.BtnCustomers.Click += new System.EventHandler(this.iconButton3_Click);
            // 
            // BtnBooks
            // 
            this.BtnBooks.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnBooks.FlatAppearance.BorderSize = 0;
            this.BtnBooks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBooks.ForeColor = System.Drawing.Color.Gainsboro;
            this.BtnBooks.IconChar = FontAwesome.Sharp.IconChar.Book;
            this.BtnBooks.IconColor = System.Drawing.Color.Gainsboro;
            this.BtnBooks.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnBooks.IconSize = 32;
            this.BtnBooks.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnBooks.Location = new System.Drawing.Point(0, 200);
            this.BtnBooks.Name = "BtnBooks";
            this.BtnBooks.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.BtnBooks.Size = new System.Drawing.Size(220, 60);
            this.BtnBooks.TabIndex = 2;
            this.BtnBooks.Text = "Quản lý Sách";
            this.BtnBooks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnBooks.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnBooks.UseVisualStyleBackColor = true;
            this.BtnBooks.Click += new System.EventHandler(this.iconButton2_Click);
            // 
            // BtnDashboard
            // 
            this.BtnDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnDashboard.FlatAppearance.BorderSize = 0;
            this.BtnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDashboard.ForeColor = System.Drawing.Color.Gainsboro;
            this.BtnDashboard.IconChar = FontAwesome.Sharp.IconChar.House;
            this.BtnDashboard.IconColor = System.Drawing.Color.Gainsboro;
            this.BtnDashboard.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnDashboard.IconSize = 32;
            this.BtnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnDashboard.Location = new System.Drawing.Point(0, 140);
            this.BtnDashboard.Name = "BtnDashboard";
            this.BtnDashboard.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.BtnDashboard.Size = new System.Drawing.Size(220, 60);
            this.BtnDashboard.TabIndex = 1;
            this.BtnDashboard.Text = "Dashboard";
            this.BtnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnDashboard.UseVisualStyleBackColor = true;
            this.BtnDashboard.Click += new System.EventHandler(this.BtnDashboard_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnHome);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(220, 140);
            this.panel2.TabIndex = 0;
            // 
            // btnHome
            // 
            this.btnHome.Image = global::QLNS.Properties.Resources.f6f225ae_e23d_43cf_afb1_fede3553ac0c_removalai_preview__3_;
            this.btnHome.Location = new System.Drawing.Point(0, 12);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(220, 112);
            this.btnHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnHome.TabIndex = 0;
            this.btnHome.TabStop = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.panel3.Controls.Add(this.lblTitleChildForm);
            this.panel3.Controls.Add(this.iconCurrentChildForm);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(220, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(829, 45);
            this.panel3.TabIndex = 1;
            this.panel3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseDown);
            this.panel3.Controls.SetChildIndex(this.iconCurrentChildForm, 0);
            this.panel3.Controls.SetChildIndex(this.lblTitleChildForm, 0);
            // 
            // lblTitleChildForm
            // 
            this.lblTitleChildForm.AutoSize = true;
            this.lblTitleChildForm.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblTitleChildForm.Location = new System.Drawing.Point(55, 17);
            this.lblTitleChildForm.Name = "lblTitleChildForm";
            this.lblTitleChildForm.Size = new System.Drawing.Size(44, 16);
            this.lblTitleChildForm.TabIndex = 1;
            this.lblTitleChildForm.Text = "Home";
            // 
            // iconCurrentChildForm
            // 
            this.iconCurrentChildForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.iconCurrentChildForm.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.iconCurrentChildForm.IconChar = FontAwesome.Sharp.IconChar.House;
            this.iconCurrentChildForm.IconColor = System.Drawing.SystemColors.MenuHighlight;
            this.iconCurrentChildForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconCurrentChildForm.Location = new System.Drawing.Point(17, 11);
            this.iconCurrentChildForm.Name = "iconCurrentChildForm";
            this.iconCurrentChildForm.Size = new System.Drawing.Size(32, 32);
            this.iconCurrentChildForm.TabIndex = 0;
            this.iconCurrentChildForm.TabStop = false;
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnMinimize.IconChar = FontAwesome.Sharp.IconChar.Minus;
            this.btnMinimize.IconColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnMinimize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMinimize.IconSize = 35;
            this.btnMinimize.Location = new System.Drawing.Point(688, 9);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(55, 36);
            this.btnMinimize.TabIndex = 4;
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // BtnMaximize
            // 
            this.BtnMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnMaximize.FlatAppearance.BorderSize = 0;
            this.BtnMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMaximize.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.BtnMaximize.IconChar = FontAwesome.Sharp.IconChar.WindowRestore;
            this.BtnMaximize.IconColor = System.Drawing.SystemColors.MenuHighlight;
            this.BtnMaximize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnMaximize.IconSize = 35;
            this.BtnMaximize.Location = new System.Drawing.Point(733, 8);
            this.BtnMaximize.Name = "BtnMaximize";
            this.BtnMaximize.Size = new System.Drawing.Size(55, 36);
            this.BtnMaximize.TabIndex = 3;
            this.BtnMaximize.UseVisualStyleBackColor = true;
            this.BtnMaximize.Click += new System.EventHandler(this.BtnMaximize_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnClose.IconChar = FontAwesome.Sharp.IconChar.Remove;
            this.btnClose.IconColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnClose.IconSize = 35;
            this.btnClose.Location = new System.Drawing.Point(774, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(55, 36);
            this.btnClose.TabIndex = 2;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panelShadow
            // 
            this.panelShadow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(24)))), ((int)(((byte)(58)))));
            this.panelShadow.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelShadow.Location = new System.Drawing.Point(220, 45);
            this.panelShadow.Name = "panelShadow";
            this.panelShadow.Size = new System.Drawing.Size(829, 10);
            this.panelShadow.TabIndex = 2;
            // 
            // panelDesktop
            // 
            this.panelDesktop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.panelDesktop.Controls.Add(this.pictureBox1);
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(220, 55);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(829, 591);
            this.panelDesktop.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::QLNS.Properties.Resources.f6f225ae_e23d_43cf_afb1_fede3553ac0c_removalai_preview__3_;
            this.pictureBox1.Location = new System.Drawing.Point(242, 193);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(320, 164);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 646);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panelShadow);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.panelShadow, 0);
            this.Controls.SetChildIndex(this.panelDesktop, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).EndInit();
            this.panelDesktop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton BtnDashboard;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton BtnStatistics;
        private FontAwesome.Sharp.IconButton BtnImport;
        private FontAwesome.Sharp.IconButton BtnStaff;
        private FontAwesome.Sharp.IconButton BtnCustomers;
        private FontAwesome.Sharp.IconButton BtnBooks;
        private System.Windows.Forms.PictureBox btnHome;
        private System.Windows.Forms.Panel panel3;
        private FontAwesome.Sharp.IconPictureBox iconCurrentChildForm;
        private System.Windows.Forms.Label lblTitleChildForm;
        private System.Windows.Forms.Panel panelShadow;
        private System.Windows.Forms.Panel panelDesktop;
        private FontAwesome.Sharp.IconButton btnClose;
        private FontAwesome.Sharp.IconButton btnMinimize;
        private FontAwesome.Sharp.IconButton BtnMaximize;
        private System.Windows.Forms.PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton BtnReceipt;
    }
}

