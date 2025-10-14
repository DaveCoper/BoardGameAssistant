namespace BoardGameAssistant.Entities.Scythe
{
    public class ScytheGame : IEntity
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; } 

        public List<ScythePlayerState> Players { get; set; } = new();

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
    }
}
