using OrderService.Domain;
using ProductService.Api.Queries;
using ProductService.Api.Queries.Dtos;
using System.Threading.Tasks;

namespace OrderService.RestClients
{
    public class ProductService : IProductService
    {
        private readonly IProductClient _productClient;

        public ProductService(IProductClient productClient)
        {
            this._productClient = productClient;
        }

        public async Task<ProductDto> GetProduct(ProductParams cmd)
        {
            var query = new FindProductByIdQuery
            {
                ProductId = cmd.ProductId
            };

            return await _productClient.GetProduct(query);
        }
       
    }
}
