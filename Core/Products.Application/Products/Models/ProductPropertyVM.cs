using AutoMapper;
using Products.Application.Common.Mappings;
using Products.Domain;
using System;

namespace Products.Application.Products.Models
{
    public class ProductPropertyVM : IMapWith<ProductProperty>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public decimal Price { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProductProperty, ProductPropertyVM>();
        }
    }
}
