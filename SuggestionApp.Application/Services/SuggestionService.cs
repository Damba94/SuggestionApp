using Microsoft.EntityFrameworkCore;
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

        public async Task<(GetAllSuggestionsByUserIdStatus Status, List<GetAllSuggestionsByUserIdResult>? Value)> GetAllSuggestionsByFilter(
            GetFilterSuggestionDto getFilterSuggestionDto)
        {
            try
            {
                if (!string.IsNullOrEmpty(getFilterSuggestionDto.UserId))
                {
                    var userExists = await _context.Users.AnyAsync(u => u.Id == getFilterSuggestionDto.UserId);
                    if (!userExists)
                        return (GetAllSuggestionsByUserIdStatus.UserNotFound, null);
                }

                var query = _context.Suggestions
                    .AsNoTracking()
                    .Include(s => s.Product)
                    .AsQueryable();

                if (!string.IsNullOrEmpty(getFilterSuggestionDto.UserId))
                    query = query.Where(s => s.UserId == getFilterSuggestionDto.UserId);

                if (!string.IsNullOrEmpty(getFilterSuggestionDto.ProductId) &&
                    int.TryParse(getFilterSuggestionDto.ProductId, out var prductId))
                {
                    query = query.Where(s => s.ProductId == prductId);
                }


                if (getFilterSuggestionDto.Status.HasValue)
                    query = query.Where(s => s.Status == getFilterSuggestionDto.Status);

                if (getFilterSuggestionDto.Date.HasValue)
                    query = query.Where(s => DateOnly.FromDateTime(s.DateCreated.Date) == getFilterSuggestionDto.Date.Value);

                var results = await query
                    .Select(s => new GetAllSuggestionsByUserIdResult
                    {
                        Status = s.Status,
                        SuggestionId = s.Id,
                        ProductName = s.Product.Name,
                        DateCreated = s.DateCreated
                    })
                    .ToListAsync();

                return (GetAllSuggestionsByUserIdStatus.Success, results);
            }
            catch
            {
                return (GetAllSuggestionsByUserIdStatus.Failure, null);
            }
        }

        public async Task<(GetAllSuggestionsByUserIdStatus Status, List<GetAllSuggestionsResult>? Value)> GetAllSuggestions()
        {
            try
            {
                var suggestion = await _context.Suggestions
                    .AsNoTracking()
                    .Select(s => new GetAllSuggestionsResult
                    {
                        Status = s.Status,
                        SuggestionId = s.Id,
                        FirstName = s.User.FirstName,
                        LastName = s.User.LastName,
                        ProductName = s.Product.Name,
                        DateCreated = s.DateCreated
                    })
                    .ToListAsync();

                return (GetAllSuggestionsByUserIdStatus.Success, suggestion);

            }
            catch
            {
                return (GetAllSuggestionsByUserIdStatus.Failure, null);
            }
        }

        public async Task<(GetAllSuggestionsByUserIdStatus Status, List<GetAllSuggestionsByUserIdResult>? Value)> GetAllSuggestionsByUser(
            string userId)
        {
            var user = await _context.Users
                .FindAsync(userId);

            if (user is null)
            {
                return (GetAllSuggestionsByUserIdStatus.UserNotFound, null);
            }

            try
            {
                var suggestion = await _context.Suggestions
                    .AsNoTracking()
                    .Where(s => s.User == user)
                    .Select(s => new GetAllSuggestionsByUserIdResult
                    {
                        Status = s.Status,
                        SuggestionId = s.Id,
                        ProductName = s.Product.Name,
                        DateCreated = s.DateCreated
                    })
                    .ToListAsync();

                return (GetAllSuggestionsByUserIdStatus.Success, suggestion);

            }
            catch
            {
                return (GetAllSuggestionsByUserIdStatus.Failure, null);
            }
        }

        public async Task<(GetAllSuggestionsByUserIdStatus Status, GetSuggestionByIdResult? Value)> GetSuggestion(int suggestionId)
        {
            try
            {
                var suggestion = await _context.Suggestions
                    .AsNoTracking()
                    .Where(s => s.Id == suggestionId)
                    .Select(s => new GetSuggestionByIdResult
                    {
                        Status = s.Status,
                        SuggestionId = s.Id,
                        SugestionTxt = s.Text,
                        FirstName = s.User.FirstName,
                        LastName = s.User.LastName,
                        ProductName = s.Product.Name,
                        DateCreated = s.DateCreated
                    })
                    .SingleOrDefaultAsync();



                return (GetAllSuggestionsByUserIdStatus.Success, suggestion);

            }
            catch
            {
                return (GetAllSuggestionsByUserIdStatus.Failure, null);
            }
        }
    }
}

