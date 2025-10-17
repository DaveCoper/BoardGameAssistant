using MudBlazor;

namespace BoardGameAssistant.Client.Model
{
    public class MenuOption
    {
        public Color Color { get; set; } = Color.Inherit;
        public required string Icon { get; set; }
        public required string Title { get; set; }

        public required Action Command { get; set; }
    }
}
