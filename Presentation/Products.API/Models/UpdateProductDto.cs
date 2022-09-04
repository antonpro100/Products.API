using AutoMapper;
using Products.Application.Common.Mappings;
using Products.Application.Products.Commands.UpdateProduct;
using System;

namespace Products.API.Models
{
    public class UpdateProductDto : IMapWith<UpdateProductCommand>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateProductDto, UpdateProductCommand>();
        }
    }
}
