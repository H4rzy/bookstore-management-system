using QLNS.Models;
using System.Collections.Generic;

namespace QLNS.DAL.Interfaces
{
    /// <summary>
    /// Repository interface for Book (Sach) entity
    /// Extends base repository with book-specific operations
    /// </summary>
    public interface ISachRepository : IRepository<Sach>
    {
        /// <summary>
        /// Gets all books by category
        /// </summary>
        /// <param name="maTheLoai">Category ID</param>
        /// <returns>Collection of books in the category</returns>
        IEnumerable<Sach> GetByTheLoai(string maTheLoai);

        /// <summary>
        /// Gets all books by publisher
        /// </summary>
        /// <param name="maNXB">Publisher ID</param>
        /// <returns>Collection of books from the publisher</returns>
        IEnumerable<Sach> GetByNXB(string maNXB);

        /// <summary>
        /// Searches books by keyword in title or author
        /// </summary>
        /// <param name="keyword">Search keyword</param>
        /// <returns>Collection of matching books</returns>
        IEnumerable<Sach> Search(string keyword);

        /// <summary>
        /// Updates stock quantity for a book
        /// </summary>
        /// <param name="maSach">Book ID</param>
        /// <param name="quantity">Quantity to add (positive) or remove (negative)</param>
        /// <returns>True if successful, false otherwise</returns>
        bool UpdateStock(string maSach, int quantity);
    }
}
