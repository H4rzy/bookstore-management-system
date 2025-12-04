using QLNS.BLL.Interfaces;
using QLNS.DAL.Interfaces;
using QLNS.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QLNS.BLL.Services
{
    public class PhieuNhapService : IPhieuNhapService
    {
        private readonly IPhieuNhapRepository _phieuNhapRepository;
        private readonly ISachRepository _sachRepository;

        public PhieuNhapService(IPhieuNhapRepository phieuNhapRepository, ISachRepository sachRepository)
        {
            _phieuNhapRepository = phieuNhapRepository ?? throw new ArgumentNullException(nameof(phieuNhapRepository));
            _sachRepository = sachRepository ?? throw new ArgumentNullException(nameof(sachRepository));
        }

        public IEnumerable<PhieuNhap> GetAllPurchaseOrders()
        {
            return _phieuNhapRepository.GetAll();
        }

        public PhieuNhap GetPurchaseOrderById(string id)
        {
            return _phieuNhapRepository.GetById(id);
        }

        public bool CreatePurchaseOrder(PhieuNhap order, List<ChiTietPhieuNhap> details, out string errorMessage)
        {
            errorMessage = string.Empty;

            // Validate
            if (order == null || details == null || details.Count == 0)
            {
                errorMessage = "Thông tin phiếu nhập không hợp lệ.";
                return false;
            }

            // Check if order ID exists
            if (_phieuNhapRepository.GetById(order.SoPN) != null)
            {
                errorMessage = "Số phiếu nhập đã tồn tại.";
                return false;
            }

            // Validate all books exist
            foreach (var detail in details)
            {
                var book = _sachRepository.GetById(detail.MaSach);
                if (book == null)
                {
                    errorMessage = $"Sách có mã {detail.MaSach} không tồn tại.";
                    return false;
                }

                if (detail.SoLuong <= 0)
                {
                    errorMessage = "Số lượng nhập phải lớn hơn 0.";
                    return false;
                }

                if (detail.DonGiaNhap <= 0)
                {
                    errorMessage = "Đơn giá nhập phải lớn hơn 0.";
                    return false;
                }
            }

            try
            {
                return _phieuNhapRepository.AddWithDetails(order, details);
            }
            catch (Exception ex)
            {
                errorMessage = $"Lỗi khi tạo phiếu nhập: {ex.Message}";
                return false;
            }
        }

        public IEnumerable<PhieuNhap> GetPurchaseOrdersByEmployee(string employeeId)
        {
            return _phieuNhapRepository.GetByEmployee(employeeId);
        }

        public IEnumerable<PhieuNhap> GetPurchaseOrdersByDateRange(DateTime fromDate, DateTime toDate)
        {
            return _phieuNhapRepository.GetByDateRange(fromDate, toDate);
        }

        public IEnumerable<ChiTietPhieuNhap> GetPurchaseOrderDetails(string orderId)
        {
            return _phieuNhapRepository.GetDetails(orderId);
        }

        public decimal CalculatePurchaseOrderTotal(string orderId)
        {
            var details = _phieuNhapRepository.GetDetails(orderId);
            return details.Sum(d => d.ThanhTien);
        }
    }
}
