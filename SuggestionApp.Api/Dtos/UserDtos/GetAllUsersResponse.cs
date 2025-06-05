using Riok.Mapperly.Abstractions;
using SuggestionApp.Application.Dtos.UserService;

namespace SuggestionApp.Api.Dtos.UserDtos
{
    public class GetAllUsersResponse
    {
        public string UserId { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
    }


    [Mapper]
    public static partial class GetAllUsersResponseMapper
    {
        public static partial GetAllUsersResponse ToDto(this GetAllUsersResult getAllUsersResult);
    }
}
