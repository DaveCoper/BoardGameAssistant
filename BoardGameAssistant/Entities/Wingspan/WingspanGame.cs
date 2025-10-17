namespace BoardGameAssistant.Entities.Wingspan
{
    public class WingspanGame : Game
    {
        public List<WingspanPlayerState> Players { get; set; } = new();

        public bool HasOceaniaExpansion { get; set; } = true;
    }
}
