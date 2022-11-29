using HR.Leave.Management.Application.DTOs.LeaveRequest;
using HR.Leave.Management.Application.Features.LeaveRequests.Requests.Commands;
using HR.Leave.Management.Application.Features.LeaveRequests.Requests.Queries;
using HR.Leave.Management.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HR.Leave.Management.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[Action]")]
    public class LeaveRequestController : Controller
    {
        private readonly IMediator _mediator;

        public LeaveRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: LeaveRequestController
        [HttpGet]
        public async Task<ActionResult<List<LeaveRequestListDto>>> GetAll()
        {
            var leaveRequests = await _mediator.Send(new GetLeaveRequestListRequest());
            return Ok(leaveRequests);
        }

        // GET: LeaveRequestController/Get/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRequestListDto>> Get(int id)
        {
            var leaveRequest = await _mediator.Send(new GetLeaveRequestDetailRequest { Id = id });
            return Ok(leaveRequest);
        }

        // POST: LeaveRequestController/Create
        [HttpPost]
        public async Task<ActionResult<CreateOrUpdateCommandResponse>> Create([FromBody] CreateLeaveRequestDto createLeaveRequestDto)
        {
            var response = await _mediator.Send(new CreateLeaveRequestCommand { CreateLeaveRequestDto = createLeaveRequestDto });

            return Ok(response);
        }

        // PUT: LeaveRequestController/Update/5
        [HttpPut("{id}")]
        public async Task<ActionResult<CreateOrUpdateCommandResponse>> Update(int id, [FromBody] UpdateLeaveRequestDto leaveRequestDto)
        {
            var response = await _mediator.Send(new UpdateLeaveRequestCommand { Id = id, UpdateLeaveRequestDto = leaveRequestDto });
            return Ok(response);
        }

        // PUT: LeaveRequestController/ChangeApprovalStatus/5
        [HttpPut("{id}")]
        public async Task<ActionResult<CreateOrUpdateCommandResponse>> ChangeApprovalStatus(int id, [FromBody] ChangeLeaveRequestApprovalDto leaveRequestDto)
        {
            var response = await _mediator.Send(new UpdateLeaveRequestCommand { Id = id, ChangeLeaveRequestApprovalDto = leaveRequestDto });
            return Ok(response);
        }

        // GET: LeaveRequestController/Delete/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteLeaveRequestCommand { Id = id });
            return Ok(response);
        }
    }
}