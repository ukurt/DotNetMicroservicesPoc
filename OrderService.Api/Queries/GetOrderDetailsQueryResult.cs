using OrderService.Api.Queries.Dto;
using System.Collections.Generic;

namespace OrderService.Api.Queries
{
    public class GetOrderDetailsQueryResult
    {
        public GetOrderDetailsQueryResult()
        {
            Orders = new List<OrderDto>();
        }
        public List<OrderDto> Orders { get; set; }    
    }
}