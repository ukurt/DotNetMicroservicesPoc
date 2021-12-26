using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerService.Domain
{
    public interface ICustomerRepository
    {
        Task Add(Customer customer);
        Task<Customer> Find(int customerId);
        Task<List<Customer>> GetAll();

    }
}
