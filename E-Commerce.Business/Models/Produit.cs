namespace E_Commerce.Busines.Models;

public class Produit
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }
    public string Image { get; set; }
    public string Category { get; set; }
    public int Rating { get; set; }
    public Array Keys { get; set; }
    public Array Values { get; set; }
}