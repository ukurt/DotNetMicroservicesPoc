using System;
using System.Collections.Generic;

namespace OrderService.Domain
 {
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public IList<OrderDetail> OrderDetails { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal TotalPrice { get; set; }
    }

 }
