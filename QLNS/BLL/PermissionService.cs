using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLNS_DTO;
using QLNS_DAL;

namespace QLNS_BLL
{
    /// <summary>
    /// Permission Service - Manages authorization and audit logging
    /// </summary>
    public class PermissionService
    {
        private QuyenDAL quyenDAL = new QuyenDAL();
        private AuditLogDAL auditLogDAL = new AuditLogDAL();

        /// <summary>
        /// Get list of permitted screen codes (MaManHinh) for a user
        /// </summary>
        public List<string> GetUserPermissions(string tenDangNhap)
        {
            try
            {
                return quyenDAL.LayQuyenTheoUser(tenDangNhap);
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting user permissions: " + ex.Message);
            }
        }

        /// <summary>
        /// Check if user has permission to access a specific screen
        /// </summary>
        public bool CheckPermission(string tenDangNhap, string maManHinh)
        {
            try
            {
                var permissions = GetUserPermissions(tenDangNhap);
                return permissions.Contains(maManHinh);
            }
            catch (Exception ex)
            {
                throw new Exception("Error checking permission: " + ex.Message);
            }
        }

        /// <summary>
        /// Get screens with permissions for a role (used for menu building)
        /// </summary>
        public List<DM_ManHinhDTO> GetMenuFeaturesByRole(string maRole)
        {
            try
            {
                return quyenDAL.LayManHinhTheoQuyen(maRole);
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting menu features: " + ex.Message);
            }
        }

        /// <summary>
        /// Log user activity to audit log
        /// </summary>
        public void LogActivity(string tenDangNhap, string hanhDong, string chiTiet)
        {
            try
            {
                AuditLogDTO log = new AuditLogDTO
                {
                    MaLog = Guid.NewGuid().ToString(),
                    TenDangNhap = tenDangNhap,
                    HanhDong = hanhDong,
                    ThoiGian = DateTime.Now,
                    ChiTiet = chiTiet
                };
                auditLogDAL.ThemLogHoatDong(log);
            }
            catch (Exception ex)
            {
                // Don't throw - logging should not break application flow
                // Could log to file or event log instead
                System.Diagnostics.Debug.WriteLine($"Audit log error: {ex.Message}");
            }
        }

        /// <summary>
        /// Get activity history for a user
        /// </summary>
        public List<AuditLogDTO> GetUserActivityHistory(string tenDangNhap, DateTime? fromDate = null, DateTime? toDate = null)
        {
            try
            {
                return auditLogDAL.LayLichSuHoatDong(tenDangNhap, fromDate, toDate);
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting activity history: " + ex.Message);
            }
        }
    }
}
