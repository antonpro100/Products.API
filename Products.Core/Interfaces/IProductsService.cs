using Products.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Products.Core.Interfaces
{
    public interface IProductsService
    {
        Task<IEnumerable<ProductLookupDto>> GetAll();
        Task<ProductDto> GetById(Guid id);
        Task<ProductDto> Create(ProductCreateDto dto, Guid userId, CancellationToken cancellationToken);
        Task<ProductDto> Update(ProductDto dto, Guid userId, CancellationToken cancellationToken);
        Task Delete(Guid id, Guid userId, CancellationToken cancellationToken);
    }
}