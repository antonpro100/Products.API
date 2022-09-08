using System;

namespace Products.Core.Dtos
{
    public class ProductLookupDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public decimal Price { get; set; }
    }
}
