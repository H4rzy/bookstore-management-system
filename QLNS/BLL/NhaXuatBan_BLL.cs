using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLNS_DTO;
using QLNS_DAL;

namespace QLNS_BLL
{
    public class NhaXuatBan_BLL
    {
        private NhaXuatBanDAL dal = new NhaXuatBanDAL();

        public bool ThemNhaXuatBan(NhaXuatBanDTO dto)
        {
            try
            {
                if (dto == null) return false;
                if (string.IsNullOrEmpty(dto.MaNXB) || string.IsNullOrEmpty(dto.TenNXB))
                    return false;

                if (dal.kiemTraTrungMa(dto.MaNXB))
                    return false;

                return dal.themNhaXuatBan(dto);
            }
            catch { return false; }
        }

        public bool CapNhatNhaXuatBan(NhaXuatBanDTO dto)
        {
            try
            {
                if (dto == null) return false;
                if (string.IsNullOrEmpty(dto.MaNXB) || string.IsNullOrEmpty(dto.TenNXB))
                    return false;

                return dal.capNhatNhaXuatBan(dto);
            }
            catch { return false; }
        }

        public bool XoaNhaXuatBan(string maNXB)
        {
            try
            {
                if (string.IsNullOrEmpty(maNXB)) return false;

                // Kiểm tra có sách của NXB này không
                SachDAL sachDAL = new SachDAL();
                var dsSach = sachDAL.laySachTheoNXB(maNXB);
                if (dsSach != null && dsSach.Count > 0)
                    return false;

                return dal.xoaNhaXuatBan(maNXB);
            }
            catch { return false; }
        }

        public List<NhaXuatBanDTO> LayDanhSachNhaXuatBan()
        {
            try
            {
                return dal.layDanhSachNhaXuatBan();
            }
            catch { return new List<NhaXuatBanDTO>(); }
        }

        public NhaXuatBanDTO LayNhaXuatBanTheoMa(string maNXB)
        {
            try
            {
                if (string.IsNullOrEmpty(maNXB)) return null;
                return dal.layNhaXuatBanTheoMa(maNXB);
            }
            catch { return null; }
        }

        public System.Data.DataTable TimKiemNhaXuatBan(string keyword)
        {
            try
            {
                if (string.IsNullOrEmpty(keyword)) return new System.Data.DataTable();
                return dal.timKiemNhaXuatBanTheoTen(keyword);
            }
            catch { return new System.Data.DataTable(); }
        }
    }
}
