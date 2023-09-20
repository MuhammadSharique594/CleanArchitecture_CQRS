using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Login.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class PingController : ControllerBase
    {
        [HttpGet("Ping")]
        public IActionResult Ping()
        {
            return Ok("Ping");
        }
    }
}
