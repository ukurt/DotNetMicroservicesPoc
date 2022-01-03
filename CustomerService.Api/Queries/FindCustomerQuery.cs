using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerService.Api.Queries
{
    public class FindCustomerQuery : IRequest<Dtos.CustomerDto>
    {
        public int CustomerId { get; set; }
    }
}
