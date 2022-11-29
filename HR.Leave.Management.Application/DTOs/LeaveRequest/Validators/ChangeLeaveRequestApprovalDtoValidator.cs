using FluentValidation;
using HR.Leave.Management.Application.Contracts.Persistence;

namespace HR.Leave.Management.Application.DTOs.LeaveRequest.Validators
{
    public class ChangeLeaveRequestApprovalDtoValidator : AbstractValidator<ChangeLeaveRequestApprovalDto>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public ChangeLeaveRequestApprovalDtoValidator(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;

            RuleFor(x => x.Id)
                .NotNull().WithMessage("{PropertyName} must be present")
                .MustAsync(async (id, token) =>
                {
                    var leaveRequest = await _leaveRequestRepository.Exists(id);
                    return leaveRequest;
                }).WithMessage("{PropertyName} with Value:{PropertyValue} not found in DB");

            RuleFor(x => x.Approved)
                .NotNull().WithMessage("{PropertyName} must be present")
                .NotEmpty().WithMessage("{PropertyName} must not be present");
        }
    }
}