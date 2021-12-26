using MediatR;
using System;

namespace OrderService.Api.Queries
{
    public class GetOrderDetailsQuery : IRequest<GetOrderDetailsQueryResult>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
