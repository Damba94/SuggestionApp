using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SuggestionApp.Application.Dtos.UserService;
using SuggestionApp.Application.Enums.User;
using SuggestionApp.Application.Interfaces;
using SuggestionApp.Data.Models;

namespace SuggestionApp.Application.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<(GetAllUsersStatus Status, List<GetAllUsersResult>? Value)> GetUsers()
        {
            try
            {
                var users = await _userManager.Users
                    .AsNoTracking()
                    .ToListAsync();

                if (!users.Any())
                    return (GetAllUsersStatus.NoUsersFound, null);

                var filteredUsers = new List<GetAllUsersResult>();

                foreach (var user in users)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    if (roles.Contains("USER"))
                    {
                        filteredUsers.Add(new GetAllUsersResult
                        {
                            UserId = user.Id,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                        });
                    }
                }

                if (!filteredUsers.Any())
                    return (GetAllUsersStatus.NoUsersFound, null);

                return (GetAllUsersStatus.Success, filteredUsers);
            }
            catch
            {
                return (GetAllUsersStatus.Failure, null);
            }
        }
    }
}
