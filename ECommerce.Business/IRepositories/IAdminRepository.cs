using E_Commerce.Business.Models;

namespace E_Commerce.Business.IRepositories;

public interface IAdminRepository
{
    void CreateAdmin(Admin newUser);
        
    void DeleteAdmin(long userId);
        
    IEnumerable<Admin>? GetAdmins();
        
    Admin GetAdminById(long? userId);
        
    BusinessResult<Admin> UpdateAdmin(long userId, Admin updatedUser);
}