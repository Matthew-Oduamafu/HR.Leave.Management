using HR.Leave.Management.Application.DTOs.Common;
using HR.Leave.Management.Application.DTOs.LeaveType;

namespace HR.Leave.Management.Application.DTOs.LeaveRequest
{
    public class LeaveRequestListDto : BaseDto
    {
        public LeaveTypeDto LeaveType { get; set; }
        public DateTime DateRequested { get; set; }
        public bool? Approved { get; set; }
    }
}