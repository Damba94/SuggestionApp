using SuggestionApp.Data.Enums;

namespace SuggestionApp.Data.Models
{
    public class Suggestion
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public string Text { get; set; } = null!;
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public SuggetionStatus Status { get; set; } = SuggetionStatus.UnderReview;
    }
}