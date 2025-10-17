using BoardGameAssistant.Entities;
using BoardGameAssistant.Entities.Scythe;
using BoardGameAssistant.Services;
using Microsoft.EntityFrameworkCore;

namespace BoardGameAssistant.Data
{
    public class ScytheDbContext : DbContext
    {
        private readonly IDateTimeProvider dateTimeProvider;

        public ScytheDbContext(
            DbContextOptions<ScytheDbContext> options,
            IDateTimeProvider dateTimeProvider) : base(options)
        {
            this.dateTimeProvider = dateTimeProvider;
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

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            UpdateAuditTrackers();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            UpdateAuditTrackers();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void UpdateAuditTrackers()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(e => e.Entity is IEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
                var entity = (IEntity)entry.Entity;
                if (entry.State == EntityState.Added)
                {
                    entity.CreatedAt = dateTimeProvider.RequestTime;
                    // entity.CreatedBy should be set from the service layer where user context is available
                }

                entity.UpdatedAt = dateTimeProvider.RequestTime;
                // entity.UpdatedBy should be set from the service layer where user context is available
            }
        }
    }
}
