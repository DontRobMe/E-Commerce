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
        public DbSet<WishlistItem> WishlistItems { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Facture> Factures { get; set; }


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
            
            modelBuilder.Entity<CartItem>()
                .HasKey(w => new { w.ClientId, w.ProduitId });

            // Configuration des relations entre les entités
            modelBuilder.Entity<CartItem>()
                .HasOne(w => w.Client)
                .WithMany(c => c.CartItems)
                .HasForeignKey(w => w.ClientId);

            modelBuilder.Entity<CartItem>()
                .HasOne(w => w.Produit)
                .WithMany(p => p.CartItems)
                .HasForeignKey(w => w.ProduitId);
            
            modelBuilder.Entity<Facture>()
                .HasKey(f => f.Id);

            modelBuilder.Entity<Facture>()
                .HasOne(f => f.Client)
                .WithMany(c => c.Factures)
                .HasForeignKey(f => f.ClientId);


            base.OnModelCreating(modelBuilder);
        }
    }
}