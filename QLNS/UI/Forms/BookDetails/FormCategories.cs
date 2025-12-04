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
    public partial class FormCategories : Form
    {
        private TheLoai_BLL theLoaiBLL = new TheLoai_BLL();

        public FormCategories()
        {
            InitializeComponent();
        }

        private void FormCategories_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var dsTheLoai = FormDataHelper.LoadTheLoai();
                ControlHelper.BindDataGridView(dgvTheLoai, dsTheLoai);
                
                if (dgvTheLoai.Columns.Count > 0)
                {
                    dgvTheLoai.Columns["MaTheLoai"].HeaderText = "Mã Thể Loại";
                    dgvTheLoai.Columns["TenTheLoai"].HeaderText = "Tên Thể Loại";
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi load dữ liệu", ex.Message);
            }
        }

        private void dgvTheLoai_SelectionChanged(object sender, EventArgs e)
        {
            if (!ControlHelper.IsRowSelected(dgvTheLoai))
                return;

            try
            {
                TheLoaiDTO selected = ControlHelper.GetSelectedRow<TheLoaiDTO>(dgvTheLoai);
                if (selected != null)
                {
                    txtMaTheLoai.Text = selected.MaTheLoai;
                    txtTenTheLoai.Text = selected.TenTheLoai;
                }
            }
            catch { }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ControlHelper.ValidateRequiredTextBox(txtMaTheLoai, "Mã thể loại"))
                    return;

                if (!ControlHelper.ValidateRequiredTextBox(txtTenTheLoai, "Tên thể loại"))
                    return;

                if (!ValidationHelper.IsValidCode(txtMaTheLoai.Text.Trim()))
                {
                    MessageHelper.ShowInvalidDataError("Mã thể loại", "Chỉ chấp nhận chữ và số");
                    txtMaTheLoai.Focus();
                    return;
                }

                TheLoaiDTO theLoai = new TheLoaiDTO
                {
                    MaTheLoai = txtMaTheLoai.Text.Trim(),
                    TenTheLoai = txtTenTheLoai.Text.Trim()
                };

                if (theLoaiBLL.ThemTheLoai(theLoai))
                {
                    MessageHelper.ShowAddSuccess("thể loại");
                    ComboDataProvider.RefreshTheLoai(); // Refresh cache
                    LoadData();
                    ClearInputs();
                }
                else
                {
                    MessageHelper.ShowAddError("thể loại", "Mã thể loại có thể đã tồn tại");
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi thêm thể loại", ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ControlHelper.ValidateRequiredTextBox(txtMaTheLoai, "Mã thể loại"))
                    return;

                if (!ControlHelper.ValidateRequiredTextBox(txtTenTheLoai, "Tên thể loại"))
                    return;

                if (!MessageHelper.ShowUpdateConfirm("thể loại"))
                    return;

                TheLoaiDTO theLoai = new TheLoaiDTO
                {
                    MaTheLoai = txtMaTheLoai.Text.Trim(),
                    TenTheLoai = txtTenTheLoai.Text.Trim()
                };

                if (theLoaiBLL.CapNhatTheLoai(theLoai))
                {
                    MessageHelper.ShowUpdateSuccess("thể loại");
                    ComboDataProvider.RefreshTheLoai();
                    LoadData();
                    ClearInputs();
                }
                else
                {
                    MessageHelper.ShowUpdateError("thể loại");
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi cập nhật thể loại", ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ControlHelper.IsRowSelected(dgvTheLoai))
                {
                    MessageHelper.ShowNoSelectionWarning();
                    return;
                }

                TheLoaiDTO selected = ControlHelper.GetSelectedRow<TheLoaiDTO>(dgvTheLoai);
                if (selected == null)
                    return;

                if (!MessageHelper.ShowDeleteConfirm("thể loại"))
                    return;

                if (theLoaiBLL.XoaTheLoai(selected.MaTheLoai))
                {
                    MessageHelper.ShowDeleteSuccess("thể loại");
                    ComboDataProvider.RefreshTheLoai();
                    LoadData();
                    ClearInputs();
                }
                else
                {
                    MessageHelper.ShowDeleteError("thể loại", "Không thể xóa vì có sách thuộc thể loại này");
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi xóa thể loại", ex.Message);
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

                var result = FormDataHelper.SearchTheLoai(txtTimKiem.Text.Trim());
                
                if (result.Rows.Count == 0)
                    MessageHelper.ShowNoDataFound();

                ControlHelper.BindDataGridView(dgvTheLoai, result);
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
            txtMaTheLoai.Clear();
            txtTenTheLoai.Clear();
            txtMaTheLoai.Focus();
        }
    }
}
