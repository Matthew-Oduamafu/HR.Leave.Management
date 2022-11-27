using HR.Leave.Management.Application.DTOs.LeaveType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Leave.Management.Application.Features.LeaveTypes.Requests.Queries
{
    public class GetLeaveTypeDetailRequest:IRequest<LeaveTypeDto>
    {
        public int Id { get; set; }
    }
}
