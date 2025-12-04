using QLNS.BLL.Interfaces;
using QLNS.BLL.Services;
using QLNS.DAL;
using QLNS.DAL.Interfaces;
using QLNS.DAL.Repositories;
using System;
using System.Collections.Generic;

namespace QLNS.Common
{
    /// <summary>
    /// Simple Dependency Injection Container
    /// Implements Service Locator pattern following DIP (Dependency Inversion Principle)
    /// </summary>
    public class ServiceContainer
    {
        private static ServiceContainer _instance;
        private readonly Dictionary<Type, object> _services;
        private readonly DatabaseContext _context;

        private ServiceContainer()
        {
            _services = new Dictionary<Type, object>();
            _context = new DatabaseContext();
            RegisterServices();
        }

        /// <summary>
        /// Gets the singleton instance of the service container
        /// </summary>
        public static ServiceContainer Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ServiceContainer();
                return _instance;
            }
        }

        /// <summary>
        /// Registers all services and repositories
        /// </summary>
        private void RegisterServices()
        {
            // Register Repositories (DAL)
            Register<ISachRepository>(new SachRepository(_context));
            Register<ITheLoaiRepository>(new TheLoaiRepository(_context));
            Register<INhaXuatBanRepository>(new NhaXuatBanRepository(_context));
            Register<IKhachHangRepository>(new KhachHangRepository(_context));
            Register<INhanVienRepository>(new NhanVienRepository(_context));
            Register<ITaiKhoanRepository>(new TaiKhoanRepository(_context));
            Register<IHoaDonRepository>(new HoaDonRepository(_context));
            Register<IPhieuNhapRepository>(new PhieuNhapRepository(_context));

            // Register Services (BLL)
            Register<ISachService>(new SachService(
                Resolve<ISachRepository>(),
                Resolve<ITheLoaiRepository>(),
                Resolve<INhaXuatBanRepository>()
            ));

            Register<IKhachHangService>(new KhachHangService(
                Resolve<IKhachHangRepository>()
            ));

            Register<INhanVienService>(new NhanVienService(
                Resolve<INhanVienRepository>()
            ));

            Register<IHoaDonService>(new HoaDonService(
                Resolve<IHoaDonRepository>(),
                Resolve<ISachRepository>()
            ));

            Register<IPhieuNhapService>(new PhieuNhapService(
                Resolve<IPhieuNhapRepository>(),
                Resolve<ISachRepository>()
            ));
        }

        /// <summary>
        /// Registers a service instance
        /// </summary>
        /// <typeparam name="T">Service type</typeparam>
        /// <param name="service">Service instance</param>
        public void Register<T>(object service)
        {
            _services[typeof(T)] = service;
        }

        /// <summary>
        /// Resolves a service from the container
        /// </summary>
        /// <typeparam name="T">Service type to resolve</typeparam>
        /// <returns>Service instance</returns>
        public T Resolve<T>()
        {
            if (_services.ContainsKey(typeof(T)))
                return (T)_services[typeof(T)];

            throw new InvalidOperationException($"Service of type {typeof(T).Name} is not registered.");
        }

        /// <summary>
        /// Disposes the database context and clears services
        /// </summary>
        public void Dispose()
        {
            _context?.Dispose();
            _services?.Clear();
            _instance = null;
        }
    }
}
