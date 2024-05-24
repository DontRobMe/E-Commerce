using E_Commerce.Business.DTO;
using E_Commerce.Business.IRepositories;
using E_Commerce.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using E_Commerce.Business.Models;

namespace E_Commerce.Data.Repositories
{
    public class DatabaseFactureRepository : IFactureRepository
    {
        private readonly MyDbContext _dbContext;

        public DatabaseFactureRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task AddFacture(FactureDto facture)
        {
            var factureEntity = new Facture
            {
                ClientId = facture.ClientId,
                Date = facture.Date,
                FichierPDF = facture.FichierPDF
            };

            _dbContext.Factures.Add(factureEntity);
            await _dbContext.SaveChangesAsync();
        }


        public async Task<List<Facture>> GetFactureById(int id)
        {
            return await _dbContext.Factures.Where(f => f.ClientId == id)
                .ToListAsync();
        }
        
        public async Task<Facture> GetFactureByIdf(int id)
        {
            return (await _dbContext.Factures.FirstOrDefaultAsync(f => f.Id == id))!;
        }
    }
}