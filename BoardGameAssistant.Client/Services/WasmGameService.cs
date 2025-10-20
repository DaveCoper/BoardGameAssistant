using BoardGameAssistant.ServiceContracts.Common;
using BoardGameAssistant.ServiceContracts.Common.Dto;
using BoardGameAssistant.ServiceContracts.Wingspan;
using BoardGameAssistant.ServiceContracts.Wingspan.Dto;
using System.Net.Http.Json;

namespace BoardGameAssistant.Client.Services
{
    public class WasmGameProvider : IGameProvider
    {
        private readonly HttpClient httpClient;

        public WasmGameProvider(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<BoardGame>> GetBoardGames(string? nameQuery, int skip, int take, bool includeExpansions, CancellationToken cancellationToken)
        {
            var queryParameters = new Dictionary<string, object>
            {
                { "skip", skip },
                { "take", take }
            };

            if (!string.IsNullOrWhiteSpace(nameQuery))
            {
                queryParameters["name"] = nameQuery;
            }

            var formattedQueryParameters = queryParameters.Select(kvp => $"{kvp.Key}={System.Net.WebUtility.UrlEncode(kvp.Value.ToString())}");
            var url = $"api/Games?{string.Join('&', formattedQueryParameters)}";
            var response = await httpClient.GetFromJsonAsync<List<BoardGame>>(url, cancellationToken);
            return response ?? throw new InvalidOperationException("Failed to deserialize the game list.");
        }
    }
}
