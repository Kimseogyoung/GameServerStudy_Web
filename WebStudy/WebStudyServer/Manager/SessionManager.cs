using WebStudyServer.Model.Auth;
using WebStudyServer.Repo;
using Proto;
using WebStudyServer.Helper;
using WebStudyServer.GAME;
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
            var expireTime = _authRepo.RpcContext.ServerTime + APP.Cfg.SessionExpireSpan;
            Model.State = ESessionState.ACTIVE;
            Model.ExpireTimestamp = TimeHelper.DateTimeToTimeStamp(expireTime);
            _authRepo.UpdateSession(Model);
        }

    }
}
