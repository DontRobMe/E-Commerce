namespace E_Commerce.Business.Models;

public class Achats
{
    public int Id { get; set; }
    public string Produit { get; set; }

    public byte[] Facture { get; set; }
    public int prix { get; set; }
    public int quantité { get; set; }
    public string Date { get; set; }
}
