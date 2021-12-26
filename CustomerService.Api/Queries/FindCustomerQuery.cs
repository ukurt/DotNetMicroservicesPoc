using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerService.Api.Queries
{
    public class FindCustomerQuery : IRequest<FindCustomerResult>
    {
        public int CustomerId { get; set; }
    }
}
