using E_Commerce.Business.Models;

namespace E_Commerce.Business.IServices;

public interface IAchatsService
{
    public BusinessResult<IEnumerable<Achats>> GetAchats();

    public BusinessResult<Achats> GetAchatById(long id);

    public BusinessResult<Achats> CreateAchat(Achats item);
    public BusinessResult DeleteAchat(long id);
}