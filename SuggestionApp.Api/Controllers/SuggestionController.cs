using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuggestionApp.Api.Dtos.SuggestionDtos;
using SuggestionApp.Api.Extensions;
using SuggestionApp.Application.Constants;
using SuggestionApp.Application.Dtos.SuggestionService;
using SuggestionApp.Application.Enums.Suggestion;
using SuggestionApp.Application.Interfaces;

namespace SuggestionApp.Api.Controllers
{
    [ApiController]
    public class SuggestionController : ControllerBase
    {
        private readonly ISuggestionService _suggestionService;
        private readonly IValidator<CreateSuggestionRequest> _createSuggestionRequestValidator;
        public SuggestionController(
            ISuggestionService suggestionService,
            IValidator<CreateSuggestionRequest> createSuggestionRequestValidator)
        {
            _suggestionService = suggestionService;
            _createSuggestionRequestValidator = createSuggestionRequestValidator;
        }

        [Authorize(Roles = $"{Roles.User},{Roles.Admin}")]
        [HttpPost(Routes.Suggestion.CreateSuggestion)]
        public async Task<ActionResult> CreateSuggestion(
            [FromBody] CreateSuggestionRequest createSuggestionRequest)
        {
            await _createSuggestionRequestValidator
                .ValidateAndThrowAsync(createSuggestionRequest);

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

        [Authorize(Roles = Roles.Admin)]
        [HttpPatch(Routes.Suggestion.ChangeStatus)]
        public async Task<ActionResult> ChangeStatus(
            [FromBody] ChangeSuggestionStatusRequest changeSuggestionStatusRequest)
        {
            var status = await _suggestionService
                .ChangeStatus(changeSuggestionStatusRequest.ToApplicationDto());

            return status switch
            {
                ChangeStatusS.Success => Ok("Suggestion status changed successfully."),
                ChangeStatusS.SuggestionNotFound => NotFound("Suggestion not found."),
                ChangeStatusS.InvalidStatus => BadRequest("Invalid status provided."),
                ChangeStatusS.Failure => StatusCode(500, "An error occurred while changing the suggestion status."),
                _ => StatusCode(500, "Unknown error.")
            };
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet(Routes.Suggestion.FilterSuggestions)]

        public async Task<ActionResult<List<GetAllSuggestionsByUserIdResponse>>> FilterSuggestions(
            [FromQuery] GetFilterSuggestionRequest filterSuggestionRequest)
        {
            var request = new GetFilterSuggestionDto
            {
                Date = filterSuggestionRequest.Date,
                Status = filterSuggestionRequest.Status,
                UserId = filterSuggestionRequest.UserId,
                SuggestionId = filterSuggestionRequest.SuggestionId
            };

            var (status, value) = await _suggestionService
                 .GetAllSuggestionsByFilter(request);

            return status switch
            {
                GetAllSuggestionsByUserIdStatus.Success => Ok(value),
                GetAllSuggestionsByUserIdStatus.UserNotFound => NotFound("User not found."),
                GetAllSuggestionsByUserIdStatus.Failure => StatusCode(500, "An error occurred."),
                _ => StatusCode(500, "Unknown error.")
            };
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet(Routes.Suggestion.GetAll)]

        public async Task<ActionResult<List<GetAllSuggestionsResponse>>> AllSuggestions()
        {
            var (status, value) = await _suggestionService
                 .GetAllSuggestions();

            return status switch
            {
                GetAllSuggestionsByUserIdStatus.Success => Ok(value),
                GetAllSuggestionsByUserIdStatus.UserNotFound => NotFound("User not found."),
                GetAllSuggestionsByUserIdStatus.Failure => StatusCode(500, "An error occurred."),
                _ => StatusCode(500, "Unknown error.")
            };
        }

        [Authorize(Roles = $"{Roles.User},{Roles.Admin}")]
        [HttpGet(Routes.Suggestion.MySuggestions)]
        public async Task<ActionResult<List<GetAllSuggestionsByUserIdResponse>>> GetMySuggestions()
        {
            string userId = User.GetUserId();

            if (userId is null)
                return BadRequest();

            var (status, value) = await _suggestionService
                .GetAllSuggestionsByUser(userId);

            return status switch
            {
                GetAllSuggestionsByUserIdStatus.Success => Ok(value),
                GetAllSuggestionsByUserIdStatus.Failure => StatusCode(500, "An error occurred."),
                _ => StatusCode(500, "Unknown error.")
            };

        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet(Routes.Suggestion.Suggestionbyid)]

        public async Task<ActionResult<GetSuggestionByIdResponse>> GetSuggestionById(
            [FromQuery] int suggestionId)
        {
            var (status, value) = await _suggestionService
                 .GetSuggestion(suggestionId);

            return status switch
            {
                GetAllSuggestionsByUserIdStatus.Success => Ok(value),
                GetAllSuggestionsByUserIdStatus.UserNotFound => NotFound("User not found."),
                GetAllSuggestionsByUserIdStatus.Failure => StatusCode(500, "An error occurred."),
                _ => StatusCode(500, "Unknown error.")
            };
        }

    }
}
