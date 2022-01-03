using CustomerService.Api.Queries;
using CustomerService.Api.Queries.Dtos;
using System.Threading.Tasks;

namespace OrderService.Domain
{
    public interface ICustomerService
    {
        Task<CustomerDto> GetCustomer(int customerId);
    }
}
