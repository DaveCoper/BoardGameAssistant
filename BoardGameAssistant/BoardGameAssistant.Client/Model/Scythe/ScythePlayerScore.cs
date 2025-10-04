namespace BoardGameAssistant.Client.Model.Scythe
{
    public class ScythePlayerScore
    {
        public string PlayerName { get; set; } 
        public int Coins { get; set; }
        public int Stars { get; set; }
        public int Territories { get; set; }
        public bool OwnsFactory { get; set; }
        public int BuildingsOnRiver { get; set; }
    }
}
