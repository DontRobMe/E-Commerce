using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Business.DTO;

public class ProduitDto
{
    public class CreateProduitDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string Category { get; set; } 
        public List<string> productcodes { get; set; }
        public int Rating { get; set; }
        public byte[] Image { get; set; }
    }
    
    public class UpdateProduitDto
    {
        public string Name { get; set; }

    }
    
    public class UpdateRatingDto
    {
        public int Rating { get; set; }
    }
    
    public class UpdateImageDto
    {
        public string Image { get; set; }
    }
}