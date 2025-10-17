namespace BoardGameAssistant.ServiceContracts.Wingspan.Dto;

public class WingspanGame
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required DateTime PlayedAt { get; set; }

    public bool HasOceaniaExpansion { get; set; } = true;

    public List<WingspanPlayerScore> PlayerScores { get; set; } = new List<WingspanPlayerScore>();
}
