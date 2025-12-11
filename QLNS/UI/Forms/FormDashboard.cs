using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLNS.UI.Forms;
using QLNS_BLL;
using QLNS_DTO;

namespace QLNS.Forms
{
    public partial class FormDashboard : Form
    {
        private Sach_BLL sachBLL = new Sach_BLL();
        private PhieuNhap_BLL phieuNhapBLL = new PhieuNhap_BLL();
        private HoaDon_BLL hoaDonBLL = new HoaDon_BLL();
        private NhanVien_BLL nhanVienBLL = new NhanVien_BLL();
        private KhachHang_BLL khachHangBLL = new KhachHang_BLL();

        public FormDashboard()
        {
            InitializeComponent();
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            LoadStatistics();
            LoadRecentActivities();
        }

        private void LoadStatistics()
        {
            try
            {
                // Load total counts
                var allBooks = sachBLL.LayTatCaSach();
                var allImports = phieuNhapBLL.LayDanhSachPhieuNhap();
                var allReceipts = hoaDonBLL.LayDanhSachHoaDon();
                var allEmployees = nhanVienBLL.LayDanhSachNhanVien();
                var allCustomers = khachHangBLL.LayDanhSachKhachHang();

                lblTotalBooks.Text = allBooks.Count.ToString();
                lblTotalImports.Text = allImports.Count.ToString();
                lblTotalReceipts.Text = allReceipts.Count.ToString();
                lblTotalEmployees.Text = allEmployees.Count.ToString();
                lblTotalCustomers.Text = allCustomers.Count.ToString();

                // Calculate total inventory value
                decimal totalValue = allBooks.Sum(s => s.SoLuongTon * s.DonGiaBan);
                lblTotalValue.Text = $"{totalValue:N0} VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thống kê: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRecentActivities()
        {
            try
            {
                // Recent Imports (last 5)
                var recentImports = phieuNhapBLL.LayDanhSachPhieuNhap()
                    .OrderByDescending(p => p.NgayNhap)
                    .Take(5)
                    .ToList();

                dgvRecentImports.DataSource = recentImports.Select(p => new
                {
                    p.SoPN,
                    NgayNhap = p.NgayNhap.ToString("dd/MM/yyyy"),
                    p.MaNV,
                    p.GhiChu
                }).ToList();

                // Recent Receipts (last 5)
                var recentReceipts = hoaDonBLL.LayDanhSachHoaDon()
                    .OrderByDescending(h => h.NgayBan)
                    .Take(5)
                    .ToList();

                dgvRecentReceipts.DataSource = recentReceipts.Select(h => new
                {
                    h.SoHD,
                    NgayBan = h.NgayBan.ToString("dd/MM/yyyy"),
                    h.MaNV,
                    h.MaKH
                }).ToList();

                // Recent Books (last 5 added - by MaSach)
                var recentBooks = sachBLL.LayTatCaSach()
                    .OrderByDescending(s => s.MaSach)
                    .Take(5)
                    .ToList();

                dgvRecentBooks.DataSource = recentBooks.Select(s => new
                {
                    s.MaSach,
                    s.TenSach,
                    s.SoLuongTon,
                    DonGiaBan = $"{s.DonGiaBan:N0} VNĐ"
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải hoạt động gần đây: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadStatistics();
            LoadRecentActivities();
            MessageBox.Show("Đã làm mới dữ liệu!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
