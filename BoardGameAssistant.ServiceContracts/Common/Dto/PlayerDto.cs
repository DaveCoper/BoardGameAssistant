namespace BoardGameAssistant.ServiceContracts.Common.Dto;

public class PlayerDto
{
    public required Guid Id { get; set; }

    public required string DisplayName { get; set; }
}
