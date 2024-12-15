using WebStudyServer.Repo;
using WebStudyServer.Model;

namespace WebStudyServer.Manager
{
    public class PlayerManager : UserManagerBase<PlayerModel>
    {
        public ulong Id => Model.Id;

        public PlayerManager(UserRepo userRepo, PlayerModel model) : base(userRepo, model)
        {
        }

        public void PreparePlayer()
        {
            // Player 상태 확인 및 초기 세팅


        }
    }
}
