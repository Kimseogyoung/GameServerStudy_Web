using WebStudyServer.Base;
using WebStudyServer.Manager;
using WebStudyServer.Repo;

namespace WebStudyServer.Component
{
    public class ChannelComponent : AuthComponentBase
    {
        public ChannelComponent(AuthRepo authRepo) : base(authRepo)
        {
        }

        public bool TryGetChannel(string key, out ChannelManager mgrAccount)
        {
            mgrAccount = null;

            var repoChannel = _authRepo.GetChannel(key);
            if (repoChannel == null)
                return false;

            mgrAccount = new ChannelManager(_authRepo, repoChannel);
            return true;
        }

        public ChannelManager CreateChannel(ulong accountId)
        {
            var repoChannel = _authRepo.CreateChannel(new Model.Auth.ChannelModel { AccountId = accountId });
            var mgrAccount = new ChannelManager(_authRepo, repoChannel);
            return mgrAccount;
        }
    }
}
