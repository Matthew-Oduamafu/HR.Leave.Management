using FluentValidation;

namespace HR.Leave.Management.Application.DTOs.LeaveType.Validators
{
    public class ILeaveTypeDtoValidator : AbstractValidator<ILeaveTypeDto>
    {
        public ILeaveTypeDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("{PropertyName} must be present")
                .NotEmpty().WithMessage("{PropertyName} must not be empty");

            RuleFor(x => x.DefaultDays)
                .NotNull().WithMessage("{PropertyName} must be present")
                .GreaterThan(0).WithMessage("{PropertyName} must exceed {ComparisonValue}");
        }
    }
}