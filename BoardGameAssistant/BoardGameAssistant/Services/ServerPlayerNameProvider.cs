using BoardGameAssistant.Client.Dto;
using BoardGameAssistant.Client.Services;
using BoardGameAssistant.Data;
using Microsoft.EntityFrameworkCore;

namespace BoardGameAssistant.Services
{
    public class ServerPlayerNameProvider : IPlayerNameProvider
    {
        private readonly ApplicationDbContext dbContext;

        public ServerPlayerNameProvider(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<PlayerDto>> GetPlayersAsync(string? contains = null, int? skip = null, int? take = null, CancellationToken cancellationToken = default)
        {
            IQueryable<ApplicationUser> query = dbContext.Users;
            if (contains != null && contains.Length < 3)
            {
                query = query
                    .Where(u => u.DisplayName!.Contains(contains))
                    .OrderBy(u => u.DisplayName!.IndexOf(contains))
                    .ThenBy(u => u.DisplayName);
            }
            else
            {
                query = query
                    .OrderBy(u => u.DisplayName);
            }

            take = Math.Clamp(take ?? 10, 1, 10);
            var players = await query
                .Skip(skip ?? 0)
                .Take(take.Value)
                .Select(u =>
                new
                {
                    u.Id,
                    u.UserName,
                    u.DisplayName,
                })
                .ToListAsync(cancellationToken: cancellationToken);

            return players
                .Select(
                    x => new PlayerDto
                    {
                        DisplayName = x.DisplayName ?? x.UserName ?? string.Empty,
                        Id = x.Id
                    })
                .ToList();
        }
    }
}
