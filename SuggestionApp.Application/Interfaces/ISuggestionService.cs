using SuggestionApp.Application.Dtos.SuggestionService;
using SuggestionApp.Application.Enums.Suggestion;

namespace SuggestionApp.Application.Interfaces
{
    public interface ISuggestionService
    {
        Task<ChangeStatusS> ChangeStatus(ChangeSuggestionStatusDto changeSuggestionStatusDto);
        Task<CreateSuggestionStatus> CreateSugcgestion(CreateSuggestionDto createSuggestionDto);
    }
}
