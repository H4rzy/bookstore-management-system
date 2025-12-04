using QLNS.BLL.Interfaces;
using QLNS.DAL.Interfaces;
using QLNS.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QLNS.BLL.Services
{
    /// <summary>
    /// Service implementation for Book business logic
    /// Implements validation and business rules following SRP (Single Responsibility Principle)
    /// </summary>
    public class SachService : ISachService
    {
        private readonly ISachRepository _sachRepository;
        private readonly ITheLoaiRepository _theLoaiRepository;
        private readonly INhaXuatBanRepository _nxbRepository;

        // Dependency Injection following DIP (Dependency Inversion Principle)
        public SachService(ISachRepository sachRepository, ITheLoaiRepository theLoaiRepository, INhaXuatBanRepository nxbRepository)
        {
            _sachRepository = sachRepository ?? throw new ArgumentNullException(nameof(sachRepository));
            _theLoaiRepository = theLoaiRepository ?? throw new ArgumentNullException(nameof(theLoaiRepository));
            _nxbRepository = nxbRepository ?? throw new ArgumentNullException(nameof(nxbRepository));
        }

        public IEnumerable<Sach> GetAllBooks()
        {
            return _sachRepository.GetAll();
        }

        public Sach GetBookById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return null;

            return _sachRepository.GetById(id);
        }

        public bool AddBook(Sach book, out string errorMessage)
        {
            errorMessage = string.Empty;

            // Validation
            if (!ValidateBook(book, out errorMessage))
                return false;

            // Business Rule: Check if book ID already exists
            if (_sachRepository.GetById(book.MaSach) != null)
            {
                errorMessage = "Mã sách đã tồn tại trong hệ thống.";
                return false;
            }

            // Business Rule: Check if category exists
            if (_theLoaiRepository.GetById(book.MaTheLoai) == null)
            {
                errorMessage = "Thể loại không tồn tại trong hệ thống.";
                return false;
            }

            // Business Rule: Check if publisher exists
            if (_nxbRepository.GetById(book.MaNXB) == null)
            {
                errorMessage = "Nhà xuất bản không tồn tại trong hệ thống.";
                return false;
            }

            try
            {
                return _sachRepository.Add(book);
            }
            catch (Exception ex)
            {
                errorMessage = $"Lỗi khi thêm sách: {ex.Message}";
                return false;
            }
        }

        public bool UpdateBook(Sach book, out string errorMessage)
        {
            errorMessage = string.Empty;

            // Validation
            if (!ValidateBook(book, out errorMessage))
                return false;

            // Business Rule: Check if book exists
            if (_sachRepository.GetById(book.MaSach) == null)
            {
                errorMessage = "Sách không tồn tại trong hệ thống.";
                return false;
            }

            // Business Rule: Check if category exists
            if (_theLoaiRepository.GetById(book.MaTheLoai) == null)
            {
                errorMessage = "Thể loại không tồn tại trong hệ thống.";
                return false;
            }

            // Business Rule: Check if publisher exists
            if (_nxbRepository.GetById(book.MaNXB) == null)
            {
                errorMessage = "Nhà xuất bản không tồn tại trong hệ thống.";
                return false;
            }

            try
            {
                return _sachRepository.Update(book);
            }
            catch (Exception ex)
            {
                errorMessage = $"Lỗi khi cập nhật sách: {ex.Message}";
                return false;
            }
        }

        public bool DeleteBook(string id, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(id))
            {
                errorMessage = "Mã sách không hợp lệ.";
                return false;
            }

            var book = _sachRepository.GetById(id);
            if (book == null)
            {
                errorMessage = "Sách không tồn tại trong hệ thống.";
                return false;
            }

            // Note: In a real system, you would check if the book has been used in invoices or purchase orders
            // and prevent deletion if it has been used

            try
            {
                return _sachRepository.Delete(id);
            }
            catch (Exception ex)
            {
                errorMessage = $"Lỗi khi xóa sách: {ex.Message}. Có thể sách đã được sử dụng trong hóa đơn hoặc phiếu nhập.";
                return false;
            }
        }

        public IEnumerable<Sach> SearchBooks(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return GetAllBooks();

            return _sachRepository.Search(keyword);
        }

        public IEnumerable<Sach> GetBooksByCategory(string categoryId)
        {
            if (string.IsNullOrWhiteSpace(categoryId))
                return new List<Sach>();

            return _sachRepository.GetByTheLoai(categoryId);
        }

        public bool CheckAvailability(string bookId, int quantity)
        {
            if (string.IsNullOrWhiteSpace(bookId) || quantity <= 0)
                return false;

            var book = _sachRepository.GetById(bookId);
            if (book == null)
                return false;

            return book.SoLuongTon >= quantity;
        }

        public decimal CalculateProfit(string bookId, int soldQuantity)
        {
            if (string.IsNullOrWhiteSpace(bookId) || soldQuantity <= 0)
                return 0;

            var book = _sachRepository.GetById(bookId);
            if (book == null)
                return 0;

            return (book.DonGiaBan - book.DonGiaNhap) * soldQuantity;
        }

        // Private validation method following SRP
        private bool ValidateBook(Sach book, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (book == null)
            {
                errorMessage = "Thông tin sách không hợp lệ.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(book.MaSach))
            {
                errorMessage = "Mã sách không được để trống.";
                return false;
            }

            if (book.MaSach.Length > 10)
            {
                errorMessage = "Mã sách không được vượt quá 10 ký tự.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(book.TenSach))
            {
                errorMessage = "Tên sách không được để trống.";
                return false;
            }

            if (book.TenSach.Length > 200)
            {
                errorMessage = "Tên sách không được vượt quá 200 ký tự.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(book.MaTheLoai))
            {
                errorMessage = "Thể loại không được để trống.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(book.MaNXB))
            {
                errorMessage = "Nhà xuất bản không được để trống.";
                return false;
            }

            if (book.DonGiaNhap <= 0)
            {
                errorMessage = "Đơn giá nhập phải lớn hơn 0.";
                return false;
            }

            if (book.DonGiaBan <= 0)
            {
                errorMessage = "Đơn giá bán phải lớn hơn 0.";
                return false;
            }

            if (book.DonGiaBan < book.DonGiaNhap)
            {
                errorMessage = "Đơn giá bán phải lớn hơn hoặc bằng đơn giá nhập.";
                return false;
            }

            if (book.SoLuongTon < 0)
            {
                errorMessage = "Số lượng tồn không được âm.";
                return false;
            }

            return true;
        }
    }
}
