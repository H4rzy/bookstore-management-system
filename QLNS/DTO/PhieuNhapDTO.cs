using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS_DTO
{
    public class PhieuNhapDTO
    {
        public string SoPN { get; set; }
        public DateTime NgayNhap { get; set; }
        public string MaNV { get; set; }
        public string GhiChu { get; set; }

        public PhieuNhapDTO(string soPN, DateTime ngayNhap, string maNV, string ghiChu)
        {
            SoPN = soPN;
            NgayNhap = ngayNhap;
            MaNV = maNV;
            GhiChu = ghiChu;
        }

        public PhieuNhapDTO()
        {
        }
    }
}
