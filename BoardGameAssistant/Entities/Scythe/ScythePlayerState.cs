using BoardGameAssistant.ServiceContracts.Scythe;

namespace BoardGameAssistant.Entities.Scythe
{
    public class ScythePlayerState: IEntity
    {
        public int Id { get; set; }
        public Guid? PlayerId { get; set; }
        public required string PlayerName { get; set; }

        public required int GameId { get; set; }
        public required ScytheGame Game { get; set; } 

        public required ScytheFaction Faction { get; set; }

        public int Coins { get; set; }
        public int Popularity { get; set; }
        public int Power { get; set; }
        public int Food { get; set; }
        public int Wood { get; set; }
        public int Metal { get; set; }
        public int Oil { get; set; }
        public int Workers { get; set; }
        public int Stars { get; set; }
        public int TerritoriesControlled { get; set; }
        public bool HasFactory { get; set; }
        public int StructuresBuilt { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
    }
}
