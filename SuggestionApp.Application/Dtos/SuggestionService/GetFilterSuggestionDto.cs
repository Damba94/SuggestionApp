using SuggestionApp.Data.Enums;

namespace SuggestionApp.Application.Dtos.SuggestionService
{
    public class GetFilterSuggestionDto
    {
        public string? UserId { get; set; }
        public string? ProductId { get; set; }
        public DateOnly? Date { get; set; }
        public SuggestionStatus? Status { get; set; }
    }
}
