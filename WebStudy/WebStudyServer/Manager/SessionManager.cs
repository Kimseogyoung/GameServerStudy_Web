using WebStudyServer.Model.Auth;
using WebStudyServer.Repo;

namespace WebStudyServer.Manager
{
    public class SessionManager : AuthManagerBase<SessionModel>
    {
        public SessionManager(AuthRepo authRepo, SessionModel model) : base(authRepo, model)
        {
        }
        
        public void Start()
        {
            // 세션 시작
            Model.State = 1;
            Model.ExpireTimestamp = 100000000; // TODO:
            _authRepo.UpdateSession(Model);
        }

    }
}
