using Riok.Mapperly.Abstractions;
using SuggestionApp.Application.Dtos.SuggestionService;
using SuggestionApp.Data.Enums;

namespace SuggestionApp.Api.Dtos.SuggestionDtos
{
    public class GetAllSuggestionsResponse
    {
        public int SuggestionId { get; set; }
        public string ProductName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime DateCreated { get; set; }
        public SuggestionStatus Status { get; set; }

    }

    [Mapper]
    public static partial class GetAllSuggestionsResponseMapper
    {
        public static partial GetAllSuggestionsResponse ToDto(this GetAllSuggestionsResult getAllSuggestionsResult);
    }
}
