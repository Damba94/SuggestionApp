using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuggestionApp.Api.Dtos.UserDtos;
using SuggestionApp.Application.Constants;
using SuggestionApp.Application.Enums.User;
using SuggestionApp.Application.Interfaces;

namespace SuggestionApp.Api.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet(Routes.User.GetAllUsers)]
        public async Task<ActionResult<List<GetAllUsersResponse>>> GetUsers()
        {
            var (status, value) = await _userService.GetUsers();

            return status switch
            {
                GetAllUsersStatus.Success => Ok(value),
                GetAllUsersStatus.NoUsersFound => NotFound("No users found."),
                GetAllUsersStatus.Failure => StatusCode(500, "An error occurred."),
                _ => StatusCode(500, "Unknown error.")
            };
        }
    }
}
