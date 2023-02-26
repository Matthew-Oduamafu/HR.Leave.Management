using HR.Leave.Management.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.Leave.Management.Persistence.Configurations.Entities
{
    public class LeaveAllocationConfigurations : IEntityTypeConfiguration<LeaveAllocation>
    {
        public void Configure(EntityTypeBuilder<LeaveAllocation> builder)
        {
        }
    }
}