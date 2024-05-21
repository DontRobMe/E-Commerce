using E_Commerce.Business.IRepositories;
using E_Commerce.Business.Models;
using E_Commerce.Data.Context;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


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
    
    public BusinessResult<string> Login(string email, string password)
    {
        var user = _dbContext.Client?.FirstOrDefault(u => u.Email == email && u.Password == password);
        if (user == null)
        {
            return new BusinessResult<string>
            {
                IsSuccess = false,
                Message = "Email ou mot de passe incorrect.",
                Result = null!
            };
        }

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Votre_clé_secrète"));

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenString = tokenHandler.WriteToken(token);
        return new BusinessResult<string>
        {
            IsSuccess = true,
            Message = "Authentification réussie.",
            Token = tokenString,
        };
    }
    
    public BusinessResult<string> Register(Clients user)
    {
        var existingUser = _dbContext.Client?.FirstOrDefault(u => u.Email == user.Email);
        if (existingUser != null)
        {
            return new BusinessResult<string>
            {
                IsSuccess = false,
                Message = "Le client existe déjà.",
                Result = null
            };
        }

        _dbContext.Client?.Add(user);
        _dbContext.SaveChanges();

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Votre_clé_secrète"));

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(1), 
            SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenString = tokenHandler.WriteToken(token);

        return new BusinessResult<string>
        {
            IsSuccess = true,
            Message = "Inscription réussie.",
            Result = tokenString
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