using CRMDev.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRMDev.API.Controllers
{
    [Route("api/opportunity")]
    public class OpportunityController : ControllerBase
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
        public IActionResult Post([FromBody] CreateOpportunityModel createOpportunityModel)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EditOpportunityModel editOpportunityModel)
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
