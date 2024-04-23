using E_Commerce.Business.Models;

namespace E_Commerce.Business.IServices;

public interface IClientService
{
    public BusinessResult<IEnumerable<Clients>> GetClients();

    public BusinessResult<Clients> GetClientById(long id);

    public BusinessResult<Clients> CreateClient(Clients item);

    public BusinessResult UpdateClient(long id, Clients model);

    public BusinessResult DeleteClient(long id);
    
    public BusinessResult UpdateWallet(long id, int amount);
    
    public BusinessResult UpdatePassword(long id, string password);
}