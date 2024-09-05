using CRMDev.Application.Command.ContactDelete;
using CRMDev.Application.Command.ContactPost;
using CRMDev.Application.Command.ContactPut;
using CRMDev.Application.Query.ContactGetAll;
using CRMDev.Application.Query.ContactGetOne;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;

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
        public async Task<IActionResult> GetAll(GetAllContactQuery command)
        {
            var contacts = await _mediator.Send(command);
            return Ok( contacts == null ? NoContent() : contacts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var command = new GetOneContactQuery();
            command.Id = id;

            var contact = await _mediator.Send(command);

            return contact == null ? NoContent() : Ok(contact);
        }

        [HttpPost("new")]
        public async Task<IActionResult> Post([FromBody] PostContactCommand command)
        {
            var contact = await _mediator.Send(command);
            
            return contact == null ? NoContent() : Ok(contact);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PutContactCommand command)
        {
            command.Id = id;
            var contact = await _mediator.Send(command);

            return contact == null ? NoContent() : Ok(contact);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteContactCommand(id);

                await _mediator.Send(command);
                return NoContent();
        }
    }
}
