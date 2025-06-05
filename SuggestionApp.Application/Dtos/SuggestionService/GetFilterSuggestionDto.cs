using SuggestionApp.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuggestionApp.Application.Dtos.SuggestionService
{
    public class GetFilterSuggestionDto
    {
        public string? UserId { get; set; }
        public string? SuggestionId { get; set; }
        public DateOnly? Date { get; set; }
        public SuggestionStatus? Status { get; set; }
    }
}
