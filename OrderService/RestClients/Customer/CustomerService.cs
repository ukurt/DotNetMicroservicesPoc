using CustomerService.Api.Queries;
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

        public async Task<FindCustomerResult> GetCustomer(CustomerParams cmd)
        {
            var query = new FindCustomerQuery
            {
                CustomerId = cmd.CustomerId
            };

            return await _customerClient.GetCustomer(query);
        }
    }
}
