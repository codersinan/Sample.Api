using System.Collections.Generic;
using FluentValidation;
using Sample.Api.Entities;

namespace Sample.Api.Requests
{
    public class AddProductRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public IList<Tag> Tags { get; set; }
    }
    
    public class AddProductValidator : AbstractValidator<AddProductRequest>
    {
        public AddProductValidator()
        {
            RuleFor(r => r.Name).NotNull().NotEmpty().MinimumLength(3);
        }
    }
}