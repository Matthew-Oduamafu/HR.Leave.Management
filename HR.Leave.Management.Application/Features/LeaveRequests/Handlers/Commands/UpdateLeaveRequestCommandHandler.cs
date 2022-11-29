using AutoMapper;
using HR.Leave.Management.Application.Contracts.Persistence;
using HR.Leave.Management.Application.DTOs.LeaveRequest.Validators;
using HR.Leave.Management.Application.Features.LeaveRequests.Requests.Commands;
using HR.Leave.Management.Application.Responses;
using MediatR;

namespace HR.Leave.Management.Application.Features.LeaveRequests.Handlers.Commands
{
    public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, CreateOrUpdateCommandResponse>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequest, ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequest;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<CreateOrUpdateCommandResponse> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateOrUpdateCommandResponse();
            var leaveRequest = await _leaveRequestRepository.Get(request.Id);

            if (leaveRequest != null)
            {
                if (request.UpdateLeaveRequestDto != null)
                {
                    var validate = new UpdateLeaveRequestDtoValidator(_leaveTypeRepository, _leaveRequestRepository);
                    var validationResult = await validate.ValidateAsync(request.UpdateLeaveRequestDto);

                    if (validationResult.IsValid == false)
                    {
                        response.Success = false;
                        response.Message = "Update failed";
                        response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();

                        return response;
                    }

                    leaveRequest = _mapper.Map(request.UpdateLeaveRequestDto, leaveRequest);
                    await _leaveRequestRepository.Update(leaveRequest);
                }
                else if (request.ChangeLeaveRequestApprovalDto != null)
                {
                    var validate = new ChangeLeaveRequestApprovalDtoValidator(_leaveRequestRepository);
                    var validationResult = await validate.ValidateAsync(request.ChangeLeaveRequestApprovalDto);

                    if (validationResult.IsValid == false)
                    {
                        response.Success = false;
                        response.Message = "Update failed";
                        response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();

                        return response;
                    }

                    leaveRequest = _mapper.Map(request.ChangeLeaveRequestApprovalDto, leaveRequest);
                    await _leaveRequestRepository.Update(leaveRequest);
                }
            }
            else
            {
                response.Id = request.Id;
                response.Success = false;
                response.Message = "Update failed";
                response.Errors = new List<string> { $"Item with id{request.Id} not found in DB" };

                return response;
            }

            response.Id = leaveRequest.Id;
            response.Success = true;
            response.Message = "Update successful";
            response.Object = leaveRequest;

            return response;
        }
    }
}