using AutoMapper;
using HR.Leave.Management.Application.Contracts.Persistence;
using HR.Leave.Management.Application.DTOs.LeaveAllocation.Validator;
using HR.Leave.Management.Application.Features.LeaveAllocations.Requests.Commands;
using HR.Leave.Management.Application.Responses;
using MediatR;

namespace HR.Leave.Management.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, CreateOrUpdateCommandResponse>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocation, ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocation;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<CreateOrUpdateCommandResponse> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateOrUpdateCommandResponse();

            var validate = new UpdateLeaveAllocationDtoValidator(_leaveTypeRepository, _leaveAllocationRepository);
            var validationResult = await validate.ValidateAsync(request.UpdateLeaveAllocationDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Update failed";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();

                return response;
            }
            var leaveAllocation = await _leaveAllocationRepository.Get(request.UpdateLeaveAllocationDto.Id);
            leaveAllocation = _mapper.Map(request.UpdateLeaveAllocationDto, leaveAllocation);
            await _leaveAllocationRepository.Update(leaveAllocation);

            response.Id = leaveAllocation.Id;
            response.Success = true;
            response.Message = "Update successful";
            response.Object = leaveAllocation;

            return response;
        }
    }
}