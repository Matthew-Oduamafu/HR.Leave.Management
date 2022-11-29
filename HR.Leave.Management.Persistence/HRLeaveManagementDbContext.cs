using HR.Leave.Management.Domain;
using HR.Leave.Management.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace HR.Leave.Management.Persistence
{
    public class HRLeaveManagementDbContext : DbContext
    {
        public HRLeaveManagementDbContext(DbContextOptions<HRLeaveManagementDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HRLeaveManagementDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.UtcNow;
                    entry.Entity.CreatedBy = "Matthew Oduamafu";
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.LastUpdateDate = DateTime.UtcNow;
                    entry.Entity.UpdatedBy = "Matthew Oduamfu";
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        // add entities
        public DbSet<LeaveType> LeaveType { get; set; }

        public DbSet<LeaveAllocation> LeaveAllocation { get; set; }
        public DbSet<LeaveRequest> LeaveRequest { get; set; }
    }
}