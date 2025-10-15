namespace BoardGameAssistant.Entities.Scythe
{
    public class ScytheGame : Game
    {
        public List<ScythePlayerState> Players { get; set; } = new();

    }
}
