using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderService.Domain;

namespace OrderService.DataAccess.EF
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext orderDbContext;

        public OrderRepository(OrderDbContext orderDbContext)
        {
            this.orderDbContext = orderDbContext ?? throw new ArgumentNullException(nameof(orderDbContext));
        }

        public async Task<int> Add(Order order)
        {
            this.orderDbContext.Orders.Add(order);
            await this.orderDbContext.SaveChangesAsync();
            return order.Id;
        }

        public async Task<List<Order>> GetAll(DateTime startDate, DateTime endDate)
        {
            return await this.orderDbContext.Orders.Include(c => c.OrderDetails).Where(o => startDate <= o.CreatedDate && o.CreatedDate <= endDate).ToListAsync();
        }
    }
}
