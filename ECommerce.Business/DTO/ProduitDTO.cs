using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Business.DTO;

public class ProduitDto
{
    public class CreateProduitDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Category { get; set; } 
        public int Rating { get; set; }
        public string Image { get; set; }
    }
    
    public class WishlistProductDto
    {
        public int ProduitId { get; set; }
        public string ProduitName { get; set; }
        public decimal ProduitPrice { get; set; }
        public string ProduitImage { get; set; }
    }
    
    public class CartProductDto
    {
        public int ProduitId { get; set; }
        public string ProduitName { get; set; }
        public decimal ProduitPrice { get; set; }
        public string ProduitImage { get; set; }
    }

}