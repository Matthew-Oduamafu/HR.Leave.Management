using HR.Leave.Management.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Leave.Management.Application.Features.LeaveTypes.Requests.Commands
{
    public class DeleteLeaveTypeCommand:IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
    }
}
