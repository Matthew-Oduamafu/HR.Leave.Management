using FluentValidation;
using HR.Leave.Management.Application.Contracts.Persistence;

namespace HR.Leave.Management.Application.DTOs.LeaveAllocation.Validator
{
    public class ILeaveAllocationDtoValidator : AbstractValidator<ILeaveAllocationDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public ILeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            RuleFor(x => x.NumberOfDays)
                .NotNull().WithMessage("{PropertyName} must be present")
                .GreaterThan(0).WithMessage("{PropertyName} must exceed {ComparisonValue}")
                .InclusiveBetween(1, 100).WithMessage("{PropertyName} must be between {ComparisonRange} inclusive");

            RuleFor(x => x.Period)
                .NotNull().WithMessage("{PropertyName} must be present")
                .GreaterThan(0).WithMessage("{PropertyName} must exceed {ComparisonValue}")
                .InclusiveBetween(1, 90).WithMessage("{PropertyName} must be between {ComparisonRange} inclusive");

            RuleFor(x => x.LeaveTypeId)
                .NotNull().WithMessage("{PropertyName} must be present")
                .MustAsync(async (id, token) =>
                {
                    var leaveType = await _leaveTypeRepository.Exists(id);
                    return leaveType;
                }).WithMessage("{PropertyName} not found in the DB");
        }
    }
}