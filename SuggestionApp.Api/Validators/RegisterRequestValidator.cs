

using FluentValidation;
using SuggestionApp.Api.Dtos.AuthDtos;

namespace SuggestionApp.Api.Validators
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(r => r.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(r => r.Password)
                .NotEmpty()
                .NotNull();

            RuleFor(r => r.FirstName)
                .NotEmpty()
                .NotNull();

            RuleFor(r => r.LastName)
                .NotEmpty()
                .NotNull();

            RuleFor(r => r.UserName)
                .NotEmpty()
                .NotNull();
        }
    }
}
