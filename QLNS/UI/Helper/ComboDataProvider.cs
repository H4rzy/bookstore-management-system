using System;
using System.Collections.Generic;
using QLNS_BLL;
using QLNS_DTO;

namespace QLNS_UI.Common
{
    /// <summary>
    /// Provider class để cache dữ liệu cho ComboBox
    /// Tránh gọi BLL nhiều lần
    /// </summary>
    public static class ComboDataProvider
    {
        // ========== CACHE STORAGE ==========
        private static List<TheLoaiDTO> _theLoaiCache = null;
        private static List<NhaXuatBanDTO> _nhaXuatBanCache = null;
        private static List<KhachHangDTO> _khachHangCache = null;
        private static List<NhanVienDTO> _nhanVienCache = null;

        // ========== GET METHODS (LAZY LOAD + CACHE) ==========

        public static List<TheLoaiDTO> GetTheLoai()
        {
            if (_theLoaiCache == null)
            {
                RefreshTheLoai();
            }
            return _theLoaiCache ?? new List<TheLoaiDTO>();
        }

        public static List<NhaXuatBanDTO> GetNhaXuatBan()
        {
            if (_nhaXuatBanCache == null)
            {
                RefreshNhaXuatBan();
            }
            return _nhaXuatBanCache ?? new List<NhaXuatBanDTO>();
        }

        public static List<KhachHangDTO> GetKhachHang()
        {
            if (_khachHangCache == null)
            {
                RefreshKhachHang();
            }
            return _khachHangCache ?? new List<KhachHangDTO>();
        }

        public static List<NhanVienDTO> GetNhanVien()
        {
            if (_nhanVienCache == null)
            {
                RefreshNhanVien();
            }
            return _nhanVienCache ?? new List<NhanVienDTO>();
        }

        // ========== REFRESH METHODS ==========

        public static void RefreshTheLoai()
        {
            try
            {
                TheLoai_BLL bll = new TheLoai_BLL();
                _theLoaiCache = bll.LayDanhSachTheLoai();
            }
            catch
            {
                _theLoaiCache = new List<TheLoaiDTO>();
            }
        }

        public static void RefreshNhaXuatBan()
        {
            try
            {
                NhaXuatBan_BLL bll = new NhaXuatBan_BLL();
                _nhaXuatBanCache = bll.LayDanhSachNhaXuatBan();
            }
            catch
            {
                _nhaXuatBanCache = new List<NhaXuatBanDTO>();
            }
        }

        public static void RefreshKhachHang()
        {
            try
            {
                KhachHang_BLL bll = new KhachHang_BLL();
                _khachHangCache = bll.LayDanhSachKhachHang();
            }
            catch
            {
                _khachHangCache = new List<KhachHangDTO>();
            }
        }

        public static void RefreshNhanVien()
        {
            try
            {
                NhanVien_BLL bll = new NhanVien_BLL();
                _nhanVienCache = bll.LayDanhSachNhanVien();
            }
            catch
            {
                _nhanVienCache = new List<NhanVienDTO>();
            }
        }

        public static void RefreshAll()
        {
            RefreshTheLoai();
            RefreshNhaXuatBan();
            RefreshKhachHang();
            RefreshNhanVien();
        }

        // ========== CLEAR CACHE ==========

        public static void ClearCache()
        {
            _theLoaiCache = null;
            _nhaXuatBanCache = null;
            _khachHangCache = null;
            _nhanVienCache = null;
        }
    }
}
