using SuggestionApp.Frontend.Helpers;

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
