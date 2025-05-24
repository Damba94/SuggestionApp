using SuggestionApp.Application.Dtos.ProductService;
using SuggestionApp.Application.Enums.Product;

namespace SuggestionApp.Application.Interfaces
{
    public interface IProductService
    {
        Task<CreateProductStatus> CreateProductAsync(CreateProductDto createProductDto);
        Task<(GetAllProductsStatus Status, List<GetAllProductsResult>? Value)> GetAllProductsAsync();
    }
}
