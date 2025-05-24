using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuggestionApp.Api.Dtos.SuggestionDtos;
using SuggestionApp.Api.Extensions;
using SuggestionApp.Application.Enums.Product;
using SuggestionApp.Application.Enums.Suggestion;
using SuggestionApp.Application.Interfaces;

namespace SuggestionApp.Api.Controllers
{
    [ApiController]
    public class SuggestionController : ControllerBase
    {
        private readonly ISuggestionService _suggestionService;
        public SuggestionController(ISuggestionService suggestionService)
        {
            _suggestionService = suggestionService;
        }

        [Authorize(Roles = "USER,ADMIN")]
        [HttpPost(Routes.Suggestion.CreateSuggestion)]
        public async Task<ActionResult> CreateSuggestion(
            CreateSuggestionRequest createSuggestionRequest)
        {
            var mappedRequest = createSuggestionRequest
                .ToApplicationDto(User.GetUserId());

            var status = await _suggestionService
                .CreateSugcgestion(mappedRequest);

            return status switch
            {
                CreateSuggestionStatus.Success => Ok("Suggestion created successfully."),
                CreateSuggestionStatus.Failure => StatusCode(500, "An error occurred while creating the suggestion."),
                _ => StatusCode(500, "Unknown error.")
            };
        }
    }
}
