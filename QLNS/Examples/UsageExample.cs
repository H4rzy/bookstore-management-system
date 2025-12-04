using QLNS.BLL.Interfaces;
using QLNS.Common;
using QLNS.Models;
using System;
using System.Windows.Forms;

namespace QLNS.Examples
{
    /// <summary>
    /// Example usage of the 3-layer architecture
    /// Demonstrates how to use services in forms following SOLID principles
    /// </summary>
    public class UsageExample
    {
        // Example 1: Using Book Service
        public void ExampleUsingBookService()
        {
            // Get service from container (Dependency Injection)
            var sachService = ServiceContainer.Instance.Resolve<ISachService>();

            // Get all books
            var allBooks = sachService.GetAllBooks();

            // Search books
            var searchResults = sachService.SearchBooks("Clean Code");

            // Add a new book
            var newBook = new Sach
            {
                MaSach = "S004",
                TenSach = "Design Patterns",
                MaTheLoai = "TL003",
                MaNXB = "NXB01",
                TacGia = "Gang of Four",
                DonGiaNhap = 120000,
                DonGiaBan = 250000,
                SoLuongTon = 15
            };

            if (sachService.AddBook(newBook, out string errorMessage))
            {
                MessageBox.Show("Thêm sách thành công!", "Thông báo");
            }
            else
            {
                MessageBox.Show(errorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Example 2: Using Customer Service
        public void ExampleUsingCustomerService()
        {
            var khachHangService = ServiceContainer.Instance.Resolve<IKhachHangService>();

            // Add customer
            var newCustomer = new KhachHang
            {
                MaKH = "KH003",
                TenKH = "Nguyễn Văn C",
                DienThoai = "0901234567",
                DiaChi = "Hà Nội",
                LoaiKH = "Thường"
            };

            if (khachHangService.AddCustomer(newCustomer, out string errorMessage))
            {
                MessageBox.Show("Thêm khách hàng thành công!");
            }
            else
            {
                MessageBox.Show(errorMessage, "Lỗi");
            }
        }

        // Example 3: Creating an Invoice
        public void ExampleCreatingInvoice()
        {
            var hoaDonService = ServiceContainer.Instance.Resolve<IHoaDonService>();
            var sachService = ServiceContainer.Instance.Resolve<ISachService>();

            // Create invoice
            var hoaDon = new HoaDon
            {
                SoHD = "HD002",
                NgayBan = DateTime.Now,
                MaNV = "NV001",
                MaKH = "KH001",
                GhiChu = "Khách hàng VIP"
            };

            // Create invoice details
            var chiTiet = new System.Collections.Generic.List<ChiTietHoaDon>
            {
                new ChiTietHoaDon
                {
                    SoHD = "HD002",
                    MaSach = "S001",
                    SoLuong = 2,
                    DonGiaBan = 120000
                },
                new ChiTietHoaDon
                {
                    SoHD = "HD002",
                    MaSach = "S002",
                    SoLuong = 1,
                    DonGiaBan = 180000
                }
            };

            // Create invoice (service will validate stock and update inventory)
            if (hoaDonService.CreateInvoice(hoaDon, chiTiet, out string errorMessage))
            {
                MessageBox.Show("Tạo hóa đơn thành công!");
                
                // Calculate total
                var total = hoaDonService.CalculateInvoiceTotal("HD002");
                MessageBox.Show($"Tổng tiền: {total:N0} VNĐ");
            }
            else
            {
                MessageBox.Show(errorMessage, "Lỗi");
            }
        }

        // Example 4: Using in a Form
        public class ExampleForm : Form
        {
            private readonly ISachService _sachService;
            private DataGridView dataGridView;

            public ExampleForm()
            {
                // Get service from container
                _sachService = ServiceContainer.Instance.Resolve<ISachService>();
                
                InitializeComponents();
                LoadBooks();
            }

            private void InitializeComponents()
            {
                dataGridView = new DataGridView
                {
                    Dock = DockStyle.Fill
                };
                this.Controls.Add(dataGridView);
            }

            private void LoadBooks()
            {
                var books = _sachService.GetAllBooks();
                dataGridView.DataSource = books;
            }

            private void SearchButton_Click(object sender, EventArgs e)
            {
                var keyword = "keyword"; // from textbox
                var results = _sachService.SearchBooks(keyword);
                dataGridView.DataSource = results;
            }
        }
    }
}
