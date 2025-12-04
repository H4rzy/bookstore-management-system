using QLNS.BLL.Interfaces;
using QLNS.DAL.Interfaces;
using QLNS.Models;
using System;
using System.Collections.Generic;

namespace QLNS.BLL.Services
{
    public class NhanVienService : INhanVienService
    {
        private readonly INhanVienRepository _repository;

        public NhanVienService(INhanVienRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public IEnumerable<NhanVien> GetAllEmployees()
        {
            return _repository.GetAll();
        }

        public NhanVien GetEmployeeById(string id)
        {
            return _repository.GetById(id);
        }

        public bool AddEmployee(NhanVien employee, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (!ValidateEmployee(employee, out errorMessage))
                return false;

            if (_repository.GetById(employee.MaNV) != null)
            {
                errorMessage = "Mã nhân viên đã tồn tại.";
                return false;
            }

            try
            {
                return _repository.Add(employee);
            }
            catch (Exception ex)
            {
                errorMessage = $"Lỗi: {ex.Message}";
                return false;
            }
        }

        public bool UpdateEmployee(NhanVien employee, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (!ValidateEmployee(employee, out errorMessage))
                return false;

            if (_repository.GetById(employee.MaNV) == null)
            {
                errorMessage = "Nhân viên không tồn tại.";
                return false;
            }

            try
            {
                return _repository.Update(employee);
            }
            catch (Exception ex)
            {
                errorMessage = $"Lỗi: {ex.Message}";
                return false;
            }
        }

        public bool DeleteEmployee(string id, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (_repository.GetById(id) == null)
            {
                errorMessage = "Nhân viên không tồn tại.";
                return false;
            }

            try
            {
                return _repository.Delete(id);
            }
            catch (Exception ex)
            {
                errorMessage = $"Lỗi: {ex.Message}";
                return false;
            }
        }

        public IEnumerable<NhanVien> SearchEmployees(string keyword)
        {
            return _repository.Search(keyword);
        }

        public IEnumerable<NhanVien> GetEmployeesByPosition(string position)
        {
            return _repository.GetByPosition(position);
        }

        private bool ValidateEmployee(NhanVien employee, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (employee == null)
            {
                errorMessage = "Thông tin nhân viên không hợp lệ.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(employee.MaNV))
            {
                errorMessage = "Mã nhân viên không được để trống.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(employee.TenNV))
            {
                errorMessage = "Tên nhân viên không được để trống.";
                return false;
            }

            return true;
        }
    }
}
