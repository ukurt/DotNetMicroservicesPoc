using CustomerService.Api.Queries;
using CustomerService.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerService.Queries
{
    public class FindCustomerHandler : IRequestHandler<FindCustomerQuery, Api.Queries.Dtos.CustomerDto>
    {
        private readonly ICustomerRepository _customerRepository;

        public FindCustomerHandler(ICustomerRepository customerRepository)
        {
            this._customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        public async Task<Api.Queries.Dtos.CustomerDto> Handle(FindCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.Find(request.CustomerId);

            return customer != null ? new Api.Queries.Dtos.CustomerDto
            {
                CustomerId = customer.CustomerId,
                Name = customer.Name,
                Surname = customer.Surname
            } : null;

        }
    }
}
