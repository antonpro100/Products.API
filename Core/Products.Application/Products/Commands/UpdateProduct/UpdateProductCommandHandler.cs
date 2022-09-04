using MediatR;
using Products.Application.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Products.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private IProductsDbContext _dbContext;
        public UpdateProductCommandHandler(IProductsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _dbContext.Products.FindAsync(request.Id);
            if (product == null)
                throw new InvalidOperationException($"Product with Id {request.Id} not found.");

            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;
            product.UpdatedBy = request.UserId;
            product.UpdatedAt = DateTime.Now; 

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
