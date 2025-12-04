using QLNS.Models;
using System.Collections.Generic;

namespace QLNS.BLL.Interfaces
{
    /// <summary>
    /// Service interface for Customer business logic
    /// </summary>
    public interface IKhachHangService
    {
        IEnumerable<KhachHang> GetAllCustomers();
        KhachHang GetCustomerById(string id);
        bool AddCustomer(KhachHang customer, out string errorMessage);
        bool UpdateCustomer(KhachHang customer, out string errorMessage);
        bool DeleteCustomer(string id, out string errorMessage);
        IEnumerable<KhachHang> SearchCustomers(string keyword);
        IEnumerable<KhachHang> GetCustomersByType(string type);
    }
}
