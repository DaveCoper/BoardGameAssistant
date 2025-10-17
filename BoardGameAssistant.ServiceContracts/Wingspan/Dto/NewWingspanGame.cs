using BoardGameAssistant.ServiceContracts.Common.Dto;

namespace BoardGameAssistant.ServiceContracts.Wingspan.Dto;

public class NewWingspanGame : NewGame
{
    public bool HasOceaniaExpansion { get; set; } = true;
}
