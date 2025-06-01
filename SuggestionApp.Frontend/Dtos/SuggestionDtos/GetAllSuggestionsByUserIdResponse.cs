using SuggestionApp.Frontend.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuggestionApp.Frontend.Dtos.SuggestionDtos
{
    public class GetAllSuggestionsByUserIdResponse
    {
        public string SuggestionId { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public DateTime DateCreated { get; set; }
        public SuggestionStatus Status { get; set; }
    }
}
