using CRMDev.API.Models;
using CRMDev.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRMDev.API.Controllers
{
    [Route("api/opportunity")]
    public class OpportunityController : ControllerBase
    {
        private readonly IOpportunityServices _services;
        public OpportunityController(IOpportunityServices services)
        {
            _services = services;
        }

        [HttpGet]
        public IActionResult GetAll(string query)
        {
            var opportunities = _services.GetAll(query);
            return Ok(opportunities);
        }

        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            var opportunity = _services.GetOne(id);
            return Ok(opportunity);
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

        [HttpPut("complete-task-{id}")]
        public IActionResult CompleteTask(int id)
        {
            var opportunity = _services.CompleteTask(id);
            return Ok(opportunity);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }

    }
}
