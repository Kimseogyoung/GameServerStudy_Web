using Microsoft.AspNetCore.Mvc;
using Protocol;
using WebStudyServer.Filter;
using WebStudyServer.Service;

namespace WebStudyServer.Controllers
{
    [ApiController]
    [Route("game")]
    [ServiceFilter(typeof(LogFilter))]
    [ServiceFilter(typeof(AuthTransactionFilter))]
    public class GameController : ControllerBase
    {
        public GameController(AuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [HttpPost("sign-up")]
        public ActionResult<AuthSignUpResPacket> SignUp(AuthSignUpReqPacket req)
        {
            var result = _authService.SignUp(req.DeviceKey);

            return new AuthSignUpResPacket
            {
                SessionKey = result.SessionKey
            };
        }

        [HttpPost("sign-in")]
        public ActionResult<AuthSignInResPacket> SignIn(AuthSignInReqPacket req)
        {
            var result = _authService.SignIn(req.ChannelId);
            return new AuthSignInResPacket
            {
                SessionKey = result.SessionKey
            };
        }

        private readonly AuthService _authService;
        private readonly ILogger _logger;
    }
}