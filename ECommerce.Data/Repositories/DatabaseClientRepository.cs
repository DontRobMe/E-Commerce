using E_Commerce.Business.IRepositories;
using E_Commerce.Business.Models;
using E_Commerce.Data.Context;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using E_Commerce.Business.DTO;
using Microsoft.EntityFrameworkCore;


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
        var user = _dbContext.Client.FirstOrDefault(u => u.Id == userId);
        if (user == null) return;
        _dbContext.Client.Remove(user);
        _dbContext.SaveChanges();
    }

    public IEnumerable<Clients> GetClients()
    {
        return _dbContext.Client;
    }

    public Clients GetClientById(long? userId)
    {
        return _dbContext.Client.FirstOrDefault(u => u.Id == userId)!;
    }

    public BusinessResult<Clients> UpdateClient(long userId, Clients updatedUser)
    {
        var user = _dbContext.Client.FirstOrDefault(u => u.Id == userId);
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
        user.Birth = updatedUser.Birth;
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
        var user = _dbContext.Client.FirstOrDefault(u => u.Id == userId);
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
        var user = _dbContext.Client.FirstOrDefault(u => u.Email == email && u.Password == password);
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
        var existingUser = _dbContext.Client.FirstOrDefault(u => u.Email == user.Email);
        if (existingUser != null)
        {
            return new BusinessResult<string>
            {
                IsSuccess = false,
                Message = "Le client existe déjà.",
                Result = null!
            };
        }

        _dbContext.Client.Add(user);
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
            Token = tokenString,
        };
    }

    public BusinessResult AddToWishlist(int userId, WishlistItem wishlistItem)
    {
        using var transaction = _dbContext.Database.BeginTransaction();
        try
        {
            var user = _dbContext.Client
                .Include(u => u.Wishlist)
                .ThenInclude(w => w.Produit)
                .FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return BusinessResult.FromError("User not found");
            }

            var existingProduct = _dbContext.Produit.Find(wishlistItem.ProduitId);
            if (existingProduct == null)
            {
                return BusinessResult.FromError($"Product with ID {wishlistItem.ProduitId} not found");
            }
                
            user.Wishlist.Add(new WishlistItem
            {
                ClientId = user.Id,
                ProduitId = existingProduct.Id,
                Produit = existingProduct
            });

            _dbContext.SaveChanges();
            transaction.Commit();

            return BusinessResult.FromSuccess($"Wishlist updated successfully {user}");
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            return BusinessResult.FromError( $"An error occurred: {ex.Message}");
        }
    }




    public BusinessResult<List<ProduitDto.WishlistProductDto>> GetWishlist(long userId)
    {
        var user = _dbContext.Client
            .Include(u => u.Wishlist)
            .ThenInclude(w => w.Produit)
            .FirstOrDefault(u => u.Id == userId);

        if (user == null)
        {
            return new BusinessResult<List<ProduitDto.WishlistProductDto>>
            {
                IsSuccess = false,
                Message = "User not found"
            };
        }

        var wishlistProducts = user.Wishlist.Select(w => new ProduitDto.WishlistProductDto
        {
            ProduitId = w.Produit.Id,
            ProduitName = w.Produit.Name,
            ProduitImage = w.Produit.Image,
            ProduitPrice = w.Produit.Price
        }).ToList();

        return new BusinessResult<List<ProduitDto.WishlistProductDto>>
        {
            IsSuccess = true,
            Message = "Wishlist found",
            Result = wishlistProducts
        };
    }

    public BusinessResult RemoveFromWishlist(int userId, int productId)
    {
        using var transaction = _dbContext.Database.BeginTransaction();
        try
        {
            var user = _dbContext.Client
                .Include(u => u.Wishlist)
                .FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return BusinessResult.FromError("User not found");
            }

            var wishlistItem = user.Wishlist.FirstOrDefault(w => w.ProduitId == productId);
            if (wishlistItem == null)
            {
                return BusinessResult.FromError($"Product with ID {productId} not found in wishlist");
            }

            user.Wishlist.Remove(wishlistItem);
            _dbContext.SaveChanges();
            transaction.Commit();

            return BusinessResult.FromSuccess("Product removed from wishlist");
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            return BusinessResult.FromError($"An error occurred: {ex.Message}");
        }
    }
    
    
    public BusinessResult AddToCart(int userId, CartItem cartItems)
    {
        using var transaction = _dbContext.Database.BeginTransaction();
        try
        {
            var user = _dbContext.Client
                .Include(u => u.CartItems)
                .ThenInclude(w => w.Produit)
                .FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return BusinessResult.FromError("User not found");
            }

            var existingProduct = _dbContext.Produit.Find(cartItems.ProduitId);
            if (existingProduct == null)
            {
                return BusinessResult.FromError($"Product with ID {cartItems.ProduitId} not found");
            }
                
            user.CartItems.Add(new CartItem
            {
                ClientId = user.Id,
                ProduitId = existingProduct.Id,
                Produit = existingProduct
            });

            _dbContext.SaveChanges();
            transaction.Commit();

            return BusinessResult.FromSuccess($"Wishlist updated successfully {user}");
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            return BusinessResult.FromError( $"An error occurred: {ex.Message}");
        }
    }




        public BusinessResult<List<ProduitDto.CartProductDto>> GetCart(long userId)
        {
            var user = _dbContext.Client
                .Include(u => u.CartItems)
                .ThenInclude(w => w.Produit)
                .FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return new BusinessResult<List<ProduitDto.CartProductDto>>
                {
                    IsSuccess = false,
                    Message = "User not found"
                };
            }

            var cartProducts = user.CartItems.Select(w => new ProduitDto.CartProductDto
            {
                ProduitId = w.Produit.Id,
                ProduitName = w.Produit.Name,
                ProduitImage = w.Produit.Image,
                ProduitPrice = w.Produit.Price,
                ProduitCategory = w.Produit.Category
            }).ToList();

            return new BusinessResult<List<ProduitDto.CartProductDto>>
            {
                IsSuccess = true,
                Message = "Wishlist found",
                Result = cartProducts
            };
        }

    public BusinessResult RemoveFromCart(int userId, int productId)
    {
        using var transaction = _dbContext.Database.BeginTransaction();
        try
        {
            var user = _dbContext.Client
                .Include(u => u.CartItems)
                .FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return BusinessResult.FromError("User not found");
            }

            var cartItem = user.CartItems.FirstOrDefault(w => w.ProduitId == productId);
            if (cartItem == null)
            {
                return BusinessResult.FromError($"Product with ID {productId} not found in wishlist");
            }

            user.CartItems.Remove(cartItem);
            _dbContext.SaveChanges();
            transaction.Commit();

            return BusinessResult.FromSuccess("Product removed from wishlist");
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            return BusinessResult.FromError($"An error occurred: {ex.Message}");
        }
    }

}