using Microsoft.AspNetCore.Identity;

namespace BoardGameAssistant.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string? DisplayName { get; set; }
    }

}
