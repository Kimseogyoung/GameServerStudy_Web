using WebStudyServer.Component;
using WebStudyServer.Manager;
using WebStudyServer.Repo;

namespace WebStudyServer.Service
{
    public class AuthComponent// 이름 고민중.
    {
        public AccountComponent Account => _accountComponent;
        public SessionComponent Session => _sessionComponent;
        public DeviceComponent Device => _deviceComponent;
        public ChannelComponent Channel => _channelComponent;

        public AuthComponent(AuthRepo authRepo, AccountComponent accountComponent, SessionComponent sessionComponent, DeviceComponent deviceComponent, ChannelComponent channelComponent)
        {
            _authRepo = authRepo;
        
            // TODO: Lazy형태로 ㄱㄱ
            _accountComponent = accountComponent;
            _sessionComponent = sessionComponent;
            _deviceComponent = deviceComponent;
            _channelComponent = channelComponent;
        }

        private readonly AuthRepo _authRepo;
        private readonly AccountComponent _accountComponent;
        private readonly SessionComponent _sessionComponent;
        private readonly DeviceComponent _deviceComponent;
        private readonly ChannelComponent _channelComponent;
    }
}
