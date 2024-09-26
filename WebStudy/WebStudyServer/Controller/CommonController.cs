using Microsoft.AspNetCore.Mvc;

namespace WebStudy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommonController : ControllerBase
    {

        private readonly ILogger<CommonController> _logger;

        public CommonController(ILogger<CommonController> logger)
        {
            _logger = logger;
        }

        [HttpGet("health-check")]
        public ActionResult<bool> HealthCheck()
        {
            return Ok("ok");
        }

        [HttpGet("hello-world")]
        public ActionResult<bool> HelloWorld()
        {
            return Ok("hello-world");
        }
    }
}