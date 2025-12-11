using System;
using System.Drawing;
using System.Windows.Forms;
using QLNS_BLL;
using QLNS_DTO;
using QLNS_UI.Common;

namespace QLNS.UI.Forms
{
    public partial class FormVIPManagement : Form
    {
        private TheVIP_BLL vipBLL = new TheVIP_BLL();
        private KhachHang_BLL khachHangBLL = new KhachHang_BLL();

        public FormVIPManagement()
        {
            InitializeComponent();
        }

        private void FormVIPManagement_Load(object sender, EventArgs e)
        {
            LoadCustomerFilter();
            LoadAllVIPCards();
        }

        private void LoadCustomerFilter()
        {
            try
            {
                var dsKH = khachHangBLL.LayDanhSachKhachHang();
                
                // Add "Tất cả" option
                var allOption = new KhachHangDTO { MaKH = "", TenKH = "-- Tất cả khách hàng --" };
                dsKH.Insert(0, allOption);
                
                cboCustomerFilter.DataSource = dsKH;
                cboCustomerFilter.DisplayMember = "TenKH";
                cboCustomerFilter.ValueMember = "MaKH";
                cboCustomerFilter.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi load danh sách khách hàng", ex.Message);
            }
        }

        private void LoadAllVIPCards()
        {
            try
            {
                var dsTheVIP = vipBLL.LayDanhSachTheVIP();
                
                // Debug: show count
                MessageBox.Show($"Số lượng thẻ VIP: {dsTheVIP.Count}", "Debug");
                
                ControlHelper.BindDataGridView(dgvVIPCards, dsTheVIP);
                
                if (dgvVIPCards.Columns.Count > 0)
                {
                    // Header text
                    dgvVIPCards.Columns["MaTheVIP"].HeaderText = "Mã Thẻ";
                    dgvVIPCards.Columns["MaKH"].HeaderText = "Mã KH";
                    dgvVIPCards.Columns["NgayCapPhat"].HeaderText = "Ngày Cấp";
                    dgvVIPCards.Columns["NgayHetHan"].HeaderText = "Ngày Hết Hạn";
                    dgvVIPCards.Columns["DiemTichLuy"].HeaderText = "Điểm";
                    dgvVIPCards.Columns["ChiTieu"].HeaderText = "Chi Tiêu";
                    dgvVIPCards.Columns["TrangThai"].HeaderText = "Trạng Thái";
                    dgvVIPCards.Columns["HangVIP"].HeaderText = "Hạng VIP";
                    
                    // Format
                    dgvVIPCards.Columns["DiemTichLuy"].DefaultCellStyle.Format = "N0";
                    dgvVIPCards.Columns["ChiTieu"].DefaultCellStyle.Format = "N0";
                    dgvVIPCards.Columns["NgayCapPhat"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dgvVIPCards.Columns["NgayHetHan"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    
                    // Width
                    dgvVIPCards.Columns["MaTheVIP"].Width = 100;
                    dgvVIPCards.Columns["MaKH"].Width = 80;
                    dgvVIPCards.Columns["HangVIP"].Width = 100;
                    dgvVIPCards.Columns["TrangThai"].Width = 120;
                }
                
                lblTotalCards.Text = $"Tổng số thẻ: {dsTheVIP.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}\n\nStack: {ex.StackTrace}", "Lỗi load VIP");
            }
        }

        private void cboCustomerFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCustomerFilter.SelectedValue == null) return;
            
            string maKH = cboCustomerFilter.SelectedValue.ToString();
            
            if (string.IsNullOrEmpty(maKH))
            {
                LoadAllVIPCards();
            }
            else
            {
                try
                {
                    var theVIP = vipBLL.LayTheVIPTheoKhachHang(maKH);
                    if (theVIP != null)
                    {
                        var list = new System.Collections.Generic.List<TheVIPDTO> { theVIP };
                        ControlHelper.BindDataGridView(dgvVIPCards, list);
                    }
                    else
                    {
                        dgvVIPCards.DataSource = null;
                        // Không hiện thông báo - chỉ clear grid
                    }
                }
                catch (Exception ex)
                {
                    MessageHelper.ShowError("Lỗi lọc theo khách hàng", ex.Message);
                }
            }
        }

