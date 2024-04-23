using E_Commerce.Business.IRepositories;
using E_Commerce.Business.Models;
using E_Commerce.Data.Context;

namespace E_Commerce.Data.Repositories;

public class DatabaseAdminRepository : IAdminRepository
{
    private readonly MyDbContext _dbContext;

    public DatabaseAdminRepository(MyDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }
    public void CreateAdmin(Admin newUser)
    {
        _dbContext.Admin?.Add(newUser);
        _dbContext.SaveChanges();
    }

    public void DeleteAdmin(long userId)
    {
        var user = _dbContext.Admin?.FirstOrDefault(u => u.Id == userId);
        if (user == null) return;
        _dbContext.Admin?.Remove(user);
        _dbContext.SaveChanges();
    }

    public IEnumerable<Admin>? GetAdmins()
    {
        return _dbContext.Admin;
    }

    public Admin GetAdminById(long? userId)
    {
        return _dbContext.Admin?.FirstOrDefault(u => u.Id == userId)!;
    }

    public BusinessResult<Admin> UpdateAdmin(long userId, Admin updatedUser)
    {   
        var user = _dbContext.Admin?.FirstOrDefault(u => u.Id == userId);
        if (user == null)
        {
            return new BusinessResult<Admin>
            {
                IsSuccess = false,
                Message = "User not found"
            };
        }
        user.Name = updatedUser.Name;
        user.LastName = updatedUser.LastName;
        user.Email = updatedUser.Email;
        user.Birth = updatedUser.Birth;
        _dbContext.SaveChanges();
        return new BusinessResult<Admin>
        {
            IsSuccess = true,
            Message = "User updated successfully",
            Result = user
        };
    }
    
    public BusinessResult<Admin> UpdateAdminPassword(long userId, Admin updatedUser)
    {
        var user = _dbContext.Admin?.FirstOrDefault(u => u.Id == userId);
        if (user == null)
        {
            return new BusinessResult<Admin>
            {
                IsSuccess = false,
                Message = "User not found"
            };
        }
        user.Password = updatedUser.Password;
        _dbContext.SaveChanges();
        return new BusinessResult<Admin>
        {
            IsSuccess = true,
            Message = "User updated successfully",
            Result = user
        };
    }
}