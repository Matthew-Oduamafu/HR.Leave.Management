using AutoMapper;
using HR.Leave.Management.Application.Contracts.Infrastructure;
using HR.Leave.Management.Application.Contracts.Persistence;
using HR.Leave.Management.Application.DTOs.LeaveRequest.Validators;
using HR.Leave.Management.Application.Features.LeaveRequests.Requests.Commands;
using HR.Leave.Management.Application.Model;
using HR.Leave.Management.Application.Responses;
using HR.Leave.Management.Domain;
using MediatR;

namespace HR.Leave.Management.Application.Features.LeaveRequests.Handlers.Commands
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, CreateOrUpdateCommandResponse>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;

        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper, ILeaveTypeRepository leaveTypeRepository, IEmailSender emailSender)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
            _emailSender = emailSender;
        }

        public async Task<CreateOrUpdateCommandResponse> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateOrUpdateCommandResponse();

            var validate = new CreateLeaveRequestDtoValidator(_leaveTypeRepository);

            var validationResult = await validate.ValidateAsync(request.CreateLeaveRequestDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation failed";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();

                return response;
            }

            var leaveRequest = _mapper.Map<LeaveRequest>(request.CreateLeaveRequestDto);
            leaveRequest = await _leaveRequestRepository.Add(leaveRequest);

            // send email notification
            var email = new Email
            {
                To = "mattoduamafu@gmail.com",
                Body = $"Your request for {request.CreateLeaveRequestDto.StartDate:D} to {request.CreateLeaveRequestDto.EndDate:D} has been submitted successfully.",
                Subject = "Leave Request Submitted"
            };
            try
            {
                await _emailSender.SendEmail(email);
            }
            catch (Exception ex)
            {
                // log or handle error but don't throw
            }

            response.Success = true;
            response.Message = "Creation successful";
            response.Object = leaveRequest;

            return response;
        }
    }
}