﻿using Proto;
using WebStudyServer.Base;
using WebStudyServer.Helper;
using WebStudyServer.Manager;
using WebStudyServer.Model.Auth;
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

        public SessionManager Touch(ulong accountId, string idfv)
        {
            var repoSession = _authRepo.GetSessionByAccountId(accountId);
            if (repoSession == null)
            {
                var newSession = new SessionModel
                {
                    Key = IdHelper.GenerateGuidKey(),
                    AccountId = accountId,
                    PublicIp = _authRepo.RpcContext.Ip,
                    ShardId = _authRepo.RpcContext.ShardId,
                    State = ESessionState.NONE,
                    Idfv = idfv,
                };

                repoSession = _authRepo.CreateSession(newSession);
            }
            var mgrSession = new SessionManager(_authRepo, repoSession);
            return mgrSession;
        }
    }
}
