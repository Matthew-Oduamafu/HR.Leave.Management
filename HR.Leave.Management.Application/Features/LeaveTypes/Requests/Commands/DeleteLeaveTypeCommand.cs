using HR.Leave.Management.Application.Responses;
using MediatR;

namespace HR.Leave.Management.Application.Features.LeaveTypes.Requests.Commands
{
    public class DeleteLeaveTypeCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
    }
}