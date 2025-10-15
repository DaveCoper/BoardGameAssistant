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

        public async Task<ScytheGame> CreateGameAsync(string? gameName, DateTime? occurence)
        {
            var response = await httpClient.PostAsJsonAsync("api/scythe/games", gameName);
            response.EnsureSuccessStatusCode();

            var createdGame = await response.Content.ReadFromJsonAsync<ScytheGame>();
            if(createdGame == null)
            {
                throw new InvalidOperationException("Failed to deserialize the created game.");
            }

            return createdGame;
        }
    }
}
