
using BoardGameAssistant.Client.Dto;

namespace BoardGameAssistant.Client.Services
{
    public interface IPlayerNameProvider
    {
        Task<List<PlayerDto>> GetPlayersAsync(string? contains = null, int? skip = null, int? take = null, CancellationToken cancellationToken = default);
    }
}