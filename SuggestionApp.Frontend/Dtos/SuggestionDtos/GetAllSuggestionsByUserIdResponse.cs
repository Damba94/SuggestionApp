using SuggestionApp.Frontend.Helpers;

namespace SuggestionApp.Frontend.Dtos.SuggestionDtos
{
    public class GetAllSuggestionsByUserIdResponse
    {
        public int SuggestionId { get; set; } 
        public string ProductName { get; set; } = null!;
        public DateTime DateCreated { get; set; }
        public SuggestionStatus Status { get; set; }
    }
}
