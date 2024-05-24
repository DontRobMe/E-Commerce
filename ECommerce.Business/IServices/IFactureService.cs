using E_Commerce.Business.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
using E_Commerce.Business.Models;

namespace E_Commerce.Business.IServices
{
    public interface IFactureService
    {
        public Task<List<Facture>> GetFactureById(int id);
        Task AddFacture(FactureDto facture);
        public Task<Facture> GetFactureByIdf(int id);
    }
}