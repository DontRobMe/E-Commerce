using E_Commerce.Business.IRepositories;
using E_Commerce.Business.Models;
using E_Commerce.Data.Context;

namespace E_Commerce.Data.Repositories;

public class DatabaseClientRepository : IClientRepository
{
    private readonly MyDbContext _dbContext;

    public DatabaseClientRepository(MyDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public void CreateClient(Clients newUser)
    {
        _dbContext.Client?.Add(newUser);
        _dbContext.SaveChanges();
    }

    public void DeleteClient(long userId)
    {
        var user = _dbContext.Client?.FirstOrDefault(u => u.Id == userId);
        if (user == null) return;
        _dbContext.Client?.Remove(user);
        _dbContext.SaveChanges();
    }

    public IEnumerable<Clients>? GetClients()
    {
        return _dbContext.Client;
    }

    public Clients GetClientById(long? userId)
    {
        return _dbContext.Client?.FirstOrDefault(u => u.Id == userId)!;
    }

    public BusinessResult<Clients> UpdateClient(long userId, Clients updatedUser)
    {
        var user = _dbContext.Client?.FirstOrDefault(u => u.Id == userId);
        if (user == null)
        {
            return new BusinessResult<Clients>
            {
                IsSuccess = false,
                Message = "User not found"
            };
        }
        user.Name = updatedUser.Name;
        user.LastName = updatedUser.LastName;
        user.Email = updatedUser.Email;
        user.Address = updatedUser.Address;
        _dbContext.SaveChanges();
        return new BusinessResult<Clients>
        {
            IsSuccess = true,
            Message = "User updated successfully",
            Result = user
        };
    }
    
    public BusinessResult<Clients> UpdateWallet(long userId, int updatedWallet)
    {
        var user = _dbContext.Client?.FirstOrDefault(u => u.Id == userId);
        if (user == null)
        {
            return new BusinessResult<Clients>
            {
                IsSuccess = false,
                Message = "User not found"
            };
        }
        user.Wallet = updatedWallet;
        _dbContext.SaveChanges();
        return new BusinessResult<Clients>
        {
            IsSuccess = true,
            Message = "Wallet updated successfully",
            Result = user
        };
    }
    
    public BusinessResult<Clients> UpdatePassword(long userId, string updatedPassword)
    {
        var user = _dbContext.Client?.FirstOrDefault(u => u.Id == userId);
        if (user == null)
        {
            return new BusinessResult<Clients>
            {
                IsSuccess = false,
                Message = "User not found"
            };
        }
        user.Password = updatedPassword;
        _dbContext.SaveChanges();
        return new BusinessResult<Clients>
        {
            IsSuccess = true,
            Message = "Password updated successfully",
            Result = user
        };
    }
}