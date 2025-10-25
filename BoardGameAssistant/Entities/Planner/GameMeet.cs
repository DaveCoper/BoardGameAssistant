namespace BoardGameAssistant.Entities.Planner
{
    public class GameMeet
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime Date { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
        public bool IsCancelled { get; set; }
        public bool IsDeleted { get; set; }

        public int? MeetSequenceId { get; set; }
        public MeetSequence? MeetSequence { get; set; }
    }
}
