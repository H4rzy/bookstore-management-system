using System;
using System.Windows.Forms;
namespace QLNS.Forms.Statistic
{
    public partial class FormCustomerStatistic : Form
    {
        public FormCustomerStatistic()
        {
            InitializeComponent();
            LoadDefaultData();
        }

        private void LoadDefaultData()
        {
            // Set default date range (last 3 months)
            dtpStartDate.Value = DateTime.Now.AddMonths(-3);
            dtpEndDate.Value = DateTime.Now;
            cboCustomerType.SelectedIndex = 0; // All types
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
                    Application.StartupPath, "Reports", "CustomerReport.rpt");
                
                if (System.IO.File.Exists(reportPath))
                {
                    report.Load(reportPath);
                    
                    report.SetParameterValue("StartDate", dtpStartDate.Value);
                    report.SetParameterValue("EndDate", dtpEndDate.Value);
                    report.SetParameterValue("CustomerType", cboCustomerType.Text);
                    
                   
                }
                else
                {
                    MessageBox.Show("Không tìm thấy file báo cáo: " + reportPath + 
                        "\n\nVui lòng tạo file CustomerReport.rpt trong thư mục Reports bằng Crystal Reports Designer.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải báo cáo: " + ex.Message, 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormCustomerStatistic_Load(object sender, EventArgs e)
        {
            btnRefresh_Click(sender, e);
        }
    }
}
