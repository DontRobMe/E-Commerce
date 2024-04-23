using E_Commerce.Business.Models;
using Microsoft.EntityFrameworkCore;
namespace E_Commerce.Data.Context;
public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }

    public DbSet<Clients>? Client { get; init; }
    public DbSet<Admin>? Admin { get; init; }
    public DbSet<Achats>? Achats { get; init; }

    public DbSet<Produit>? Produit { get; init; }

    public DbSet<Site>? Site { get; init; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Site>().HasNoKey();
        base.OnModelCreating(modelBuilder);
    }
}