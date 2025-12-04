using System;
using System.Text.RegularExpressions;

namespace QLNS_UI.Common
{
    /// <summary>
    /// Helper class để validate dữ liệu
    /// </summary>
    public static class ValidationHelper
    {
        // ========== GENERAL VALIDATION ==========

        public static bool IsNullOrEmpty(string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static bool IsValidEmail(string email)
        {
            if (IsNullOrEmpty(email)) return false;
            try
            {
                string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                return Regex.IsMatch(email, pattern);
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidPhone(string phone)
        {
            if (IsNullOrEmpty(phone)) return false;
            // Chấp nhận số điện thoại VN: 10-11 số, bắt đầu 0
            string pattern = @"^0\d{9,10}$";
            return Regex.IsMatch(phone, pattern);
        }

        public static bool IsValidNumber(string value)
        {
            if (IsNullOrEmpty(value)) return false;
            decimal result;
            return decimal.TryParse(value, out result);
        }

        public static bool IsValidDate(string date)
        {
            if (IsNullOrEmpty(date)) return false;
            DateTime result;
            return DateTime.TryParse(date, out result);
        }

        public static bool IsValidInteger(string value)
        {
            if (IsNullOrEmpty(value)) return false;
            int result;
            return int.TryParse(value, out result);
        }

        // ========== BOOKSTORE SPECIFIC ==========

        public static bool IsValidPrice(decimal giaBan, decimal giaNhap)
        {
            return giaBan > giaNhap && giaBan > 0 && giaNhap > 0;
        }

        public static bool IsValidQuantity(int soLuong)
        {
            return soLuong > 0;
        }

        public static bool IsValidCode(string code)
        {
            if (IsNullOrEmpty(code)) return false;
            // Chỉ chấp nhận chữ, số và không quá 20 ký tự
            if (code.Length > 20) return false;
            string pattern = @"^[a-zA-Z0-9]+$";
            return Regex.IsMatch(code, pattern);
        }

        public static bool IsValidName(string name)
        {
            if (IsNullOrEmpty(name)) return false;
            // Không quá 200 ký tự
            return name.Length <= 200;
        }

        public static bool IsValidAddress(string address)
        {
            if (IsNullOrEmpty(address)) return false;
            return address.Length <= 500;
        }

        // ========== PASSWORD & USERNAME ==========

        public static bool IsValidPassword(string password)
        {
            if (IsNullOrEmpty(password)) return false;
            // Mật khẩu ít nhất 6 ký tự
            return password.Length >= 6;
        }

        public static bool IsValidUsername(string username)
        {
            if (IsNullOrEmpty(username)) return false;
            // Username: chữ, số, gạch dưới, 3-50 ký tự
            if (username.Length < 3 || username.Length > 50) return false;
            string pattern = @"^[a-zA-Z0-9_]+$";
            return Regex.IsMatch(username, pattern);
        }

        // ========== VALIDATION WITH MESSAGE ==========

        public static bool ValidateRequired(string value, string fieldName, out string message)
        {
            message = string.Empty;
            if (IsNullOrEmpty(value))
            {
                message = $"{fieldName} không được để trống";
                return false;
            }
            return true;
        }

        public static bool ValidatePrice(decimal giaBan, decimal giaNhap, out string message)
        {
            message = string.Empty;
            if (giaBan <= 0 || giaNhap <= 0)
            {
                message = "Giá phải lớn hơn 0";
                return false;
            }
            if (giaBan <= giaNhap)
            {
                message = "Giá bán phải lớn hơn giá nhập";
                return false;
            }
            return true;
        }

        public static bool ValidateQuantity(int soLuong, out string message)
        {
            message = string.Empty;
            if (soLuong <= 0)
            {
                message = "Số lượng phải lớn hơn 0";
                return false;
            }
            return true;
        }

        public static bool ValidatePasswordMatch(string password, string confirmPassword, out string message)
        {
            message = string.Empty;
            if (password != confirmPassword)
            {
                message = "Mật khẩu xác nhận không khớp";
                return false;
            }
            return true;
        }
    }
}
