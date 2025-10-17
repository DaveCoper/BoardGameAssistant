
namespace BoardGameAssistant.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime RequestTime { get; } = DateTime.Now;
    }
}
