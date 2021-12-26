using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerService.Api.Queries.Dtos
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
