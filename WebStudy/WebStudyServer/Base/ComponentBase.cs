using WebStudyServer.Model;
using WebStudyServer.Repo;

namespace WebStudyServer.Base
{
    public class AuthComponentBase 
    {
        protected AuthRepo _authRepo;

        public AuthComponentBase(AuthRepo authRepo)
        {
            _authRepo = authRepo;
        }
    }
}
