using BoardGameAssistant.Entities.Scythe;
using Microsoft.EntityFrameworkCore;

namespace BoardGameAssistant.Data
{
    public class ScytheDbContext : DbContext
    {
        public ScytheDbContext(DbContextOptions<ScytheDbContext> options) : base(options)
        {
        }

        public DbSet<ScytheGame> Games { get; set; }
        public DbSet<ScythePlayerState> PlayerStates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ScytheGame>(entity =>
            {
                entity.HasKey(e => e.Id);                
                entity.HasMany(e => e.Players)
                      .WithOne(p => p.Game)
                      .HasForeignKey(p => p.GameId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ScythePlayerState>(entity =>
            { 
                entity.HasKey(e => e.Id);        
                entity.Property(e => e.Faction)
                    .HasConversion<string>()
                    .HasMaxLength(12)
                    .HasColumnType("CHAR(12)");

            });


        }
    }
}
