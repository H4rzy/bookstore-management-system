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
using QLNS_UI.Common;

namespace QLNS.UI.Forms.BookDetails
{
    public partial class FormBooks : Form
    {
        private Sach_BLL sachBLL = new Sach_BLL();
        private bool isEditMode = false;
        private string selectedTheLoai = null;  // null = Tất cả
        private string selectedNXB = null;      // null = Tất cả


        public FormBooks()
        {
            InitializeComponent();
        }

        private void FormBooks_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            LoadTreeViews();
            LoadData();
        }

        private void LoadComboBoxes()
        {
            try
            {
                // Load ComboBox sử dụng ComboDataProvider (cache)
                var dsTheLoai = ComboDataProvider.GetTheLoai();
                ControlHelper.BindComboBox(cboTheLoai, dsTheLoai, "TenTheLoai", "MaTheLoai");

                var dsNXB = ComboDataProvider.GetNhaXuatBan();
                ControlHelper.BindComboBox(cboNXB, dsNXB, "TenNXB", "MaNXB");
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi load ComboBox", ex.Message);
            }
        }

        private void LoadTreeViews()
        {
            try
            {
                // Load TreeView Thể Loại sử dụng Helper
                var dsTheLoai = ComboDataProvider.GetTheLoai();
                ControlHelper.PopulateTreeView(treeTheLoai, dsTheLoai, "TenTheLoai", "MaTheLoai", "📚 Tất cả");

                // Load TreeView NXB sử dụng Helper
                var dsNXB = ComboDataProvider.GetNhaXuatBan();
                ControlHelper.PopulateTreeView(treeNXB, dsNXB, "TenNXB", "MaNXB", "🏢 Tất cả");
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi load TreeView", ex.Message);
            }
        }

