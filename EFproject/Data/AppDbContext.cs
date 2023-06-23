using EFproject.Models;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;

namespace EFproject.Data
{
    public class AppDbContext : DbContext
    {
      public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
      {
      
      }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<ProductDetailsModel> ProductDetailsModel { get; set; }
        public DbSet<OrderModel> OrderModels { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductModel>().HasData(new ProductModel { Id = 1, Name = "Phone", Description = "New Device", Category = "Tech", Price = 5550});
            modelBuilder.Entity<ProductModel>().HasData(new ProductModel { Id = 2, Name = "Printer", Description = "New Device", Category = "Tech", Price = 850 });
            modelBuilder.Entity<ProductModel>().HasData(new ProductModel { Id = 3, Name = "TV", Description = "New Device", Category = "Tech", Price = 9950 });
             
        }
    }
}
