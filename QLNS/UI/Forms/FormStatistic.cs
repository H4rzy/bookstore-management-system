using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLNS.Forms.Statistic;

namespace QLNS.Forms
{
    public partial class FormStatistic : Form
    {
        private Form currentChildForm;
        private Button currentButton;

        public FormStatistic()
        {
            InitializeComponent();
            // Load default statistics (Revenue) on form load
            btnRevenueStats_Click(btnRevenueStats, EventArgs.Empty);
        }

        private void LoadChildForm(Form childForm, Button sender)
        {
            // Close current child form if exists
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }

            // Reset previous button styling
            if (currentButton != null)
            {
                currentButton.BackColor = Color.FromArgb(45, 45, 48);
                currentButton.Font = new Font("Segoe UI", 10F);
            }

            // Highlight active button
            currentButton = sender;
            currentButton.BackColor = Color.FromArgb(0, 122, 204);
            currentButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            // Load new child form
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(childForm);
            childForm.Show();
        }

        private void btnRevenueStats_Click(object sender, EventArgs e)
        {
            LoadChildForm(new FormRevenueStatistic(), (Button)sender);
        }

        private void btnTopBooksStats_Click(object sender, EventArgs e)
        {
            LoadChildForm(new FormTopBooksStatistic(), (Button)sender);
        }

        private void btnInventoryStats_Click(object sender, EventArgs e)
        {
            LoadChildForm(new FormInventoryStatistic(), (Button)sender);
        }

        private void btnCustomerStats_Click(object sender, EventArgs e)
        {
            LoadChildForm(new FormCustomerStatistic(), (Button)sender);
        }
    }
}
