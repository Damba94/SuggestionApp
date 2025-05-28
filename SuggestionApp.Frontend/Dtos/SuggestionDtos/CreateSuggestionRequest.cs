
namespace SuggestionApp.Api.Dtos.SuggestionDtos
{
    public class CreateSuggestionRequest
    {
        public int ProductId { get; set; }
        public string Text { get; set; } = null!;
    }

}
