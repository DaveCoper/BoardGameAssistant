namespace BoardGameAssistant.Services
{
    public interface IDateTimeProvider
    {
        DateTime RequestTime { get; }
    }
}
