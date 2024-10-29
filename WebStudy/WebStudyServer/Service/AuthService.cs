using WebStudyServer.Base;
using WebStudyServer;
using WebStudyServer.Repo;

namespace WebStudyServer.Service
{
    public class AuthService : ServiceBase
    {
        public AuthService(AuthComponent authComp, RpcContext rpcContext, ILogger<AuthService> logger) :base(rpcContext, logger) 
        {
            _authComp = authComp;
        }

        public void SignUp(string idfv)
        {
            // idfv 찾기. 
            if (_authComp.Device.TryGetDevice(idfv, out var mgrDevice))
            {
                // 일치하는 idfv가 이미 있다면 해당 계정 정보 리턴

                // 계정 찾기
                if (_authComp.Account.TryGetAccount(mgrDevice.Model.AccountId, out var originMgrAccount))
                {
                    var originMgrSession = _authComp.Session.Touch(originMgrAccount.Id);
                    originMgrSession.Start();
                    return;
                }
            }
            
            // ~idfv가 없다면

            // Account 생성
            var mgrAccount = _authComp.Account.CreateAccount();
            // Session 생성
            var mgrSession = _authComp.Session.Touch(mgrAccount.Id);
            // Device 정보 생성
            mgrDevice = _authComp.Device.CreateDevice(idfv);
            // 채널 생성
            var mgrChannel = _authComp.Channel.CreateChannel(mgrAccount.Id);
            
            // 세션 갱신 및 리턴
            mgrSession.Start();
        }

        public void SignIn()
        {
            // 채널 찾기

            //

            // 채널 -> Account 찾기
            
            // 세션 갱신 및 리턴
        }

        private readonly AuthComponent _authComp;
    }
}
