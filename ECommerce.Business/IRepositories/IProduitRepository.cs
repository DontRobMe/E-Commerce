using E_Commerce.Business.Models;

namespace E_Commerce.Business.IRepositories;

public interface IProduitRepository
{
    void CreateProduit(Produit newUser);
        
    void DeleteProduit(long userId);
        
    IEnumerable<Produit>? GetProduits();
        
    Produit GetProduitById(long? userId);
        
    BusinessResult<Produit> UpdateProduit(long userId, Produit updatedUser);
}