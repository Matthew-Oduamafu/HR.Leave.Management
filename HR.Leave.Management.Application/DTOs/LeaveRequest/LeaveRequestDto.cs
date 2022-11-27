﻿using HR.Leave.Management.Application.DTOs.Common;
using HR.Leave.Management.Application.DTOs.LeaveType;

namespace HR.Leave.Management.Application.DTOs.LeaveRequest
{
    public class LeaveRequestDto : BaseDto, ILeaveRequestDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LeaveTypeId { get; set; }
    }
}
