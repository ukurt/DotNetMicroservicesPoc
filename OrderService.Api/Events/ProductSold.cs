using MediatR;

namespace OrderService.Api.Events
{
    public class ProductSold : INotification
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
