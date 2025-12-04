using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLNS_BLL;
using QLNS_DTO;

namespace QLNS.UI.Forms
{
    public partial class FormOrders : Form
    {
        private string maKH;
        private HoaDon_BLL hoaDonBLL = new HoaDon_BLL();
        private ChiTietHoaDon_BLL chiTietBLL = new ChiTietHoaDon_BLL();
        private Sach_BLL sachBLL = new Sach_BLL();

        public FormOrders(string maKH)
        {
            InitializeComponent();
            this.maKH = maKH;
        }

        private void FormOrders_Load(object sender, EventArgs e)
        {
            LoadOrderData();
        }

        private void LoadOrderData()
        {
            try
            {
                // Lấy danh sách hóa đơn của khách hàng
                var hoaDons = hoaDonBLL.LayHoaDonTheoKhachHang(maKH);

                // Tạo DataTable để hiển thị
                DataTable dt = new DataTable();
                dt.Columns.Add("Mã Hóa Đơn", typeof(string));
                dt.Columns.Add("Tên Sách", typeof(string));
                dt.Columns.Add("Số Lượng", typeof(int));
                dt.Columns.Add("Đơn Giá", typeof(decimal));
                dt.Columns.Add("Thành Tiền", typeof(decimal));
                dt.Columns.Add("Ngày Mua", typeof(DateTime));

                foreach (var hd in hoaDons)
                {
                    // Lấy chi tiết hóa đơn
                    var chiTiets = chiTietBLL.LayChiTiet(hd.SoHD);

                    foreach (var ct in chiTiets)
                    {
                        // Lấy tên sách
                        var sach = sachBLL.LaySachTheoMa(ct.MaSach);
                        string tenSach = sach != null ? sach.TenSach : ct.MaSach;

                        // Tính thành tiền
                        decimal thanhTien = ct.SoLuong * ct.DonGiaBan;

                        // Thêm vào DataTable
                        dt.Rows.Add(hd.SoHD, tenSach, ct.SoLuong, ct.DonGiaBan, thanhTien, hd.NgayBan);
                    }
                }

                // Hiển thị dữ liệu
                dgvOrders.DataSource = dt;

                // Định dạng cột
                if (dgvOrders.Columns.Count > 0)
                {
                    dgvOrders.Columns["Đơn Giá"].DefaultCellStyle.Format = "N0";
                    dgvOrders.Columns["Thành Tiền"].DefaultCellStyle.Format = "N0";
                    dgvOrders.Columns["Ngày Mua"].DefaultCellStyle.Format = "dd/MM/yyyy";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
