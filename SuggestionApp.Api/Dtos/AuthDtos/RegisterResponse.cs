using Riok.Mapperly.Abstractions;
using SuggestionApp.Application.Dtos.IdentityService;

namespace SuggestionApp.Api.Dtos.AuthDtos
{
    public class RegisterResponse
    {
        public string Jwt { get; init; } = null!;
        ///public string RefreshToken { get; init; } = null!;
    }

    [Mapper]
    public static partial class RegisterResponseMapper
    {
        public static partial RegisterResponse ToDto(this UserRegisterResult registerRequest);
    }
}
