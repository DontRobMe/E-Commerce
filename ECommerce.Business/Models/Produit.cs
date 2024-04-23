namespace E_Commerce.Business.Models;

public class Produit
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }
    //public string Image { get; set; }
    public string Category { get; set; }
    public int Rating { get; set; }
    public string Keys { get; set; }
    
}