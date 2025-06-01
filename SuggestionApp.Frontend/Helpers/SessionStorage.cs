namespace SuggestionApp.Frontend.Helpers
{
    public static class SessionStorage
    {
        public static string Token { get; set; } = null!;
        public static string Role { get; set; } = null!;
        public static string UserId { get; set; } = null!;
    }
}
