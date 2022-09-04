using MediatR;
using Products.Application.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Products.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private IProductsDbContext _dbContext;
        public DeleteProductCommandHandler(IProductsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _dbContext.Products.FindAsync(request.Id);
            if (product == null)
                throw new InvalidOperationException($"Product with Id {request.Id} not found.");

            product.IsActive = false;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
