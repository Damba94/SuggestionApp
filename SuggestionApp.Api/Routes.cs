namespace SuggestionApp.Api
{
    public static class Routes
    {
        private const string _base = "/api";

        public static class Auth
        {
            private const string _controllerBase = $"{_base}/auth";

            public const string Register = $"{_controllerBase}/register";

            public const string Login = $"{_controllerBase}/login";

            public const string RefreshToken = $"{_controllerBase}/refresh-token";

        }

        public static class Product
        {
            private const string _controllerBase = $"{_base}/product";

            public const string GetAllProducts = $"{_controllerBase}/getAll";

            public const string CreateProduct = $"{_controllerBase}";
        }

       
    }
 }