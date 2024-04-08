using System.Text.Json.Nodes;

namespace E_Commerce.Busines.Models;

public class Achats
{
    public int Id { get; set; }
    public string Produit { get; set; }
    public JsonArray Facture { get; set; }
    public string Date { get; set; }
}