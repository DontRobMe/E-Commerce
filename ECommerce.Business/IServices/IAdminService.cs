using E_Commerce.Business.Models;

namespace E_Commerce.Business.IServices;

public interface IAdminService
{
    public BusinessResult<IEnumerable<Admin>> GetAdmins();

    public BusinessResult<Admin> GetAdminById(long id);

    public BusinessResult CreateAdmin(Admin item);

    public BusinessResult UpdateAdmin(long id, Admin model);

    public BusinessResult DeleteAdmin(long id);
}