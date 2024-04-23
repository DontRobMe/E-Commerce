﻿using E_Commerce.Business.IRepositories;
using E_Commerce.Business.IServices;
using E_Commerce.Business.Models;

namespace E_Commerce.Business.Services;

public class ProduitService : IProduitService
{
    private readonly IProduitRepository _produitRepository;

    public ProduitService(IProduitRepository produitRepository)
    {
        _produitRepository = produitRepository ?? throw new ArgumentNullException(nameof(produitRepository));
    }
    public BusinessResult<IEnumerable<Produit>> GetProduits()
    {
        var produits = _produitRepository.GetProduits();
        return BusinessResult<IEnumerable<Produit>>.FromSuccess(produits);
    }

    public BusinessResult<Produit> GetProduitById(long id)
    {
        var produit = _produitRepository.GetProduitById(id);
        return BusinessResult<Produit>.FromSuccess(produit);
    }

    public BusinessResult<Produit> CreateProduit(Produit item)
    {
        _produitRepository.CreateProduit(item);
        return BusinessResult<Produit>.FromSuccess(item);
    }

    public BusinessResult UpdateProduit(long id, Produit model)
    {
        var updatedProduit = _produitRepository.UpdateProduit(id, model);
        return BusinessResult.FromSuccess(updatedProduit);
    }

    public BusinessResult DeleteProduit(long id)
    {
        _produitRepository.DeleteProduit(id);
        return BusinessResult.FromSuccess();
    }
}