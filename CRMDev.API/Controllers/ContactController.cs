using CRMDev.Application.InputModels;
using CRMDev.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRMDev.API.Controllers
{
    [Route("api/contacts")]
    public class ContactController : ControllerBase
    {
        private readonly IContactServices _services;

        public ContactController(IContactServices services)
        {
            _services = services;
        }

        [HttpGet]
        public IActionResult GetAll(string query)
        {
            var contacts = _services.GetAll(query);

            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            return Ok(_services.GetOne(id));
        }

        [HttpPost("new")]
        public IActionResult Post([FromBody] ContactCreateInputModel contact)
        {
            return Ok(_services.Post(contact));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ContactEditInputModel newInfo)
        {
            return Ok(_services.Put(id, newInfo));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _services.Delete(id);
            return NoContent();
        }
    }
}
