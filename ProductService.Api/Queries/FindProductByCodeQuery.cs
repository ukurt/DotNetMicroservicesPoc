using MediatR;
using ProductService.Api.Queries.Dtos;

namespace ProductService.Api.Queries
{
    public class FindProductByIdQuery : IRequest<ProductDto>
    {
        public int ProductId { get; set; }
    }
}
