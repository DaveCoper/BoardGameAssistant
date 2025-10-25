namespace BoardGameAssistant.Entities.Planner
{
    public class MeetSequence
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public TimeInterval Occurs { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
