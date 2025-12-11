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
using QLNS.UI.Forms.ImportDetails;

namespace QLNS.Forms
{
    public partial class FormNavImport : Form
    {
        private IconButton currentBtn;
        private Panel underlinePanel;
        private Form currentChildForm;

        public FormNavImport()
        {
            InitializeComponent();
            underlinePanel = new Panel();
            underlinePanel.Size = new Size(220, 3);
            panelNav.Controls.Add(underlinePanel);
            underlinePanel.BringToFront();
            
            // Mở FormImportList mặc định
            ActivateButton(btnImportList, Color.FromArgb(0, 122, 204));
            OpenChildForm(new FormImportList());
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

        private void btnImportList_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(0, 122, 204));
            OpenChildForm(new FormImportList());
        }

        private void btnImportDetails_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(0, 122, 204));
            OpenChildForm(new FormImportDetails());
        }
    }
}
