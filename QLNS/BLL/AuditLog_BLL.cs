using System;
using System.Collections.Generic;
using QLNS_DTO;
using QLNS_DAL;

namespace QLNS_BLL
{
    public class AuditLog_BLL
    {
        private AuditLogDAL dal = new AuditLogDAL();

        /// <summary>
        /// Log user activity
        /// </summary>
        public bool LogActivity(string action, string details = "")
        {
            try
            {
                var log = new AuditLogDTO
                {
                    MaLog = "LOG" + DateTime.Now.ToString("yyyyMMddHHmmssfff"),
                    TenDangNhap = QLNS.CurrentUser.Username ?? "SYSTEM",
                    HanhDong = action,
                    ThoiGian = DateTime.Now,
                    ChiTiet = details
                };

                return dal.ThemLogHoatDong(log);
            }
            catch
            {
                // Don't throw exception for audit log failures
                return false;
            }
        }

        /// <summary>
        /// Get activity history for current user
        /// </summary>
        public List<AuditLogDTO> GetActivityHistory(DateTime? fromDate = null, DateTime? toDate = null)
        {
            try
            {
                string username = QLNS.CurrentUser.Username;
                if (string.IsNullOrEmpty(username))
                    return new List<AuditLogDTO>();

                return dal.LayLichSuHoatDong(username, fromDate, toDate);
            }
            catch
            {
                return new List<AuditLogDTO>();
            }
        }

        /// <summary>
        /// Get all activity history (Admin only)
        /// </summary>
        public List<AuditLogDTO> GetAllActivityHistory(string username = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            try
            {
                return dal.LayLichSuHoatDong(username, fromDate, toDate);
            }
            catch
            {
                return new List<AuditLogDTO>();
            }
        }
    }
}
