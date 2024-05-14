using E_Commerce.Business.Models;

namespace E_Commerce.Business.IRepositories;

public interface IClientRepository
{
    void DeleteClient(long userId);
        
    IEnumerable<Clients>? GetClients();
        
    Clients GetClientById(long? userId);
        
    BusinessResult<Clients> UpdateClient(long userId, Clients updatedUser);
    
    BusinessResult<Clients> Login(string email, string password);
    
    BusinessResult<Clients> Register(Clients newUser);
    
    BusinessResult<Clients> UpdateWallet(long userId, int updatedWallet);
    
    BusinessResult<Clients> UpdatePassword(long userId, string newPassword);
    
    BusinessResult<Clients> AddToWishlist(long userId, List<Produit> updatedWishList);
    
    BusinessResult<Clients> GetWishlist(long userId);
}