using BoardGameAssistant.Entities.Planner;
using BoardGameAssistant.ServiceContracts.Common;
using BoardGameAssistant.ServiceContracts.Common.Dto;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System.Globalization;

namespace BoardGameAssistant.Services
{
    public class BggGameProvider : IGameProvider
    {
        private readonly IMemoryCache memoryCache;
        private readonly BggGameProviderOptions options;

        public BggGameProvider(IMemoryCache memoryCache, IOptions<BggGameProviderOptions> options)
        {
            this.memoryCache = memoryCache;
            this.options = options.Value;
        }

        public async Task<List<BoardGame>> GetBoardGames(
            string? nameQuery, 
            int skip, 
            int take, 
            bool includeExpansions,
            CancellationToken cancellationToken)
        {
            var list = await memoryCache.GetOrCreateAsync("bgg_games_db", entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(1);
                return Task.Run(LoadCsvBoardbameDB);
            });

            if (list == null || list.Count == 0)
            {
                return [];
            }

            var query = list.AsQueryable();

            if (!includeExpansions)
            {
                query = query.Where(g => !g.IsExpansion);
            }

            if (!string.IsNullOrWhiteSpace(nameQuery))
            {
                query = query
                    .Where(g => g.Name.Contains(nameQuery, StringComparison.CurrentCultureIgnoreCase))
                    .OrderBy(g => g.Name.IndexOf(nameQuery, StringComparison.CurrentCultureIgnoreCase))
                    .ThenByDescending(g => g.YearPublished)
                    .ThenBy(g => g.Rank);
            }
            else
            {
                query = query
                    .OrderBy(g => g.Rank)
                    .ThenByDescending(g => g.YearPublished);
            }

            var result = query
                .Skip(skip)
                .Take(take)
                .Select(g => new BoardGame
                {
                    Id = g.Id,
                    Name = g.Name,
                    YearPublished = g.YearPublished
                })
                .ToList();

            return result;
        }

        private List<BggGameData> LoadCsvBoardbameDB()
        {
            var csvReaderConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                MissingFieldFound = null,
                HeaderValidated = null,
                Escape = '"',
                Delimiter = ",",
                TrimOptions = TrimOptions.Trim
            };

            using CsvReader csvReader = new CsvReader(new StreamReader(options.BggDbLocation), csvReaderConfiguration);
            var records = csvReader.GetRecords<BggGameData>();
            return records.ToList();
        }
    }
}
