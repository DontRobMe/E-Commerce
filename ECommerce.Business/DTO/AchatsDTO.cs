namespace E_Commerce.Business.DTO;

public class AchatsDto
{
    public class CreateAchatsDto
    {
        public string Produit { get; set; }
        public string Facture { get; set; }
        public int prix { get; set; }
        public int quantité { get; set; }
        public string Date { get; set; }
    }
    
    public class UpdateAchatsDto
    {
        public string Name { get; set; }

    }
    
}