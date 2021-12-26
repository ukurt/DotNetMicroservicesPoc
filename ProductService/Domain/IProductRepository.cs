using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductService.Domain
{
    public interface IProductRepository
    {
        Task Add(Product product);
        Task<Product> FindById(int id);
        Task<List<Product>> GetAll();
    }
}
