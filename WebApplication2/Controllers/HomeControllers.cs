using Microsoft.AspNetCore.Mvc;

namespace NoteManagerAPI.Controllers
{
    [Route("/")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Witaj w NoteManagerAPI!");
        }
    }
}
