namespace E_Commerce.Business.DTO;

public class AdminDto
{
    public class CreateAdminDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string  Birth{ get; set; }
    }
    
    public class UpdateAdminDto
    {
        public string Name { get; set; }

    }
}