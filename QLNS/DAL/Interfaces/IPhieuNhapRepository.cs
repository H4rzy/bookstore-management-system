using QLNS.Models;
using System;
using System.Collections.Generic;

namespace QLNS.DAL.Interfaces
{
    /// <summary>
    /// Repository interface for Purchase Order (PhieuNhap) entity
    /// </summary>
    public interface IPhieuNhapRepository : IRepository<PhieuNhap>
    {
        /// <summary>
        /// Gets purchase orders by employee
        /// </summary>
        /// <param name="maNV">Employee ID</param>
        /// <returns>Collection of purchase orders created by the employee</returns>
        IEnumerable<PhieuNhap> GetByEmployee(string maNV);

        /// <summary>
        /// Gets purchase orders by date range
        /// </summary>
        /// <param name="fromDate">Start date</param>
        /// <param name="toDate">End date</param>
        /// <returns>Collection of purchase orders within the date range</returns>
        IEnumerable<PhieuNhap> GetByDateRange(DateTime fromDate, DateTime toDate);

        /// <summary>
        /// Gets purchase order details
        /// </summary>
        /// <param name="soPN">Purchase order number</param>
        /// <returns>Collection of purchase order details</returns>
        IEnumerable<ChiTietPhieuNhap> GetDetails(string soPN);

        /// <summary>
        /// Adds a purchase order with its details
        /// </summary>
        /// <param name="phieuNhap">Purchase order</param>
        /// <param name="chiTiet">Purchase order details</param>
        /// <returns>True if successful, false otherwise</returns>
        bool AddWithDetails(PhieuNhap phieuNhap, List<ChiTietPhieuNhap> chiTiet);
    }
}
