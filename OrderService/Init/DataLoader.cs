using OrderService.DataAccess.EF;
using System.Linq;

namespace OrderService.Init
{
    public class DataLoader
    {

        private readonly OrderDbContext dbContext;

        public DataLoader(OrderDbContext context)
        {
            dbContext = context;
        }

        public void Seed()
        {
            dbContext.Database.EnsureCreated();
            if (dbContext.Orders.Any())
            {
                return;
            }

            var order = new Domain.Order
            {
                CreatedDate = System.DateTime.Now,
                Id = 1,
                TotalPrice = 10,
                UserId = 1
            };
            order.OrderDetails = new System.Collections.Generic.List<Domain.OrderDetail>();
            order.OrderDetails.Add(new Domain.OrderDetail
            {
                CreatedDate = System.DateTime.Now,
                ProductId = 1,
                Quantity = 1,
                TotalPrice = 10,
                UnitPrice = 10,
                Id = 1
            });
            dbContext.Orders.Add(order);

            dbContext.SaveChanges();
        }
    }
}
