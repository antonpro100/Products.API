using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Products.Application.Interfaces;
using Products.Application.Products.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Products.Application.Products.Queries
{
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, IEnumerable<ProductLookupVM>>
    {
        private IProductsDbContext _dbContext;
        private IMapper _mapper;
        public GetProductListQueryHandler(IProductsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductLookupVM>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            var product = await _dbContext.Products
                .ProjectTo<ProductLookupVM>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return product;
        }
    }
}
