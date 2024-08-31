using CRMDev.Application.Command.ContactDelete;
using CRMDev.Application.Command.ContactPost;
using CRMDev.Application.Command.ContactPut;
using CRMDev.Application.Query.ContactGetAll;
using CRMDev.Application.Query.ContactGetOne;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CRMDev.API.Controllers
{
    [Route("api/contacts")]
    public class ContactController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult GetAll(GetAllContactQuery command)
        {
            return Ok(_mediator.Send(command));
        }

        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            var command = new GetOneContactQuery();
            command.Id = id;

            var contact = _mediator.Send(command);

            return contact == null ? NotFound() : Ok(contact);
        }

        [HttpPost("new")]
        public IActionResult Post([FromBody] PostContactCommand command)
        {
            var contact = _mediator.Send(command);
            
            return contact == null ? NotFound() : Ok(contact);

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PutContactCommand command)
        {
            command.Id = id;
            var contact = _mediator.Send(command);

            return contact == null ? NotFound() : Ok(contact);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var command = new DeleteContactCommand(id);

            _mediator.Send(command);
            return NoContent();
        }
    }
}
