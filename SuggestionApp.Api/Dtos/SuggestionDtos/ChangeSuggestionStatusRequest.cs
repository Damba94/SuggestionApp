using Riok.Mapperly.Abstractions;
using SuggestionApp.Application.Dtos.SuggestionService;

namespace SuggestionApp.Api.Dtos.SuggestionDtos
{
    public class ChangeSuggestionStatusRequest
    {
        public int SuggestionId { get; set; }
        public int Status { get; set; }
    }

    [Mapper]
    public static partial class ChangeSuggestionStatusRequestMapper
    {
        public static partial ChangeSuggestionStatusDto ToApplicationDto(this ChangeSuggestionStatusRequest changeSuggestionStatusRequest);
    }

}
