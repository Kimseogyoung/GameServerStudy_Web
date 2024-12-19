using WebStudyServer.Model;
using WebStudyServer.Repo;

namespace WebStudyServer.Base
{
    public class UserComponentBase 
    {
        protected UserRepo _userRepo;

        public UserComponentBase(UserRepo userRepo)
        {
            _userRepo = userRepo;
        }
    }
}
