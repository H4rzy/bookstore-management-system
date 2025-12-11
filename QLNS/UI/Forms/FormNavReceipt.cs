using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using QLNS.UI.Forms;
using QLNS.UI.Forms.ReceiptDetails;

namespace QLNS.Forms
{
    public partial class FormNavReceipt : Form
    {
        private IconButton currentBtn;
        private Panel underlinePanel;
        private Form currentChildForm;

        public FormNavReceipt()
        {
            InitializeComponent();
            underlinePanel = new Panel();
            underlinePanel.Size = new Size(220, 3);
            panelNav.Controls.Add(underlinePanel);
            underlinePanel.BringToFront();
            
            // Mở FormReceiptList mặc định
            ActivateButton(btnReceiptList, Color.FromArgb(220, 53, 69));
            OpenChildForm(new FormReceiptList());
        }

        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.IconColor = color;

                // Underline ở dưới button
                underlinePanel.BackColor = color;
                underlinePanel.Size = new Size(currentBtn.Width, 3);
                underlinePanel.Location = new Point(currentBtn.Location.X, currentBtn.Height - 3);
                underlinePanel.Visible = true;
                underlinePanel.BringToFront();
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.IconColor = Color.Gainsboro;
            }
        }

        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelContent.Controls.Add(childForm);
            panelContent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnReceiptList_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(220, 53, 69));
            OpenChildForm(new FormReceiptList());
        }

        private void btnNewSale_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(40, 167, 69));
            OpenChildForm(new FormSales());
        }

        private void btnReceiptDetails_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(220, 53, 69));
            OpenChildForm(new FormReceiptDetails());
        }
    }
}
