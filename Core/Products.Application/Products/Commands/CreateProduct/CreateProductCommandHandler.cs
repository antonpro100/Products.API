using MediatR;
using Products.Application.Interfaces;
using Products.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Products.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private IProductsDbContext _dbContext;
        public CreateProductCommandHandler(IProductsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                CreatedAt = DateTime.Now,
                CreatedBy = request.UserId,
            };

            await _dbContext.Products.AddAsync(product, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return product.Id;
        }
    }
}
