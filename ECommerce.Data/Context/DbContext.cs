using E_Commerce.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Data.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<Clients> Client { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Achats> Achats { get; set; }
        public DbSet<Produit> Produit { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<WishlistItem> WishlistItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration de la clé primaire composite pour WishlistItem
            modelBuilder.Entity<WishlistItem>()
                .HasKey(w => new { w.ClientId, w.ProduitId });

            // Configuration des relations entre les entités
            modelBuilder.Entity<WishlistItem>()
                .HasOne(w => w.Client)
                .WithMany(c => c.Wishlist)
                .HasForeignKey(w => w.ClientId);

            modelBuilder.Entity<WishlistItem>()
                .HasOne(w => w.Produit)
                .WithMany(p => p.WishlistItems)
                .HasForeignKey(w => w.ProduitId);

            modelBuilder.Entity<Site>().HasNoKey();

            base.OnModelCreating(modelBuilder);
        }
    }
}