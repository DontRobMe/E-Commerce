using System.Net.Mail;

namespace E_Commerce.Busines.Models;

public class Client
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public MailAddress Email { get; set; }
    public string Address { get; set; }
    public int Wallet { get; set; }
    public string Password { get; set; }
}