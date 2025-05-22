using Microsoft.AspNetCore.Identity;

namespace SuggestionApp.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public bool IsDeleted { get; set; } = false;

        public ICollection<Suggestion> Suggestions { get; set; } = null!;
    }


}
