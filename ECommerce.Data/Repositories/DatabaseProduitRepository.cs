using E_Commerce.Business.IRepositories;
using E_Commerce.Business.Models;
using E_Commerce.Data.Context;

namespace E_Commerce.Data.Repositories;

public class DatabaseProduitRepository : IProduitRepository
{
    private readonly MyDbContext _dbContext;

    public DatabaseProduitRepository(MyDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }
    public BusinessResult<Produit> CreateProduit(Produit newProduit)
    { 
        var produit = _dbContext.Produit?.FirstOrDefault(u => u.Name == newProduit.Name);
        if (produit != null)
        {
            return new BusinessResult<Produit>
            {
                IsSuccess = false,
                Message = "Produit already exists"
            };
        }
        _dbContext.Produit?.Add(newProduit);
        _dbContext.SaveChanges();
        return new BusinessResult<Produit>
        {
            IsSuccess = true,
            Message = "Produit created successfully",
            Result = newProduit
        };
    }

    public void DeleteProduit(long produitId)
    {
        var produit = _dbContext.Produit?.FirstOrDefault(u => u.Id == produitId);
        if (produit == null) return;
        _dbContext.Produit?.Remove(produit);
        _dbContext.SaveChanges();
    }

    public IEnumerable<Produit>? GetProduits()
    {
        return _dbContext.Produit;
    }

    public Produit GetProduitById(long? produitId)
    {
        return _dbContext.Produit?.FirstOrDefault(u => u.Id == produitId)!;
    }

    public BusinessResult<Produit> UpdateProduit(long ProduitId, Produit updatedProduit)
    {
        var produit = _dbContext.Produit?.FirstOrDefault(u => u.Id == ProduitId);
        if (produit == null)
        {
            return new BusinessResult<Produit>
            {
                IsSuccess = false,
                Message = "Produit not found"
            };
        }
        produit.Name = updatedProduit.Name;
        produit.Description = updatedProduit.Description;
        produit.Price = updatedProduit.Price;
        produit.Stock = updatedProduit.Stock;
        produit.Image = updatedProduit.Image;
        produit.Category = updatedProduit.Category;
        _dbContext.SaveChanges();
        return new BusinessResult<Produit>
        {
            IsSuccess = true,
            Message = "Produit updated successfully",
            Result = produit
        };
    }
    public Produit GetProduitByName(string name)
    {
        return _dbContext.Produit?.FirstOrDefault(u => u.Name == name)!;
    }
}