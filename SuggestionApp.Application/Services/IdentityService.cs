using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SuggestionApp.Application.Dtos.IdentityService;
using SuggestionApp.Application.Enums;
using SuggestionApp.Application.Interfaces;
using SuggestionApp.Data.Enums;
using SuggestionApp.Data.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;



namespace SuggestionApp.Application.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;
        public IdentityService(
            IConfiguration configuration,
            UserManager<ApplicationUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }
        public async Task<(RegistrationStatus Status, UserRegisterResult? Value)> UserRegister(UserRegisterDto userRegisterData)
        {
            var existingUser = await _userManager.FindByEmailAsync(userRegisterData.Email);
            if (existingUser is not null)
                return (RegistrationStatus.EmailInUseError, null);

            var newUser = new ApplicationUser
            {
                UserName = userRegisterData.UserName,
                Email = userRegisterData.Email,
                FirstName = userRegisterData.FirstName,
                LastName = userRegisterData.LastName,
            };

            var result = await _userManager.CreateAsync(newUser, userRegisterData.Password);

            if (!result.Succeeded)
            {

                return (RegistrationStatus.UnhandledError, null);
            }

            await _userManager.AddToRoleAsync(newUser, "USER");

            var jwt = GenerateJwt(
                newUser.Id,
                newUser.UserName,
                newUser.Email,
                "USER"
            );

            return (
                RegistrationStatus.Registered,
                new UserRegisterResult
                {
                    Jwt = jwt,
                    //RefreshToken = GenerateRefreshToken(),
                });
        }

        public async Task<(LoginStatus Status, LoginResult? Value)> Login(
            UserLoginDto userLoginData)
        {
            var user = await _userManager.FindByNameAsync(userLoginData.UserName);

            if (user is null)
                return (LoginStatus.UnknownEmailError, null);

            bool isPasswordValid = await _userManager.CheckPasswordAsync(user, userLoginData.Password);

            if (!isPasswordValid)
                return (LoginStatus.InvalidPasswordError, null);

            var roles = await _userManager.GetRolesAsync(user);

            var Jwt = GenerateJwt(
                user.Id,
                user.UserName,
                user.Email,
                roles[0]);
            //var refreshToken = GenerateRefreshToken();

            //user.RefreshToken = refreshToken;
            //user.RefreshTokenCreated = DateTime.UtcNow;

            //await _userService.UpdateUser(user);

            return (
                LoginStatus.Success,
                new LoginResult
                {
                    Jwt = Jwt,
                    //RefreshToken = refreshToken,
                });
        }



        private string GenerateJwt(
            string userId,
            string userName,
            string email,
            string userRole)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenSecret = _configuration.GetValue<string>("Identity:TokenSecret")!;

            var key = Encoding.UTF8.GetBytes(tokenSecret);

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new(ClaimTypes.Name, userName),
                new(ClaimTypes.Email, email),
                new(ClaimTypes.Role, userRole)

            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(_configuration.GetValue<int>("Identity:JwtLifetimeMinutes")),
                Issuer = _configuration.GetValue<string>("Identity:Issuer")!,
                Audience = _configuration.GetValue<string>("Identity:Audience")!,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var Jwt = tokenHandler.WriteToken(token);

            return Jwt;
        }

    }
}
