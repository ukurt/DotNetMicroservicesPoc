using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OrderService.Api.Queries;
using OrderService.Api.Queries.Dto;
using OrderService.Domain;

namespace OrderService.Commands
{
    public class GetOrdersHandle : IRequestHandler<GetOrderDetailsQuery, GetOrderDetailsQueryResult>
    {
        private readonly IOrderRepository _repo;
        private readonly IProductService _productService;
        private readonly ICustomerService _customerService;
        


        public GetOrdersHandle(IOrderRepository repo, IProductService productService, ICustomerService customerService)
        {
            this._repo = repo;
            _productService = productService;
            _customerService = customerService;
        }

        public async Task<GetOrderDetailsQueryResult> Handle(GetOrderDetailsQuery request, CancellationToken cancellationToken)
        {
            var result = await _repo.GetAll(request.StartDate, request.EndDate);

            var orderResult = new GetOrderDetailsQueryResult();

            if (result != null && result.Any())
            {
                foreach (var item in result)
                {
                    var customer = await _customerService.GetCustomer(new CustomerParams { CustomerId = item.UserId});
                    var order = new OrderDto
                    {
                        CreatedDate = item.CreatedDate,
                        OrderId = item.Id,
                        TotalPrice = item.TotalPrice
                    };

                    order.Customer = new CustomerDto
                    {
                        CustomerId = customer.CustomerId,
                        Name = customer.Name,
                        Surname = customer.Surname
                    };

                    foreach (var orderDetail in item.OrderDetails)
                    {
                        var product = await _productService.GetProduct(new ProductParams { ProductId = orderDetail.ProductId });
                        
                        var orderDto = new OrderDetailDto
                        {
                            CreatedDate = orderDetail.CreatedDate,
                            OrderDetailId = orderDetail.Id,
                            Quantity = orderDetail.Quantity,
                            TotalPrice = orderDetail.TotalPrice,
                            UnitPrice = orderDetail.UnitPrice
                        };

                        orderDto.Product = new ProductDto
                        {
                            CustomerId = product.CustomerId,
                            ProductId = product.ProductId,
                            SKUCode = product.SKUCode,
                            Title = product.Title
                        };

                        order.OrderDetails.Add(orderDto);
                    }

                    orderResult.Orders.Add(order);
                }

            }

            return orderResult;

        }
    }
}
