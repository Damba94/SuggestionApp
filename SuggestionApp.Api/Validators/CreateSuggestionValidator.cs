using FluentValidation;
using SuggestionApp.Api.Dtos.SuggestionDtos;

namespace SuggestionApp.Api.Validators
{
    public class CreateSuggestionValidator : AbstractValidator<CreateSuggestionRequest>
    {
        public CreateSuggestionValidator()
        {
            RuleFor(r => r.Text)
                .NotEmpty()
                .NotNull();

        }
    }
}
