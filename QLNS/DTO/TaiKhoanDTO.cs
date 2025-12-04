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
        public string Quyen { get; set; }

        public TaiKhoanDTO(string tenDangNhap, string matKhau, string maNV, string quyen)
        {
            TenDangNhap = tenDangNhap;
            MatKhau = matKhau;
            MaNV = maNV;
            Quyen = quyen;
        }

        public TaiKhoanDTO()
        {
        }
    }
}
