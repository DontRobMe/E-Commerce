namespace E_Commerce.Business.DTO;

public class ClientDto
{
    public class CreateClientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        
    }
    
    public class UpdateClientDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        
    }
    
    public class WalletClientDto
    {
        public int Wallet { get; set; }
    }
    
    public class PasswordClientDto
    {
        public string Password { get; set; }
    }
}