using QLNS.Models;
using System.Collections.Generic;

namespace QLNS.BLL.Interfaces
{
    /// <summary>
    /// Service interface for Book business logic
    /// Defines operations for managing books with validation and business rules
    /// </summary>
    public interface ISachService
    {
        /// <summary>
        /// Gets all books from the database
        /// </summary>
        /// <returns>Collection of all books</returns>
        IEnumerable<Sach> GetAllBooks();

        /// <summary>
        /// Gets a book by its ID
        /// </summary>
        /// <param name="id">Book ID</param>
        /// <returns>Book entity or null if not found</returns>
        Sach GetBookById(string id);

        /// <summary>
        /// Adds a new book with validation
        /// </summary>
        /// <param name="book">Book to add</param>
        /// <param name="errorMessage">Error message if validation fails</param>
        /// <returns>True if successful, false otherwise</returns>
        bool AddBook(Sach book, out string errorMessage);

        /// <summary>
        /// Updates an existing book with validation
        /// </summary>
        /// <param name="book">Book to update</param>
        /// <param name="errorMessage">Error message if validation fails</param>
        /// <returns>True if successful, false otherwise</returns>
        bool UpdateBook(Sach book, out string errorMessage);

        /// <summary>
        /// Deletes a book (with business rule checks)
        /// </summary>
        /// <param name="id">Book ID to delete</param>
        /// <param name="errorMessage">Error message if deletion fails</param>
        /// <returns>True if successful, false otherwise</returns>
        bool DeleteBook(string id, out string errorMessage);

        /// <summary>
        /// Searches books by keyword
        /// </summary>
        /// <param name="keyword">Search keyword</param>
        /// <returns>Collection of matching books</returns>
        IEnumerable<Sach> SearchBooks(string keyword);

        /// <summary>
        /// Gets books by category
        /// </summary>
        /// <param name="categoryId">Category ID</param>
        /// <returns>Collection of books in the category</returns>
        IEnumerable<Sach> GetBooksByCategory(string categoryId);

        /// <summary>
        /// Checks if a book is available in the specified quantity
        /// </summary>
        /// <param name="bookId">Book ID</param>
        /// <param name="quantity">Quantity needed</param>
        /// <returns>True if available, false otherwise</returns>
        bool CheckAvailability(string bookId, int quantity);

        /// <summary>
        /// Calculates profit for selling a book
        /// </summary>
        /// <param name="bookId">Book ID</param>
        /// <param name="soldQuantity">Quantity sold</param>
        /// <returns>Profit amount</returns>
        decimal CalculateProfit(string bookId, int soldQuantity);
    }
}
