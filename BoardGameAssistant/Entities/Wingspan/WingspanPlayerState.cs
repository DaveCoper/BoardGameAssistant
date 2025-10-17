namespace BoardGameAssistant.Entities.Wingspan
{
    public class WingspanPlayerState : IEntity
    {
        public int Id { get; set; }
        public Guid? PlayerId { get; set; }
        public required string PlayerName { get; set; }

        public required int GameId { get; set; }
        public required WingspanGame Game { get; set; }

        // stuff on the board
        public int Eggs { get; set; }
        public int FoodOnCards { get; set; }
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

        // audit fields
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
    }
}
