using CustomerService.Api.Queries;
using CustomerService.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerService.Queries
{
    public class FindCustomerHandler : IRequestHandler<FindCustomerQuery, FindCustomerResult>
    {
        private readonly ICustomerRepository _customerRepository;

        public FindCustomerHandler(ICustomerRepository customerRepository)
        {
            this._customerRepository = customerRepository;
        }

        public async Task<FindCustomerResult> Handle(FindCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.Find(request.CustomerId);

            return FindCustomerResult(customer);
        }

        private FindCustomerResult FindCustomerResult(Customer customer)
        {
            return new FindCustomerResult
            {
                Customer = new CustomerService.Api.Queries.Dtos.CustomerDto
                {
                    CustomerId = customer.CustomerId,
                    Name = customer.Name,
                    Surname = customer.Surname
                }
            };
        }
    }
}
