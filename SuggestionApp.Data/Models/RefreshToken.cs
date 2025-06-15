using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuggestionApp.Data.Models
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public string Token { get; set; } = Guid.NewGuid().ToString();
        public string UserId { get; set; } = null!;
        public DateTime ExpiresAt { get; set; }
        public bool IsUsed { get; set; } = false;
    }

}
