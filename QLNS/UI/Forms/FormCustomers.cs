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

namespace QLNS.UI.Forms
{
    public partial class FormCustomers : Form
    {
        private KhachHang_BLL khachHangBLL = new KhachHang_BLL();
        private bool isEditMode = false;

        public FormCustomers()
        {
            InitializeComponent();
        }

        private void FormCustomers_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var dsKhachHang = FormDataHelper.LoadKhachHang();
                ControlHelper.BindDataGridView(dgvKhachHang, dsKhachHang);
                
                if (dgvKhachHang.Columns.Count > 0)
                {
                    dgvKhachHang.Columns["MaKH"].HeaderText = "Mã KH";
                    dgvKhachHang.Columns["TenKH"].HeaderText = "Tên Khách Hàng";
                    dgvKhachHang.Columns["DiaChi"].HeaderText = "Địa Chỉ";
                    dgvKhachHang.Columns["DienThoai"].HeaderText = "Điện Thoại";
                    dgvKhachHang.Columns["LoaiKH"].HeaderText = "Loại KH";
                }
                
                // Tự chọn dòng đầu tiên
                if (dgvKhachHang.Rows.Count > 0)
                {
                    dgvKhachHang.CurrentCell = dgvKhachHang.Rows[0].Cells[0];
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi load dữ liệu", ex.Message);
            }
        }

        private void dgvKhachHang_SelectionChanged(object sender, EventArgs e)
        {
            if (!ControlHelper.IsRowSelected(dgvKhachHang))
                return;

            try
            {
                KhachHangDTO selected = ControlHelper.GetSelectedRow<KhachHangDTO>(dgvKhachHang);
                if (selected != null)
                {
                    isEditMode = true;
                    txtMaKH.Text = selected.MaKH;
                    txtMaKH.Enabled = false;
                    txtTenKH.Text = selected.TenKH;
                    txtDiaChi.Text = selected.DiaChi;
                    txtDienThoai.Text = selected.DienThoai;
                    cboLoaiKH.Text = selected.LoaiKH;
                    
                    btnLuu.Text = "💾 Lưu";
                }
            }
            catch { }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ClearInputs();
            isEditMode = false;
            txtMaKH.Enabled = true;
            txtMaKH.Focus();
            btnLuu.Text = "➕ Thêm Mới";
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ClearInputs();
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ControlHelper.IsRowSelected(dgvKhachHang))
                {
                    MessageHelper.ShowNoSelectionWarning();
                    return;
                }

                KhachHangDTO selected = ControlHelper.GetSelectedRow<KhachHangDTO>(dgvKhachHang);
                if (selected == null)
                    return;

                if (!MessageHelper.ShowDeleteConfirm("khách hàng"))
                    return;

                if (khachHangBLL.XoaKhachHang(selected.MaKH))
                {
                    MessageHelper.ShowDeleteSuccess("khách hàng");
                    LoadData();
                }
                else
                {
                    MessageHelper.ShowDeleteError("khách hàng", "Khách hàng có thể đang có hóa đơn");
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi xóa khách hàng", ex.Message);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate
                if (!ControlHelper.ValidateRequiredTextBox(txtMaKH, "Mã khách hàng"))
                    return;

                if (!ControlHelper.ValidateRequiredTextBox(txtTenKH, "Tên khách hàng"))
                    return;

                if (!ValidationHelper.IsValidCode(txtMaKH.Text.Trim()))
                {
                    MessageHelper.ShowInvalidDataError("Mã KH", "Chỉ chấp nhận chữ và số");
                    txtMaKH.Focus();
                    return;
                }

                if (!string.IsNullOrWhiteSpace(txtDienThoai.Text) && 
                    !ValidationHelper.IsValidPhone(txtDienThoai.Text.Trim()))
                {
                    MessageHelper.ShowInvalidDataError("Điện thoại", "Số điện thoại không hợp lệ");
                    txtDienThoai.Focus();
                    return;
                }

                // Tạo DTO
                KhachHangDTO kh = new KhachHangDTO
                {
                    MaKH = txtMaKH.Text.Trim(),
                    TenKH = txtTenKH.Text.Trim(),
                    DiaChi = txtDiaChi.Text.Trim(),
                    DienThoai = txtDienThoai.Text.Trim(),
                    LoaiKH = cboLoaiKH.Text.Trim()
                };

                // Thêm hoặc Sửa
                if (isEditMode)
                {
                    if (khachHangBLL.CapNhatKhachHang(kh))
                    {
                        MessageHelper.ShowUpdateSuccess("khách hàng");
                        LoadData();
                    }
                    else
                    {
                        MessageHelper.ShowUpdateError("khách hàng");
                    }
                }
                else
                {
                    if (khachHangBLL.ThemKhachHang(kh))
                    {
                        MessageHelper.ShowAddSuccess("khách hàng");
                        ClearInputs();
                        LoadData();
                    }
                    else
                    {
                        MessageHelper.ShowAddError("khách hàng", "Mã KH có thể đã tồn tại");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi lưu khách hàng", ex.Message);
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

                var result = FormDataHelper.SearchKhachHang(txtTimKiem.Text.Trim());
                
                if (result.Rows.Count == 0)
                    MessageHelper.ShowNoDataFound();

                ControlHelper.BindDataGridView(dgvKhachHang, result);
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

        private void ClearInputs()
        {
            txtMaKH.Clear();
            txtMaKH.Enabled = true;
            txtTenKH.Clear();
            txtDiaChi.Clear();
            txtDienThoai.Clear();
            cboLoaiKH.SelectedIndex = -1;
            txtMaKH.Focus();
            isEditMode = false;
            btnLuu.Text = "💾 Lưu";
        }

        private void btnDaMua_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ControlHelper.IsRowSelected(dgvKhachHang))
                {
                    MessageHelper.ShowNoSelectionWarning();
                    return;
                }

                KhachHangDTO selected = ControlHelper.GetSelectedRow<KhachHangDTO>(dgvKhachHang);
                if (selected == null)
                    return;

                // Mở form lịch sử mua hàng
                FormOrders frmOrders = new FormOrders(selected.MaKH);
                frmOrders.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi mở lịch sử mua hàng", ex.Message);
            }
        }


    }
}
