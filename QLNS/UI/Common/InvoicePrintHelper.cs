using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QLNS.UI.Forms;

namespace QLNS_UI.Common
{
    public static class InvoicePrintHelper
    {
        public static string GenerateInvoiceHTML(
            string soHD,
            DateTime ngayBan,
            string tenKH,
            string nhanVien,
            List<CartItem> items,
            decimal discount,
            decimal total,
            decimal payment,
            decimal change)
        {
            var sb = new StringBuilder();
            
            sb.AppendLine("<!DOCTYPE html>");
            sb.AppendLine("<html>");
            sb.AppendLine("<head>");
            sb.AppendLine("<meta charset='utf-8'>");
            sb.AppendLine("<style>");
            sb.AppendLine(@"
                body {
                    font-family: 'Arial', sans-serif;
                    max-width: 800px;
                    margin: 20px auto;
                    padding: 20px;
                }
                .header {
                    text-align: center;
                    border-bottom: 2px solid #333;
                    padding-bottom: 10px;
                    margin-bottom: 20px;
                }
                .company-name {
                    font-size: 24px;
                    font-weight: bold;
                    color: #2c3e50;
                }
                .invoice-title {
                    font-size: 20px;
                    font-weight: bold;
                    margin: 15px 0;
                }
                .info-section {
                    margin: 15px 0;
                }
                table {
                    width: 100%;
                    border-collapse: collapse;
                    margin: 20px 0;
                }
                th {
                    background-color: #34495e;
                    color: white;
                    padding: 10px;
                    text-align: left;
                }
                td {
                    padding: 8px;
                    border-bottom: 1px solid #ddd;
                }
                .text-right {
                    text-align: right;
                }
                .totals {
                    margin-top: 20px;
                    float: right;
                    width: 300px;
                }
                .totals table {
                    margin: 0;
                }
                .total-row {
                    font-weight: bold;
                    font-size: 16px;
                }
                .footer {
                    clear: both;
                    margin-top: 50px;
                    text-align: center;
                    border-top: 1px solid #ddd;
                    padding-top: 20px;
                }
                @media print {
                    body { margin: 0; padding: 10px; }
                    .no-print { display: none; }
                }
            ");
            sb.AppendLine("</style>");
            sb.AppendLine("</head>");
            sb.AppendLine("<body>");
            
            // Header
            sb.AppendLine("<div class='header'>");
            sb.AppendLine("  <div class='company-name'>NHÀ SÁCH ABC</div>");
            sb.AppendLine("  <div>123 Đường ABC, Quận 1, TP.HCM</div>");
            sb.AppendLine("  <div>ĐT: (028) 1234 5678 | Email: info@nhasachabc.vn</div>");
            sb.AppendLine("</div>");
            
            // Invoice Title
            sb.AppendLine("<div class='invoice-title'>HÓA ĐƠN BÁN HÀNG</div>");
            
            // Info
            sb.AppendLine("<div class='info-section'>");
            sb.AppendLine($"  <div><strong>Số hóa đơn:</strong> {soHD}</div>");
            sb.AppendLine($"  <div><strong>Ngày:</strong> {ngayBan:dd/MM/yyyy HH:mm}</div>");
            sb.AppendLine($"  <div><strong>Khách hàng:</strong> {tenKH ?? "Khách lẻ"}</div>");
            sb.AppendLine($"  <div><strong>Nhân viên:</strong> {nhanVien}</div>");
            sb.AppendLine("</div>");
            
            // Items table
            sb.AppendLine("<table>");
            sb.AppendLine("  <thead>");
            sb.AppendLine("    <tr>");
            sb.AppendLine("      <th style='width: 50px;'>STT</th>");
            sb.AppendLine("      <th>Tên sách</th>");
            sb.AppendLine("      <th class='text-right' style='width: 100px;'>Đơn giá</th>");
            sb.AppendLine("      <th class='text-right' style='width: 80px;'>SL</th>");
            sb.AppendLine("      <th class='text-right' style='width: 120px;'>Thành tiền</th>");
            sb.AppendLine("    </tr>");
            sb.AppendLine("  </thead>");
            sb.AppendLine("  <tbody>");
            
            int stt = 1;
            foreach (var item in items)
            {
                sb.AppendLine("    <tr>");
                sb.AppendLine($"      <td>{stt++}</td>");
                sb.AppendLine($"      <td>{item.TenSach}</td>");
                sb.AppendLine($"      <td class='text-right'>{item.DonGiaBan:N0}</td>");
                sb.AppendLine($"      <td class='text-right'>{item.SoLuong}</td>");
                sb.AppendLine($"      <td class='text-right'>{item.ThanhTien:N0}</td>");
                sb.AppendLine("    </tr>");
            }
            
            sb.AppendLine("  </tbody>");
            sb.AppendLine("</table>");
            
            // Totals
            decimal subtotal = items.Sum(i => i.ThanhTien);
            
            sb.AppendLine("<div class='totals'>");
            sb.AppendLine("  <table>");
            sb.AppendLine("    <tr>");
            sb.AppendLine($"      <td>Tổng cộng:</td>");
            sb.AppendLine($"      <td class='text-right'>{subtotal:N0} VNĐ</td>");
            sb.AppendLine("    </tr>");
            
            if (discount > 0)
            {
                sb.AppendLine("    <tr>");
                sb.AppendLine($"      <td>Giảm giá:</td>");
                sb.AppendLine($"      <td class='text-right'>-{discount:N0} VNĐ</td>");
                sb.AppendLine("    </tr>");
            }
            
            sb.AppendLine("    <tr class='total-row'>");
            sb.AppendLine($"      <td>Thành tiền:</td>");
            sb.AppendLine($"      <td class='text-right'>{total:N0} VNĐ</td>");
            sb.AppendLine("    </tr>");
            sb.AppendLine("    <tr>");
            sb.AppendLine($"      <td>Tiền khách đưa:</td>");
            sb.AppendLine($"      <td class='text-right'>{payment:N0} VNĐ</td>");
            sb.AppendLine("    </tr>");
            sb.AppendLine("    <tr>");
            sb.AppendLine($"      <td>Tiền thối:</td>");
            sb.AppendLine($"      <td class='text-right'>{change:N0} VNĐ</td>");
            sb.AppendLine("    </tr>");
            sb.AppendLine("  </table>");
            sb.AppendLine("</div>");
            
            // Footer
            sb.AppendLine("<div class='footer'>");
            sb.AppendLine("  <div><strong>Cảm ơn quý khách! Hẹn gặp lại!</strong></div>");
            sb.AppendLine($"  <div style='margin-top: 10px; font-size: 12px;'>In lúc: {DateTime.Now:dd/MM/yyyy HH:mm:ss}</div>");
            sb.AppendLine("</div>");
            
            sb.AppendLine("</body>");
            sb.AppendLine("</html>");
            
            return sb.ToString();
        }
        
        public static void PrintInvoice(string html)
        {
            // Create temporary form with WebBrowser
            Form printForm = new Form
            {
                Width = 850,
                Height = 600,
                StartPosition = FormStartPosition.CenterScreen,
                Text = "In Hóa Đơn",
                ShowInTaskbar = false,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };
            
            WebBrowser browser = new WebBrowser
            {
                Dock = DockStyle.Fill,
                DocumentText = html
            };
            
            Panel buttonPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 50,
                Padding = new Padding(10)
            };
            
            Button btnPrint = new Button
            {
                Text = "🖨️ In",
                Width = 120,
                Height = 35,
                Location = new Point(10, 7),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            
            Button btnClose = new Button
            {
                Text = "✖ Đóng",
                Width = 120,
                Height = 35,
                Location = new Point(140, 7),
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                BackColor = Color.FromArgb(149, 165, 166),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            
            btnPrint.Click += (s, e) =>
            {
                try
                {
                    browser.ShowPrintDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi in: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            
            btnClose.Click += (s, e) =>
            {
                printForm.Close();
            };
            
            buttonPanel.Controls.Add(btnPrint);
            buttonPanel.Controls.Add(btnClose);
            
            printForm.Controls.Add(browser);
            printForm.Controls.Add(buttonPanel);
            
            printForm.ShowDialog();
        }
    }
}
