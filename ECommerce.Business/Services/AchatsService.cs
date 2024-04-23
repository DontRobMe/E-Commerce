using E_Commerce.Business.IRepositories;
using E_Commerce.Business.IServices;
using E_Commerce.Business.Models;

namespace E_Commerce.Business.Services;

public class AchatService : IAchatsService
{
    private readonly IAchatsRepository _achatsRepository;

    public AchatService(IAchatsRepository achatsRepository)
    {
        _achatsRepository = achatsRepository ?? throw new ArgumentNullException(nameof(achatsRepository));
    }
    public BusinessResult<IEnumerable<Achats>> GetAchats()
    {
        var achats = _achatsRepository.GetAchats();
        return BusinessResult<IEnumerable<Achats>>.FromSuccess(achats);
    }

    public BusinessResult<Achats> GetAchatById(long id)
    {
        var achat = _achatsRepository.GetAchatById(id);
        return BusinessResult<Achats>.FromSuccess(achat);
    }

    public BusinessResult<Achats> CreateAchat(Achats item)
    {
        _achatsRepository.CreateAchat(item);
        return BusinessResult<Achats>.FromSuccess(item);
    }

    public BusinessResult DeleteAchat(long id)
    {
        _achatsRepository.DeleteAchat(id);
        return BusinessResult.FromSuccess();
    }
}