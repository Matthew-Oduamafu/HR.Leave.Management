using HR.Leave.Management.Application.DTOs.LeaveAllocation;
using HR.Leave.Management.Application.Features.LeaveAllocations.Requests.Commands;
using HR.Leave.Management.Application.Features.LeaveAllocations.Requests.Queries;
using HR.Leave.Management.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HR.Leave.Management.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[Action]")]
    public class LeaveAllocationController : Controller
    {
        private readonly IMediator _mediator;

        public LeaveAllocationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: LeaveAllocationController
        [HttpGet]
        public async Task<ActionResult<List<LeaveAllocationDto>>> GetAll()
        {
            var leaveAllocations = await _mediator.Send(new GetLeaveAllocationListRequest());
            return Ok(leaveAllocations);
        }

        // GET: LeaveAllocationController/Get/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveAllocationDto>> Get(int id)
        {
            var leaveAllocation = await _mediator.Send(new GetLeaveAllocationDetailRequest { Id = id });
            return Ok(leaveAllocation);
        }

        // POST: LeaveAllocationController/Create
        [HttpPost]
        public async Task<ActionResult<CreateOrUpdateCommandResponse>> Create([FromBody] CreateLeaveAllocationDto createLeaveAllocationDto)
        {
            var response = await _mediator.Send(new CreateLeaveAllocationCommand { CreateLeaveAllocationDto = createLeaveAllocationDto });

            return Ok(response);
        }

        // PUT: LeaveAllocationController/Update/5
        [HttpPut("{id}")]
        public async Task<ActionResult<CreateOrUpdateCommandResponse>> Update(int id, [FromBody] UpdateLeaveAllocationDto leaveAllocationDto)
        {
            var response = await _mediator.Send(new UpdateLeaveAllocationCommand { UpdateLeaveAllocationDto = leaveAllocationDto });
            return Ok(response);
        }

        // GET: LeaveAllocationController/Delete/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteLeaveAllocationCommand { Id = id });
            return Ok(response);
        }
    }
}