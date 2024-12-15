using WebStudyServer.Component;
using WebStudyServer.Repo;

namespace WebStudyServer.Service
{
    public class UserComponent// 이름 고민중.
    {

        public UserComponent(UserRepo userRepo, PlayerComponent playerComponent)
        {
            _userRepo = userRepo;

            // TODO: Lazy형태로 ㄱㄱ
            _playerComponent = playerComponent;
        }

        private readonly UserRepo _userRepo;
        private readonly PlayerComponent _playerComponent;
    }
}
