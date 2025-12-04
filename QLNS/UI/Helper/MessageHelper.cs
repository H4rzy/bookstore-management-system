using System;
using System.Windows.Forms;

namespace QLNS_UI.Common
{
    /// <summary>
    /// Helper class để hiển thị message box
    /// </summary>
    public static class MessageHelper
    {
        // ========== SUCCESS MESSAGES ==========

        public static void ShowSuccess(string action)
        {
            MessageBox.Show($"{action} thành công!", "Thành công", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowAddSuccess(string entityName)
        {
            MessageBox.Show($"Thêm {entityName} thành công!", "Thành công", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowUpdateSuccess(string entityName)
        {
            MessageBox.Show($"Cập nhật {entityName} thành công!", "Thành công", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowDeleteSuccess(string entityName)
        {
            MessageBox.Show($"Xóa {entityName} thành công!", "Thành công", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ========== ERROR MESSAGES ==========

        public static void ShowError(string title, string message)
        {
            MessageBox.Show(message, title, 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowAddError(string entityName, string detail = "")
        {
            string msg = $"Thêm {entityName} thất bại!";
            if (!string.IsNullOrEmpty(detail))
                msg += $"\nChi tiết: {detail}";
            
            MessageBox.Show(msg, "Lỗi", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowUpdateError(string entityName, string detail = "")
        {
            string msg = $"Cập nhật {entityName} thất bại!";
            if (!string.IsNullOrEmpty(detail))
                msg += $"\nChi tiết: {detail}";
            
            MessageBox.Show(msg, "Lỗi", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowDeleteError(string entityName, string detail = "")
        {
            string msg = $"Xóa {entityName} thất bại!";
            if (!string.IsNullOrEmpty(detail))
                msg += $"\nChi tiết: {detail}";
            
            MessageBox.Show(msg, "Lỗi", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowLoadDataError(string entityName, string detail = "")
        {
            string msg = $"Tải dữ liệu {entityName} thất bại!";
            if (!string.IsNullOrEmpty(detail))
                msg += $"\nChi tiết: {detail}";
            
            MessageBox.Show(msg, "Lỗi", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowSearchError(string entityName, string detail = "")
        {
            string msg = $"Tìm kiếm {entityName} thất bại!";
            if (!string.IsNullOrEmpty(detail))
                msg += $"\nChi tiết: {detail}";
            
            MessageBox.Show(msg, "Lỗi", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // ========== VALIDATION MESSAGES ==========

        public static void ShowRequiredFieldError(string fieldName)
        {
            MessageBox.Show($"{fieldName} không được để trống!", "Lỗi nhập liệu", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ShowInvalidDataError(string fieldName, string reason = "")
        {
            string msg = $"{fieldName} không hợp lệ!";
            if (!string.IsNullOrEmpty(reason))
                msg += $"\n{reason}";
            
            MessageBox.Show(msg, "Lỗi nhập liệu", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ShowDuplicateError(string entityName, string value)
        {
            MessageBox.Show($"{entityName} '{value}' đã tồn tại!", "Trùng dữ liệu", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // ========== CONFIRMATION MESSAGES ==========

        public static bool ShowConfirm(string message, string title = "Xác nhận")
        {
            DialogResult result = MessageBox.Show(message, title, 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result == DialogResult.Yes;
        }

        public static bool ShowDeleteConfirm(string entityName)
        {
            return ShowConfirm($"Bạn có chắc muốn xóa {entityName} này?", "Xác nhận xóa");
        }

        public static bool ShowUpdateConfirm(string entityName)
        {
            return ShowConfirm($"Bạn có chắc muốn cập nhật {entityName} này?", "Xác nhận cập nhật");
        }

        // ========== WARNING MESSAGES ==========

        public static void ShowWarning(string message, string title = "Cảnh báo")
        {
            MessageBox.Show(message, title, 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ShowNoSelectionWarning()
        {
            ShowWarning("Vui lòng chọn một dòng dữ liệu!", "Chưa chọn");
        }

        public static void ShowInsufficientStockWarning()
        {
            ShowWarning("Số lượng tồn kho không đủ!", "Cảnh báo tồn kho");
        }

        // ========== INFO MESSAGES ==========

        public static void ShowInfo(string message, string title = "Thông báo")
        {
            MessageBox.Show(message, title, 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowNoDataFound()
        {
            ShowInfo("Không tìm thấy dữ liệu!", "Kết quả tìm kiếm");
        }
    }
}
