using System;
using System.Collections.Generic;
using System.Data;
using QLNS_BLL;
using QLNS_DTO;

namespace QLNS_UI.Common
{
    /// <summary>
    /// Helper class để load dữ liệu từ BLL cho Form
    /// </summary>
    public static class FormDataHelper
    {
        // ========== LOAD METHODS ==========

        public static List<TheLoaiDTO> LoadTheLoai()
        {
            try
            {
                TheLoai_BLL bll = new TheLoai_BLL();
                return bll.LayDanhSachTheLoai() ?? new List<TheLoaiDTO>();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowLoadDataError("thể loại", ex.Message);
                return new List<TheLoaiDTO>();
            }
        }

        public static List<NhaXuatBanDTO> LoadNhaXuatBan()
        {
            try
            {
                NhaXuatBan_BLL bll = new NhaXuatBan_BLL();
                return bll.LayDanhSachNhaXuatBan() ?? new List<NhaXuatBanDTO>();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowLoadDataError("nhà xuất bản", ex.Message);
                return new List<NhaXuatBanDTO>();
            }
        }

        public static List<SachDTO> LoadSach()
        {
            try
            {
                Sach_BLL bll = new Sach_BLL();
                return bll.LayDanhSachSach() ?? new List<SachDTO>();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowLoadDataError("sách", ex.Message);
                return new List<SachDTO>();
            }
        }

        public static List<SachDTO> LoadTatCaSach()
        {
            try
            {
                Sach_BLL bll = new Sach_BLL();
                return bll.LayTatCaSach() ?? new List<SachDTO>();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowLoadDataError("sách", ex.Message);
                return new List<SachDTO>();
            }
        }

        public static List<KhachHangDTO> LoadKhachHang()
        {
            try
            {
                KhachHang_BLL bll = new KhachHang_BLL();
                return bll.LayDanhSachKhachHang() ?? new List<KhachHangDTO>();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowLoadDataError("khách hàng", ex.Message);
                return new List<KhachHangDTO>();
            }
        }

        public static List<NhanVienDTO> LoadNhanVien()
        {
            try
            {
                NhanVien_BLL bll = new NhanVien_BLL();
                return bll.LayDanhSachNhanVien() ?? new List<NhanVienDTO>();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowLoadDataError("nhân viên", ex.Message);
                return new List<NhanVienDTO>();
            }
        }

        public static List<TaiKhoanDTO> LoadTaiKhoan()
        {
            try
            {
                TaiKhoan_BLL bll = new TaiKhoan_BLL();
                return bll.LayDanhSachTaiKhoan() ?? new List<TaiKhoanDTO>();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowLoadDataError("tài khoản", ex.Message);
                return new List<TaiKhoanDTO>();
            }
        }

        public static List<PhieuNhapDTO> LoadPhieuNhap()
        {
            try
            {
                PhieuNhap_BLL bll = new PhieuNhap_BLL();
                return bll.LayDanhSachPhieuNhap() ?? new List<PhieuNhapDTO>();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowLoadDataError("phiếu nhập", ex.Message);
                return new List<PhieuNhapDTO>();
            }
        }

        public static List<HoaDonDTO> LoadHoaDon()
        {
            try
            {
                HoaDon_BLL bll = new HoaDon_BLL();
                return bll.LayDanhSachHoaDon() ?? new List<HoaDonDTO>();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowLoadDataError("hóa đơn", ex.Message);
                return new List<HoaDonDTO>();
            }
        }

        // ========== SEARCH METHODS ==========

        public static DataTable SearchTheLoai(string keyword)
        {
            try
            {
                TheLoai_BLL bll = new TheLoai_BLL();
                return bll.TimKiemTheLoai(keyword) ?? new DataTable();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowSearchError("thể loại", ex.Message);
                return new DataTable();
            }
        }

        public static DataTable SearchSach(string keyword)
        {
            try
            {
                Sach_BLL bll = new Sach_BLL();
                return bll.TimKiemSach(keyword) ?? new DataTable();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowSearchError("sách", ex.Message);
                return new DataTable();
            }
        }

        public static DataTable SearchKhachHang(string keyword)
        {
            try
            {
                KhachHang_BLL bll = new KhachHang_BLL();
                return bll.TimKiemKhachHang(keyword) ?? new DataTable();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowSearchError("khách hàng", ex.Message);
                return new DataTable();
            }
        }

        public static DataTable SearchNhanVien(string keyword)
        {
            try
            {
                NhanVien_BLL bll = new NhanVien_BLL();
                return bll.TimKiemNhanVien(keyword) ?? new DataTable();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowSearchError("nhân viên", ex.Message);
                return new DataTable();
            }
        }

        public static DataTable SearchNhaXuatBan(string keyword)
        {
            try
            {
                NhaXuatBan_BLL bll = new NhaXuatBan_BLL();
                return bll.TimKiemNhaXuatBan(keyword) ?? new DataTable();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowSearchError("nhà xuất bản", ex.Message);
                return new DataTable();
            }
        }
    }
}
