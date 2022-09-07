using AutoMapper;
using Products.Application.Common.Mappings;
using Products.Domain;
using System;

namespace Products.Application.Products.Models
{
    public class ProductPropertyVM : IMapWith<ProductProperty>
    {
        public int OrderNumber { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProductProperty, ProductPropertyVM>();
        }
    }
}
