using BoardGameAssistant.ServiceContracts.Scythe.Dto;

namespace BoardGameAssistant.Client.Services
{
    public interface IScytheGameService
    {
        Task<ScytheGame> CreateGameAsync(string? gameName = null, DateTime? occurence = null);
    }
}