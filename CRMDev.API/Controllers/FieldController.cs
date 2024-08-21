using Microsoft.AspNetCore.Mvc;

namespace CRMDev.API.Controllers
{
    [Route("field")]
    public class FieldController : Controller
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            return Ok(); 
        }

        //[HttpPost]
        //public IActionResult Post([FromBody] )
    
    
    }
}
