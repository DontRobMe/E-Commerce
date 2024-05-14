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
        user.birth = updatedUser.birth;
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
    
    public BusinessResult<Clients> Login(string email, string password)
    {
        var user = _dbContext.Client?.FirstOrDefault(u => u.Email == email && u.Password == password);
        if (user == null)
        {
            return new BusinessResult<Clients>
            {
                IsSuccess = false,
                Message = "User not found"
            };
        }
        return new BusinessResult<Clients>
        {
            IsSuccess = true,
            Message = "User found",
            Result = user
        };
    }
    
    public BusinessResult<Clients> Register(Clients newUser)
    {
        var user = _dbContext.Client?.FirstOrDefault(u => u.Email == newUser.Email);
        if (user != null)
        {
            return new BusinessResult<Clients>
            {
                IsSuccess = false,
                Message = "User already exists"
            };
        }
        _dbContext.Client?.Add(newUser);
        _dbContext.SaveChanges();
        return new BusinessResult<Clients>
        {
            IsSuccess = true,
            Message = "User created successfully",
            Result = newUser
        };
    }
    
    public BusinessResult<Clients> AddToWishlist(long userId, List<Produit> updatedWishList)
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
        user.WishList = updatedWishList;
        _dbContext.SaveChanges();
        return new BusinessResult<Clients>
        {
            IsSuccess = true,
            Message = "Wishlist updated successfully",
            Result = user
        };
    }
    
    public BusinessResult<Clients> GetWishlist(long userId)
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
        return new BusinessResult<Clients>
        {
            IsSuccess = true,
            Message = "Wishlist found",
            Result = user
        };
    }
}