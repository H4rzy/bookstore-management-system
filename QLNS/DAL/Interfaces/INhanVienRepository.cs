using QLNS.Models;
using System.Collections.Generic;

namespace QLNS.DAL.Interfaces
{
    /// <summary>
    /// Repository interface for Employee (NhanVien) entity
    /// </summary>
    public interface INhanVienRepository : IRepository<NhanVien>
    {
        /// <summary>
        /// Searches employees by name
        /// </summary>
        /// <param name="keyword">Search keyword</param>
        /// <returns>Collection of matching employees</returns>
        IEnumerable<NhanVien> Search(string keyword);

        /// <summary>
        /// Gets employees by position
        /// </summary>
        /// <param name="chucVu">Position title</param>
        /// <returns>Collection of employees in the position</returns>
        IEnumerable<NhanVien> GetByPosition(string chucVu);
    }
}
