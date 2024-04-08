using System.Net.Mail;
using System.Runtime.InteropServices.JavaScript;

namespace E_Commerce.Busines.Models;

public class Admin
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public MailAddress Email { get; set; }
    public string Password { get; set; }
    public JSType.Date  Birth{ get; set; }
}