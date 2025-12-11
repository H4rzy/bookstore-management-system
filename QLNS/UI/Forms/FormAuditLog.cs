using System;
using System.Windows.Forms;
using QLNS;
using QLNS_BLL;
using QLNS_DTO;
using QLNS_UI.Common;

namespace QLNS.UI.Forms
{
    public partial class FormAuditLog : Form
    {
        private AuditLog_BLL auditLogBLL = new AuditLog_BLL();
        private PermissionService permissionService = new PermissionService();

        public FormAuditLog()
        {
            InitializeComponent();
        }

        private void FormAuditLog_Load(object sender, EventArgs e)
        {
            // Set default date range (last 7 days)
            dtpToDate.Value = DateTime.Now;
            dtpFromDate.Value = DateTime.Now.AddDays(-7);
            
            // Check if admin - only admin can see all users
            if (!CurrentUser.IsAdmin)
            {
                txtUsername.Text = CurrentUser.Username;
                txtUsername.Enabled = false;
                lblInfo.Text = "Bạn chỉ có thể xem lịch sử hoạt động của mình.";
            }
            else
            {
                lblInfo.Text = "Admin có thể xem lịch sử hoạt động của tất cả người dùng.";
            }
            
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                string username = txtUsername.Text.Trim();
                DateTime fromDate = dtpFromDate.Value.Date;
                DateTime toDate = dtpToDate.Value.Date.AddDays(1).AddSeconds(-1); // End of day
                
                System.Collections.Generic.List<AuditLogDTO> logs;
                
                if (CurrentUser.IsAdmin && string.IsNullOrEmpty(username))
                {
                    // Admin viewing all logs
                    logs = auditLogBLL.GetAllActivityHistory(null, fromDate, toDate);
                }
                else if (CurrentUser.IsAdmin)
                {
                    // Admin viewing specific user's logs
                    logs = auditLogBLL.GetAllActivityHistory(username, fromDate, toDate);
                }
                else
                {
                    // Regular user viewing their own logs
                    logs = auditLogBLL.GetActivityHistory(fromDate, toDate);
                }
                
                // Display in DataGridView
                var displayData = logs.ConvertAll(log => new
                {
                    ThoiGian = log.ThoiGian.ToString("dd/MM/yyyy HH:mm:ss"),
                    TenDangNhap = log.TenDangNhap,
                    HanhDong = log.HanhDong,
                    ChiTiet = log.ChiTiet
                });
                
                dgvAuditLog.DataSource = displayData;
                
                if (dgvAuditLog.Columns.Count > 0)
                {
                    dgvAuditLog.Columns["ThoiGian"].HeaderText = "Thời Gian";
                    dgvAuditLog.Columns["TenDangNhap"].HeaderText = "Người Dùng";
                    dgvAuditLog.Columns["HanhDong"].HeaderText = "Hành Động";
                    dgvAuditLog.Columns["ChiTiet"].HeaderText = "Chi Tiết";
                    
                    dgvAuditLog.Columns["ThoiGian"].Width = 150;
                    dgvAuditLog.Columns["TenDangNhap"].Width = 100;
                    dgvAuditLog.Columns["HanhDong"].Width = 150;
                    dgvAuditLog.Columns["ChiTiet"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                
                lblCount.Text = $"Tổng số: {logs.Count} bản ghi";
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi tải dữ liệu", ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (CurrentUser.IsAdmin)
            {
                txtUsername.Clear();
            }
            dtpFromDate.Value = DateTime.Now.AddDays(-7);
            dtpToDate.Value = DateTime.Now;
            LoadData();
        }
    }
}
