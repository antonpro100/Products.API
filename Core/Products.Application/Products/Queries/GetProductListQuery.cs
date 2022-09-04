using MediatR;
using Products.Application.Products.Models;
using System.Collections.Generic;

namespace Products.Application.Products.Queries
{
    public class GetProductListQuery : IRequest<IEnumerable<ProductLookupVM>>
    {
    }
}
