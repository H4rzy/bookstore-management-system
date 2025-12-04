using QLNS.Models;
using System;
using System.Collections.Generic;

namespace QLNS.BLL.Interfaces
{
    /// <summary>
    /// Service interface for Invoice business logic
    /// </summary>
    public interface IHoaDonService
    {
        IEnumerable<HoaDon> GetAllInvoices();
        HoaDon GetInvoiceById(string id);
        bool CreateInvoice(HoaDon invoice, List<ChiTietHoaDon> details, out string errorMessage);
        IEnumerable<HoaDon> GetInvoicesByEmployee(string employeeId);
        IEnumerable<HoaDon> GetInvoicesByCustomer(string customerId);
        IEnumerable<HoaDon> GetInvoicesByDateRange(DateTime fromDate, DateTime toDate);
        IEnumerable<ChiTietHoaDon> GetInvoiceDetails(string invoiceId);
        decimal CalculateInvoiceTotal(string invoiceId);
    }
}
