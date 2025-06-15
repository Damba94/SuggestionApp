using Riok.Mapperly.Abstractions;
using SuggestionApp.Application.Dtos.IdentityService;
using SuggestionApp.Application.Dtos.SuggestionService;

namespace SuggestionApp.Api.Dtos.AuthDtos
{
    public class RefreshTokenRequest
    {
        public string RefreshToken { get; set; } = null!;
    }
    [Mapper]
    public static partial class RefreshTokenRequestMapper
    {
        public static RefreshTokenDto ToApplicationDto(this RefreshTokenRequest refreshTokenRequest, string userId)
        {
            var mapped = ToApplicationDto(refreshTokenRequest);
            mapped.UserId = userId;
            return mapped;
        }
        private static partial RefreshTokenDto ToApplicationDto(this RefreshTokenRequest refreshTokenRequest);
    }
}


