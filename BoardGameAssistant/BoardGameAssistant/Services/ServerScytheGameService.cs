using BoardGameAssistant.Client.Services;
using BoardGameAssistant.Data;
using BoardGameAssistant.ServiceContracts.Scythe.Dto;

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

        public async Task<ScytheGame> CreateGameAsync(string? gameName, DateTime? occurence)
        {
            var currentUserId = await GetCurrentUserId();

            using var scope = this.logger.BeginScope(new Dictionary<string, object>
            {
                ["UserId"] = currentUserId
            });

            this.logger.LogTrace("User '{UserId}' is creating new Scythe game ", currentUserId);

            if (!occurence.HasValue)
            {
                occurence = DateTime.Now;
                this.logger.LogTrace("No occurence time provided using curret time");
            }

            if (string.IsNullOrWhiteSpace(gameName))
            {
                gameName = $"Scythe {occurence.Value:dd:MM:YYYY}"; 
                this.logger.LogTrace("No game name provided using default");
            }

            var proxy = scytheDbContext.Games.Add(new Entities.Scythe.ScytheGame
            {
                Name = gameName,
                PlayedAt = occurence.Value,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                CreatedBy = currentUserId,
                UpdatedBy = currentUserId
            });

            await scytheDbContext.SaveChangesAsync();

            this.logger.LogInformation("User '{UserId}' created new Scythe game {GameId}", currentUserId, proxy.Entity.Id);

            return new ScytheGame
            {
                Id = proxy.Entity.Id,
                Name = proxy.Entity.Name,
                PlayedAt = proxy.Entity.PlayedAt
            };
        }

        private async Task<Guid?> GetCurrentUserId()
        {
            return null; // TODO: Implement user identification logic
        }
    }
}
