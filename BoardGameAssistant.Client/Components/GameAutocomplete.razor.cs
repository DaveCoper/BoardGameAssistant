using BoardGameAssistant.ServiceContracts.Common;
using BoardGameAssistant.ServiceContracts.Common.Dto;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BoardGameAssistant.Client.Components
{
    public partial class GameAutocomplete
    {
        private BoardGame? game = null;

        [Parameter]
        public BoardGame? Game
        {
            get => game;
            set
            {
                if (value != game)
                {
                    game = value;
                    GameChanged.InvokeAsync(value);
                }
            }
        }

        [Parameter]
        public EventCallback<BoardGame> GameChanged { get; set; }

        [Parameter]
        public Variant Variant { get; set; } = Variant.Outlined;

        [Inject]
        public IGameProvider GameProvider { get; set; } = null!;

        private async Task<IEnumerable<BoardGame?>> Search(string value, CancellationToken token)
        {
            var games = await GameProvider.GetBoardGames(
                nameFilter: value,
                skip: 0,
                take: 10,
                false,
                cancellationToken: token);

            return games;
        }
    }
}
