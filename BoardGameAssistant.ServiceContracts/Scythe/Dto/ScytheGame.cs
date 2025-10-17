namespace BoardGameAssistant.ServiceContracts.Scythe.Dto;

public class ScytheGame
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required DateTime PlayedAt { get; set; }

    public bool HasInvadersFromAfarExpansion { get; set; }
    public bool HasWindGambitExpansion { get; set; }
    public bool HasRiseOfFenrisExpansion { get; set; }
    public bool HasModularBoard { get; set; }

    public List<ScythePlayerScore> PlayerScores { get; set; } = new();
}
