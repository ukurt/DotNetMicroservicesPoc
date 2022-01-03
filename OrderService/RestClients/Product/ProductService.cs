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

        public async Task<ProductDto> GetProduct(int productId)
        {
            return await _productClient.FindProductById(productId);
        }
       
    }
}