        private void LoadData()
        {
            try
            {
                // Load dữ liệu sử dụng FormDataHelper
                var dsSach = FormDataHelper.LoadTatCaSach();
                ControlHelper.BindDataGridView(dgvSach, dsSach);
                
                // Tùy chỉnh hiển thị cột
                if (dgvSach.Columns.Count > 0)
                {
                    dgvSach.Columns["MaSach"].HeaderText = "Mã Sách";
                    dgvSach.Columns["TenSach"].HeaderText = "Tên Sách";
                    dgvSach.Columns["TacGia"].HeaderText = "Tác Giả";
                    dgvSach.Columns["MaTheLoai"].HeaderText = "Thể Loại";
                    dgvSach.Columns["MaNXB"].HeaderText = "NXB";
                    dgvSach.Columns["DonGiaNhap"].HeaderText = "Giá Nhập";
                    dgvSach.Columns["DonGiaBan"].HeaderText = "Giá Bán";
                    dgvSach.Columns["SoLuongTon"].HeaderText = "Tồn Kho";
                    
                    dgvSach.Columns["DonGiaNhap"].DefaultCellStyle.Format = "N0";
                    dgvSach.Columns["DonGiaBan"].DefaultCellStyle.Format = "N0";
                }
                
                // Tự chọn dòng đầu tiên nếu có dữ liệu
                if (dgvSach.Rows.Count > 0)
                {
                    dgvSach.CurrentCell = dgvSach.Rows[0].Cells[0];
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi load dữ liệu", ex.Message);
            }
        }

        private void ApplyFilter()
        {
            try
            {
                // Load tất cả sách
                var dsSach = FormDataHelper.LoadTatCaSach();

                // Filter theo Thể Loại
                if (!string.IsNullOrEmpty(selectedTheLoai))
                {
                    dsSach = dsSach.Where(s => s.MaTheLoai == selectedTheLoai).ToList();
                }

                // Filter theo NXB (chồng filter)
                if (!string.IsNullOrEmpty(selectedNXB))
                {
                    dsSach = dsSach.Where(s => s.MaNXB == selectedNXB).ToList();
                }

                ControlHelper.BindDataGridView(dgvSach, dsSach);

                // Tự chọn dòng đầu tiên
                if (dgvSach.Rows.Count > 0)
                {
                    dgvSach.CurrentCell = dgvSach.Rows[0].Cells[0];
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi filter dữ liệu", ex.Message);
            }
        }

        private void dgvSach_SelectionChanged(object sender, EventArgs e)
        {
            if (!ControlHelper.IsRowSelected(dgvSach))
                return;

            try
            {
                SachDTO selected = ControlHelper.GetSelectedRow<SachDTO>(dgvSach);
                if (selected != null)
                {
                    isEditMode = true;
                    txtMaSach.Text = selected.MaSach;
                    txtMaSach.Enabled = false; // Không cho sửa mã khi edit
                    txtTenSach.Text = selected.TenSach;
                    txtTacGia.Text = selected.TacGia;
                    numDonGiaNhap.Value = selected.DonGiaNhap;
                    numDonGiaBan.Value = selected.DonGiaBan;
                    numSoLuongTon.Value = selected.SoLuongTon;
                    
                    ControlHelper.SetComboBoxValue(cboTheLoai, selected.MaTheLoai);
                    ControlHelper.SetComboBoxValue(cboNXB, selected.MaNXB);
                    
                    btnLuu.Text = "💾 Lưu";
                }
            }
            catch { }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ClearInputs();
            isEditMode = false;
            txtMaSach.Enabled = true;
            txtMaSach.Focus();
            btnLuu.Text = "➕ Thêm Mới";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Nút Hủy
            ClearInputs();
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ControlHelper.IsRowSelected(dgvSach))
                {
                    MessageHelper.ShowNoSelectionWarning();
                    return;
                }

                SachDTO selected = ControlHelper.GetSelectedRow<SachDTO>(dgvSach);
                if (selected == null)
                    return;

                if (!MessageHelper.ShowDeleteConfirm("sách"))
                    return;

                if (sachBLL.XoaSach(selected.MaSach))
                {
                    MessageHelper.ShowDeleteSuccess("sách");
                    LoadData(); // Tự động chọn dòng đầu
                }
                else
                {
                    MessageHelper.ShowDeleteError("sách", "Sách có thể đang được sử dụng trong phiếu nhập hoặc hóa đơn");
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi xóa sách", ex.Message);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate
                if (!ControlHelper.ValidateRequiredTextBox(txtMaSach, "Mã sách"))
                    return;

                if (!ControlHelper.ValidateRequiredTextBox(txtTenSach, "Tên sách"))
                    return;

                if (!ValidationHelper.IsValidCode(txtMaSach.Text.Trim()))
                {
                    MessageHelper.ShowInvalidDataError("Mã sách", "Chỉ chấp nhận chữ và số");
                    txtMaSach.Focus();
                    return;
                }

                if (!ValidationHelper.IsValidPrice(numDonGiaBan.Value, numDonGiaNhap.Value))
                {
                    MessageHelper.ShowInvalidDataError("Giá", "Giá bán phải lớn hơn giá nhập");
                    numDonGiaBan.Focus();
                    return;
                }

                if (cboTheLoai.SelectedIndex < 0 || cboNXB.SelectedIndex < 0)
                {
                    MessageHelper.ShowRequiredFieldError("Thể loại và Nhà xuất bản");
                    return;
                }

                // Tạo DTO
                SachDTO sach = new SachDTO
                {
                    MaSach = txtMaSach.Text.Trim(),
                    TenSach = txtTenSach.Text.Trim(),
                    TacGia = txtTacGia.Text.Trim(),
                    MaTheLoai = ControlHelper.GetComboBoxValue(cboTheLoai).ToString(),
                    MaNXB = ControlHelper.GetComboBoxValue(cboNXB).ToString(),
                    DonGiaNhap = numDonGiaNhap.Value,
                    DonGiaBan = numDonGiaBan.Value,
                    SoLuongTon = (int)numSoLuongTon.Value
                };

                // Thêm hoặc Sửa
                if (isEditMode)
                {
                    if (sachBLL.CapNhatSach(sach))
                    {
                        MessageHelper.ShowUpdateSuccess("sách");
                        LoadData(); // Tự động chọn dòng đầu
                    }
                    else
                    {
                        MessageHelper.ShowUpdateError("sách");
                    }
                }
                else
                {
                    if (sachBLL.ThemSach(sach))
                    {
                        MessageHelper.ShowAddSuccess("sách");
                        ClearInputs(); // Clear sau khi thêm
                        LoadData();
                    }
                    else
                    {
                        MessageHelper.ShowAddError("sách", "Mã sách có thể đã tồn tại");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi lưu sách", ex.Message);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
                {
                    LoadData();
                    return;
                }

                var result = FormDataHelper.SearchSach(txtTimKiem.Text.Trim());
                
                if (result.Rows.Count == 0)
                    MessageHelper.ShowNoDataFound();

                ControlHelper.BindDataGridView(dgvSach, result);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi tìm kiếm", ex.Message);
            }
        }

        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnTimKiem_Click(sender, e);
                e.Handled = true;
            }
        }

        private void treeTheLoai_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null && e.Node.Tag != null)
            {
                selectedTheLoai = e.Node.Tag.ToString();
            }
            else
            {
                selectedTheLoai = null; // Tất cả
            }
            ApplyFilter();
        }

        private void treeNXB_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null && e.Node.Tag != null)
            {
                selectedNXB = e.Node.Tag.ToString();
            }
            else
            {
                selectedNXB = null; // Tất cả
            }
            ApplyFilter();
        }

        private void ClearInputs()
        {
            txtMaSach.Clear();
            txtMaSach.Enabled = true;
            txtTenSach.Clear();
            txtTacGia.Clear();
            numDonGiaNhap.Value = 0;
            numDonGiaBan.Value = 0;
            numSoLuongTon.Value = 0;
            cboTheLoai.SelectedIndex = -1;
            cboNXB.SelectedIndex = -1;
            txtMaSach.Focus();
            isEditMode = false;
            btnLuu.Text = "💾 Lưu";
        }
    }
}
