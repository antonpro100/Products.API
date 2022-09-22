using System.Collections.Generic;

namespace Products.Core.Dtos
{
    public class ProductCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public decimal Price { get; set; }
        public List<ProductPropertyDto> Properties { get; set; } = new List<ProductPropertyDto>();
    }
}
