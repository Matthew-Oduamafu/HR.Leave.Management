using HR.Leave.Management.Application.DTOs.LeaveType;
using HR.Leave.Management.Application.Responses;
using MediatR;

namespace HR.Leave.Management.Application.Features.LeaveTypes.Requests.Commands
{
    public class CreateLeaveTypeCommand : IRequest<CreateOrUpdateCommandResponse>
    {
        public CreateLeaveTypeDto CreateLeaveTypeDto { get; set; }
    }
}