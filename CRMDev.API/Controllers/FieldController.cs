using CRMDev.Application.Command.FieldDelete;
using CRMDev.Application.Command.FieldPost;
using CRMDev.Application.Command.FieldPut;
using CRMDev.Application.InputModels;
using CRMDev.Application.Query.FieldGetAll;
using CRMDev.Application.Query.FieldGetOne;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
        public IActionResult GetAll(GetAllFieldCommand command)
        {
            var fields = _mediator.Send(command);

            return fields == null ? NotFound() : Ok(fields);
        }

        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            var command = new GetOneFieldCommand(id);

            var field = _mediator.Send(command);

            return field == null ? NotFound() : Ok(field);
        }

        [HttpPost]
        public IActionResult Post([FromBody] PostFieldCommand command)
        {
            var field = _mediator.Send(command);

            return field == null ? NoContent() : Ok(field);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PutFieldCommand command)
        {
            var field = _mediator.Send(command);

            return field == null ? NoContent() : Ok(field);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var command = new FieldDeleteCommand(id);
            
            _mediator.Send(command);
            return NoContent();
        }

    }
}
