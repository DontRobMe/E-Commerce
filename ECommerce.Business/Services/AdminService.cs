﻿using E_Commerce.Business.IRepositories;
using E_Commerce.Business.IServices;
using E_Commerce.Business.Models;

namespace E_Commerce.Business.Services;

public class AdminService : IAdminService
{
    private readonly IAdminRepository _adminRepository;

    public AdminService(IAdminRepository adminRepository)
    {
        _adminRepository = adminRepository ?? throw new ArgumentNullException(nameof(adminRepository));
    }
    public BusinessResult<IEnumerable<Admin>> GetAdmins()
    {
        var admins = _adminRepository.GetAdmins();
        return BusinessResult<IEnumerable<Admin>>.FromSuccess(admins);
    }

    public BusinessResult<Admin> GetAdminById(long id)
    {
        var admin = _adminRepository.GetAdminById(id);
        return BusinessResult<Admin>.FromSuccess(admin);
    }

    public BusinessResult<Admin> CreateAdmin(Admin item)
    {
        _adminRepository.CreateAdmin(item);
        return BusinessResult<Admin>.FromSuccess(item);
    }

    public BusinessResult UpdateAdmin(long id, Admin model)
    {
        var updatedAdmin = _adminRepository.UpdateAdmin(id, model);
        return BusinessResult.FromSuccess(updatedAdmin);
    }

    public BusinessResult DeleteAdmin(long id)
    {
        _adminRepository.DeleteAdmin(id);
        return BusinessResult.FromSuccess();
    }
}