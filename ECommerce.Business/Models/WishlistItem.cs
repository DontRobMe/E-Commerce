namespace E_Commerce.Business.Models;

public class WishlistItem
{
    public int Id { get; set; }

    public int ClientId { get; set; }
    public Clients Client { get; set; }

    public int ProduitId { get; set; }
    public Produit Produit { get; set; }
}