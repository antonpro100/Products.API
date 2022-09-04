using AutoMapper;
using Products.Application.Common.Mappings;
using Products.Application.Products.Commands.CreateProduct;

namespace Products.API.Models
{
    public class CreateProductDto : IMapWith<CreateProductCommand>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateProductDto, CreateProductCommand>();
        }
    }
}
