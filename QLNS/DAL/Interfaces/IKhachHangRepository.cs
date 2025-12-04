using QLNS.Models;
using System.Collections.Generic;

namespace QLNS.DAL.Interfaces
{
    /// <summary>
    /// Repository interface for Customer (KhachHang) entity
    /// </summary>
    public interface IKhachHangRepository : IRepository<KhachHang>
    {
        /// <summary>
        /// Searches customers by name or phone number
        /// </summary>
        /// <param name="keyword">Search keyword</param>
        /// <returns>Collection of matching customers</returns>
        IEnumerable<KhachHang> Search(string keyword);

        /// <summary>
        /// Gets customers by type
        /// </summary>
        /// <param name="loaiKH">Customer type</param>
        /// <returns>Collection of customers of the specified type</returns>
        IEnumerable<KhachHang> GetByType(string loaiKH);
    }
}
