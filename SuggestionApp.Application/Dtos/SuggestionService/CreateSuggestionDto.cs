namespace SuggestionApp.Application.Dtos.SuggestionService
{
    public class CreateSuggestionDto
    {
        public int ProductId { get; set; }
        public string Text { get; set; } = null!;
        public string UserId { get; set; } = null!;
    }
}
