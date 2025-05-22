namespace SuggestionApp.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsDeleted { get; set; } = false;

        public ICollection<Suggestion> Suggestions { get; set; } = null!;
    }

}