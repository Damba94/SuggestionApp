using SuggestionApp.Data.Enums;

namespace SuggestionApp.Application.Dtos.SuggestionService
{
    public class GetAllSuggestionsResult
    {
        public int SuggestionId { get; set; }
        public string ProductName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime DateCreated { get; set; }
        public SuggestionStatus Status { get; set; }
    }
}
