using System;
using System.Windows.Forms;

namespace QLNS.Forms.Statistic
{
    public partial class FormTopBooksStatistic : Form
    {
        public FormTopBooksStatistic()
        {
            InitializeComponent();
            LoadDefaultData();
        }

        private void LoadDefaultData()
        {
            // Set default date range (current month)
            dtpStartDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpEndDate.Value = DateTime.Now;
            nudTopN.Value = 10; // Top 10 by default
            cboCategory.SelectedIndex = 0; // All categories
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (dtpStartDate.Value > dtpEndDate.Value)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                CrystalDecisions.CrystalReports.Engine.ReportDocument report = 
                    new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                
                string reportPath = System.IO.Path.Combine(
                    Application.StartupPath, "Reports", "TopBooksReport.rpt");
                
                if (System.IO.File.Exists(reportPath))
                {
                    report.Load(reportPath);
                    
                    report.SetParameterValue("StartDate", dtpStartDate.Value);
                    report.SetParameterValue("EndDate", dtpEndDate.Value);
                    report.SetParameterValue("TopN", (int)nudTopN.Value);
                    report.SetParameterValue("Category", cboCategory.Text);
                    

                }
                else
                {
                    MessageBox.Show("Không tìm thấy file báo cáo: " + reportPath + 
                        "\n\nVui lòng tạo file TopBooksReport.rpt trong thư mục Reports bằng Crystal Reports Designer.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải báo cáo: " + ex.Message, 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormTopBooksStatistic_Load(object sender, EventArgs e)
        {
            btnRefresh_Click(sender, e);
        }
    }
}
