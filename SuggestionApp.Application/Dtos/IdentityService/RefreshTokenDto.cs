using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuggestionApp.Application.Dtos.IdentityService
{
    public class RefreshTokenDto
    {
        public string RefreshToken { get; set; } = null!;
        public string UserId { get; set; } = null!;
    }
}
