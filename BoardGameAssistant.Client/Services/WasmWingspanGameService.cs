using BoardGameAssistant.ServiceContracts.Wingspan;
using BoardGameAssistant.ServiceContracts.Wingspan.Dto;
using System.Net.Http.Json;

namespace BoardGameAssistant.Client.Services
{
    public class WasmWingspanGameService : IWingspanGameService
    {
        private readonly HttpClient httpClient;

        public WasmWingspanGameService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<WingspanGame> CreateGameAsync(NewWingspanGame wingspanGameSettings)
        {
            var response = await httpClient.PostAsJsonAsync("api/wingspan", wingspanGameSettings);
            response.EnsureSuccessStatusCode();

            var createdGame = await response.Content.ReadFromJsonAsync<WingspanGame>();
            if(createdGame == null)
            {
                throw new InvalidOperationException("Failed to deserialize the created game.");
            }

            return createdGame;
        }

        public async Task<WingspanGame> GetGameAsync(int gameId, CancellationToken cancellationToken = default)
        {
            var response = await httpClient.GetFromJsonAsync<WingspanGame>($"api/wingspan/{gameId}", cancellationToken);
            return response ?? throw new InvalidOperationException("Failed to deserialize the game.");
        }
    }
}
