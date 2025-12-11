using System;
using System.IO;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace QLNS.Forms.Statistic
{
    public partial class FormRevenueStatistic : Form
    {
        private ReportDocument reportDocument;

        public FormRevenueStatistic()
        {
            InitializeComponent();
        }

        private void FormRevenueStatistic_Load(object sender, EventArgs e)
        {
            LoadReport();

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void LoadReport()
        {
            try
            {
                // Dispose old report
                if (reportDocument != null)
                {
                    reportDocument.Close();
                    reportDocument.Dispose();
                }

                // Get report file path - try multiple locations
                string reportPath = Path.Combine(Application.StartupPath, "Reports", "RevenueReport.rpt");
                
                if (!File.Exists(reportPath))
                {
                    // Try parent directory
                    reportPath = Path.Combine(Application.StartupPath, "..", "Reports", "RevenueReport.rpt");
                }
                
                if (!File.Exists(reportPath))
                {
                    MessageBox.Show($"Không tìm thấy file báo cáo:\n{reportPath}", 
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Load report from file (not embedded resource)
                reportDocument = new ReportDocument();
                reportDocument.Load(reportPath);

                // Bind to viewer
                crystalReportViewer1.ReportSource = reportDocument;
                crystalReportViewer1.DisplayStatusBar = false;
                crystalReportViewer1.DisplayToolbar = true;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải báo cáo:\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (reportDocument != null)
            {
                reportDocument.Close();
                reportDocument.Dispose();
            }
        }
    }
}
