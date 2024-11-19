﻿using WebStudyServer.Model.Auth;
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
            var sessionKey = IdHelper.GenerateGuidKey();
            Model.Key = sessionKey;
            Model.State = ESessionState.ACTIVE;
            Model.ExpireTimestamp = TimeHelper.DateTimeToTimeStamp(expireTime);
            Model.PublicIp = _authRepo.RpcContext.Ip;
            Model.ClientSecret = "";
            Model.DeviceKey = _authRepo.RpcContext.DeviceKey;
            Model.EncryptIV = "";
            Model.EncryptSecret = "";
            _authRepo.UpdateSession(Model);

            _authRepo.RpcContext.SetSessionKey(sessionKey);
        }

    }
}
