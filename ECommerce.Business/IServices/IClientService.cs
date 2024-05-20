using E_Commerce.Business.Models;

namespace E_Commerce.Business.IServices;

public interface IClientService
{
    public BusinessResult<IEnumerable<Clients>> GetClients();

    public BusinessResult<Clients> GetClientById(long id);
    
    public BusinessResult UpdateClient(long id, Clients model);

    public BusinessResult DeleteClient(long id);
    
    public BusinessResult UpdatePassword(long id, string password);
    
    public BusinessResult Login(string email, string password);
    
    public BusinessResult Register(Clients newUser);
    
    public BusinessResult AddToWishlist(long id, List<Produit> updatedWishList);
    
    public BusinessResult<Clients> GetWishlist(long id);
}