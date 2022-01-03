using ProductService.Api.Queries.Dtos;
using System.Threading.Tasks;

namespace OrderService.Domain
{
    public interface IProductService
    {
        Task<ProductDto> GetProduct(int productId);
    }
}
