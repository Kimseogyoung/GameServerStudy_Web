using Dapper;
using System.Numerics;
using System.Threading.Channels;
using WebStudyServer.Base;
using WebStudyServer.Extension;
using WebStudyServer.GAME;
using WebStudyServer.Model.Auth;

namespace WebStudyServer.Repo
{
    public class AuthRepo : RepoBase
    {
        public RpcContext RpcContext {  get; private set; }
        protected override List<string> _dbConnStrList => APP.Cfg.AuthDbConnectionStrList;
        public AuthRepo(RpcContext rpcContext)
        {
            RpcContext = rpcContext;
        }

        #region
        public AccountModel CreateAccount(AccountModel newAccount)
        {
            // 데이터베이스에 삽입
            _executor.Excute((sqlConnection) =>
            {
                newAccount = sqlConnection.Insert<AccountModel>(newAccount);
            });

            return newAccount; // 새로 생성된 계정 모델 반환
        }

        public AccountModel GetAccount(ulong id)
        {
            AccountModel mdlAccount = null;

            _executor.Excute((sqlConnection) =>
            {
                mdlAccount = sqlConnection.SelectByPk<AccountModel>(new { Id = id });
            });

            return mdlAccount;
        }

        public void UpdateAccount(AccountModel mdlAccount)
        {
            _executor.Excute((sqlConnection) =>
            {
                sqlConnection.Update(mdlAccount);
            });
        }
        #endregion

        #region
        public DeviceModel CreateDevice(DeviceModel inChannel)
        {
            DeviceModel newDevice = null;
            // 데이터베이스에 삽입
            _executor.Excute((sqlConnection) =>
            {
                newDevice = sqlConnection.Insert(inChannel);
            });

            return newDevice; // 새로 생성된 계정 모델 반환
        }

        public DeviceModel GetDevice(string deviceKey)
        {
            DeviceModel mdlDevice = null;

            _executor.Excute((sqlConnection) =>
            {
                mdlDevice = sqlConnection.SelectByPk<DeviceModel>(new { Key = deviceKey });
            });

            return mdlDevice;
        }

        public void UpdateDevice(DeviceModel mdlDevice)
        {
            _executor.Excute((sqlConnection) =>
            {
                sqlConnection.Update(mdlDevice);
            });
        }
        #endregion


        #region
        public ChannelModel CreateChannel(ChannelModel inChannel)
        {
            ChannelModel newChannel = null;
            // 데이터베이스에 삽입
            _executor.Excute((sqlConnection) =>
            { 
                newChannel = sqlConnection.Insert(inChannel);
            });

            return newChannel; // 새로 생성된 계정 모델 반환
        }

        public List<ChannelModel> GetChannelList(ulong accountId)
        {
           var mdlChannelList = new List<ChannelModel>();

            _executor.Excute((sqlConnection) =>
            {
                mdlChannelList = sqlConnection.SelectListByConditions<ChannelModel>(new { AccountId = accountId }).ToList();
            });

            return mdlChannelList;
        }


        public ChannelModel GetChannel(string key)
        {
            ChannelModel mdlChannel = null;

            _executor.Excute((sqlConnection) =>
            {
                mdlChannel = sqlConnection.SelectByPk<ChannelModel>(new { Key = key });
            });

            return mdlChannel;
        }

        public void UpdateChannel(ChannelModel mdlChannel)
        {
            _executor.Excute((sqlConnection) =>
            {
                sqlConnection.Update(mdlChannel);
            });
        }
        #endregion


        #region
        public SessionModel CreateSession(SessionModel inSession)
        {
            SessionModel newSession = null;
            // 데이터베이스에 삽입
            _executor.Excute((sqlConnection) =>
            {
                newSession = sqlConnection.Insert(inSession);
            });

            return newSession; // 새로 생성된 계정 모델 반환
        }

        public SessionModel GetSession(string key)
        {
            SessionModel mdlSession = null;

            _executor.Excute((sqlConnection) =>
            {
                mdlSession = sqlConnection.SelectByPk<SessionModel>(new { Key = key});
            });

            return mdlSession;
        }

        public SessionModel GetSessionByAccountId(ulong accountId)
        {
            SessionModel mdlSession = null;

            _executor.Excute((sqlConnection) =>
            {
                mdlSession = sqlConnection.SelectByConditions<SessionModel>(new { AccountId = accountId});
            });

            return mdlSession;
        }

        public void UpdateSession(SessionModel mdlSession)
        {
            _executor.Excute((sqlConnection) =>
            {
                sqlConnection.Update(mdlSession);
            });
        }
        #endregion


    }
}
