using SuggestionApp.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuggestionApp.Application.Dtos.SuggestionService
{
    public class GetAllSuggestionsByUserIdResult
    {
        public int SuggestionId { get; set; } 
        public string ProductName { get; set; } = null!;
        public DateTime DateCreated { get; set; }
        public SuggestionStatus Status { get; set; }

    }
}
