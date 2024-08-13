using CRMDev.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRMDev.API.Controllers
{
    [Route("api/contacts")]
    public class ContactController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll(string query)
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateContactModel contact)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EditContactModel newInfo)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}
