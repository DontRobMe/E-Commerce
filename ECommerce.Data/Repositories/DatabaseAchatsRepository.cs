using E_Commerce.Business.IRepositories;
using E_Commerce.Business.Models;
using E_Commerce.Data.Context;

namespace E_Commerce.Data.Repositories;

public class DatabaseAchatsRepository : IAchatsRepository
{
    private readonly MyDbContext _dbContext;

    public DatabaseAchatsRepository(MyDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }
    public void CreateAchat(Achats newAchat)
    {
        _dbContext.Achats?.Add(newAchat);
        _dbContext.SaveChanges();
    }

    public void DeleteAchat(long AchatId)
    {
        var Achat = _dbContext.Achats?.FirstOrDefault(x => x.Id == AchatId);
        if (Achat != null)
        {
            _dbContext.Achats?.Remove(Achat);
            _dbContext.SaveChanges();
        }
    }

    public IEnumerable<Achats>? GetAchats()
    {
        return _dbContext.Achats;
    }

    public Achats GetAchatById(long? userId)
    {
        return _dbContext.Achats?.FirstOrDefault(x => x.Id == userId)!;
    }
}