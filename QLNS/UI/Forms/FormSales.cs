using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QLNS_BLL;
using QLNS_DTO;
using QLNS_UI.Common;

namespace QLNS.UI.Forms
{
    public partial class FormSales : Form
    {
        private HoaDon_BLL hoaDonBLL = new HoaDon_BLL();
        private ChiTietHoaDon_BLL chiTietBLL = new ChiTietHoaDon_BLL();
        private KhachHang_BLL khachHangBLL = new KhachHang_BLL();
        private Sach_BLL sachBLL = new Sach_BLL();
        private AuditLog_BLL auditLogBLL = new AuditLog_BLL();
        private TheVIP_BLL vipBLL = new TheVIP_BLL();

        private string currentSoHD = string.Empty;
        private List<CartItem> cartItems = new List<CartItem>();
        private List<SachDTO> allBooks = new List<SachDTO>();
        private decimal discountAmount = 0;
        private decimal vipDiscountPercent = 0;
        private KhachHangDTO selectedCustomer = null; // Khách hàng đã chọn

        public FormSales()
        {
            InitializeComponent();
            InitializeData();
        }

        private void FormSales_Load(object sender, EventArgs e)
        {
            LoadBooks();
            ResetForm();
        }

        #region Initialization

        private void InitializeData()
        {
            // Setup DataGridViews
            SetupProductGrid();
            SetupCartGrid();
        }

