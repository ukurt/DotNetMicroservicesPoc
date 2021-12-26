using CustomerService.Domain;
using Microsoft.EntityFrameworkCore;

namespace CustomerService.DataAccess.EF
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {}

        public DbSet<Customer> Customers { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

    }
}
