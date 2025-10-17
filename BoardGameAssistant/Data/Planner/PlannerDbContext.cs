using BoardGameAssistant.Entities.Planner;
using Microsoft.EntityFrameworkCore;

namespace BoardGameAssistant.Data.Planner
{
    public class PlannerDbContext : DbContext
    {
        public PlannerDbContext(DbContextOptions<PlannerDbContext> options)
            : base(options)
        {
        }

        public DbSet<GameMeet> Meetings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("planner");
        }


    }
}
