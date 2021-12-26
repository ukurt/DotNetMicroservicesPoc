using System.Collections.Generic;

namespace ProductService.Api.Queries.Dtos
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string SKUCode { get; set; }
        public string Title { get; set; }
        public int CustomerId { get; set; }
    }
}
