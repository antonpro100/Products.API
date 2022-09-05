using System;

namespace Products.Domain
{
    public class PropuctProperty
    {
        public Guid ProductId { get; set; }
        public int OrderNumber { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
