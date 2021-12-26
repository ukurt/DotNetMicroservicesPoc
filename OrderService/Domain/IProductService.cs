using ProductService.Api.Queries.Dtos;
using System.Threading.Tasks;

namespace OrderService.Domain
{
    public interface IProductService
    {
        Task<ProductDto> GetProduct(ProductParams cmd);
    }

    public class ProductParams
    {
        public int ProductId { get; set; }
    }
}
