using WebStudyServer.Base;
using WebStudyServer.Manager;
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
            var repoAccount = _authRepo.CreateAccount();
            var mgrAccount = new AccountManager(_authRepo, repoAccount);
            return mgrAccount;
        }
    }
}
