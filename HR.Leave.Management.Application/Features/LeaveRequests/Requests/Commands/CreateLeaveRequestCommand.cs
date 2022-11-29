using HR.Leave.Management.Application.DTOs.LeaveRequest;
using HR.Leave.Management.Application.Responses;
using MediatR;

namespace HR.Leave.Management.Application.Features.LeaveRequests.Requests.Commands
{
    public class CreateLeaveRequestCommand : IRequest<CreateOrUpdateCommandResponse>
    {
        public CreateLeaveRequestDto CreateLeaveRequestDto { get; set; }
    }
}