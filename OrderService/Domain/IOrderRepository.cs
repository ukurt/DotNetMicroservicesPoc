using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderService.Domain
{
    public interface IOrderRepository
    {
        Task<int> Add(Order order);
        Task<List<Order>> GetAll(DateTime startDate, DateTime endDate);
    }
}
