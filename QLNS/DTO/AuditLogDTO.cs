using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS_DTO
{
    /// <summary>
    /// Data Transfer Object for Audit Log
    /// Records all user activities in the system
    /// </summary>
    public class AuditLogDTO
    {
        public string MaLog { get; set; }
        public string TenDangNhap { get; set; }
        public string HanhDong { get; set; }
        public DateTime ThoiGian { get; set; }
        public string ChiTiet { get; set; }

        public AuditLogDTO()
        {
        }

        public AuditLogDTO(string maLog, string tenDangNhap, string hanhDong, DateTime thoiGian, string chiTiet)
        {
            MaLog = maLog;
            TenDangNhap = tenDangNhap;
            HanhDong = hanhDong;
            ThoiGian = thoiGian;
            ChiTiet = chiTiet;
        }
    }
}
