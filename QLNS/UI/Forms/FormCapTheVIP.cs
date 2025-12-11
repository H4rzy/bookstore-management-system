using System;
using System.Linq;
using System.Windows.Forms;
using QLNS_BLL;
using QLNS_DTO;
using QLNS_UI.Common;

namespace QLNS.UI.Forms
{
    public partial class FormCapTheVIP : Form
    {
        private KhachHang_BLL khachHangBLL = new KhachHang_BLL();
        private TheVIP_BLL vipBLL = new TheVIP_BLL();

        public string SelectedCustomerID { get; private set; }
        public int SelectedMonths { get; private set; }

        public FormCapTheVIP()
        {
            InitializeComponent();
        }

        private void FormCapTheVIP_Load(object sender, EventArgs e)
        {
            LoadEligibleCustomers();
            UpdatePreview();
        }

        private void LoadEligibleCustomers()
        {
            try
            {
                var dsKH = khachHangBLL.LayDanhSachKhachHang();
                
                // Filter out customers who already have active VIP cards
                var eligible = dsKH.Where(kh => 
                {
                    var vipCard = vipBLL.LayTheVIPTheoKhachHang(kh.MaKH);
                    return vipCard == null || vipCard.IsExpired;
                }).ToList();

                if (eligible.Count == 0)
                {
                    MessageBox.Show("Không có khách hàng đủ điều kiện cấp thẻ VIP mới!\n" +
                        "Tất cả khách hàng đã có thẻ VIP còn hiệu lực.",
                        "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return;
                }

                cboKhachHang.DataSource = eligible;
                cboKhachHang.DisplayMember = "TenKH";
                cboKhachHang.ValueMember = "MaKH";
                
                if (eligible.Count > 0)
                    cboKhachHang.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi load danh sách khách hàng", ex.Message);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void nudSoThang_ValueChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void UpdatePreview()
        {
            int months = (int)nudSoThang.Value;
            DateTime ngayHetHan = DateTime.Now.AddMonths(months);
            
            lblPreview.Text = $"📅 Ngày hết hạn: {ngayHetHan:dd/MM/yyyy} ({months} tháng)";
            
            // Calculate approximate cost (if applicable)
            decimal estimatedCost = months * 50000; // Example: 50k/month
            lblCost.Text = $"💰 Phí dự kiến: {estimatedCost:N0} VNĐ";
        }

        private void cboKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKhachHang.SelectedValue == null) return;
            
            try
            {
                string maKH = cboKhachHang.SelectedValue.ToString();
                var kh = khachHangBLL.LayKhachHangTheoMa(maKH);
                
                if (kh != null)
                {
                    lblCustomerInfo.Text = $"📱 {kh.DienThoai ?? "N/A"} | 📍 {kh.DiaChi ?? "N/A"}";
                    
                    // Check if customer had previous VIP card
                    var oldVip = vipBLL.LayTheVIPTheoKhachHang(maKH);
                    if (oldVip != null)
                    {
                        lblPreviousVIP.Visible = true;
                        lblPreviousVIP.Text = $"⚠️ Thẻ cũ: {oldVip.HangVIP} - " +
                            $"{oldVip.DiemTichLuy:N0} điểm - Hết hạn {oldVip.NgayHetHan:dd/MM/yyyy}";
                        lblPreviousVIP.ForeColor = System.Drawing.Color.Orange;
                    }
                    else
                    {
                        lblPreviousVIP.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi load thông tin khách hàng", ex.Message);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cboKhachHang.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng!", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboKhachHang.Focus();
                return;
            }

            if (nudSoThang.Value < 1 || nudSoThang.Value > 60)
            {
                MessageBox.Show("Số tháng phải từ 1 đến 60!", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudSoThang.Focus();
                return;
            }

            // Confirm
            var kh = cboKhachHang.SelectedItem as KhachHangDTO;
            int months = (int)nudSoThang.Value;
            DateTime expiryDate = DateTime.Now.AddMonths(months);

            var result = MessageBox.Show(
                $"Xác nhận cấp thẻ VIP?\n\n" +
                $"Khách hàng: {kh.TenKH}\n" +
                $"Thời hạn: {months} tháng\n" +
                $"Hết hạn: {expiryDate:dd/MM/yyyy}\n\n" +
                $"Khách hàng sẽ được hưởng ưu đãi ngay sau khi cấp thẻ.",
                "Xác Nhận", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                SelectedCustomerID = cboKhachHang.SelectedValue.ToString();
                SelectedMonths = months;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
