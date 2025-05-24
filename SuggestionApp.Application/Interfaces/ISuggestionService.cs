using SuggestionApp.Application.Dtos.SuggestionService;
using SuggestionApp.Application.Enums.Suggestion;

namespace SuggestionApp.Application.Interfaces
{
    public interface ISuggestionService
    {
        Task<CreateSuggestionStatus> CreateSugcgestion(CreateSuggestionDto createSuggestionDto);
    }
}
