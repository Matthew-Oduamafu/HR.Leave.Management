using FluentValidation;
using HR.Leave.Management.Application.Contracts.Persistence;

namespace HR.Leave.Management.Application.DTOs.LeaveRequest.Validators
{
    public class UpdateLeaveRequestDtoValidator : AbstractValidator<UpdateLeaveRequestDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public UpdateLeaveRequestDtoValidator(ILeaveTypeRepository leaveTypeRepository, ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _leaveRequestRepository = leaveRequestRepository;

            Include(new ILeaveRequestDtoValidator(_leaveTypeRepository));

            RuleFor(x => x.Id)
                .NotNull().WithMessage("{PropertyName} must be present")
                .MustAsync(async (id, token) =>
                {
                    var leaveRequest = await _leaveRequestRepository.Exists(id);
                    return leaveRequest;
                }).WithMessage("{PropertyName} with Value:{PropertyValue} not found in DB");

            RuleFor(x => x.RequestComments)
                .NotNull().WithMessage("{PropertyName} must be present")
                .NotEmpty().WithMessage("{PropertyName} must not be empty");

            RuleFor(x => x.Cancelled)
                .NotNull().WithMessage("{PropertyName} must be present")
                .NotEmpty().WithMessage("{PropertyName} must not be empty");
        }
    }
}