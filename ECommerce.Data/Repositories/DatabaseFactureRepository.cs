using E_Commerce.Business.IRepositories;
using E_Commerce.Business.Models;
using E_Commerce.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Data.Repositories;

public class DatabaseFactureRepository : IFactureRepository
{
    private readonly MyDbContext _dbContext;

    
    public DatabaseFactureRepository(MyDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }
    
    
    public async Task<Facture> AddFacture(Facture facture)
    {
        await _dbContext.Factures.AddAsync(facture);
        await _dbContext.SaveChangesAsync();
        return facture;
    }
    
    public async Task<IEnumerable<Facture>> GetFactures()
    {
        return await _dbContext.Factures.ToListAsync();
    }
    
}