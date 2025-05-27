using Riok.Mapperly.Abstractions;
using SuggestionApp.Application.Dtos.SuggestionService;

namespace SuggestionApp.Api.Dtos.SuggestionDtos
{
    public class GetSuggestionStatusesResponse
    {
        public int Value { get; set; }
        public string Name { get; set; } = null!;
    }
    [Mapper]
    public static partial class GetSuggestionStatusesResponseMapper
    {
        public static partial GetSuggestionStatusesResponse ToDto(this GetSuggestionStatusesResult getSuggestionStatusesResult);
    }
}
