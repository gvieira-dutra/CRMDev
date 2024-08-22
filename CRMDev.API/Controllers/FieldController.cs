using CRMDev.Application.InputModels;
using CRMDev.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRMDev.API.Controllers
{
    [Route("field")]
    public class FieldController : ControllerBase
    {
        private readonly IFieldServices _services;

        public FieldController(IFieldServices services)
        {
            _services = services;
        }

        [HttpGet]
        public IActionResult GetAll(string query)
        {

            return Ok(_services.GetAll(query)) ;
        }

        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            return Ok(_services.GetOne(id)); 
        }

        [HttpPost]
        public IActionResult Post([FromBody] FieldInputModel newField)
        {
            return Ok(_services.Post(newField));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] FieldInputModel fieldModel)
        {
            return Ok(_services.Put(id, fieldModel));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _services.Delete(id);
            return NoContent();
        }

    }
}
