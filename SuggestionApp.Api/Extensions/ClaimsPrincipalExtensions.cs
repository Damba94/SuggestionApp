using System.Security.Claims;

namespace SuggestionApp.Api.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUsername(this ClaimsPrincipal principal) =>
            principal.FindFirstValue(ClaimTypes.Name)
            ?? throw new ArgumentException(
                $"Request does not include the '{ClaimTypes.Name}' claim in the bearer token.");
    }

}
