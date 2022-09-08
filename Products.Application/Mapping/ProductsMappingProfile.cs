using AutoMapper;
using Products.Core.Dtos;
using Products.Core.Entities;

namespace Products.Core.Mapping
{
    public class ProductsMappingProfile : Profile
    {
        public ProductsMappingProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(d => d.Properties, m => m.MapFrom(s => s.Properties));

            CreateMap<Product, ProductLookupDto>();

            CreateMap<ProductProperty, ProductPropertyDto>();
        }
    }
}