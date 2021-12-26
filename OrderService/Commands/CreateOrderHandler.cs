using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OrderService.Api.Commands;
using OrderService.Domain;

namespace OrderService.Commands
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, CreateOrderResult>
    {
        private readonly IOrderRepository _repo;

        public CreateOrderHandler(IOrderRepository repo)
        {
            this._repo = repo;
        }

        public async Task<CreateOrderResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var orderId = await _repo.Add(null);
            
            return new CreateOrderResult
            {
                OrderId = orderId
            };
        }
    }
}
