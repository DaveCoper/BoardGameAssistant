namespace BoardGameAssistant.Entities.Scythe
{
    public class Game : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime PlayedAt { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
    }
}