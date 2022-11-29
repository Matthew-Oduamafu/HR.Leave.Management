using HR.Leave.Management.Domain.Common;

namespace HR.Leave.Management.Domain
{
    public class LeaveType : BaseDomainEntity
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}