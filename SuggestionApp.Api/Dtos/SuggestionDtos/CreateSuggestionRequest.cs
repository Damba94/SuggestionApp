using Riok.Mapperly.Abstractions;
using SuggestionApp.Application.Dtos.SuggestionService;

namespace SuggestionApp.Api.Dtos.SuggestionDtos
{
    public class CreateSuggestionRequest
    {
        public int ProductId { get; set; }
        public string Text { get; set; } = null!;
    }
    [Mapper]
    public static partial class CreateSuggestionRequestMapper
    {
        public static CreateSuggestionDto ToApplicationDto(this CreateSuggestionRequest createSuggestionRequest, string userId)
        {
            var mapped = ToApplicationDto(createSuggestionRequest);
            mapped.UserId = userId;
            return mapped;
        }
        private static partial CreateSuggestionDto ToApplicationDto(this CreateSuggestionRequest createSuggestionRequest);
    }
}
