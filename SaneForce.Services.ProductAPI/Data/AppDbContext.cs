using Microsoft.EntityFrameworkCore;
using SaneForce.Services.ProductAPI.Models;

namespace SaneForce.Services.ProductAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }
        public DbSet<Product> ProductMaster { get; set; }
        public DbSet<OrderDetails> OrderDetailsMaster { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Code = 111,
                Name = "mango",
                Rate = 12
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Code = 222,
                Name = "apple",
                Rate = 10
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Code = 333,
                Name = "banana",
                Rate = 13
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Code = 444,
                Name = "pine apple",
                Rate = 14
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Code = 555,
                Name = "grapes",
                Rate = 16
            });

        }
    }
}
