namespace QLNS.Forms
{
    partial class FormNavBooks
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
            this.btnAuthors = new FontAwesome.Sharp.IconButton();
            this.btnCategories = new FontAwesome.Sharp.IconButton();
            this.btnBooks = new FontAwesome.Sharp.IconButton();
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelNav
            // 
            this.panelNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.panelNav.Controls.Add(this.btnAuthors);
            this.panelNav.Controls.Add(this.btnCategories);
            this.panelNav.Controls.Add(this.btnBooks);
            this.panelNav.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelNav.Location = new System.Drawing.Point(0, 0);
            this.panelNav.Margin = new System.Windows.Forms.Padding(0);
            this.panelNav.Name = "panelNav";
            this.panelNav.Size = new System.Drawing.Size(800, 60);
            this.panelNav.TabIndex = 0;
            // 
            // btnAuthors
            // 
            this.btnAuthors.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAuthors.FlatAppearance.BorderSize = 0;
            this.btnAuthors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAuthors.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAuthors.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnAuthors.IconChar = FontAwesome.Sharp.IconChar.Users;
            this.btnAuthors.IconColor = System.Drawing.Color.Gainsboro;
            this.btnAuthors.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAuthors.IconSize = 32;
            this.btnAuthors.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAuthors.Location = new System.Drawing.Point(463, 0);
            this.btnAuthors.Name = "btnAuthors";
            this.btnAuthors.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnAuthors.Size = new System.Drawing.Size(265, 60);
            this.btnAuthors.TabIndex = 2;
            this.btnAuthors.Text = "Nhà xuất bản";
            this.btnAuthors.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAuthors.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAuthors.UseVisualStyleBackColor = true;
            this.btnAuthors.Click += new System.EventHandler(this.btnAuthors_Click);
            // 
            // btnCategories
            // 
            this.btnCategories.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCategories.FlatAppearance.BorderSize = 0;
            this.btnCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategories.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCategories.IconChar = FontAwesome.Sharp.IconChar.LayerGroup;
            this.btnCategories.IconColor = System.Drawing.Color.Gainsboro;
            this.btnCategories.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCategories.IconSize = 32;
            this.btnCategories.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategories.Location = new System.Drawing.Point(225, 0);
            this.btnCategories.Name = "btnCategories";
            this.btnCategories.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnCategories.Size = new System.Drawing.Size(238, 60);
            this.btnCategories.TabIndex = 1;
            this.btnCategories.Text = "  Thể Loại";
            this.btnCategories.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategories.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCategories.UseVisualStyleBackColor = true;
            this.btnCategories.Click += new System.EventHandler(this.btnCategories_Click);
            // 
            // btnBooks
            // 
            this.btnBooks.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnBooks.FlatAppearance.BorderSize = 0;
            this.btnBooks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBooks.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnBooks.IconChar = FontAwesome.Sharp.IconChar.Book;
            this.btnBooks.IconColor = System.Drawing.Color.Gainsboro;
            this.btnBooks.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBooks.IconSize = 32;
            this.btnBooks.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBooks.Location = new System.Drawing.Point(0, 0);
            this.btnBooks.Name = "btnBooks";
            this.btnBooks.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnBooks.Size = new System.Drawing.Size(225, 60);
            this.btnBooks.TabIndex = 0;
            this.btnBooks.Text = "  Sách";
            this.btnBooks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBooks.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBooks.UseVisualStyleBackColor = true;
            this.btnBooks.Click += new System.EventHandler(this.btnBooks_Click);
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 60);
            this.panelContent.Margin = new System.Windows.Forms.Padding(0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(800, 390);
            this.panelContent.TabIndex = 1;
            // 
            // FormNavBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormNavBooks";
            this.Text = "FormNavBooks";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelNav.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelNav;
        private FontAwesome.Sharp.IconButton btnBooks;
        private FontAwesome.Sharp.IconButton btnCategories;
        private FontAwesome.Sharp.IconButton btnAuthors;
        private System.Windows.Forms.Panel panelContent;
    }
}