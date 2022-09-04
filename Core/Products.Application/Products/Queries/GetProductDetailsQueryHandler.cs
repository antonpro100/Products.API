using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Products.Application.Interfaces;
using Products.Application.Products.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Products.Application.Products.Queries
{
    public class GetProductDetailsQueryHandler : IRequestHandler<GetProductDetailsQuery, ProductDetailsVM>
    {
        private IProductsDbContext _dbContext;
        private IMapper _mapper;
        public GetProductDetailsQueryHandler(IProductsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ProductDetailsVM> Handle(GetProductDetailsQuery request, CancellationToken cancellationToken)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == request.Id && p.IsActive);
            if (product == null)
                throw new InvalidOperationException($"Product with Id {request.Id} not found.");

            return _mapper.Map<ProductDetailsVM>(product);
        }
    }
}
