using FluentValidation;

namespace HR.Leave.Management.Application.DTOs.LeaveType.Validators
{
    public class LeaveTypeDtoValidator : AbstractValidator<LeaveTypeDto>
    {
        public LeaveTypeDtoValidator()
        {
            Include(new ILeaveTypeDtoValidator());
        }
    }
}