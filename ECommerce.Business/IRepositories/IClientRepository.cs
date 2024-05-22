using E_Commerce.Business.DTO;
using E_Commerce.Business.Models;

namespace E_Commerce.Business.IRepositories;

public interface IClientRepository
{
    void DeleteClient(long userId);
        
    IEnumerable<Clients>? GetClients();
        
    Clients GetClientById(long? userId);
        
    BusinessResult<Clients> UpdateClient(long userId, Clients updatedUser);
    
    BusinessResult<string> Login(string email, string password);
    
    BusinessResult<string> Register(Clients newUser);
    BusinessResult<Clients> UpdatePassword(long userId, string newPassword);

    public BusinessResult AddToWishlist(int userId, WishlistItem wishlistItem);
    
    BusinessResult<List<ProduitDto.WishlistProductDto>> GetWishlist(long userId);
    
    public BusinessResult RemoveFromWishlist(int userId, int productId);
}