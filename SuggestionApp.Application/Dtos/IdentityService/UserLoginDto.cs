using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuggestionApp.Application.Dtos.IdentityService
{
    public class UserLoginDto
    {
        public string UserName { get; init; } = null!;
        public string Password { get; init; } = null!;
    }
}
