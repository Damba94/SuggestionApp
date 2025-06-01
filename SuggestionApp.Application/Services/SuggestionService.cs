using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SuggestionApp.Application.Dtos.SuggestionService;
using SuggestionApp.Application.Enums.Suggestion;
using SuggestionApp.Application.Interfaces;
using SuggestionApp.Data.Context;
using SuggestionApp.Data.Enums;
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

        public async Task<ChangeStatusS> ChangeStatus(
            ChangeSuggestionStatusDto changeSuggestionStatusDto)
        {
            var suggestion = await _context.Suggestions
                .FindAsync(changeSuggestionStatusDto.SuggestionId);

            if (suggestion is null)
            {
                return ChangeStatusS.SuggestionNotFound;
            }

            if (Enum.IsDefined(typeof(SuggestionStatus), changeSuggestionStatusDto.Status))
            {
                var status = (SuggestionStatus)changeSuggestionStatusDto.Status;

                try
                {
                    suggestion.Status = status;
                    await _context.SaveChangesAsync();
                    return ChangeStatusS.Success;
                }
                catch
                {
                    return ChangeStatusS.Failure;
                }
            }
            else
            {
                return ChangeStatusS.InvalidStatus;
            }
        }

        public async Task<(GetAllSuggestionsByUserIdStatus Status,List<GetAllSuggestionsByUserIdResult>? Value)>GetAllSuggestionsByUser(
            string userId)
        {
            var user= await _context.Users
                .FindAsync(userId);

            if (user is null)
            {
                return (GetAllSuggestionsByUserIdStatus.UserNotFound,null);
            }

            try
            {
                var suggestion=await _context.Suggestions
                    .AsNoTracking()
                    .Where(s=>s.User==user)
                    .Select(s => new GetAllSuggestionsByUserIdResult
                    {
                        Status = s.Status,
                        SuggestionId=s.Id,
                        ProductName=s.Product.Name,
                        DateCreated=s.DateCreated
                    })
                    .ToListAsync();

                return (GetAllSuggestionsByUserIdStatus.Success, suggestion);
                       
            }
            catch {
                return (GetAllSuggestionsByUserIdStatus.Failure,null);
            }
        }
    }
}
