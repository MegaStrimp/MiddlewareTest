using Microsoft.AspNetCore.Mvc;

namespace MiddlewareTest.Controllers
{
    [ApiController]
    [Route("")]
    public class TestController : ControllerBase
    {
        [HttpGet("hello")]
        public async Task<IActionResult> Hello()
        {
            return Ok("Hello");
        }

        [HttpGet("health-check")]
        public async Task<IActionResult> HealthCheck()
        {
            return Ok("I am alive!");
        }
    }
}
