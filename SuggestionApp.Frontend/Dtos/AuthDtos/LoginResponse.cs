
namespace SuggestionApp.Api.Dtos.AuthDtos
{
    public class LoginResponse
    {
        public string Jwt { get; init; } = null!;
        public string RefreshToken { get; init; } = null!;
    }


}
