using E_Commerce.Business.Models;

namespace E_Commerce.Business.IRepositories;

public interface IAchatsRepository
{
    void CreateAchat(Achats newUser);
        
    void DeleteAchat(long userId);
        
    IEnumerable<Achats>? GetAchats();
        
    Achats GetAchatById(long? userId);
        
}