using WebStudyServer.Service;
using WebStudyServer;

namespace Server.Service
{
    public class GameService : ServiceBase
    {
        public GameService(UserComponent userComp, RpcContext rpcContext, ILogger<GameService> logger) : base(rpcContext, logger)
        {
            _userComp = userComp;
        }

        private readonly UserComponent _userComp;
    }
}
