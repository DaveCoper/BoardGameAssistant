namespace BoardGameAssistant.ServiceContracts.Scythe.Dto
{
    public class ScytheGame
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required DateTime PlayedAt { get; set; }
    }
}
