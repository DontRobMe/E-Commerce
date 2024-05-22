namespace E_Commerce.Business.Models;

public class WishlistItem
{
    public int Id { get; set; }

    // Clé étrangère pour le client
    public int ClientId { get; set; }
    public Clients Client { get; set; }

    // Clé étrangère pour le produit
    public int ProduitId { get; set; }
    public Produit Produit { get; set; }
}