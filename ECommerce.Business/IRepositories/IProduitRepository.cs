using E_Commerce.Business.Models;

namespace E_Commerce.Business.IRepositories;

public interface IProduitRepository
{
    BusinessResult<Produit> CreateProduit(Produit newUser);
        
    void DeleteProduit(long userId);
        
    IEnumerable<Produit>? GetProduits();
        
    Produit GetProduitById(long? userId);
    
    Produit GetProduitByName(string name);
        
    BusinessResult<Produit> UpdateProduit(long userId, Produit updatedUser);
}