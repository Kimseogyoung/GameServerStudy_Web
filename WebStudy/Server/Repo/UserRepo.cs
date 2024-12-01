using WebStudyServer.Base;
using WebStudyServer.GAME;
using WebStudyServer.Repo.Database;

namespace WebStudyServer.Repo
{
    public class UserRepo : RepoBase
    {
        public RpcContext RpcContext { get; private set; }
        protected override List<string> _dbConnStrList => APP.Cfg.UserDbConnectionStrList;
        public UserRepo(RpcContext rpcContext)
        {
            RpcContext = rpcContext;
        }
    }
}
