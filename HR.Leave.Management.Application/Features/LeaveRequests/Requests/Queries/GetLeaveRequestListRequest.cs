using HR.Leave.Management.Application.DTOs.LeaveRequest;
using HR.Leave.Management.Domain;
using MediatR;

namespace HR.Leave.Management.Application.Features.LeaveRequests.Requests.Queries
{
    public class GetLeaveRequestListRequest:IRequest<List<LeaveRequestListDto>>
    {
    }
}
