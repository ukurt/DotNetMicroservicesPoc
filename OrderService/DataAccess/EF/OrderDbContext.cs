using Microsoft.EntityFrameworkCore;
using OrderService.DataAccess.EF.Configuration;
using OrderService.Domain;

namespace OrderService.DataAccess.EF
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {}

        public DbSet<Order> Orders { get; set; } 
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>().HasOne(p => p.Order).WithMany(c => c.OrderDetails);
        }
    }
}
