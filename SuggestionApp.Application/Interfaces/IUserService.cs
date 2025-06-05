using SuggestionApp.Application.Dtos.UserService;
using SuggestionApp.Application.Enums.User;

namespace SuggestionApp.Application.Interfaces
{
    public interface IUserService
    {
        Task<(GetAllUsersStatus Status, List<GetAllUsersResult>? Value)> GetUsers();
    }
}
