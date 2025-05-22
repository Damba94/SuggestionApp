using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuggestionApp.Application.Dtos.IdentityService
{
    public class LoginResult
    {
        public string Jwt { get; init; } = null!;
        public string RefreshToken { get; init; } = null!;

}   }
