using FluentValidation;
using SuggestionApp.Api.Dtos.ProductDtos;

namespace SuggestionApp.Api.Validators
{
    public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
    {
        public CreateProductRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(3);
        }
    }
}
