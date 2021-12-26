using CustomerService.Domain;
using System.Linq;

namespace CustomerService.Init
{
    public class DataLoader
    {

        private readonly ICustomerRepository _repo;

        public DataLoader(ICustomerRepository repo)
        {
            _repo = repo;
        }

        public void Seed()
        {
            if (_repo.GetAll().Result != null && _repo.GetAll().Result.Count > 0)
            {
                return;
            }

            _repo.Add(new Customer { CustomerId = 1, Name = "unal", Surname = "kurt" });
        }
    }
}
