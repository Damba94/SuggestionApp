using Riok.Mapperly.Abstractions;
using SuggestionApp.Application.Dtos.IdentityService;

namespace SuggestionApp.Api.Dtos.AuthDtos
{
    public class RegisterRequest
    {
        public string FirstName { get; init; } = null!;
        public string LastName { get; init; } = null!;
        public string Email { get; init; } = null!;
        public string UserName { get; init; } = null!;
        public string Password { get; init; } = null!;

    }

    [Mapper]
    public static partial class RegisterRequestMapper
    {
        public static partial UserRegisterDto ToApplicationDto(this RegisterRequest registerRequest);
    }
}
