using QLNS.BLL.Interfaces;
using QLNS.DAL.Interfaces;
using QLNS.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QLNS.BLL.Services
{
    public class HoaDonService : IHoaDonService
    {
        private readonly IHoaDonRepository _hoaDonRepository;
        private readonly ISachRepository _sachRepository;

        public HoaDonService(IHoaDonRepository hoaDonRepository, ISachRepository sachRepository)
        {
            _hoaDonRepository = hoaDonRepository ?? throw new ArgumentNullException(nameof(hoaDonRepository));
            _sachRepository = sachRepository ?? throw new ArgumentNullException(nameof(sachRepository));
        }

        public IEnumerable<HoaDon> GetAllInvoices()
        {
            return _hoaDonRepository.GetAll();
        }

        public HoaDon GetInvoiceById(string id)
        {
            return _hoaDonRepository.GetById(id);
        }

        public bool CreateInvoice(HoaDon invoice, List<ChiTietHoaDon> details, out string errorMessage)
        {
            errorMessage = string.Empty;

            // Validate invoice
            if (invoice == null || details == null || details.Count == 0)
            {
                errorMessage = "Thông tin hóa đơn không hợp lệ.";
                return false;
            }

            // Check if invoice ID exists
            if (_hoaDonRepository.GetById(invoice.SoHD) != null)
            {
                errorMessage = "Số hóa đơn đã tồn tại.";
                return false;
            }

            // Validate stock availability for each book
            foreach (var detail in details)
            {
                var book = _sachRepository.GetById(detail.MaSach);
                if (book == null)
                {
                    errorMessage = $"Sách có mã {detail.MaSach} không tồn tại.";
                    return false;
                }

                if (book.SoLuongTon < detail.SoLuong)
                {
                    errorMessage = $"Sách '{book.TenSach}' không đủ số lượng. Còn lại: {book.SoLuongTon}";
                    return false;
                }
            }

            try
            {
                return _hoaDonRepository.AddWithDetails(invoice, details);
            }
            catch (Exception ex)
            {
                errorMessage = $"Lỗi khi tạo hóa đơn: {ex.Message}";
                return false;
            }
        }

        public IEnumerable<HoaDon> GetInvoicesByEmployee(string employeeId)
        {
            return _hoaDonRepository.GetByEmployee(employeeId);
        }

        public IEnumerable<HoaDon> GetInvoicesByCustomer(string customerId)
        {
            return _hoaDonRepository.GetByCustomer(customerId);
        }

        public IEnumerable<HoaDon> GetInvoicesByDateRange(DateTime fromDate, DateTime toDate)
        {
            return _hoaDonRepository.GetByDateRange(fromDate, toDate);
        }

        public IEnumerable<ChiTietHoaDon> GetInvoiceDetails(string invoiceId)
        {
            return _hoaDonRepository.GetDetails(invoiceId);
        }

        public decimal CalculateInvoiceTotal(string invoiceId)
        {
            var details = _hoaDonRepository.GetDetails(invoiceId);
            return details.Sum(d => d.ThanhTien);
        }
    }
}
