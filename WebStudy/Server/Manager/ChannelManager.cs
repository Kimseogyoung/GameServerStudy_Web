using WebStudyServer.Model.Auth;
using WebStudyServer.Repo;

namespace WebStudyServer.Manager
{
    public class ChannelManager : AuthManagerBase<ChannelModel>
    {
        public ChannelManager(AuthRepo authRepo, ChannelModel model) : base(authRepo, model)
        {
        }


    }
}