        private void SetupProductGrid()
        {
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.Columns.Clear();
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.MultiSelect = false;
            dgvProducts.ReadOnly = true;

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaSach",
                HeaderText = "Mã sách",
                Name = "MaSach",
                Width = 100
            });

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenSach",
                HeaderText = "Tên sách",
                Name = "TenSach",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DonGiaBan",
                HeaderText = "Giá bán",
                Name = "DonGiaBan",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SoLuongTon",
                HeaderText = "Tồn kho",
                Name = "SoLuongTon",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
            });
        }

        private void SetupCartGrid()
        {
            dgvCart.AutoGenerateColumns = false;
            dgvCart.Columns.Clear();
            dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCart.MultiSelect = false;

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenSach",
                HeaderText = "Tên sách",
                Name = "TenSach",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true
            });

            // Editable quantity column
            var qtyColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SoLuong",
                HeaderText = "Số lượng",
                Name = "SoLuong",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
            };
            dgvCart.Columns.Add(qtyColumn);

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DonGiaBan",
                HeaderText = "Đơn giá",
                Name = "DonGiaBan",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight },
                ReadOnly = true
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ThanhTien",
                HeaderText = "Thành tiền",
                Name = "ThanhTien",
                Width = 140,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight },
                ReadOnly = true
            });
        }

        #endregion

        #region Data Loading

        /// <summary>
        /// Tra cứu khách hàng theo Mã hoặc SĐT
        /// </summary>
        private void SearchCustomer(string keyword)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(keyword))
                {
                    MessageBox.Show("Vui lòng nhập mã KH hoặc SĐT!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var customers = khachHangBLL.LayDanhSachKhachHang();
                var found = customers.FirstOrDefault(kh =>
                    kh.MaKH.ToUpper().Contains(keyword.ToUpper()) ||
                    (kh.DienThoai != null && kh.DienThoai.Contains(keyword)) ||
                    (kh.TenKH != null && kh.TenKH.ToUpper().Contains(keyword.ToUpper())));

                if (found != null)
                {
                    SelectCustomer(found);
                    MessageBox.Show($"Đã tìm thấy:\n{found.TenKH}\nSĐT: {found.DienThoai}",
                        "Tìm thấy", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCustomerSearch.Clear();
                }
                else
                {
                    MessageBox.Show($"Không tìm thấy khách hàng với: {keyword}", "Không tìm thấy",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SelectCustomer(KhachHangDTO kh)
        {
            selectedCustomer = kh;
            lblSelectedCustomer.Text = $"👤 {kh.TenKH} ({kh.MaKH})";
            lblSelectedCustomer.ForeColor = Color.FromArgb(0, 123, 255);

            // Check VIP status
            CheckVIPStatus(kh.MaKH);
        }

        private void CheckVIPStatus(string maKH)
        {
            try
            {
                if (vipBLL.KiemTraKhachHangLaVIP(maKH))
                {
                    var theVIP = vipBLL.LayTheVIPTheoKhachHang(maKH);
                    if (theVIP != null && theVIP.IsActive)
                    {
                        vipDiscountPercent = vipBLL.TinhPhanTramGiamGia(maKH);
                        lblSelectedCustomer.Text += $" ⭐ VIP {theVIP.HangVIP} (-{vipDiscountPercent}%)";
                        lblSelectedCustomer.ForeColor = GetVIPRankColor(theVIP.HangVIP);
                        ApplyVIPDiscount();
                    }
                }
                else
                {
                    vipDiscountPercent = 0;
                }
                CalculateTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi kiểm tra VIP: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearCustomer()
        {
            selectedCustomer = null;
            lblSelectedCustomer.Text = "👤 Khách lẻ";
            lblSelectedCustomer.ForeColor = Color.FromArgb(40, 167, 69);
            vipDiscountPercent = 0;
            txtDiscount.Clear();
            CalculateTotal();
        }

        private void txtCustomerSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SearchCustomer(txtCustomerSearch.Text.Trim());
            }
        }

        private void btnClearCustomer_Click(object sender, EventArgs e)
        {
            ClearCustomer();
        }

        private void LoadBooks()
        {
            try
            {
                allBooks = sachBLL.LayTatCaSach();
                dgvProducts.DataSource = allBooks;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách sách: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Search and Filter

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtSearch.Text.ToLower().Trim();
                
                if (string.IsNullOrEmpty(keyword))
                {
                    dgvProducts.DataSource = allBooks;
                }
                else
                {
                    var filtered = allBooks.Where(s =>
                        s.TenSach.ToLower().Contains(keyword) ||
                        s.MaSach.ToLower().Contains(keyword) ||
                        s.TacGia.ToLower().Contains(keyword)
                    ).ToList();
                    
                    dgvProducts.DataSource = filtered;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Thêm sách vào giỏ theo mã khi nhấn Enter
        /// </summary>
        private void txtBookCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                AddBookByCode();
            }
        }

        private void btnAddByCode_Click(object sender, EventArgs e)
        {
            AddBookByCode();
        }

        private void AddBookByCode()
        {
            try
            {
                string maSach = txtBookCode.Text.Trim().ToUpper();
                if (string.IsNullOrEmpty(maSach))
                {
                    MessageBox.Show("Vui lòng nhập mã sách!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBookCode.Focus();
                    return;
                }

                var sach = allBooks.FirstOrDefault(s => s.MaSach.ToUpper() == maSach);
                if (sach == null)
                {
                    MessageBox.Show($"Không tìm thấy sách với mã: {maSach}", "Không tìm thấy",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBookCode.SelectAll();
                    txtBookCode.Focus();
                    return;
                }

                // Check if book already in cart
                var existingItem = cartItems.FirstOrDefault(c => c.MaSach == sach.MaSach);
                if (existingItem != null)
                {
                    // Increment quantity
                    if (existingItem.SoLuong + 1 > sach.SoLuongTon)
                    {
                        MessageBox.Show($"Không đủ hàng trong kho!\nTồn kho: {sach.SoLuongTon}, Trong giỏ: {existingItem.SoLuong}",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    existingItem.SoLuong++;
                }
                else
                {
                    // Add new item
                    if (sach.SoLuongTon <= 0)
                    {
                        MessageBox.Show("Sách này đã hết hàng!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    cartItems.Add(new CartItem
                    {
                        MaSach = sach.MaSach,
                        TenSach = sach.TenSach,
                        SoLuong = 1,
                        DonGiaBan = sach.DonGiaBan,
                        SoLuongTonKho = sach.SoLuongTon
                    });
                }

                RefreshCart();
                txtBookCode.Clear();
                txtBookCode.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm sách: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Cart Management

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            AddSelectedProductToCart();
        }

        private void dgvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                AddSelectedProductToCart();
            }
        }

        private void AddSelectedProductToCart()
        {
            try
            {
                if (dgvProducts.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn sách để thêm vào giỏ!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var row = dgvProducts.SelectedRows[0];
                string maSach = row.Cells["MaSach"].Value?.ToString();
                
                if (string.IsNullOrEmpty(maSach))
                    return;

                var sach = allBooks.FirstOrDefault(s => s.MaSach == maSach);
                if (sach == null) return;

                // Check if book already in cart
                var existingItem = cartItems.FirstOrDefault(c => c.MaSach == maSach);
                if (existingItem != null)
                {
                    // Increment quantity
                    if (existingItem.SoLuong + 1 > sach.SoLuongTon)
                    {
                        MessageBox.Show($"Không đủ hàng trong kho!\nTồn kho: {sach.SoLuongTon}, Trong giỏ: {existingItem.SoLuong}",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    existingItem.SoLuong++;
                }
                else
                {
                    // Add new item
                    if (sach.SoLuongTon <= 0)
                    {
                        MessageBox.Show("Sách này đã hết hàng!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    cartItems.Add(new CartItem
                    {
                        MaSach = sach.MaSach,
                        TenSach = sach.TenSach,
                        SoLuong = 1,
                        DonGiaBan = sach.DonGiaBan,
                        SoLuongTonKho = sach.SoLuongTon
                    });
                }

                RefreshCart();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm vào giỏ: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveFromCart_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCart.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var row = dgvCart.SelectedRows[0];
                string maSach = cartItems[row.Index].MaSach;

                cartItems.RemoveAll(c => c.MaSach == maSach);
                RefreshCart();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa khỏi giỏ: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearCart_Click(object sender, EventArgs e)
        {
            if (cartItems.Count == 0) return;

            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa toàn bộ giỏ hàng?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                cartItems.Clear();
                RefreshCart();
            }
        }

        private void dgvCart_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgvCart.Columns["SoLuong"].Index)
                {
                    var row = dgvCart.Rows[e.RowIndex];
                    var item = cartItems[e.RowIndex];

                    if (int.TryParse(row.Cells["SoLuong"].Value?.ToString(), out int newQty))
                    {
                        if (newQty <= 0)
                        {
                            MessageBox.Show("Số lượng phải lớn hơn 0!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            row.Cells["SoLuong"].Value = item.SoLuong;
                            return;
                        }

                        if (newQty > item.SoLuongTonKho)
                        {
                            MessageBox.Show($"Không đủ hàng trong kho!\nTồn kho: {item.SoLuongTonKho}",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            row.Cells["SoLuong"].Value = item.SoLuong;
                            return;
                        }

                        item.SoLuong = newQty;
                        RefreshCart();
                    }
                    else
                    {
                        row.Cells["SoLuong"].Value = item.SoLuong;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật số lượng: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshCart()
        {
            dgvCart.DataSource = null;
            dgvCart.DataSource = cartItems.Select(c => new
            {
                c.TenSach,
                c.SoLuong,
                c.DonGiaBan,
                c.ThanhTien
            }).ToList();

            // Apply VIP discount if customer is VIP
            if (vipDiscountPercent > 0)
            {
                ApplyVIPDiscount();
            }

            CalculateTotal();
        }

        private Color GetVIPRankColor(string rank)
        {
            switch (rank)
            {
                case "Platinum":
                    return Color.FromArgb(78, 78, 78); // Dark gray/platinum
                case "Gold":
                    return Color.FromArgb(255, 215, 0); // Gold
                case "Silver":
                    return Color.FromArgb(192, 192, 192); // Silver
                default:
                    return Color.Black;
            }
        }

        private void ApplyVIPDiscount()
        {
            if (vipDiscountPercent > 0)
            {
                decimal subtotal = cartItems.Sum(c => c.ThanhTien);
                decimal vipDiscount = subtotal * (vipDiscountPercent / 100);

                // Update discount textbox
                txtDiscount.Text = vipDiscount.ToString("N0");
            }
        }

        #endregion

        #region Payment Calculation

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void txtPayment_TextChanged(object sender, EventArgs e)
        {
            CalculateChange();
        }

        private void CalculateTotal()
        {
            decimal subtotal = cartItems.Sum(c => c.ThanhTien);
            lblSubTotal.Text = $"{subtotal:N0} VNĐ";

            // Calculate discount
            discountAmount = 0;
            if (decimal.TryParse(txtDiscount.Text, out decimal discount) && discount > 0)
            {
                discountAmount = discount;
            }

            decimal total = subtotal - discountAmount;
            if (total < 0) total = 0;

            lblTotal.Text = $"{total:N0} VNĐ";

            CalculateChange();
        }

        private void CalculateChange()
        {
            decimal total = GetTotalAmount();
            
            if (decimal.TryParse(txtPayment.Text, out decimal payment))
            {
                decimal change = payment - total;
                lblChange.Text = $"{(change >= 0 ? change : 0):N0} VNĐ";
                
                // Highlight if payment is insufficient
                if (payment < total && payment > 0)
                {
                    lblChange.ForeColor = Color.Red;
                }
                else
                {
                    lblChange.ForeColor = Color.FromArgb(40, 167, 69);
                }
            }
            else
            {
                lblChange.Text = "0 VNĐ";
                lblChange.ForeColor = Color.FromArgb(40, 167, 69);
            }
        }

        private decimal GetTotalAmount()
        {
            decimal subtotal = cartItems.Sum(c => c.ThanhTien);
            return subtotal - discountAmount;
        }

        #endregion

        #region Complete Sale

        private void btnCompleteSale_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (cartItems.Count == 0)
                {
                    MessageBox.Show("Giỏ hàng trống! Vui lòng thêm sản phẩm.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check payment
                decimal total = GetTotalAmount();
                if (!decimal.TryParse(txtPayment.Text, out decimal payment) || payment < total)
                {
                    MessageBox.Show($"Số tiền thanh toán không đủ!\nTổng cần thanh toán: {total:N0} VNĐ",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPayment.Focus();
                    return;
                }

                // Validate stock for all items
                foreach (var item in cartItems)
                {
                    if (!sachBLL.KiemTraTonKhoDu(item.MaSach, item.SoLuong))
                    {
                        MessageBox.Show($"Không đủ hàng trong kho cho '{item.TenSach}'!",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Confirm
                var result = MessageBox.Show(
                    $"Xác nhận hoàn tất bán hàng?\n\nTổng tiền: {total:N0} VNĐ\nKhách thanh toán: {payment:N0} VNĐ\nTiền thối: {(payment - total):N0} VNĐ",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;

                // Create Invoice
                currentSoHD = hoaDonBLL.TaoSoHDMoi();
                
                string maKH = selectedCustomer?.MaKH;

                var hoaDon = new HoaDonDTO
                {
                    SoHD = currentSoHD,
                    NgayBan = DateTime.Now,
                    MaNV = CurrentUser.MaNV,
                    MaKH = maKH,
                    GhiChu = $"Giảm giá: {discountAmount:N0} VNĐ"
                };

                try
                {
                    if (!hoaDonBLL.ThemHoaDon(hoaDon))
                    {
                        MessageBox.Show($"Lỗi khi tạo hóa đơn!\nSoHD: {currentSoHD}\nMaNV: {CurrentUser.MaNV}", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                catch (Exception exHD)
                {
                    MessageBox.Show($"Lỗi chi tiết: {exHD.Message}\n\nSoHD: {currentSoHD}\nMaNV: {CurrentUser.MaNV}\nMaKH: {maKH ?? "NULL"}", 
                        "Lỗi khi tạo hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Add invoice details
                bool allDetailsAdded = true;
                foreach (var item in cartItems)
                {
                    var chiTiet = new ChiTietHoaDonDTO
                    {
                        SoHD = currentSoHD,
                        MaSach = item.MaSach,
                        SoLuong = item.SoLuong,
                        DonGiaBan = item.DonGiaBan
                    };

                    if (!chiTietBLL.ThemChiTiet(chiTiet))
                    {
                        allDetailsAdded = false;
                        break;
                    }
                }

                if (!allDetailsAdded)
                {
                    MessageBox.Show("Lỗi khi thêm chi tiết hóa đơn!\nVui lòng kiểm tra lại tồn kho.",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    // Rollback: delete the invoice
                    hoaDonBLL.XoaHoaDon(currentSoHD);
                    return;
                }

                // Log successful sale
                string logDetails = $"Hóa đơn: {currentSoHD}, Tổng tiền: {total:N0} VNĐ, Số lượng mặt hàng: {cartItems.Count}";
                auditLogBLL.LogActivity("BÁN HÀNG", logDetails);

                // Update VIP points if customer is VIP
                if (!string.IsNullOrEmpty(maKH) && vipBLL.KiemTraKhachHangLaVIP(maKH))
                {
                    // Add points (1 point per 1,000 VND)
                    int pointsToAdd = (int)(total / 1000);
                    if (pointsToAdd > 0)
                    {
                        vipBLL.CongDiemTichLuy(maKH, pointsToAdd);
                        logDetails = $"Cộng {pointsToAdd} điểm VIP cho KH: {maKH}";
                    }
                }

                // Success
                string successMsg = $"Bán hàng thành công!\n\nSố hóa đơn: {currentSoHD}\nTổng tiền: {total:N0} VNĐ\nTiền thối: {(payment - total):N0} VNĐ";
                
                if (vipDiscountPercent > 0)
                {
                    successMsg += $"\n\n⭐ Đã áp dụng giảm giá VIP {vipDiscountPercent}%";
                    if (!string.IsNullOrEmpty(maKH))
                    {
                        int points = (int)(total / 1000);
                        if (points > 0)
                        {
                            successMsg += $"\n💎 Đã cộng {points:N0} điểm tích lũy";
                        }
                    }
                }
                
                MessageBox.Show(successMsg, "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Ask if user wants to print invoice
                var printResult = MessageBox.Show(
                    "Bạn có muốn in hóa đơn không?",
                    "In Hóa Đơn",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (printResult == DialogResult.Yes)
                {
                    try
                    {
                        // Get customer name
                        string customerName = selectedCustomer != null 
                            ? $"{selectedCustomer.TenKH} ({selectedCustomer.MaKH})" 
                            : "Khách lẻ";

                        // Generate HTML
                        string html = InvoicePrintHelper.GenerateInvoiceHTML(
                            currentSoHD,
                            DateTime.Now,
                            customerName,
                            $"{CurrentUser.MaNV} - {CurrentUser.TenNV}",
                            cartItems,
                            discountAmount,
                            total,
                            payment,
                            payment - total
                        );
                        
                        // Show print dialog
                        InvoicePrintHelper.PrintInvoice(html);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi in hóa đơn: {ex.Message}",
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                // Reset form
                ResetForm();
                LoadBooks(); // Refresh stock
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hoàn tất bán hàng: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Form Reset

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (cartItems.Count > 0)
            {
                var result = MessageBox.Show("Bạn có chắc chắn muốn hủy? Giỏ hàng sẽ bị xóa.",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    ResetForm();
                }
            }
        }

        private void ResetForm()
        {
            cartItems.Clear();
            currentSoHD = hoaDonBLL.TaoSoHDMoi();
            
            lblInvoiceNumber.Text = $"Số HĐ: {currentSoHD}";
            lblDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            lblEmployee.Text = $"NV: {CurrentUser.MaNV} - {CurrentUser.TenNV}";
            
            // Clear customer selection
            ClearCustomer();
            txtCustomerSearch.Clear();
            txtSearch.Clear();
            txtBookCode.Clear();
            txtPayment.Clear();
            
            lblSubTotal.Text = "0 VNĐ";
            lblTotal.Text = "0 VNĐ";
            lblChange.Text = "0 VNĐ";
            
            RefreshCart();
        }

        #endregion

        #region Keyboard Shortcuts

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F9)
            {
                btnCompleteSale_Click(null, null);
                return true;
            }
            else if (keyData == Keys.Escape)
            {
                btnCancel_Click(null, null);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        private void pnlTop_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    #region Cart Item Class

    public class CartItem
    {
        public string MaSach { get; set; }
        public string TenSach { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGiaBan { get; set; }
        public int SoLuongTonKho { get; set; }

        public decimal ThanhTien
        {
            get { return SoLuong * DonGiaBan; }
        }
    }

    #endregion
}
