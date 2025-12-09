using System;
using System.Windows.Forms;

namespace QLNS.Forms.Statistic
{
    public partial class FormInventoryStatistic : Form
    {
        public FormInventoryStatistic()
        {
            InitializeComponent();
            LoadDefaultData();
        }

        private void LoadDefaultData()
        {
            cboCategory.SelectedIndex = 0; // All categories
            nudThreshold.Value = 5; // Low stock threshold
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                CrystalDecisions.CrystalReports.Engine.ReportDocument report = 
                    new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                
                string reportPath = System.IO.Path.Combine(
                    Application.StartupPath, "Reports", "InventoryReport.rpt");
                
                if (System.IO.File.Exists(reportPath))
                {
                    report.Load(reportPath);
                    
                    report.SetParameterValue("Category", cboCategory.Text);
                    report.SetParameterValue("LowStockThreshold", (int)nudThreshold.Value);
                    
      
                }
                else
                {
                    MessageBox.Show("Không tìm thấy file báo cáo: " + reportPath + 
                        "\n\nVui lòng tạo file InventoryReport.rpt trong thư mục Reports bằng Crystal Reports Designer.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải báo cáo: " + ex.Message, 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormInventoryStatistic_Load(object sender, EventArgs e)
        {
            btnRefresh_Click(sender, e);
        }
    }
}
