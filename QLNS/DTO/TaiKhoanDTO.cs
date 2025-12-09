using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS_DTO
{
    public class TaiKhoanDTO
    {
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string MaNV { get; set; }
        public string MaRole { get; set; }
        public bool TrangThai { get; set; }

        // Legacy property for backward compatibility
        [Obsolete("Use MaRole instead")]
        public string Quyen 
        { 
            get => MaRole; 
            set => MaRole = value; 
        }

        public TaiKhoanDTO(string tenDangNhap, string matKhau, string maNV, string maRole, bool trangThai = true)
        {
            TenDangNhap = tenDangNhap;
            MatKhau = matKhau;
            MaNV = maNV;
            MaRole = maRole;
            TrangThai = trangThai;
        }

        public TaiKhoanDTO()
        {
            TrangThai = true;
        }
    }
}
