using CustomerService.Api.Queries;
using CustomerService.Api.Queries.Dtos;
using System.Threading.Tasks;

namespace OrderService.Domain
{
    public interface ICustomerService
    {
        Task<CustomerDto> GetCustomer(CustomerParams cmd);
    }

    public class CustomerParams
    {
        public int CustomerId { get; set; }
    }
}
