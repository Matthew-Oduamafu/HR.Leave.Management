using HR.Leave.Management.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.Leave.Management.Persistence.Configurations.Entities
{
    public class LeaveTypeConfigurations : IEntityTypeConfiguration<LeaveType>
    {
        public void Configure(EntityTypeBuilder<LeaveType> builder)
        {
            builder.HasData(
                new LeaveType
                {
                    Id = 1,
                    DefaultDays = 10,
                    Name = "Vacation",
                    CreatedBy = "Matthew Oduamafu"
                },
                new LeaveType
                {
                    Id = 2,
                    DefaultDays = 12,
                    Name = "Sick",
                    CreatedBy = "Matthew Oduamafu",
                }
                );
        }
    }
}
