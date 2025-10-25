namespace BoardGameAssistant.ServiceContracts.Planner
{
    public interface IMeetService
    {
        Task<List<Dto.GameMeet>> GetMeetsAsync(DateTime from, DateTime to, CancellationToken cancellationToken = default);


    }
}
