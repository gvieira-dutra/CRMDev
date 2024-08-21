using Microsoft.AspNetCore.Mvc;

namespace CRMDev.API.Controllers
{
    [Route("note")]
    public class NoteController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
