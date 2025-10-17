using BoardGameAssistant.ServiceContracts.Scythe;
using BoardGameAssistant.ServiceContracts.Scythe.Dto;
using System.Net.Http.Json;

namespace BoardGameAssistant.Client.Services
{
    public class WasmScytheGameService : IScytheGameService
    {
        private readonly HttpClient httpClient;

        public WasmScytheGameService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<ScytheGame> CreateGameAsync(NewScytheGame newGameSettings)
        {
            var response = await httpClient.PostAsJsonAsync("api/scythe", newGameSettings);
            response.EnsureSuccessStatusCode();

            var createdGame = await response.Content.ReadFromJsonAsync<ScytheGame>();
            if(createdGame == null)
            {
                throw new InvalidOperationException("Failed to deserialize the created game.");
            }

            return createdGame;
        }

        public async Task<ScytheGame> GetGameAsync(int gameId, CancellationToken cancellationToken = default)
        {
            return await httpClient.GetFromJsonAsync<ScytheGame>($"api/scythe/{gameId}", cancellationToken)
                ?? throw new InvalidOperationException("Failed to deserialize the game.");
        }
    }
}
