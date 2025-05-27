using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuggestionApp.Api.Dtos.ProductDtos;
using SuggestionApp.Application.Constants;
using SuggestionApp.Application.Enums.Product;
using SuggestionApp.Application.Interfaces;

namespace SuggestionApp.Api.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IValidator<CreateProductRequest> _createProductRequestValidator;
        public ProductController(
            IProductService productService,
            IValidator<CreateProductRequest> createProductRequestValidator)
        {
            _productService = productService;
            _createProductRequestValidator = createProductRequestValidator;
        }

        [Authorize(Roles = $"{Roles.User},{Roles.Admin}")]
        [HttpGet(Routes.Product.GetAllProducts)]
        public async Task<ActionResult<List<GetAllProductsResponse>>> GetAllProducts()
        {
            var (status, value) = await _productService
                .GetAllProductsAsync();

            if (status is GetAllProductsStatus.NotFound)
                return (BadRequest(status));

            return Ok(value);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPost(Routes.Product.CreateProduct)]
        public async Task<ActionResult> CreateProduct(
            [FromBody] CreateProductRequest createProductRequest)
        {
            await _createProductRequestValidator
                .ValidateAndThrowAsync(createProductRequest);

            var status = await _productService
                .CreateProductAsync(createProductRequest.ToApplicationDto());

            return status switch
            {
                CreateProductStatus.Success => Ok("Product created successfully."),
                CreateProductStatus.AlreadyExists => Conflict("Product with the same name already exists."),
                CreateProductStatus.InvalidData => BadRequest("Invalid product data."),
                CreateProductStatus.Failure => StatusCode(500, "An error occurred while creating the product."),
                _ => StatusCode(500, "Unknown error.")
            };
        }
    }
}
