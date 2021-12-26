using System;
using System.Collections.Generic;

namespace OrderService.Domain
 {
    public class OrderDetail
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual Order Order { get; private set; }
    }

 }
