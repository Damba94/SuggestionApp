using Microsoft.EntityFrameworkCore;
using SuggestionApp.Application.Dtos.SuggestionService;
using SuggestionApp.Application.Enums.Suggestion;
using SuggestionApp.Application.Interfaces;
using SuggestionApp.Data.Context;
using SuggestionApp.Data.Models;

namespace SuggestionApp.Application.Services
{
    public class SuggestionService : ISuggestionService
    {
        private readonly ApplicationDbContext _context;
        public SuggestionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CreateSuggestionStatus> CreateSugcgestion(
            CreateSuggestionDto createSuggestionDto)
        {
            var existing = await _context.Products
                .AsNoTracking()
                .AnyAsync(p => p.Id == createSuggestionDto.ProductId);

            if (!existing)
                return CreateSuggestionStatus.ProductNotFound;

            var suggestion = new Suggestion
            {
                UserId = createSuggestionDto.UserId,
                ProductId = createSuggestionDto.ProductId,
                Text = createSuggestionDto.Text,
            };

            try
            {
                _context.Suggestions.Add(suggestion);
                await _context.SaveChangesAsync();
                return CreateSuggestionStatus.Success;
            }
            catch
            {
                return CreateSuggestionStatus.Failure;
            }
        }
    }
}
