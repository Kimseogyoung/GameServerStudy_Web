using Microsoft.AspNetCore.Mvc;
using WebStudyServer.Filter;

namespace WebStudyServer.Controllers
{
    [ApiController]
    [Route("auth")]
    [ServiceFilter(typeof(LogFilter))]
    public class AuthController : ControllerBase
    {
        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;
        }

        [HttpPost("sign-up")]
        public ActionResult<bool> SignUp()
        {
            return Ok("sign-up");
        }

        [HttpPost("sign-in")]
        public ActionResult<bool> SignIn()
        {
            return Ok("sign-in");
        }

        private readonly ILogger _logger;
    }
}