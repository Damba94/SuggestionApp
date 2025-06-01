using Riok.Mapperly.Abstractions;
using SuggestionApp.Application.Dtos.SuggestionService;
using SuggestionApp.Data.Enums;

namespace SuggestionApp.Api.Dtos.SuggestionDtos
{
    public class GetAllSuggestionsByUserIdResponse
    {
        public int SuggestionId { get; set; } 
        public string ProductName { get; set; } = null!;
        public DateTime DateCreated { get; set; }
        public SuggestionStatus Status { get; set; }

    }

    [Mapper]
    public static partial class GetAllSuggestionsByUserIdResponseMapper
    {
        public static partial GetAllSuggestionsByUserIdResponse ToDto(this GetAllSuggestionsByUserIdResult getAllSuggestionsByUserIdResult);
    }
}
