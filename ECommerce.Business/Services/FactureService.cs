using E_Commerce.Business.DTO;
using E_Commerce.Business.IRepositories;
using E_Commerce.Business.IServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using E_Commerce.Business.Models;

namespace E_Commerce.Business.Services
{
    public class FactureService : IFactureService
    {
        private readonly IFactureRepository _factureRepository;

        public FactureService(IFactureRepository factureRepository)
        {
            _factureRepository = factureRepository ?? throw new ArgumentNullException(nameof(factureRepository));
        }
        
        public async Task<List<Facture>> GetFactureById(int id)
        {
            return await _factureRepository.GetFactureById(id);        }

        public async Task AddFacture(FactureDto facture)
        {
            await _factureRepository.AddFacture(facture);
        }
        
        public async Task<Facture> GetFactureByIdf(int id)
        {
            return await _factureRepository.GetFactureByIdf(id);
        }
    }
}