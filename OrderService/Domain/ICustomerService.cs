using CustomerService.Api.Queries;
using System.Threading.Tasks;

namespace OrderService.Domain
{
    public interface ICustomerService
    {
        Task<FindCustomerResult> GetCustomer(CustomerParams cmd);
    }

    public class CustomerParams
    {
        public int CustomerId { get; set; }
    }
}
