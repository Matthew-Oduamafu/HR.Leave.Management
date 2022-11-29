using HR.Leave.Management.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR.Leave.Management.Domain
{
    public class LeaveAllocation : BaseDomainEntity
    {
        public int NumberOfDays { get; set; }
        public int LeaveTypeId { get; set; }

        [ForeignKey("LeaveTypeId")]
        public LeaveType LeaveType { get; set; }

        public int Period { get; set; }
    }
}