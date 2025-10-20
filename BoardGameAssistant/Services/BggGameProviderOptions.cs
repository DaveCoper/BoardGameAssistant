
namespace BoardGameAssistant.Services
{
    public class BggGameProviderOptions
    {
        public const string SectionKey = "BggOptions";

        public required string BggDbLocation { get; set; }
    }
}