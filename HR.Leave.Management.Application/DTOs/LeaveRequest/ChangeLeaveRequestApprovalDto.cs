using HR.Leave.Management.Application.DTOs.Common;

namespace HR.Leave.Management.Application.DTOs.LeaveRequest
{
    public class ChangeLeaveRequestApprovalDto : BaseDto
    {
        public bool? Approved { get; set; }
    }
}