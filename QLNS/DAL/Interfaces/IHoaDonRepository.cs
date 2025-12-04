using QLNS.Models;
using System;
using System.Collections.Generic;

namespace QLNS.DAL.Interfaces
{
    /// <summary>
    /// Repository interface for Invoice (HoaDon) entity
    /// </summary>
    public interface IHoaDonRepository : IRepository<HoaDon>
    {
        /// <summary>
        /// Gets invoices by employee
        /// </summary>
        /// <param name="maNV">Employee ID</param>
        /// <returns>Collection of invoices created by the employee</returns>
        IEnumerable<HoaDon> GetByEmployee(string maNV);

        /// <summary>
        /// Gets invoices by customer
        /// </summary>
        /// <param name="maKH">Customer ID</param>
        /// <returns>Collection of invoices for the customer</returns>
        IEnumerable<HoaDon> GetByCustomer(string maKH);

        /// <summary>
        /// Gets invoices by date range
        /// </summary>
        /// <param name="fromDate">Start date</param>
        /// <param name="toDate">End date</param>
        /// <returns>Collection of invoices within the date range</returns>
        IEnumerable<HoaDon> GetByDateRange(DateTime fromDate, DateTime toDate);

        /// <summary>
        /// Gets invoice details
        /// </summary>
        /// <param name="soHD">Invoice number</param>
        /// <returns>Collection of invoice details</returns>
        IEnumerable<ChiTietHoaDon> GetDetails(string soHD);

        /// <summary>
        /// Adds an invoice with its details
        /// </summary>
        /// <param name="hoaDon">Invoice</param>
        /// <param name="chiTiet">Invoice details</param>
        /// <returns>True if successful, false otherwise</returns>
        bool AddWithDetails(HoaDon hoaDon, List<ChiTietHoaDon> chiTiet);
    }
}