        private void dgvVIPCards_SelectionChanged(object sender, EventArgs e)
        {
            if (!ControlHelper.IsRowSelected(dgvVIPCards)) return;
            
            try
            {
                var selected = ControlHelper.GetSelectedRow<TheVIPDTO>(dgvVIPCards);
                if (selected == null) return;
                
                // Display basic info
                txtMaTheVIP.Text = selected.MaTheVIP;
                txtMaKH.Text = selected.MaKH;
                
                // Load customer name
                var kh = khachHangBLL.LayKhachHangTheoMa(selected.MaKH);
                txtTenKH.Text = kh?.TenKH ?? "";
                txtDienThoai.Text = kh?.DienThoai ?? "";
                
                dtpNgayCapPhat.Value = selected.NgayCapPhat;
                dtpNgayHetHan.Value = selected.NgayHetHan;
                txtDiemTichLuy.Text = selected.DiemTichLuy.ToString("N0");
                txtChiTieu.Text = selected.ChiTieu.ToString("N0");
                txtTrangThai.Text = selected.TrangThai ? "Hoạt động" : "Không hoạt động";

                // Display VIP rank with styling
                lblHangVIP.Text = selected.HangVIP;
                lblHangVIP.Font = new Font(lblHangVIP.Font.FontFamily, 16, FontStyle.Bold);
                lblHangVIP.ForeColor = GetRankColor(selected.HangVIP);
                
                // Display discount
                decimal discount = vipBLL.TinhPhanTramGiamGia(selected.MaKH);
                lblDiscount.Text = $"{discount}%";
                lblDiscount.Font = new Font(lblDiscount.Font.FontFamily, 14, FontStyle.Bold);
                lblDiscount.ForeColor = Color.Green;
                
                // Expiry status
                if (selected.IsExpired)
                {
                    lblExpiryStatus.Text = "❌ Đã hết hạn";
                    lblExpiryStatus.ForeColor = Color.Red;
                }
                else if (selected.SoNgayConLai < 30)
                {
                    lblExpiryStatus.Text = $"⚠️ Còn {selected.SoNgayConLai} ngày";
                    lblExpiryStatus.ForeColor = Color.Orange;
                }
                else
                {
                    lblExpiryStatus.Text = $"✅ Còn {selected.SoNgayConLai} ngày";
                    lblExpiryStatus.ForeColor = Color.Green;
                }
                
                // Next rank progress
                DisplayNextRankProgress(selected);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi hiển thị chi tiết", ex.Message);
            }
        }

        private Color GetRankColor(string rank)
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

        private void DisplayNextRankProgress(TheVIPDTO vip)
        {
            string message = "";
            
            if (vip.HangVIP == "Platinum")
            {
                message = "🏆 Đã đạt hạng cao nhất!";
                lblNextRank.ForeColor = Color.Green;
            }
            else if (vip.HangVIP == "Gold")
            {
                int pointsNeeded = 1000 - vip.DiemTichLuy;
                decimal spendingNeeded = 10000000 - vip.ChiTieu;
                
                if (pointsNeeded > 0 && spendingNeeded > 0)
                {
                    message = $"Cần thêm {pointsNeeded:N0} điểm HOẶC {spendingNeeded:N0} VNĐ để lên Platinum";
                }
                else
                {
                    message = "✨ Đủ điều kiện lên Platinum!";
                    lblNextRank.ForeColor = Color.Green;
                }
            }
            else // Silver or below
            {
                int pointsNeeded = 500 - vip.DiemTichLuy;
                decimal spendingNeeded = 5000000 - vip.ChiTieu;
                
                if (pointsNeeded > 0 && spendingNeeded > 0)
                {
                    message = $"Cần thêm {pointsNeeded:N0} điểm HOẶC {spendingNeeded:N0} VNĐ để lên Gold";
                }
                else
                {
                    message = "✨ Đủ điều kiện lên Gold!";
                    lblNextRank.ForeColor = Color.Green;
                }
            }
            
            lblNextRank.Text = message;
        }

