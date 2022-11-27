using HR.Leave.Management.Application.DTOs.LeaveAllocation;
using HR.Leave.Management.Domain;
using MediatR;

namespace HR.Leave.Management.Application.Features.LeaveAllocations.Requests.Queries
{
    public class GetLeaveAllocationListRequest:IRequest<List<LeaveAllocationDto>>
    {
    }
}
