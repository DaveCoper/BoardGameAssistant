using BoardGameAssistant.Entities;
using BoardGameAssistant.Entities.Wingspan;
using BoardGameAssistant.Services;
using Microsoft.EntityFrameworkCore;

namespace BoardGameAssistant.Data.Wingspan
{
    public class WingspanDbContext : DbContext
    {
        private readonly IDateTimeProvider dateTimeProvider;

        public WingspanDbContext(
            DbContextOptions<WingspanDbContext> options,
            IDateTimeProvider dateTimeProvider) : base(options)
        {
            this.dateTimeProvider = dateTimeProvider;
        }

        public DbSet<WingspanGame> Games { get; set; }
        public DbSet<WingspanPlayerState> PlayerStates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("wingspan");
            modelBuilder.Entity<WingspanGame>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasMany(e => e.Players)
                      .WithOne(p => p.Game)
                      .HasForeignKey(p => p.GameId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<WingspanPlayerState>(entity =>
            {
                entity.HasKey(e => e.Id);

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
