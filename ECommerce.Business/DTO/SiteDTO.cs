namespace E_Commerce.Business.DTO;

public class SiteDto
{
    public class CreateSiteDto
    {
        public int NbMembers { get; set; }
        public int Sells { get; set; }
        public int Sells7Days { get; set; }
        public int SiteMoney { get; set; }
        public int SiteMoney7Days { get; set; }    }
    
    public class UpdateSiteDto
    {
        public string Name { get; set; }

    }
}