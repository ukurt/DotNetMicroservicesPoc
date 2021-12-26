using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ProductService.Api.Queries;
using ProductService.Api.Queries.Dtos;
using ProductService.Domain;

namespace ProductService.Queries
{
    public class FindProductByCodeHandler : IRequestHandler<FindProductByIdQuery, ProductDto>
    {
        private readonly IProductRepository productRepository;

        public FindProductByCodeHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }       

        public async Task<ProductDto> Handle(FindProductByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await productRepository.FindById(request.ProductId);

            return result != null ? new ProductDto
            {
                CustomerId = result.CustomerId,
                ProductId = result.ProductId,
                SKUCode = result.SKUCode,
                Title = result.Title

            } : null;
        }
    }
}
