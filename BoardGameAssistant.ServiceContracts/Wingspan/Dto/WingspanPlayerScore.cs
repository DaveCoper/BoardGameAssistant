namespace BoardGameAssistant.ServiceContracts.Wingspan.Dto;

public class WingspanPlayerScore
{
    public Guid? PlayerId { get; set; }
    public string PlayerName { get; set; } = string.Empty;

    // stuff on the board
    public int Eggs { get; set; }
    public int TuckedCards { get; set; }

    // points
    public int PointsForBirds { get; set; }
    public int PointsForObjectives { get; set; }

    // stored nectar
    public int NectarOnRow1 { get; set; }
    public int NectarOnRow2 { get; set; }
    public int NectarOnRow3 { get; set; }

    // end of round points
    public int EndOfRoundGoals { get; set; }
}
