using FluentValidation;
using HR.Leave.Management.Application.Contracts.Persistence;

namespace HR.Leave.Management.Application.DTOs.LeaveAllocation.Validator
{
    public class UpdateLeaveAllocationDtoValidator : AbstractValidator<UpdateLeaveAllocationDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;

        public UpdateLeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository, ILeaveAllocationRepository leaveAllocationRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _leaveAllocationRepository = leaveAllocationRepository;

            Include(new ILeaveAllocationDtoValidator(_leaveTypeRepository));
            RuleFor(x => x.Id)
                .NotNull().WithMessage("{PropertyName} must be present")
                .MustAsync(async (id, token) =>
                {
                    var leaveAllocation = await _leaveAllocationRepository.Exists(id);
                    return leaveAllocation;
                }).WithMessage("{PropertyName}: {PropertyValue} does not exist in the DB");
        }
    }
}