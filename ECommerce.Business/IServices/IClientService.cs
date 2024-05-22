using E_Commerce.Business.DTO;
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

    public BusinessResult AddToWishlist(int userId, int updatedWishListDtos);
    
    public BusinessResult<List<ProduitDto.WishlistProductDto>> GetWishlist(long id);
    public BusinessResult RemoveFromWishlist(int userId, int productId);
}