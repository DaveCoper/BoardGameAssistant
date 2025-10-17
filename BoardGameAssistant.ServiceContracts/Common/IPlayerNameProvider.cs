using BoardGameAssistant.ServiceContracts.Common.Dto;

namespace BoardGameAssistant.ServiceContracts.Common;

public interface IPlayerNameProvider
{
    Task<List<PlayerDto>> GetPlayersAsync(string? contains = null, int? skip = null, int? take = null, CancellationToken cancellationToken = default);
}