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
    public partial class FormAuthors : Form
    {
        private NhaXuatBan_BLL nxbBLL = new NhaXuatBan_BLL();

        public FormAuthors()
        {
            InitializeComponent();
        }

        private void FormAuthors_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var dsNXB = FormDataHelper.LoadNhaXuatBan();
                ControlHelper.BindDataGridView(dgvNXB, dsNXB);
                
                if (dgvNXB.Columns.Count > 0)
                {
                    dgvNXB.Columns["MaNXB"].HeaderText = "Mã NXB";
                    dgvNXB.Columns["TenNXB"].HeaderText = "Tên Nhà Xuất Bản";
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi load dữ liệu", ex.Message);
            }
        }

        private void dgvNXB_SelectionChanged(object sender, EventArgs e)
        {
            if (!ControlHelper.IsRowSelected(dgvNXB))
                return;

            try
            {
                NhaXuatBanDTO selected = ControlHelper.GetSelectedRow<NhaXuatBanDTO>(dgvNXB);
                if (selected != null)
                {
                    txtMaNXB.Text = selected.MaNXB;
                    txtTenNXB.Text = selected.TenNXB;
                }
            }
            catch { }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ControlHelper.ValidateRequiredTextBox(txtMaNXB, "Mã NXB"))
                    return;

                if (!ControlHelper.ValidateRequiredTextBox(txtTenNXB, "Tên NXB"))
                    return;

                if (!ValidationHelper.IsValidCode(txtMaNXB.Text.Trim()))
                {
                    MessageHelper.ShowInvalidDataError("Mã NXB", "Chỉ chấp nhận chữ và số");
                    txtMaNXB.Focus();
                    return;
                }

                NhaXuatBanDTO nxb = new NhaXuatBanDTO
                {
                    MaNXB = txtMaNXB.Text.Trim(),
                    TenNXB = txtTenNXB.Text.Trim()
                };

                if (nxbBLL.ThemNhaXuatBan(nxb))
                {
                    MessageHelper.ShowAddSuccess("nhà xuất bản");
                    ComboDataProvider.RefreshNhaXuatBan();
                    LoadData();
                    ClearInputs();
                }
                else
                {
                    MessageHelper.ShowAddError("nhà xuất bản", "Mã NXB có thể đã tồn tại");
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi thêm NXB", ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ControlHelper.ValidateRequiredTextBox(txtMaNXB, "Mã NXB"))
                    return;

                if (!ControlHelper.ValidateRequiredTextBox(txtTenNXB, "Tên NXB"))
                    return;

                if (!MessageHelper.ShowUpdateConfirm("nhà xuất bản"))
                    return;

                NhaXuatBanDTO nxb = new NhaXuatBanDTO
                {
                    MaNXB = txtMaNXB.Text.Trim(),
                    TenNXB = txtTenNXB.Text.Trim()
                };

                if (nxbBLL.CapNhatNhaXuatBan(nxb))
                {
                    MessageHelper.ShowUpdateSuccess("nhà xuất bản");
                    ComboDataProvider.RefreshNhaXuatBan();
                    LoadData();
                    ClearInputs();
                }
                else
                {
                    MessageHelper.ShowUpdateError("nhà xuất bản");
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi cập nhật NXB", ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ControlHelper.IsRowSelected(dgvNXB))
                {
                    MessageHelper.ShowNoSelectionWarning();
                    return;
                }

                NhaXuatBanDTO selected = ControlHelper.GetSelectedRow<NhaXuatBanDTO>(dgvNXB);
                if (selected == null)
                    return;

                if (!MessageHelper.ShowDeleteConfirm("nhà xuất bản"))
                    return;

                if (nxbBLL.XoaNhaXuatBan(selected.MaNXB))
                {
                    MessageHelper.ShowDeleteSuccess("nhà xuất bản");
                    ComboDataProvider.RefreshNhaXuatBan();
                    LoadData();
                    ClearInputs();
                }
                else
                {
                    MessageHelper.ShowDeleteError("nhà xuất bản", "Không thể xóa vì có sách của NXB này");
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi xóa NXB", ex.Message);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInputs();
            LoadData();
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

                var result = FormDataHelper.SearchNhaXuatBan(txtTimKiem.Text.Trim());
                
                if (result.Rows.Count == 0)
                    MessageHelper.ShowNoDataFound();

                ControlHelper.BindDataGridView(dgvNXB, result);
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
            txtMaNXB.Clear();
            txtTenNXB.Clear();
            txtMaNXB.Focus();
        }
    }
}
