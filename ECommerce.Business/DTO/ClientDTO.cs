using E_Commerce.Business.Models;

namespace E_Commerce.Business.DTO;

public class ClientDto
{
    public class UpdateClientDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        
        public string birth { get; set; }
    }
    
    public class WalletClientDto
    {
        public int Wallet { get; set; }
    }
    
    public class PasswordClientDto
    {
        public string Password { get; set; }
    }
    
    public class LoginClientDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    
    public class RegisterClientDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        
        public string birth { get; set; }
    }
    
}