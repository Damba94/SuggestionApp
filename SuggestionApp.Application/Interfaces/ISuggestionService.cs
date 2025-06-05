using SuggestionApp.Application.Dtos.SuggestionService;
using SuggestionApp.Application.Enums.Suggestion;

namespace SuggestionApp.Application.Interfaces
{
    public interface ISuggestionService
    {
        Task<ChangeStatusS> ChangeStatus(ChangeSuggestionStatusDto changeSuggestionStatusDto);
        Task<CreateSuggestionStatus> CreateSugcgestion(CreateSuggestionDto createSuggestionDto);
        Task<(GetAllSuggestionsByUserIdStatus Status, List<GetAllSuggestionsResult>? Value)> GetAllSuggestions();
        Task<(GetAllSuggestionsByUserIdStatus Status, List<GetAllSuggestionsByUserIdResult>? Value)> GetAllSuggestionsByFilter(GetFilterSuggestionDto getFilterSuggestionDto);
        Task<(GetAllSuggestionsByUserIdStatus Status, List<GetAllSuggestionsByUserIdResult>? Value)> GetAllSuggestionsByUser(string userId);
    }
}
