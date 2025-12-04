using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS_DTO
{
    public class NhaXuatBanDTO
    {
        public string MaNXB { get; set; }
        public string TenNXB { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }

        public NhaXuatBanDTO(string maNXB, string tenNXB, string diaChi, string dienThoai)
        {
            MaNXB = maNXB;
            TenNXB = tenNXB;
            DiaChi = diaChi;
            DienThoai = dienThoai;
        }

        public NhaXuatBanDTO()
        {
        }
    }
}
