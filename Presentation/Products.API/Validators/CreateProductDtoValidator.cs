using FluentValidation;
using Products.API.Models;
using System;

namespace Products.API.Validators
{
    public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductDtoValidator()
        {
            RuleFor(c => c.Name).NotEmpty().MaximumLength(250);
            RuleFor(c => c.Price).GreaterThanOrEqualTo(0);
        }
    }
}
