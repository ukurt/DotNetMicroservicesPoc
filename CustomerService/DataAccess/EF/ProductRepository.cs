using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerService.Domain;
using Microsoft.EntityFrameworkCore;

namespace CustomerService.DataAccess.EF
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDbContext customerDbContext;

        public CustomerRepository(CustomerDbContext customerDbContext)
        {
            this.customerDbContext = customerDbContext ?? throw new ArgumentNullException(nameof(customerDbContext));
        }

        public async Task Add(Customer customer)
        {
            this.customerDbContext.Customers.Add(customer);
            await this.customerDbContext.SaveChangesAsync();
        }

        public async Task<Customer> Find(int customerId)
        {
            return await this.customerDbContext.Customers.FirstOrDefaultAsync(p => p.CustomerId == customerId);
        }

        public async Task<List<Customer>> GetAll()
        {
            return await this.customerDbContext.Customers.ToListAsync();
        }
    }
}
