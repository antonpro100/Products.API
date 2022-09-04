using AutoMapper;

namespace Products.Application.Common.Mappings
{
    public interface IMapWith<T>
    {
        void Mapping(Profile profile);
    }
}