        private void btnCapThe_Click(object sender, EventArgs e)
        {
            try
            {
                FormCapTheVIP dialog = new FormCapTheVIP();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string maKH = dialog.SelectedCustomerID;
                    int soThang = dialog.SelectedMonths;
                    
                    if (vipBLL.CapTheVIP(maKH, soThang))
                    {
                        MessageHelper.ShowAddSuccess("thẻ VIP");
                        LoadAllVIPCards();
                    }
                    else
                    {
                        MessageHelper.ShowAddError("thẻ VIP", "Khách hàng đã có thẻ VIP hoặc lỗi cấp thẻ");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi cấp thẻ VIP", ex.Message);
            }
        }

        private void btnGiaHan_Click(object sender, EventArgs e)
        {
            if (!ControlHelper.IsRowSelected(dgvVIPCards))
            {
                MessageHelper.ShowNoSelectionWarning();
                return;
            }
            
            try
            {
                var selected = ControlHelper.GetSelectedRow<TheVIPDTO>(dgvVIPCards);
                
                // Simple input prompt
                using (Form prompt = new Form())
                {
                    prompt.Width = 350;
                    prompt.Height = 150;
                    prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
                    prompt.Text = "Gia Hạn Thẻ VIP";
                    prompt.StartPosition = FormStartPosition.CenterScreen;
                    prompt.MaximizeBox = false;
                    prompt.MinimizeBox = false;
                    
                    Label textLabel = new Label() { Left = 20, Top = 20, Text = "Nhập số tháng gia hạn:" };
                    NumericUpDown inputBox = new NumericUpDown() { Left = 20, Top = 45, Width = 300, Minimum = 1, Maximum = 60, Value = 12 };
                    Button confirmation = new Button() { Text = "OK", Left = 120, Width = 80, Top = 75, DialogResult = DialogResult.OK };
                    Button cancel = new Button() { Text = "Hủy", Left = 210, Width = 80, Top = 75, DialogResult = DialogResult.Cancel };
                    
                    prompt.Controls.Add(textLabel);
                    prompt.Controls.Add(inputBox);
                    prompt.Controls.Add(confirmation);
                    prompt.Controls.Add(cancel);
                    prompt.AcceptButton = confirmation;
                    prompt.CancelButton = cancel;
                    
                    if (prompt.ShowDialog() == DialogResult.OK)
                    {
                        int soThang = (int)inputBox.Value;
                        
                        if (vipBLL.GiaHanTheVIP(selected.MaKH, soThang))
                        {
                            MessageHelper.ShowUpdateSuccess("thẻ VIP");
                            LoadAllVIPCards();
                        }
                        else
                        {
                            MessageHelper.ShowUpdateError("thẻ VIP");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi gia hạn thẻ", ex.Message);
            }
        }

        private void btnHuyThe_Click(object sender, EventArgs e)
        {
            if (!ControlHelper.IsRowSelected(dgvVIPCards))
            {
                MessageHelper.ShowNoSelectionWarning();
                return;
            }
            
            try
            {
                var selected = ControlHelper.GetSelectedRow<TheVIPDTO>(dgvVIPCards);
                
                if (!MessageHelper.ShowDeleteConfirm("thẻ VIP")) return;
                
                if (vipBLL.HuyTheVIP(selected.MaKH))
                {
                    MessageHelper.ShowDeleteSuccess("thẻ VIP");
                    LoadAllVIPCards();
                }
                else
                {
                    MessageHelper.ShowDeleteError("thẻ VIP", "");
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi hủy thẻ", ex.Message);
            }
        }

        private void btnCongDiem_Click(object sender, EventArgs e)
        {
            if (!ControlHelper.IsRowSelected(dgvVIPCards))
            {
                MessageHelper.ShowNoSelectionWarning();
                return;
            }
            
            try
            {
                var selected = ControlHelper.GetSelectedRow<TheVIPDTO>(dgvVIPCards);
                
                using (Form prompt = new Form())
                {
                    prompt.Width = 350;
                    prompt.Height = 150;
                    prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
                    prompt.Text = "Cộng Điểm Tích Lũy";
                    prompt.StartPosition = FormStartPosition.CenterScreen;
                    
                    Label textLabel = new Label() { Left = 20, Top = 20, Text = "Nhập số điểm cộng:" };
                    NumericUpDown inputBox = new NumericUpDown() { Left = 20, Top = 45, Width = 300, Minimum = 1, Maximum = 10000, Value = 100 };
                    Button confirmation = new Button() { Text = "OK", Left = 120, Width = 80, Top = 75, DialogResult = DialogResult.OK };
                    Button cancel = new Button() { Text = "Hủy", Left = 210, Width = 80, Top = 75, DialogResult = DialogResult.Cancel };
                    
                    prompt.Controls.Add(textLabel);
                    prompt.Controls.Add(inputBox);
                    prompt.Controls.Add(confirmation);
                    prompt.Controls.Add(cancel);
                    
                    if (prompt.ShowDialog() == DialogResult.OK)
                    {
                        int diem = (int)inputBox.Value;
                        if (vipBLL.CongDiemTichLuy(selected.MaKH, diem))
                        {
                            MessageBox.Show($"Đã cộng {diem:N0} điểm thành công!", "Thành Công", 
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadAllVIPCards();
                        }
                        else
                        {
                            MessageBox.Show("Lỗi cộng điểm!", "Lỗi", 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi cộng điểm", ex.Message);
            }
        }

        private void btnTruDiem_Click(object sender, EventArgs e)
        {
            if (!ControlHelper.IsRowSelected(dgvVIPCards))
            {
                MessageHelper.ShowNoSelectionWarning();
                return;
            }
            
            try
            {
                var selected = ControlHelper.GetSelectedRow<TheVIPDTO>(dgvVIPCards);
                
                using (Form prompt = new Form())
                {
                    prompt.Width = 350;
                    prompt.Height = 150;
                    prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
                    prompt.Text = "Trừ Điểm Tích Lũy";
                    prompt.StartPosition = FormStartPosition.CenterScreen;
                    
                    Label textLabel = new Label() { Left = 20, Top = 20, Text = "Nhập số điểm trừ:" };
                    NumericUpDown inputBox = new NumericUpDown() { Left = 20, Top = 45, Width = 300, Minimum = 1, Maximum = 10000, Value = 100 };
                    Button confirmation = new Button() { Text = "OK", Left = 120, Width = 80, Top = 75, DialogResult = DialogResult.OK };
                    Button cancel = new Button() { Text = "Hủy", Left = 210, Width = 80, Top = 75, DialogResult = DialogResult.Cancel };
                    
                    prompt.Controls.Add(textLabel);
                    prompt.Controls.Add(inputBox);
                    prompt.Controls.Add(confirmation);
                    prompt.Controls.Add(cancel);
                    
                    if (prompt.ShowDialog() == DialogResult.OK)
                    {
                        int diem = (int)inputBox.Value;
                        if (vipBLL.TruDiemTichLuy(selected.MaKH, diem))
                        {
                            MessageBox.Show($"Đã trừ {diem:N0} điểm thành công!", "Thành Công", 
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadAllVIPCards();
                        }
                        else
                        {
                            MessageBox.Show("Lỗi trừ điểm!", "Lỗi", 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi trừ điểm", ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cboCustomerFilter.SelectedIndex = 0;
            LoadAllVIPCards();
        }
    }
}
