using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuggestionApp.Frontend.Helpers
{
    public static class SessionStorage
    {
        public static string Token { get; set; } = null!;
        public static string Role { get; set; } = null!;
        public static string UserId { get; set; } = null!;
    }
}
