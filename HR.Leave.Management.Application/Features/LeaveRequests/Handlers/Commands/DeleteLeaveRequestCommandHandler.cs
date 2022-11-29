using HR.Leave.Management.Application.Contracts.Persistence;
using HR.Leave.Management.Application.Features.LeaveRequests.Requests.Commands;
using HR.Leave.Management.Application.Responses;
using MediatR;

namespace HR.Leave.Management.Application.Features.LeaveRequests.Handlers.Commands
{
    public class DeleteLeaveRequestCommandHandler : IRequestHandler<DeleteLeaveRequestCommand, BaseCommandResponse>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public DeleteLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
        }

        public async Task<BaseCommandResponse> Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var leaveRequest = await _leaveRequestRepository.Get(request.Id);

            if (leaveRequest == null)
            {
                response.Id = request.Id;
                response.Success = false;
                response.Message = "Deletion failed";
                response.Errors = new List<string> { "Item not found" };

                return response;
            }

            await _leaveRequestRepository.Delete(leaveRequest);

            response.Id = request.Id;
            response.Success = true;
            response.Message = "Deletion successful";

            return response;
        }
    }
}