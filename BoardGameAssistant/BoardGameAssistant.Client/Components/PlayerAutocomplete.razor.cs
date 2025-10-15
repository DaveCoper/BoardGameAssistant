using BoardGameAssistant.Client.Dto;
using BoardGameAssistant.Client.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BoardGameAssistant.Client.Components
{
    public partial class PlayerAutocomplete
    {
        private PlayerDto player = new PlayerDto { Id = Guid.Empty, DisplayName = string.Empty };

        [Parameter]
        public PlayerDto Player
        {
            get => player;
            set
            {
                if (value != player)
                {
                    player = value;
                    PlayerNameChanged.InvokeAsync(value);
                }
            }
        }

        [Parameter]
        public EventCallback<PlayerDto> PlayerNameChanged { get; set; }

        [Parameter]
        public Variant Variant { get; set; } = Variant.Outlined;

        [Inject]
        public IPlayerNameProvider PlayerNameProvider { get; set; } = null!;

        private async Task<IEnumerable<PlayerDto>> Search(string value, CancellationToken token)
        {
            var players = await PlayerNameProvider.GetPlayersAsync(
                contains: value,
                skip: 0,
                take: 10,
                cancellationToken: token);

            return players;
        }
    }
}
