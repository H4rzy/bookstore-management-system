using QLNS.BLL.Interfaces;
using QLNS.DAL.Interfaces;
using QLNS.Models;
using System;
using System.Collections.Generic;

namespace QLNS.BLL.Services
{
    public class KhachHangService : IKhachHangService
    {
        private readonly IKhachHangRepository _repository;

        public KhachHangService(IKhachHangRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public IEnumerable<KhachHang> GetAllCustomers()
        {
            return _repository.GetAll();
        }

        public KhachHang GetCustomerById(string id)
        {
            return _repository.GetById(id);
        }

        public bool AddCustomer(KhachHang customer, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (!ValidateCustomer(customer, out errorMessage))
                return false;

            if (_repository.GetById(customer.MaKH) != null)
            {
                errorMessage = "Mã khách hàng đã tồn tại.";
                return false;
            }

            try
            {
                return _repository.Add(customer);
            }
            catch (Exception ex)
            {
                errorMessage = $"Lỗi: {ex.Message}";
                return false;
            }
        }

        public bool UpdateCustomer(KhachHang customer, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (!ValidateCustomer(customer, out errorMessage))
                return false;

            if (_repository.GetById(customer.MaKH) == null)
            {
                errorMessage = "Khách hàng không tồn tại.";
                return false;
            }

            try
            {
                return _repository.Update(customer);
            }
            catch (Exception ex)
            {
                errorMessage = $"Lỗi: {ex.Message}";
                return false;
            }
        }

        public bool DeleteCustomer(string id, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (_repository.GetById(id) == null)
            {
                errorMessage = "Khách hàng không tồn tại.";
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

        public IEnumerable<KhachHang> SearchCustomers(string keyword)
        {
            return _repository.Search(keyword);
        }

        public IEnumerable<KhachHang> GetCustomersByType(string type)
        {
            return _repository.GetByType(type);
        }

        private bool ValidateCustomer(KhachHang customer, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (customer == null)
            {
                errorMessage = "Thông tin khách hàng không hợp lệ.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(customer.MaKH))
            {
                errorMessage = "Mã khách hàng không được để trống.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(customer.TenKH))
            {
                errorMessage = "Tên khách hàng không được để trống.";
                return false;
            }

            return true;
        }
    }
}
