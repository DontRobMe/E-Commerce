using E_Commerce.Business.Models;

namespace E_Commerce.Business.IRepositories;

public interface IClientRepository
{
    void CreateClient(Clients newUser);
        
    void DeleteClient(long userId);
        
    IEnumerable<Clients>? GetClients();
        
    Clients GetClientById(long? userId);
        
    BusinessResult<Clients> UpdateClient(long userId, Clients updatedUser);
}