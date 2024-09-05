using CRMDev.Application.Command.FieldDelete;
using CRMDev.Application.Command.FieldPost;
using CRMDev.Application.Command.FieldPut;
using CRMDev.Application.Query.FieldGetAll;
using CRMDev.Application.Query.FieldGetOne;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CRMDev.API.Controllers
{
    [Route("field")]
    public class FieldController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FieldController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(GetAllFieldCommand command)
        {
            var fields = await _mediator.Send(command);

            return fields == null ? NoContent() : Ok(fields);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var command = new GetOneFieldCommand(id);

            var field = await _mediator.Send(command);

            return field == null ? NoContent() : Ok(field);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostFieldCommand command)
        {
            var field = await _mediator.Send(command);

            return field == null ? NoContent() : Ok(field);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PutFieldCommand command)
        {
            command.Id = id;
            var field = await _mediator.Send(command);

            return field == null ? NoContent() : Ok(field);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new FieldDeleteCommand(id);

            try
            {
                await _mediator.Send(command);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest("Cannot delete field, there are professionals that are part of this industry.");
            }
        }

    }
}
