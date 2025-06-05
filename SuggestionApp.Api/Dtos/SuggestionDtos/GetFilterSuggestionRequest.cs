using SuggestionApp.Application.Dtos.ProductService;
using SuggestionApp.Application.Dtos.SuggestionService;
using SuggestionApp.Data.Enums;

namespace SuggestionApp.Api.Dtos.SuggestionDtos
{
    public class GetFilterSuggestionRequest
    {
        public string? UserId { get; set; }
        public string? SuggestionId { get; set;}
        public DateOnly? Date {  get; set; }
        public SuggestionStatus? Status { get; set; }
    }

}
