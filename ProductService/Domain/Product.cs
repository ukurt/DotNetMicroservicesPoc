using System;
using System.Collections.Generic;

namespace ProductService.Domain
{
    public class Product
    {
        public int ProductId { get; set; }
        public string SKUCode { get; set; }
        public string Title { get; set; }
        public int CustomerId { get; set; }

    }
}
