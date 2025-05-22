using FluentValidation;
using SuggestionApp.Api.Dtos.AuthDtos;

namespace SuggestionApp.Api.Validators
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(r => r.UserName)
                .NotEmpty()
                .NotNull();

            RuleFor(r => r.Password)
                .NotEmpty()
                .NotNull();
        }
    }
}
