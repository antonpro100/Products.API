using AutoMapper;
using Products.Application.Common.Mappings;
using Products.Domain;
using System;

namespace Products.Application.Products.Models
{
    public class ProductDetailsVM : IMapWith<Product>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductDetailsVM>()
                .ForMember(prodVM => prodVM.Id, c => c.MapFrom(prod => prod.Id))
                .ForMember(prodVM => prodVM.Name, c => c.MapFrom(prod => prod.Name))
                .ForMember(prodVM => prodVM.Description, c => c.MapFrom(prod => prod.Description))
                .ForMember(prodVM => prodVM.Price, c => c.MapFrom(prod => prod.Price));
        }
    }

    
}
