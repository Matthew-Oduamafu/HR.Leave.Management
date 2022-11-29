using HR.Leave.Management.Application.DTOs.Common;
using HR.Leave.Management.Application.DTOs.LeaveType;

namespace HR.Leave.Management.Application.DTOs.LeaveAllocation
{
    public class LeaveAllocationDto : BaseDto, ILeaveAllocationDto
    {
        public int NumberOfDays { get; set; }
        public int LeaveTypeId { get; set; }
        public LeaveTypeDto LeaveType { get; set; }
        public int Period { get; set; }
    }
}