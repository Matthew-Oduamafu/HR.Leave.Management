﻿using HR.Leave.Management.Application.DTOs.LeaveAllocation;
using MediatR;

namespace HR.Leave.Management.Application.Features.LeaveAllocations.Requests.Queries
{
    public class GetLeaveAllocationDetailRequest : IRequest<LeaveAllocationDto>
    {
        public int Id { get; set; }
    }
}