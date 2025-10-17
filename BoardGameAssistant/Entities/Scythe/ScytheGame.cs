namespace BoardGameAssistant.Entities.Scythe
{
    public class ScytheGame : Game
    {
        public List<ScythePlayerState> Players { get; set; } = new();
        
        public bool HasInvadersFromAfarExpansion { get; internal set; }
        public bool HasWindGambitExpansion { get; internal set; }
        public bool HasRiseOfFenrisExpansion { get; internal set; }
        public bool HasModularBoard { get; internal set; }
    }
}
