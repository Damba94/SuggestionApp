using Riok.Mapperly.Abstractions;
using SuggestionApp.Application.Dtos.ProductService;

namespace SuggestionApp.Api.Dtos.ProductDtos
{
    public class GetAllProductsResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }

    [Mapper]
    public static partial class GetAllProductsResponseMapper
    {
        public static partial GetAllProductsResponse ToDto(this GetAllProductsResult getAllBoardsResult);
    }
}
