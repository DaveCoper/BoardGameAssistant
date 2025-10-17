using BoardGameAssistant.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BoardGameAssistant.Data.App
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>(options)
    {
    }
}
