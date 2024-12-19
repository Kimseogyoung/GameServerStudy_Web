using Microsoft.AspNetCore.Mvc;
using Protocol;
using Server.Service;
using WebStudyServer.Filter;
using WebStudyServer.Service;

namespace WebStudyServer.Controllers
{
    [ApiController]
    [Route("game")]
    [ServiceFilter(typeof(LogFilter))]
    [ServiceFilter(typeof(UserTransactionFilter))]
    public class GameController : ControllerBase
    {
        public GameController(GameService gameService, ILogger<GameController> logger)
        {
            _gameService = gameService;
            _logger = logger;
        }

        [HttpPost("enter")]
        public ActionResult<GameEnterResPacket> Enter(GameEnterReqPacket req)
        {
            var result = _gameService.Enter();

            return new GameEnterResPacket
            {
            };
        }

        [HttpPost("change-name")]
        public ActionResult<GameChangeNameResPacket> ChangeName(GameChangeNameReqPacket req)
        {
            var resultName = _gameService.ChangeNameFirst(req.PlayerName);
            return new GameChangeNameResPacket
            {
                PlayerName = resultName,
            };
        }

        private readonly GameService _gameService;
        private readonly ILogger _logger;
    }
}