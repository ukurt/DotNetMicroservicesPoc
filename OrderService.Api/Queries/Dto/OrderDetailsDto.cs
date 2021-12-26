using System;
using System.Collections.Generic;

namespace OrderService.Api.Queries.Dto
{
    public class OrderDto
    {
        public OrderDto()
        {
            OrderDetails = new List<OrderDetailDto>();
        }
        public int OrderId { get; set; }
        public CustomerDto Customer { get; set; }
        public List<OrderDetailDto> OrderDetails { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal TotalPrice { get; set; }
    }

    public class OrderDetailDto
    {
        public int OrderId { get; set; }
        public int OrderDetailId { get; set; }
        public ProductDto Product { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class ProductDto
    {
        public int ProductId { get; set; }
        public string SKUCode { get; set; }
        public string Title { get; set; }
        public int CustomerId { get; set; }
    }

    public class CustomerDto
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}