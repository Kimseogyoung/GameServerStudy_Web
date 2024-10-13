using WebStudyServer.Base;
using WebStudyServer;
using WebStudyServer.Repo;

namespace WebStudyServer.Service
{
    public class AuthService : ServiceBase
    {
        public AuthService(AuthRepo authRepo, RpcContext rpcContext, ILogger<AuthService> logger) :base(rpcContext, logger) 
        {
            _authRepo = authRepo;
        }

        public void SignUp()
        {

        }

        public void SignIn()
        {

        }
        
        private readonly AuthRepo _authRepo;
    }
}
