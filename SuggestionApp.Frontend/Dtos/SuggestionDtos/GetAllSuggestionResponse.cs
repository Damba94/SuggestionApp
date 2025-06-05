using SuggestionApp.Frontend.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuggestionApp.Frontend.Dtos.SuggestionDtos
{
    public class GetAllSuggestionResponse
    {
        public int SuggestionId { get; set; }
        public string ProductName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime DateCreated { get; set; }
        public SuggestionStatus Status { get; set; }
    }
}
