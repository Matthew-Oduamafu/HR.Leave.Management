using HR.Leave.Management.Application.DTOs.LeaveRequest;
using MediatR;

namespace HR.Leave.Management.Application.Features.LeaveRequests.Requests.Queries
{
    public class GetLeaveRequestListRequest : IRequest<List<LeaveRequestListDto>>
    {
    }
}