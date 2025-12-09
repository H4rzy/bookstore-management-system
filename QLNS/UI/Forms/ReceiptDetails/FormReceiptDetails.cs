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

namespace QLNS.UI.Forms.ReceiptDetails
{
    public partial class FormReceiptDetails : Form
    {
        private HoaDon_BLL hoaDonBLL = new HoaDon_BLL();
        private ChiTietHoaDon_BLL chiTietBLL = new ChiTietHoaDon_BLL();
        private Sach_BLL sachBLL = new Sach_BLL();

        private string selectedSoHD = string.Empty;

        public FormReceiptDetails()
        {
            InitializeComponent();
        }

        private void FormReceiptDetails_Load(object sender, EventArgs e)
        {
            LoadHoaDon();
            SetupDataGridView();
            btnAddDetail.Enabled = false;
            btnDeleteDetail.Enabled = false;
        }

        #region Setup

        private void SetupDataGridView()
        {
            cboHoaDon.DisplayMember = "SoHD";
            cboHoaDon.ValueMember = "SoHD";

            dgvChiTiet.AutoGenerateColumns = false;
            dgvChiTiet.Columns.Clear();

            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaSach",
                HeaderText = "Mã sách",
                Name = "MaSach",
                Width = 120
            });

            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenSach",
                HeaderText = "Tên sách",
                Name = "TenSach",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SoLuong",
                HeaderText = "Số lượng",
                Name = "SoLuong",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DonGiaBan",
                HeaderText = "Đơn giá bán",
                Name = "DonGiaBan",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ThanhTien",
                HeaderText = "Thành tiền",
                Name = "ThanhTien",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            });
        }

        #endregion

        #region Load Data

        private void LoadHoaDon()
        {
            try
            {
                var dsHoaDon = hoaDonBLL.LayDanhSachHoaDon();
                cboHoaDon.DataSource = dsHoaDon;

                if (dsHoaDon.Count > 0)
                {
                    cboHoaDon.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách hóa đơn: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadChiTiet(string soHD)
        {
            try
            {
                var dsChiTiet = chiTietBLL.LayChiTiet(soHD);

                var displayList = new List<dynamic>();
                foreach (var ct in dsChiTiet)
                {
                    var sach = sachBLL.LaySachTheoMa(ct.MaSach);
                    displayList.Add(new
                    {
                        ct.SoHD,
                        ct.MaSach,
                        TenSach = sach != null ? sach.TenSach : "N/A",
                        ct.SoLuong,
                        ct.DonGiaBan,
                        ThanhTien = ct.SoLuong * ct.DonGiaBan
                    });
                }

                dgvChiTiet.DataSource = displayList;

                decimal tongTien = chiTietBLL.TinhTongTien(soHD);
                lblTongTien.Text = $"Tổng tiền: {tongTien:N0} VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải chi tiết hóa đơn: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Event Handlers

        private void cboHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboHoaDon.SelectedValue != null)
            {
                selectedSoHD = cboHoaDon.SelectedValue.ToString();
                LoadChiTiet(selectedSoHD);
                btnAddDetail.Enabled = true;
                btnDeleteDetail.Enabled = dgvChiTiet.Rows.Count > 0;
            }
            else
            {
                selectedSoHD = string.Empty;
                dgvChiTiet.DataSource = null;
                lblTongTien.Text = "Tổng tiền: 0 VNĐ";
                btnAddDetail.Enabled = false;
                btnDeleteDetail.Enabled = false;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadHoaDon();
            if (!string.IsNullOrEmpty(selectedSoHD))
            {
                LoadChiTiet(selectedSoHD);
            }
        }

        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedSoHD))
            {
                MessageBox.Show("Vui lòng chọn hóa đơn trước!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var dialog = new FormReceiptDetailEdit(selectedSoHD, null))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    LoadChiTiet(selectedSoHD);
                    MessageBox.Show("Thêm chi tiết bán hàng thành công!\nTồn kho đã được cập nhật.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnDeleteDetail_Click(object sender, EventArgs e)
        {
            if (dgvChiTiet.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn chi tiết cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dgvChiTiet.SelectedRows[0];
            string maSach = row.Cells["MaSach"].Value?.ToString() ?? string.Empty;

            if (string.IsNullOrEmpty(maSach))
                return;

            var result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa chi tiết này?\n" +
                "Thao tác này sẽ cộng lại tồn kho của sách và không thể hoàn tác!",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    if (chiTietBLL.XoaChiTiet(selectedSoHD, maSach))
                    {
                        MessageBox.Show("Xóa chi tiết thành công!\nTồn kho đã được cập nhật.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadChiTiet(selectedSoHD);
                    }
                    else
                    {
                        MessageBox.Show("Xóa chi tiết thất bại!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa chi tiết: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion
    }

    #region Dialog Form

    public class FormReceiptDetailEdit : Form
    {
        private ChiTietHoaDon_BLL chiTietBLL = new ChiTietHoaDon_BLL();
        private Sach_BLL sachBLL = new Sach_BLL();
        private string soHD;
        private ChiTietHoaDonDTO chiTiet;
        private bool isEditMode;

        private ComboBox cboSach;
        private NumericUpDown nudSoLuong;
        private TextBox txtDonGiaBan;
        private Label lblThanhTien;
        private Button btnSave;
        private Button btnCancel;

        public FormReceiptDetailEdit(string soHD, ChiTietHoaDonDTO chiTiet)
        {
            this.soHD = soHD;
            this.chiTiet = chiTiet;
            isEditMode = chiTiet != null;
            InitializeComponent();
            LoadData();
        }

        private void InitializeComponent()
        {
            this.Text = "Thêm chi tiết bán hàng";
            this.Size = new Size(500, 300);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            int y = 20;
            int labelWidth = 120;
            int controlWidth = 330;
            int spacing = 45;

            var lblSach = new Label { Text = "Sách:", Location = new Point(20, y), Width = labelWidth };
            cboSach = new ComboBox
            {
                Location = new Point(150, y),
                Width = controlWidth,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            this.Controls.Add(lblSach);
            this.Controls.Add(cboSach);
            y += spacing;

            var lblSoLuong = new Label { Text = "Số lượng:", Location = new Point(20, y), Width = labelWidth };
            nudSoLuong = new NumericUpDown
            {
                Location = new Point(150, y),
                Width = controlWidth,
                Minimum = 1,
                Maximum = 10000,
                Value = 1
            };
            nudSoLuong.ValueChanged += (s, e) => UpdateThanhTien();
            this.Controls.Add(lblSoLuong);
            this.Controls.Add(nudSoLuong);
            y += spacing;

            var lblDonGia = new Label { Text = "Đơn giá bán:", Location = new Point(20, y), Width = labelWidth };
            txtDonGiaBan = new TextBox { Location = new Point(150, y), Width = controlWidth };
            txtDonGiaBan.TextChanged += (s, e) => UpdateThanhTien();
            this.Controls.Add(lblDonGia);
            this.Controls.Add(txtDonGiaBan);
            y += spacing;

            var lblThanhTienLabel = new Label { Text = "Thành tiền:", Location = new Point(20, y), Width = labelWidth };
            lblThanhTien = new Label
            {
                Location = new Point(150, y),
                Width = controlWidth,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(220, 53, 69)
            };
            this.Controls.Add(lblThanhTienLabel);
            this.Controls.Add(lblThanhTien);
            y += spacing + 5;

            btnSave = new Button
            {
                Text = "Lưu",
                Location = new Point(270, y),
                Width = 100,
                Height = 35,
                BackColor = Color.FromArgb(40, 167, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnSave.Click += btnSave_Click;

            btnCancel = new Button
            {
                Text = "Hủy",
                Location = new Point(380, y),
                Width = 100,
                Height = 35,
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;

            this.Controls.Add(btnSave);
            this.Controls.Add(btnCancel);
        }

        private void LoadData()
        {
            var dsSach = sachBLL.LayTatCaSach();
            cboSach.DisplayMember = "TenSach";
            cboSach.ValueMember = "MaSach";
            cboSach.DataSource = dsSach;

            if (isEditMode && chiTiet != null)
            {
                cboSach.SelectedValue = chiTiet.MaSach;
                cboSach.Enabled = false;
                nudSoLuong.Value = chiTiet.SoLuong;
                txtDonGiaBan.Text = chiTiet.DonGiaBan.ToString();
            }
            else if (cboSach.Items.Count > 0)
            {
                var sach = (SachDTO)cboSach.SelectedItem;
                if (sach != null)
                {
                    txtDonGiaBan.Text = sach.DonGiaBan.ToString();
                }
            }

            UpdateThanhTien();
        }

        private void UpdateThanhTien()
        {
            if (decimal.TryParse(txtDonGiaBan.Text, out decimal donGia))
            {
                decimal thanhTien = (decimal)nudSoLuong.Value * donGia;
                lblThanhTien.Text = $"{thanhTien:N0} VNĐ";
            }
            else
            {
                lblThanhTien.Text = "0 VNĐ";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboSach.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtDonGiaBan.Text, out decimal donGia) || donGia <= 0)
            {
                MessageBox.Show("Vui lòng nhập đơn giá hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGiaBan.Focus();
                return;
            }

            try
            {
                var dto = new ChiTietHoaDonDTO
                {
                    SoHD = soHD,
                    MaSach = cboSach.SelectedValue.ToString(),
                    SoLuong = (int)nudSoLuong.Value,
                    DonGiaBan = donGia
                };

                bool success = chiTietBLL.ThemChiTiet(dto);

                if (success)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Thêm chi tiết thất bại!\nKiểm tra lại thông tin hoặc sách đã tồn tại trong hóa đơn này.",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    #endregion
}
