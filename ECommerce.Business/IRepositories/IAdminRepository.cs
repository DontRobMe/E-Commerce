using E_Commerce.Business.Models;

namespace E_Commerce.Business.IRepositories;

public interface IAdminRepository
{
    BusinessResult<Admin> CreateAdmin(Admin newUser);
        
    void DeleteAdmin(long userId);
        
    IEnumerable<Admin>? GetAdmins();
        
    Admin GetAdminById(long? userId);
        
    BusinessResult<Admin> UpdateAdmin(long userId, Admin updatedUser);
    
    BusinessResult<Admin> LoginAdmin(string email, string password);
}