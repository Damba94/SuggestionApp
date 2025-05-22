using Riok.Mapperly.Abstractions;
using SuggestionApp.Application.Dtos.ProductService;

namespace SuggestionApp.Api.Dtos.ProductDtos
{
    public class GetAllProductsRequest
    {
        public string UserName { get; set; }
    }
    [Mapper]
    public static partial class GetAllProductsRequestMapper
    {
        public static GetAllProductsDto ToApplicationDto(this GetAllProductsRequest getAllProductsRequest, string userName)
        {
            var mapped = ToApplicationDto(getAllProductsRequest);
            mapped.UserName = userName;
            return mapped;
        }

        private static partial GetAllProductsDto ToApplicationDto(this GetAllProductsRequest getAllProductsRequest);
    }
}
