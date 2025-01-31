﻿using E_Commerce.Business.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
using E_Commerce.Business.Models;

namespace E_Commerce.Business.IRepositories
{
    public interface IFactureRepository
    {
        Task AddFacture(FactureDto facture);
        public Task<List<Facture>> GetFactureById(int id);
        public Task<Facture> GetFactureByIdf(int id);

    }
}