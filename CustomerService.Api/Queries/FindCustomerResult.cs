using CustomerService.Api.Queries.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerService.Api.Queries
{
    public class FindCustomerResult
    {
        public CustomerDto Customer { get; set; }
    }
}
