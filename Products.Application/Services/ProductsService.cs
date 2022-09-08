using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Products.Core.Dtos;
using Products.Core.Entities;
using Products.Core.Interfaces;
using Products.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Products.Application.Services
{
    public class ProductsService : IProductsService
    {
        private readonly ProductsDbContext _dbContext;
        private readonly IMapper _mapper;
        public ProductsService(ProductsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductLookupDto>> GetAll()
        {
            var product = await _dbContext.Products
                .ProjectTo<ProductLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return product;
        }

        public async Task<ProductDto> GetById(Guid id)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
                throw new InvalidOperationException($"Product with Id {id} not found.");

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> Create(ProductDto dto, Guid userId, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Description = dto.Description,
                ImagePath = dto.ImagePath,
                Price = dto.Price,
                Properties = dto.Properties.Select(p => new ProductProperty
                {
                    OrderNumber = p.OrderNumber,
                    Name = p.Name,
                    Value = p.Value
                }).ToList(),
                CreatedAt = DateTime.Now,
                CreatedBy = userId,
            };

            await _dbContext.Products.AddAsync(product, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            dto.Id = product.Id;

            return dto;
        }

        public async Task<ProductDto> Update(ProductDto dto, Guid userId, CancellationToken cancellationToken)
        {
            var product = await _dbContext.Products.FindAsync(dto.Id);
            if (product == null)
                throw new InvalidOperationException($"Product with Id {dto.Id} not found.");

            product.Name = dto.Name;
            product.Description = dto.Description;
            product.Price = dto.Price;
            product.ImagePath = dto.ImagePath;

            product.Properties = dto.Properties.Select(p => new ProductProperty
            {
                OrderNumber = p.OrderNumber,
                Name = p.Name,
                Value = p.Value
            }).ToList();

            product.UpdatedBy = userId;
            product.UpdatedAt = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return dto;
        }

        public async Task Delete(Guid id, Guid userId, CancellationToken cancellationToken)
        {
            var product = await _dbContext.Products.FindAsync(id);

            if (product == null)
                throw new InvalidOperationException($"Product with Id {id} not found.");

            product.IsActive = false;
            product.UpdatedAt = DateTime.Now;
            product.UpdatedBy = userId;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
