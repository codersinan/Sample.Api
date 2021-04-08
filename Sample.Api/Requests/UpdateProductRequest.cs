using FluentValidation;

namespace Sample.Api.Requests
{
    public class UpdateProductRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductRequestValidator()
        {
            RuleFor(r => r.Name).NotNull().NotEmpty().MinimumLength(3);
        }
    }
}