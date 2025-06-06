using SuggestionApp.Frontend.Helpers;

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
