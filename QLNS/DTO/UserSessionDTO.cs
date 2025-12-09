using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS_DTO
{
    /// <summary>
    /// User Session Data Transfer Object
    /// Stores current logged-in user information and permissions
    /// </summary>
    public class UserSessionDTO
    {
        public string TenDangNhap { get; set; }
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public string MaRole { get; set; }
        public string TenRole { get; set; }
        public List<string> QuyenList { get; set; }
        public DateTime LoginTime { get; set; }

        public UserSessionDTO()
        {
            QuyenList = new List<string>();
            LoginTime = DateTime.Now;
        }
    }
}
