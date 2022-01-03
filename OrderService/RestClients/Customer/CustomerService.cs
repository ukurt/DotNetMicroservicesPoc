using CustomerService.Api.Queries;
using CustomerService.Api.Queries.Dtos;
using OrderService.Domain;
using System.Threading.Tasks;

namespace OrderService.RestClients
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerClient _customerClient;

        public CustomerService(ICustomerClient customerClient)
        {
            this._customerClient = customerClient;
        }

        public async Task<CustomerDto> GetCustomer(int customerId)
        {
            return await _customerClient.GetByCode(customerId);
        }
    }
}
