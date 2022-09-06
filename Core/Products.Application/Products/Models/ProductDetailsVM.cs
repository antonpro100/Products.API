using AutoMapper;
using Products.Application.Common.Mappings;
using Products.Domain;
using System;
using System.Collections.Generic;

namespace Products.Application.Products.Models
{
    public class ProductDetailsVM : IMapWith<Product>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public decimal Price { get; set; }
        public List<ProductPropertyVM> Properties { get; set; } = new List<ProductPropertyVM>();
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductDetailsVM>()
                .ForMember(d => d.Properties, m => m.MapFrom(s => s.Properties));
        }
    }

    
}
