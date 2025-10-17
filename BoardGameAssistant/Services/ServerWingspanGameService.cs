using BoardGameAssistant.Data;
using BoardGameAssistant.ServiceContracts.Wingspan;
using BoardGameAssistant.ServiceContracts.Wingspan.Dto;
using BoardGameAssistant.Services.Mappers;

using Microsoft.EntityFrameworkCore;

namespace BoardGameAssistant.Services
{
    public class ServerWingspanGameService : IWingspanGameService
    {
        private readonly WingspanDbContext WingspanDbContext;
        private readonly ILogger<ServerWingspanGameService> logger;

        public ServerWingspanGameService(
            WingspanDbContext WingspanDbContext,
            ILogger<ServerWingspanGameService> logger)
        {
            this.WingspanDbContext = WingspanDbContext;
            this.logger = logger;
        }

        public async Task<WingspanGame> CreateGameAsync(NewWingspanGame gameSettings)
        {
            var currentUserId = await GetCurrentUserId();

            using var scope = this.logger.BeginScope(new Dictionary<string, object>
            {
                ["UserId"] = currentUserId
            });

            this.logger.LogTrace("User '{UserId}' is creating new Wingspan game", currentUserId);

            if (!gameSettings.Occurrence.HasValue)
            {
                gameSettings.Occurrence = DateTime.Now;
                this.logger.LogTrace("No occurrence time provided using current time");
            }

            if (string.IsNullOrWhiteSpace(gameSettings.Name))
            {
                gameSettings.Name = $"Wingspan {gameSettings.Occurrence.Value:dd:MM:YYYY}";
                this.logger.LogTrace("No game name provided using default");
            }

            var proxy = WingspanDbContext.Games.Add(new Entities.Wingspan.WingspanGame
            {
                Name = gameSettings.Name,
                PlayedAt = gameSettings.Occurrence.Value,
                HasOceaniaExpansion = gameSettings.HasOceaniaExpansion,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                CreatedBy = currentUserId,
                UpdatedBy = currentUserId,
            });

            await WingspanDbContext.SaveChangesAsync();

            this.logger.LogInformation("User '{UserId}' created new Wingspan game '{GameId}'", currentUserId, proxy.Entity.Id);

            return proxy.Entity.ToContract();
        }

        public async Task<WingspanGame> GetGameAsync(int gameId, CancellationToken cancellationToken = default)
        {
            var currentUserId = await GetCurrentUserId();
            this.logger.LogTrace("User '{UserId}' is looking for Wingspan game '{GameId}'", currentUserId, gameId);

            var entity = await WingspanDbContext.Games
                .SelectContract()
                .FirstOrDefaultAsync(x => x.Id == gameId);

            if (entity is null)
            {
                this.logger.LogWarning("User '{UserId}' tried to access non-existing Wingspan game {GameId}", currentUserId, gameId);
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
