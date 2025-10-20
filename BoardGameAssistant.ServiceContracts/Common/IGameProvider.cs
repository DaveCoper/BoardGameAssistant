using BoardGameAssistant.ServiceContracts.Common.Dto;

namespace BoardGameAssistant.ServiceContracts.Common
{
    public interface IGameProvider
    {
        Task<List<BoardGame>> GetBoardGames(
            string? nameFilter,
            int skip,
            int take,
            bool includeExpansions,
            CancellationToken cancellationToken);
    }
}
