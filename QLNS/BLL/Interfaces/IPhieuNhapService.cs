using QLNS.Models;
using System;
using System.Collections.Generic;

namespace QLNS.BLL.Interfaces
{
    /// <summary>
    /// Service interface for Purchase Order business logic
    /// </summary>
    public interface IPhieuNhapService
    {
        IEnumerable<PhieuNhap> GetAllPurchaseOrders();
        PhieuNhap GetPurchaseOrderById(string id);
        bool CreatePurchaseOrder(PhieuNhap order, List<ChiTietPhieuNhap> details, out string errorMessage);
        IEnumerable<PhieuNhap> GetPurchaseOrdersByEmployee(string employeeId);
        IEnumerable<PhieuNhap> GetPurchaseOrdersByDateRange(DateTime fromDate, DateTime toDate);
        IEnumerable<ChiTietPhieuNhap> GetPurchaseOrderDetails(string orderId);
        decimal CalculatePurchaseOrderTotal(string orderId);
    }
}
