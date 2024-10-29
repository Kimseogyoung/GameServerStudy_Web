using WebStudyServer.Base;
using WebStudyServer.Manager;
using WebStudyServer.Repo;

namespace WebStudyServer.Component
{
    public class SessionComponent : AuthComponentBase
    {
        public SessionComponent(AuthRepo authRepo) : base(authRepo)
        {
        }

        public bool TryGet(ulong accountId, out SessionManager mgrSession)
        {
            mgrSession = null;

            var repoSession = _authRepo.GetSessionByAccountId(accountId);
            if (repoSession == null)
                return false;

            mgrSession = new SessionManager(_authRepo, repoSession);
            return true;
        }

        public SessionManager Touch(ulong accountId)
        {
            var repoSession = _authRepo.GetSessionByAccountId(accountId);
            if (repoSession == null)
                repoSession = _authRepo.CreateSession( new Model.Auth.SessionModel { AccountId = accountId });

            var mgrSession = new SessionManager(_authRepo, repoSession);
            return mgrSession;
        }
    }
}
