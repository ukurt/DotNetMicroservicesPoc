using ProductService.Domain;
using System.Linq;

namespace ProductService.Init
{
    public class DataLoader
    {

        private readonly IProductRepository _repo;

        public DataLoader(IProductRepository repo)
        {
            _repo = repo;
        }

        public void Seed()
        {
            if (_repo.GetAll().Result != null && _repo.GetAll().Result.Count > 0)
            {
                return;
            }

            _repo.Add(new Product { CustomerId = 1, ProductId = 1, SKUCode = "product001", Title = "test_product" });
        }
    }
}
