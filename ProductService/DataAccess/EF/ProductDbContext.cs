using Microsoft.EntityFrameworkCore;
using ProductService.Domain;

namespace ProductService.DataAccess.EF
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {}

        public DbSet<Product> Products { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

    }
}
