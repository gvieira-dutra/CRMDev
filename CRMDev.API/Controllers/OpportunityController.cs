using CRMDev.Application.InputModels;
using CRMDev.Application.Services.Interfaces;
using CRMDev.Core.Enums;
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
        public IActionResult Post([FromBody] CreateOpportunityInputModel createOpportunityModel)
        {
            return Ok(_services.Post(createOpportunityModel));
        }

        [HttpPut("edit/{id}")]
        public IActionResult Put(int id, [FromBody] EditOpportunityInputModel opportunityNewInfo)
        {
            return Ok(_services.Put(id, opportunityNewInfo));
        }

        [HttpPut("complete-current-task/{opportunityId}")]
        public IActionResult CompleteCurrentTask(int opportunityId)
        {
            var opportunity = _services.CompleteCurrentTask(opportunityId);
            return Ok(opportunity);
        }

        [HttpPut("set-status-closed{id}")]
        public IActionResult SetStatusClosed(int id)
        {
            return Ok(_services.SetStatusClosed(id));
        }

        [HttpPut("set-status-lost/{opportunityId}")]
        public IActionResult SetStatusLost(int opportunityId, [FromBody] ReasonForLostDeal reason)
        {
            return Ok(_services.SetStatusLost(opportunityId, reason));
        }

    }
}
