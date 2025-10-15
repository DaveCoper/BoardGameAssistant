using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using BoardGameAssistant.Client.Dto;

namespace BoardGameAssistant.Client.Services
{
    public partial class WasmPlayerNameProvider : IPlayerNameProvider
    {
        private readonly HttpClient _httpClient;

        public WasmPlayerNameProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Získá seznam hráčů z API.
        /// </summary>
        /// <param name="contains">Filtr na jméno hráče (volitelné, min. 3 znaky pro filtrování).</param>
        /// <param name="skip">Počet přeskočených záznamů (volitelné).</param>
        /// <param name="take">Počet načtených záznamů (volitelné, max. 10).</param>
        /// <returns>Seznam hráčů.</returns>
        public async Task<List<PlayerDto>> GetPlayersAsync(string? contains = null, int? skip = null, int? take = null, CancellationToken cancellationToken = default)
        {
            var url = "api/Player?";
            if (!string.IsNullOrWhiteSpace(contains))
                url += $"contains={System.Net.WebUtility.UrlEncode(contains)}&";
            if (skip.HasValue)
                url += $"skip={skip.Value}&";
            if (take.HasValue)
                url += $"take={take.Value}&";

            // Odstraň poslední '&' nebo '?', pokud je na konci
            url = url.TrimEnd('&', '?');

            var players = await _httpClient.GetFromJsonAsync<List<PlayerDto>>(url, cancellationToken);
            return players ?? new List<PlayerDto>();
        }
    }
}
