using E_Commerce.Business.Models;

namespace E_Commerce.Business.IServices;

public interface IProduitService
{
    public BusinessResult<IEnumerable<Produit>> GetProduits();

    public BusinessResult<Produit> GetProduitById(long id);

    public BusinessResult<Produit> CreateProduit(Produit item);

    public BusinessResult UpdateProduit(long id, Produit model);

    public BusinessResult DeleteProduit(long id);
}