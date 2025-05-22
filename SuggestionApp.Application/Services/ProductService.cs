using Microsoft.EntityFrameworkCore;
using SuggestionApp.Application.Dtos.ProductService;
using SuggestionApp.Application.Enums.Product;
using SuggestionApp.Application.Interfaces;
using SuggestionApp.Data.Context;
using SuggestionApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuggestionApp.Application.Services
{
    public class ProductService:IProductService
    {
        private readonly ApplicationDbContext _context;
        public ProductService(
            ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<(GetAllProductsStatus Status, List<GetAllProductsResult> ?Value)>GetAllProductsAsync()
        {
            try
            {
                var products = await _context.Products
                    .AsNoTracking()
                    .Where(p => !p.IsDeleted)
                    .Select(p => new GetAllProductsResult
                    {
                        Id = p.Id,
                        Name = p.Name
                    })
                    .ToListAsync();

                return (GetAllProductsStatus.Success, products);
            }
            catch
            {
                return (GetAllProductsStatus.Error, null!);
            }
        }

        public async Task<CreateProductStatus>CreateProductAsync(
            CreateProductDto createProductDto)
        {
            if (string.IsNullOrWhiteSpace(createProductDto.Name))
                return CreateProductStatus.InvalidData;

            var existing = await _context.Products
                .AnyAsync(p => p.Name == createProductDto.Name && !p.IsDeleted);

            if (existing)
                return CreateProductStatus.AlreadyExists;

            var product = new Product
            {
                Name = createProductDto.Name
            };
            try
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return CreateProductStatus.Success;

            }
            catch 
            {
                return (CreateProductStatus.Failure);
            }
        }
    }

}
