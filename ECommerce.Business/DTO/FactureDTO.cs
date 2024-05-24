namespace E_Commerce.Business.DTO
{
    public class FactureDto
    {
        public int ClientId { get; set; }
        public DateTime Date { get; set; }
        public string FichierPDF { get; set; }
    }
}