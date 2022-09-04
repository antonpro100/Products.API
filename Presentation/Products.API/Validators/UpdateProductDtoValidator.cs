using FluentValidation;
using Products.API.Models;
using System;

namespace Products.API.Validators
{
    public class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
    {
        public UpdateProductDtoValidator()
        {
            RuleFor(c => c.Name).NotEmpty().MaximumLength(250);
            RuleFor(c => c.Price).GreaterThanOrEqualTo(0);
            RuleFor(c => c.Id).NotEqual(Guid.Empty);
        }
    }
}
