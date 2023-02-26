using AutoMapper;
using HR.Leave.Management.Application.Contracts.Persistence;
using HR.Leave.Management.Application.DTOs.LeaveType.Validators;
using HR.Leave.Management.Application.Features.LeaveTypes.Requests.Commands;
using HR.Leave.Management.Application.Responses;
using HR.Leave.Management.Domain;
using MediatR;

namespace HR.Leave.Management.Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, CreateOrUpdateCommandResponse>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<CreateOrUpdateCommandResponse> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateOrUpdateCommandResponse();

            var validate = new CreateLeaveTypeDtoValidator();
            var validationResult = validate.Validate(request.CreateLeaveTypeDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation failed";
                response.Errors = validationResult.Errors.ConvertAll(x => x.ErrorMessage);

                return response;
            }

            var leaveType = _mapper.Map<LeaveType>(request.CreateLeaveTypeDto);
            await _leaveTypeRepository.Add(leaveType);

            // if creation successful
            response.Success = true;
            response.Message = "Creation successful";
            response.Object = leaveType;

            return response;
        }
    }
}