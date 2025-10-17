namespace BoardGameAssistant.ServiceContracts.Scythe.Dto;

public class ScythePlayerScore
{
    public Guid? PlayerId { get; set; }
    public string PlayerName { get; set; } = string.Empty;

    public ScytheFaction Faction { get; set; }

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
}
