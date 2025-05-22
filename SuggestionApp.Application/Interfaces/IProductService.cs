using SuggestionApp.Application.Dtos.ProductService;
using SuggestionApp.Application.Enums.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuggestionApp.Application.Interfaces
{
    public interface IProductService
    {
        Task<CreateProductStatus> CreateProductAsync(CreateProductDto createProductDto);
        Task<(GetAllProductsStatus Status, List<GetAllProductsResult>? Value)> GetAllProductsAsync();
    }
}
