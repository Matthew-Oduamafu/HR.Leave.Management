using AutoMapper;
using HR.Leave.Management.Application.Contracts.Persistence;
using HR.Leave.Management.Application.DTOs.LeaveType.Validators;
using HR.Leave.Management.Application.Features.LeaveTypes.Requests.Commands;
using HR.Leave.Management.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Leave.Management.Application.Features.LeaveTypes.Handlers.Commands
{
    public class DeleteLeaveTypeCommandHandler:IRequestHandler<DeleteLeaveTypeCommand, BaseCommandResponse>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository= leaveTypeRepository;
        }

        public async Task<BaseCommandResponse> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var leaveType = await _leaveTypeRepository.Get(request.Id);

            if (leaveType == null) 
            {
                response.Success = false;
                response.Message = "Deletion failed";
                response.Errors = new List<string> { "Item not found" };

                return response;
            }

            response.Id = request.Id;
            response.Success = true;
            response.Message = "Deletion successful";

            await _leaveTypeRepository.Delete(leaveType);
            return response;
        }
    }
}
