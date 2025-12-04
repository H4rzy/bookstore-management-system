using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS_DTO
{
    public class NhanVienDTO
    {
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public bool GioiTinh { get; set; }
        public string DienThoai { get; set; }
        public string DiaChi { get; set; }
        public string ChucVu { get; set; }

        public NhanVienDTO(string maNV, string tenNV, bool gioiTinh, string dienThoai, string diaChi, string chucVu)
        {
            MaNV = maNV;
            TenNV = tenNV;
            GioiTinh = gioiTinh;
            DienThoai = dienThoai;
            DiaChi = diaChi;
            ChucVu = chucVu;
        }

        public NhanVienDTO()
        {
        }
    }
}
