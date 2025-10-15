namespace BoardGameAssistant.ServiceContracts.Scythe.Dto
{
    public class ScythePlayerScore
    {
        public string PlayerName { get; set; } = string.Empty;
        public int Coins { get; set; }
        public int Stars { get; set; }
        public int Territories { get; set; }
        public bool OwnsFactory { get; set; }
        public int BuildingScore{ get; set; }
    }
}
