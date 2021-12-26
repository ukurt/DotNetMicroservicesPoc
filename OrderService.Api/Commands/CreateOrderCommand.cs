using System;
using MediatR;

namespace OrderService.Api.Commands
{
    public class CreateOrderCommand : IRequest<CreateOrderResult>
    {
        public string SkuCode { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
    }
}
