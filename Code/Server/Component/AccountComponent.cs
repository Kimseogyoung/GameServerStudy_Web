using WebStudyServer.Base;
using WebStudyServer.Manager;
using WebStudyServer.Model;
using WebStudyServer.Repo;

namespace WebStudyServer.Component
{
    public class AccountComponent : AuthComponentBase
    {
        public AccountComponent(AuthRepo authRepo) : base(authRepo)
        {
        }

        public bool TryGetAccount(ulong accountId, out AccountManager mgrAccount)
        {
            mgrAccount = null;

            var repoAccount = _authRepo.GetAccount(accountId);
            if (repoAccount == null)
                return false;

            mgrAccount = new AccountManager(_authRepo, repoAccount);
            return true;
        }

        public AccountManager CreateAccount()
        {
            var newAccount = new AccountModel
            {
                ShardId = 0, // TODO: ShardId
                State = Proto.EAccountState.ACTIVE,
                AdditionalPlayerCnt = 0,
                ClientSecret = ""
            };

            var repoAccount = _authRepo.CreateAccount(newAccount);
            var mgrAccount = new AccountManager(_authRepo, repoAccount);

            _authRepo.RpcContext.SetAccountId(mgrAccount.Id);
            _authRepo.RpcContext.SetShardId(mgrAccount.Model.ShardId);
            return mgrAccount;
        }
    }
}
