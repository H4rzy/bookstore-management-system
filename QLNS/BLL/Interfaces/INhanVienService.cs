using QLNS.Models;
using System.Collections.Generic;

namespace QLNS.BLL.Interfaces
{
    /// <summary>
    /// Service interface for Employee business logic
    /// </summary>
    public interface INhanVienService
    {
        IEnumerable<NhanVien> GetAllEmployees();
        NhanVien GetEmployeeById(string id);
        bool AddEmployee(NhanVien employee, out string errorMessage);
        bool UpdateEmployee(NhanVien employee, out string errorMessage);
        bool DeleteEmployee(string id, out string errorMessage);
        IEnumerable<NhanVien> SearchEmployees(string keyword);
        IEnumerable<NhanVien> GetEmployeesByPosition(string position);
    }
}
