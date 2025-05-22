using Riok.Mapperly.Abstractions;
using SuggestionApp.Application.Dtos.IdentityService;
using SuggestionApp.Application.Dtos.ProductService;

namespace SuggestionApp.Api.Dtos.ProductDtos
{
    public class CreateProductRequest
    {
        public string Name { get; set; } = null!;
    }

    [Mapper]
    public static partial class CreateProductRequestMapper
    {
        public static partial CreateProductDto ToApplicationDto(this CreateProductRequest createProductRequest);
    }
}
