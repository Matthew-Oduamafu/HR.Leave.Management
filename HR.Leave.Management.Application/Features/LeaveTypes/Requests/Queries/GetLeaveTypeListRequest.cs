using HR.Leave.Management.Application.DTOs.LeaveType;
using MediatR;

namespace HR.Leave.Management.Application.Features.LeaveTypes.Requests.Queries
{
    public class GetLeaveTypeListRequest : IRequest<List<LeaveTypeDto>>
    {
    }
}