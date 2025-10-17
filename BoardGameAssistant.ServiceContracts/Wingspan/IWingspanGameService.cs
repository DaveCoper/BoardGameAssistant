using BoardGameAssistant.ServiceContracts.Wingspan.Dto;

namespace BoardGameAssistant.ServiceContracts.Wingspan;

public interface IWingspanGameService
{
    Task<WingspanGame> CreateGameAsync(NewWingspanGame newGameSettings);

    Task<WingspanGame> GetGameAsync(int gameId, CancellationToken cancellationToken = default);
}
