using BoardGameAssistant.ServiceContracts.Scythe.Dto;

namespace BoardGameAssistant.ServiceContracts.Scythe;

public interface IScytheGameService
{
    Task<ScytheGame> CreateGameAsync(NewScytheGame newGameSettings);
    Task<ScytheGame> GetGameAsync(int gameId, CancellationToken cancellationToken = default);
}