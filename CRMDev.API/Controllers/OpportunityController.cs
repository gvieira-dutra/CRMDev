using CRMDev.Application.Command.OpportunityCompleteCurrTask;
using CRMDev.Application.Command.OpportunitySetStatusClosed;
using CRMDev.Application.Command.OpportunitySetStatusLost;
using CRMDev.Application.Command.PostOpportunity;
using CRMDev.Application.Query.OpportunityGetAll;
using CRMDev.Application.Query.OpportunityGetOne;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CRMDev.API.Controllers
{
    [Route("api/opportunity")]
    public class OpportunityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OpportunityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(GetAllOpportunityCommand command)
        {
            var opportunities = await _mediator.Send(command);

            return opportunities == null ? NoContent() : Ok(opportunities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var command = new GetOneOpportunityCommand(id);
                var opportunity = await _mediator.Send(command);
                return opportunity == null ? NoContent() : Ok(opportunity);

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostOpportunityCommand command)
        {
            var opportunity = await _mediator.Send(command);

            return opportunity == null ? NoContent() : Ok(opportunity);
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PutOpportunityCommand command)
        {
            command.Id = id;
            var opportunity = await _mediator.Send(command);

            return opportunity == null ? NoContent() : Ok(opportunity);
        }

        [HttpPut("complete-current-task/{opportunityId}")]
        public async Task<IActionResult> CompleteCurrentTask(int opportunityId)
        {
            var command = new CompleteCurrentTaskCommand(opportunityId);
            var opportunity = await _mediator.Send(command);

            return opportunity == null ? NoContent() : Ok(opportunity);
        }

        [HttpPut("set-status-closed{id}")]
        public async Task<IActionResult> SetStatusClosed(int id)
        {
            var command = new SetStatusClosedCommand(id);
            var opportunity = await _mediator.Send(command);

            return opportunity == null ? NoContent() : Ok(opportunity);
        }

        [HttpPut("set-status-lost/{opportunityId}")]
        public async Task<IActionResult> SetStatusLost(int opportunityId, [FromBody] SetStatusLostCommand command)
        {
            command.Id = opportunityId;
            var opportunity = await _mediator.Send(command);

            return opportunity == null ? NoContent() : Ok(opportunity);
        }

    }
}
