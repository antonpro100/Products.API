using MediatR;
using Products.Application.Products.Models;
using System;

namespace Products.Application.Products.Queries
{
    public class GetProductDetailsQuery : IRequest<ProductDetailsVM>
    {
        public Guid Id { get; set; }
    }
}
