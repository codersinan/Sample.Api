using FluentValidation;
using Sample.Api.Entities;

namespace Sample.Api.Requests
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(r => r.Name).NotNull().NotEmpty().MinimumLength(3);
        }
    }
}