using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLNS_DTO;
using QLNS_DAL;

namespace QLNS_BLL
{
    public class TheLoai_BLL
    {
        private TheLoaiDAL dal = new TheLoaiDAL();

        public bool ThemTheLoai(TheLoaiDTO dto)
        {
            try
            {
                if (dto == null) return false;
                if (string.IsNullOrEmpty(dto.MaTheLoai) || string.IsNullOrEmpty(dto.TenTheLoai))
                    return false;

                if (dal.kiemTraTrungMa(dto.MaTheLoai))
                    return false;

                return dal.themTheLoai(dto);
            }
            catch { return false; }
        }

        public bool CapNhatTheLoai(TheLoaiDTO dto)
        {
            try
            {
                if (dto == null) return false;
                if (string.IsNullOrEmpty(dto.MaTheLoai) || string.IsNullOrEmpty(dto.TenTheLoai))
                    return false;

                return dal.capNhatTheLoai(dto);
            }
            catch { return false; }
        }

        public bool XoaTheLoai(string maTheLoai)
        {
            try
            {
                if (string.IsNullOrEmpty(maTheLoai)) return false;

                // Kiểm tra có sách thuộc thể loại này không
                SachDAL sachDAL = new SachDAL();
                var dsSach = sachDAL.laySachTheoTheLoai(maTheLoai);
                if (dsSach != null && dsSach.Count > 0)
                    return false;

                return dal.xoaTheLoai(maTheLoai);
            }
            catch { return false; }
        }

        public List<TheLoaiDTO> LayDanhSachTheLoai()
        {
            try
            {
                return dal.layDanhSachTheLoai();
            }
            catch { return new List<TheLoaiDTO>(); }
        }

        public TheLoaiDTO LayTheLoaiTheoMa(string maTheLoai)
        {
            try
            {
                if (string.IsNullOrEmpty(maTheLoai)) return null;
                return dal.layTheLoaiTheoMa(maTheLoai);
            }
            catch { return null; }
        }

        public System.Data.DataTable TimKiemTheLoai(string keyword)
        {
            try
            {
                if (string.IsNullOrEmpty(keyword)) return new System.Data.DataTable();
                return dal.timKiemTheLoaiTheoTen(keyword);
            }
            catch { return new System.Data.DataTable(); }
        }
    }
}
