using BoardGameAssistant.ServiceContracts.Common.Dto;

namespace BoardGameAssistant.ServiceContracts.Scythe.Dto;

public class NewScytheGame : NewGame
{
    public bool HasInvadersFromAfarExpansion { get; set; }
    public bool HasWindGambitExpansion { get; set; }
    public bool HasRiseOfFenrisExpansion { get; set; }
    public bool HasModularBoard { get; set; }
}
