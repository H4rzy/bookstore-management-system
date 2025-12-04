using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS_DTO
{
    public class HoaDonDTO
    {
        public string SoHD { get; set; }
        public DateTime NgayBan { get; set; }
        public string MaNV { get; set; }
        public string MaKH { get; set; }
        public string GhiChu { get; set; }

        public HoaDonDTO(string soHD, DateTime ngayBan, string maNV, string maKH, string ghiChu)
        {
            SoHD = soHD;
            NgayBan = ngayBan;
            MaNV = maNV;
            MaKH = maKH;
            GhiChu = ghiChu;
        }

        public HoaDonDTO()
        {
        }
    }
}
