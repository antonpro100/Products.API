using AutoMapper;
using Products.Application.Common.Mappings;
using Products.Domain;
using System;

namespace Products.Application.Products.Models
{
    public class ProductLookupVM : IMapWith<Product>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductLookupVM>();
        }
    }
}
