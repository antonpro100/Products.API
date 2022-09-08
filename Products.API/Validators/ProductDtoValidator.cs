using FluentValidation;
using Products.Core.Dtos;

namespace Products.API.Validators
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            RuleFor(c => c.Name).NotEmpty().MaximumLength(250);
            RuleFor(c => c.Price).GreaterThanOrEqualTo(0);
        }
    }
}
