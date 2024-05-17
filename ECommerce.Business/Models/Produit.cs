using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Business.Models;

public class Produit
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }
    public byte[] Image { get; set; }
    public string Category { get; set; }
    public int Rating { get; set; }
    [NotMapped]
    public List<string>? productcodes { get; set; }
    
}