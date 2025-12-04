using QLNS.BLL.Interfaces;
using QLNS.Common;
using QLNS.DAL.Interfaces;
using QLNS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QLNS.Forms
{
    public partial class FormBooks : Form
    {
        private readonly ISachService _sachService;
        private readonly ITheLoaiRepository _theLoaiRepository;
        private readonly INhaXuatBanRepository _nxbRepository;

        public FormBooks()
        {
            InitializeComponent();
            
            // Get services from container
            _sachService = ServiceContainer.Instance.Resolve<ISachService>();
            _theLoaiRepository = ServiceContainer.Instance.Resolve<ITheLoaiRepository>();
            _nxbRepository = ServiceContainer.Instance.Resolve<INhaXuatBanRepository>();

            // Initialize form
            InitializeListView();
            LoadCategories();
            LoadPublishers();
            LoadBooks();
        }

        private void InitializeListView()
        {
            // Configure ListView
            listViewBooks.View = View.Details;
            listViewBooks.FullRowSelect = true;
            listViewBooks.GridLines = true;
            listViewBooks.MultiSelect = false;

            // Add columns
            listViewBooks.Columns.Add("Mã sách", 100);
            listViewBooks.Columns.Add("Tên sách", 250);
            listViewBooks.Columns.Add("Thể loại", 120);
            listViewBooks.Columns.Add("Nhà xuất bản", 150);
            listViewBooks.Columns.Add("Tác giả", 150);
            listViewBooks.Columns.Add("Giá nhập", 100);
            listViewBooks.Columns.Add("Giá bán", 100);
            listViewBooks.Columns.Add("Tồn kho", 80);
        }

        private void LoadCategories()
        {
            try
            {
                var categories = _theLoaiRepository.GetAll().ToList();
                cmbTheLoai.DataSource = categories;
                cmbTheLoai.DisplayMember = "TenTheLoai";
                cmbTheLoai.ValueMember = "MaTheLoai";
                cmbTheLoai.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách thể loại: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPublishers()
        {
            try
            {
                var publishers = _nxbRepository.GetAll().ToList();
                cmbNXB.DataSource = publishers;
                cmbNXB.DisplayMember = "TenNXB";
                cmbNXB.ValueMember = "MaNXB";
                cmbNXB.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách nhà xuất bản: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBooks()
        {
            try
            {
                listViewBooks.Items.Clear();

                var books = string.IsNullOrWhiteSpace(txtSearch.Text)
                    ? _sachService.GetAllBooks()
                    : _sachService.SearchBooks(txtSearch.Text);

                foreach (var book in books)
                {
                    var item = new ListViewItem(book.MaSach);
                    item.SubItems.Add(book.TenSach);
                    item.SubItems.Add(book.TheLoai?.TenTheLoai ?? "");
                    item.SubItems.Add(book.NhaXuatBan?.TenNXB ?? "");
                    item.SubItems.Add(book.TacGia ?? "");
                    item.SubItems.Add(book.DonGiaNhap.ToString("N0"));
                    item.SubItems.Add(book.DonGiaBan.ToString("N0"));
                    item.SubItems.Add(book.SoLuongTon.ToString());
                    item.Tag = book;

                    listViewBooks.Items.Add(item);
                }

                lblTotal.Text = $"Tổng số: {listViewBooks.Items.Count} sách";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách sách: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputs()
        {
            txtMaSach.Clear();
            txtTenSach.Clear();
            cmbTheLoai.SelectedIndex = -1;
            cmbNXB.SelectedIndex = -1;
            txtTacGia.Clear();
            txtDonGiaNhap.Clear();
            txtDonGiaBan.Clear();
            txtSoLuong.Clear();
            txtMaSach.Enabled = true;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            txtMaSach.Focus();
        }

        private void listViewBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewBooks.SelectedItems.Count > 0)
            {
                var book = listViewBooks.SelectedItems[0].Tag as Sach;
                if (book != null)
                {
                    txtMaSach.Text = book.MaSach;
                    txtTenSach.Text = book.TenSach;
                    cmbTheLoai.SelectedValue = book.MaTheLoai;
                    cmbNXB.SelectedValue = book.MaNXB;
                    txtTacGia.Text = book.TacGia;
                    txtDonGiaNhap.Text = book.DonGiaNhap.ToString();
                    txtDonGiaBan.Text = book.DonGiaBan.ToString();
                    txtSoLuong.Text = book.SoLuongTon.ToString();

                    txtMaSach.Enabled = false;
                    btnAdd.Enabled = false;
                    btnUpdate.Enabled = true;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var newBook = new Sach
                {
                    MaSach = txtMaSach.Text.Trim(),
                    TenSach = txtTenSach.Text.Trim(),
                    MaTheLoai = cmbTheLoai.SelectedValue?.ToString(),
                    MaNXB = cmbNXB.SelectedValue?.ToString(),
                    TacGia = txtTacGia.Text.Trim(),
                    DonGiaNhap = decimal.Parse(txtDonGiaNhap.Text),
                    DonGiaBan = decimal.Parse(txtDonGiaBan.Text),
                    SoLuongTon = int.Parse(txtSoLuong.Text)
                };

                if (_sachService.AddBook(newBook, out string errorMessage))
                {
                    MessageBox.Show("Thêm sách thành công!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadBooks();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show(errorMessage, "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng số cho giá và số lượng!", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var updatedBook = new Sach
                {
                    MaSach = txtMaSach.Text.Trim(),
                    TenSach = txtTenSach.Text.Trim(),
                    MaTheLoai = cmbTheLoai.SelectedValue?.ToString(),
                    MaNXB = cmbNXB.SelectedValue?.ToString(),
                    TacGia = txtTacGia.Text.Trim(),
                    DonGiaNhap = decimal.Parse(txtDonGiaNhap.Text),
                    DonGiaBan = decimal.Parse(txtDonGiaBan.Text),
                    SoLuongTon = int.Parse(txtSoLuong.Text)
                };

                if (_sachService.UpdateBook(updatedBook, out string errorMessage))
                {
                    MessageBox.Show("Cập nhật sách thành công!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadBooks();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show(errorMessage, "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng số cho giá và số lượng!", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listViewBooks.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sách cần xóa!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa sách này?", "Xác nhận", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var bookId = txtMaSach.Text.Trim();

                    if (_sachService.DeleteBook(bookId, out string errorMessage))
                    {
                        MessageBox.Show("Xóa sách thành công!", "Thông báo", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadBooks();
                        ClearInputs();
                    }
                    else
                    {
                        MessageBox.Show(errorMessage, "Lỗi", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadBooks();
            ClearInputs();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadBooks();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadBooks();
        }
    }
}
