using BoardGameAssistant.Data;
using BoardGameAssistant.ServiceContracts.Scythe;
using BoardGameAssistant.ServiceContracts.Scythe.Dto;
using BoardGameAssistant.Services.Mappers;

using Microsoft.EntityFrameworkCore;

namespace BoardGameAssistant.Services
{
    public class ServerScytheGameService : IScytheGameService
    {
        private readonly ScytheDbContext scytheDbContext;
        private readonly ILogger<ServerScytheGameService> logger;

        public ServerScytheGameService(
            ScytheDbContext scytheDbContext,
            ILogger<ServerScytheGameService> logger)
        {
            this.scytheDbContext = scytheDbContext;
            this.logger = logger;
        }

        public async Task<ScytheGame> CreateGameAsync(NewScytheGame gameSettings)
        {
            var currentUserId = await GetCurrentUserId();

            using var scope = this.logger.BeginScope(new Dictionary<string, object>
            {
                ["UserId"] = currentUserId
            });

            this.logger.LogTrace("User '{UserId}' is creating new Scythe game", currentUserId);

            if (!gameSettings.Occurrence.HasValue)
            {
                gameSettings.Occurrence = DateTime.Now;
                this.logger.LogTrace("No occurrence time provided using current time");
            }

            if (string.IsNullOrWhiteSpace(gameSettings.Name))
            {
                gameSettings.Name = $"Scythe {gameSettings.Occurrence.Value:dd:MM:YYYY}";
                this.logger.LogTrace("No game name provided using default");
            }

            var proxy = scytheDbContext.Games.Add(new Entities.Scythe.ScytheGame
            {
                Name = gameSettings.Name,
                PlayedAt = gameSettings.Occurrence.Value,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                CreatedBy = currentUserId,
                UpdatedBy = currentUserId,
                HasInvadersFromAfarExpansion = gameSettings.HasInvadersFromAfarExpansion,
                HasWindGambitExpansion = gameSettings.HasWindGambitExpansion,
                HasRiseOfFenrisExpansion = gameSettings.HasRiseOfFenrisExpansion,
                HasModularBoard = gameSettings.HasModularBoard,
            });

            await scytheDbContext.SaveChangesAsync();

            this.logger.LogInformation("User '{UserId}' created new Scythe game '{GameId}'", currentUserId, proxy.Entity.Id);

            return proxy.Entity.ToContract();
        }

        public async Task<ScytheGame> GetGameAsync(int gameId, CancellationToken cancellationToken = default)
        {
            var currentUserId = await GetCurrentUserId();
            this.logger.LogTrace("User '{UserId}' is looking for Scythe game '{GameId}'", currentUserId, gameId);

            var entity = await scytheDbContext.Games
                .SelectContract()
                .FirstOrDefaultAsync(x => x.Id == gameId);

            if (entity is null)
            {
                this.logger.LogWarning("User '{UserId}' tried to access non-existing Scythe game {GameId}", currentUserId, gameId);
                throw new KeyNotFoundException($"Game with id {gameId} not found");
            }

            return entity;
        }

        private Task<Guid?> GetCurrentUserId()
        {
            return Task.FromResult<Guid?>(null); // TODO: Implement user identification logic
        }
    }
}
