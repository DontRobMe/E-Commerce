namespace E_Commerce.Business.Models;

public class Clients
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string Password { get; set; }
    public string birth { get; set; }
    public List<Produit> WishList { get; set; }
}