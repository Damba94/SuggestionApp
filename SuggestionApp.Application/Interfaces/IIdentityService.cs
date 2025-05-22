using SuggestionApp.Application.Dtos.IdentityService;
using SuggestionApp.Application.Enums;
using SuggestionApp.Data.Enums;

namespace SuggestionApp.Application.Interfaces
{
    public interface IIdentityService
    {
        Task<(LoginStatus Status, LoginResult? Value)> Login(UserLoginDto userLoginData);
        Task<(RegistrationStatus Status, UserRegisterResult? Value)> UserRegister(UserRegisterDto userRegisterData);

        /*
        Task<string?> RegisterAdminAsync(string email, string password);
        Task<bool> AssignRoleAsync(string userId, string role);
        Task<ApplicationUser?> GetUserByIdAsync(string userId);
        Task<IList<string>> GetRolesAsync(string userId);*/
    }
}
