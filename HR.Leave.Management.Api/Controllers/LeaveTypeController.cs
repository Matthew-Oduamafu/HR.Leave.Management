using HR.Leave.Management.Application.DTOs.LeaveType;
using HR.Leave.Management.Application.Features.LeaveTypes.Requests.Commands;
using HR.Leave.Management.Application.Features.LeaveTypes.Requests.Queries;
using HR.Leave.Management.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HR.Leave.Management.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[Action]")]
    public class LeaveTypeController : Controller
    {
        private readonly IMediator _mediator;

        public LeaveTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: LeaveTypeController
        [HttpGet]
        public async Task<ActionResult<List<LeaveTypeDto>>> GetAll()
        {
            var leaveTypes = await _mediator.Send(new GetLeaveTypeListRequest());
            return Ok(leaveTypes);
        }

        // GET: LeaveTypeController/Get/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveTypeDto>> Get(int id)
        {
            var leaveType = await _mediator.Send(new GetLeaveTypeDetailRequest { Id = id });
            return Ok(leaveType);
        }

        // POST: LeaveTypeController/Create
        [HttpPost]
        public async Task<ActionResult<CreateOrUpdateCommandResponse>> Create([FromBody] CreateLeaveTypeDto createLeaveTypeDto)
        {
            var response = await _mediator.Send(new CreateLeaveTypeCommand { CreateLeaveTypeDto = createLeaveTypeDto });

            return Ok(response);
        }

        // PUT: LeaveTypeController/Update/5
        [HttpPut("{id}")]
        public async Task<ActionResult<CreateOrUpdateCommandResponse>> Update(int id, [FromBody] LeaveTypeDto leaveTypeDto)
        {
            var response = await _mediator.Send(new UpdateLeaveTypeCommand { LeaveTypeDto = leaveTypeDto });
            return Ok(response);
        }

        // GET: LeaveTypeController/Delete/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteLeaveTypeCommand { Id = id });
            return Ok(response);
        }
    }
}