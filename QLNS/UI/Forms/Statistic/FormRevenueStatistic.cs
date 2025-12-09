using System;
using System.Windows.Forms;

namespace QLNS.Forms.Statistic
{
    public partial class FormRevenueStatistic : Form
    {
        public FormRevenueStatistic()
        {
            InitializeComponent();
            LoadDefaultData();
        }

        private void LoadDefaultData()
        {
            // Set default date range (current month)
            dtpStartDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpEndDate.Value = DateTime.Now;
            cboGroupBy.SelectedIndex = 1; // Monthly
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Validate date range
            if (dtpStartDate.Value > dtpEndDate.Value)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Load Crystal Report with parameters
            try
            {
                // Create and load the report
                CrystalDecisions.CrystalReports.Engine.ReportDocument report = 
                    new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                
                string reportPath = System.IO.Path.Combine(
                    Application.StartupPath, "Reports", "RevenueReport.rpt");
                
                if (System.IO.File.Exists(reportPath))
                {
                    report.Load(reportPath);
                    
                    // Set parameters
                    report.SetParameterValue("StartDate", dtpStartDate.Value);
                    report.SetParameterValue("EndDate", dtpEndDate.Value);
                    report.SetParameterValue("GroupBy", cboGroupBy.Text);
                    
                    // Display in viewer
                 
                }
                else
                {
                    MessageBox.Show("Không tìm thấy file báo cáo: " + reportPath + 
                        "\n\nVui lòng tạo file RevenueReport.rpt trong thư mục Reports bằng Crystal Reports Designer.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải báo cáo: " + ex.Message, 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormRevenueStatistic_Load(object sender, EventArgs e)
        {
            // Auto-load report on form load
            btnRefresh_Click(sender, e);
        }
    }
}
