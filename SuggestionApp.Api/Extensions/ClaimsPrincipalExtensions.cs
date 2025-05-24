namespace SuggestionApp.Api.Extensions
{
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;

    public static class ClaimsPrincipalExtensions
    {
        public static string GetUsername(this ClaimsPrincipal principal) =>
            principal.FindFirstValue(ClaimTypes.Name)
            ?? throw new ArgumentException(
                $"Request does not include the '{ClaimTypes.Name}' claim in the bearer token.");

        public static string GetUserId(this ClaimsPrincipal principal) =>
            principal.FindFirstValue(ClaimTypes.NameIdentifier)
            ?? principal.FindFirstValue(JwtRegisteredClaimNames.Sub)
            ?? throw new ArgumentException(
                "Request does not include the 'sub' or 'nameid' claim in the bearer token.");

        public static string GetEmail(this ClaimsPrincipal principal) =>
            principal.FindFirstValue(ClaimTypes.Email)
            ?? throw new ArgumentException(
                $"Request does not include the '{ClaimTypes.Email}' claim in the bearer token.");

        public static List<string> GetRoles(this ClaimsPrincipal principal) =>
            principal.FindAll(ClaimTypes.Role)
                     .Select(r => r.Value)
                     .ToList();
    }

}
