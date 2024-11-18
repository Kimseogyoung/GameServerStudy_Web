using Microsoft.AspNetCore.Mvc;
using WebStudyServer.Filter;
using WebStudyServer.Service;

namespace WebStudyServer.Controllers
{
    [ApiController]
    [Route("auth")]
    [ServiceFilter(typeof(LogFilter))]
    public class AuthController : ControllerBase
    {
        public AuthController(AuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [HttpPost("sign-up")]
        public ActionResult SignUp(string deviceKey)
        {
            var result = _authService.SignUp(deviceKey);
            return Ok(result);
        }

        [HttpPost("sign-in")]
        public ActionResult<bool> SignIn(string channelId)
        {
            var result = _authService.SignIn(channelId);
            return Ok(result);
        }

        private readonly AuthService _authService;
        private readonly ILogger _logger;
    }
}