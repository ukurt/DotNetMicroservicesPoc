using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductService.Domain;

namespace ProductService.DataAccess.EF
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext productDbContext;

        public ProductRepository(ProductDbContext productDbContext)
        {
            this.productDbContext = productDbContext ?? throw new ArgumentNullException(nameof(productDbContext));
        }

        public async Task Add(Product product)
        {
            this.productDbContext.Products.Add(product);
            await this.productDbContext.SaveChangesAsync();
        }

        public async Task<Product> FindById(int id)
        {
            return await this.productDbContext.Products.FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task<List<Product>> GetAll()
        {
            return await this.productDbContext.Products.ToListAsync();
        }
    }
}
