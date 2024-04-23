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
    public void CreateProduit(Produit newProduit)
    {
        _dbContext.Produit?.Add(newProduit);
        _dbContext.SaveChanges();   
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
        //produit.Image = updatedProduit.Image;
        produit.Category = updatedProduit.Category;
        _dbContext.SaveChanges();
        return new BusinessResult<Produit>
        {
            IsSuccess = true,
            Message = "Produit updated successfully",
            Result = produit
        };
    }
    /* "name": "paul",
  "lastName": "de jean",
  "email": "moi@moi.com",
  "password": "19911974",
  "birth": "10/10/2001"*/
    public BusinessResult<Produit> UpdateRating(long ProduitId, int rating)
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
        produit.Rating = rating;
        _dbContext.SaveChanges();
        return new BusinessResult<Produit>
        {
            IsSuccess = true,
            Message = "Rating updated successfully",
            Result = produit
        };
    }
    
    //update keys
    public BusinessResult<Produit> UpdateKeys(long ProduitId, string keys)
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
        produit.Keys = keys;
        _dbContext.SaveChanges();
        return new BusinessResult<Produit>
        {
            IsSuccess = true,
            Message = "Keys updated successfully",
            Result = produit
        };
    }
}