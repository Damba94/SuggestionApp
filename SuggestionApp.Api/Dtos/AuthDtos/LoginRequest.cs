using Riok.Mapperly.Abstractions;
using SuggestionApp.Application.Dtos.IdentityService;

namespace SuggestionApp.Api.Dtos.AuthDtos
{
    public class LoginRequest
    {
        public string UserName { get; init; } = null!;
        public string Password { get; init; } = null!;
    }

    [Mapper]
    public static partial class LoginRequestMapper
    {
        public static partial UserLoginDto ToApplicationDto(this LoginRequest loginRequest);
    }
}
