using Dapper;
using System.Numerics;
using System.Threading.Channels;
using WebStudyServer.Base;
using WebStudyServer.Model.Auth;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebStudyServer.Repo
{
    public class AuthRepo : RepoBase
    {
        protected override List<string> _dbConnStrList => CONFIG.AuthDbConnectionStrList;

        #region
        public AccountModel CreateAccount()
        {
            var newAccount = new AccountModel
            {
                ShardId = 0,
                State = 1,
                AdditionalPlayerCount = 0,
                ClientSecret = "",
                Flag = 0,
            };

            // 데이터베이스에 삽입
            _executor.Excute((sqlConnection) =>
            {
                // INSERT 쿼리 후 삽입된 전체 Account 데이터를 가져오는 쿼리
                const string insertSql = "INSERT INTO Account (ShardId, State, AdditionalPlayerCount, ClientSecret, Flag, Name, Level) " +
                                          "VALUES (@ShardId, @State, @AdditionalPlayerCount, @ClientSecret, @Flag, @Name, @Level); " +
                                          "SELECT * FROM Account WHERE Id = CAST(SCOPE_IDENTITY() AS int);";

                // Dapper의 QuerySingleOrDefault 메서드를 사용하여 결과를 AccountModel로 변환
                newAccount = sqlConnection.QuerySingleOrDefault<AccountModel>(insertSql, newAccount);
            });

            return newAccount; // 새로 생성된 계정 모델 반환
        }

        public AccountModel GetAccount(ulong id)
        {
            AccountModel mdlAccount = null;

            _executor.Excute((sqlConnection) =>
            {
                const string selectSql = "SELECT * FROM Account WHERE Id = @Id;";
                mdlAccount = sqlConnection.QuerySingleOrDefault<AccountModel>(selectSql, new { Id = id });
            });

            return mdlAccount;
        }

        public void UpdateAccount(AccountModel mdlAccount)
        {

            // SQL 쿼리를 사용하여 Account 정보를 업데이트합니다.
            const string updateSql = @"
                    UPDATE Account
                    SET ShardId = @ShardId,
                        State = @State,
                        AdditionalPlayerCount = @AdditionalPlayerCount,
                        ClientSecret = @ClientSecret,
                        Flag = @Flag,
                        Name = @Name,
                        Level = @Level
                    WHERE Id = @Id;";

            _executor.Excute((sqlConnection) =>
            {
                sqlConnection.Execute(updateSql, mdlAccount);
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
                // INSERT 쿼리 후 삽입된 전체 Account 데이터를 가져오는 쿼리
                const string insertSql = "INSERT INTO Device (ShardId, State, AdditionalPlayerCount, ClientSecret, Flag, Name, Level) " +
                                          "VALUES (@ShardId, @State, @AdditionalPlayerCount, @ClientSecret, @Flag, @Name, @Level); " +
                                          "SELECT * FROM Account WHERE Id = CAST(SCOPE_IDENTITY() AS int);";

                // Dapper의 QuerySingleOrDefault 메서드를 사용하여 결과를 AccountModel로 변환
                newDevice = sqlConnection.QuerySingleOrDefault<DeviceModel>(insertSql, inChannel);
            });

            return newDevice; // 새로 생성된 계정 모델 반환
        }

        public DeviceModel GetDevice(string idfv)
        {
            DeviceModel mdlDevice = null;

            _executor.Excute((sqlConnection) =>
            {
                const string selectSql = "SELECT * FROM Account WHERE Id = @Id;";
                mdlDevice = sqlConnection.QuerySingleOrDefault<DeviceModel>(selectSql, new { Idfv = idfv });
            });

            return mdlDevice;
        }

        public void UpdateDevice(DeviceModel mdlDevice)
        {

            // SQL 쿼리를 사용하여 Account 정보를 업데이트합니다.
            const string updateSql = @"
                    UPDATE Account
                    SET ShardId = @ShardId,
                        State = @State,
                        AdditionalPlayerCount = @AdditionalPlayerCount,
                        ClientSecret = @ClientSecret,
                        Flag = @Flag,
                        Name = @Name,
                        Level = @Level
                    WHERE Id = @Id;";

            _executor.Excute((sqlConnection) =>
            {
                sqlConnection.Execute(updateSql, mdlDevice);
            });
        }
        #endregion


        #region
        public ChannelModel CreateChannel(ChannelModel inChannel)
        {
            ChannelModel newChannel = null;
            // 데이터베이스에 삽입
            _executor.Excute((Action<System.Data.IDbConnection>)((sqlConnection) =>
            {
                // INSERT 쿼리 후 삽입된 전체 Account 데이터를 가져오는 쿼리
                const string insertSql = "INSERT INTO Device (ShardId, State, AdditionalPlayerCount, ClientSecret, Flag, Name, Level) " +
                                          "VALUES (@ShardId, @State, @AdditionalPlayerCount, @ClientSecret, @Flag, @Name, @Level); " +
                                          "SELECT * FROM Account WHERE Id = CAST(SCOPE_IDENTITY() AS int);";

                // Dapper의 QuerySingleOrDefault 메서드를 사용하여 결과를 AccountModel로 변환
                newChannel = sqlConnection.QuerySingleOrDefault<ChannelModel>(insertSql, (object)inChannel);
            }));

            return newChannel; // 새로 생성된 계정 모델 반환
        }

        public ChannelModel GetChannel(string key)
        {
            ChannelModel mdlChannel = null;

            _executor.Excute((sqlConnection) =>
            {
                const string selectSql = "SELECT * FROM Account WHERE Id = @Id;";
                mdlChannel = sqlConnection.QuerySingleOrDefault<ChannelModel>(selectSql, new { Key = key });
            });

            return mdlChannel;
        }

        public void UpdateChannel(ChannelModel mdlChannel)
        {

            // SQL 쿼리를 사용하여 Account 정보를 업데이트합니다.
            const string updateSql = @"
                    UPDATE Account
                    SET ShardId = @ShardId,
                        State = @State,
                        AdditionalPlayerCount = @AdditionalPlayerCount,
                        ClientSecret = @ClientSecret,
                        Flag = @Flag,
                        Name = @Name,
                        Level = @Level
                    WHERE Id = @Id;";

            _executor.Excute((sqlConnection) =>
            {
                sqlConnection.Execute(updateSql, mdlChannel);
            });
        }
        #endregion


        #region
        public SessionModel CreateSession(SessionModel inSession)
        {
            SessionModel newSession = null;
            // 데이터베이스에 삽입
            _executor.Excute((Action<System.Data.IDbConnection>)((sqlConnection) =>
            {
                // INSERT 쿼리 후 삽입된 전체 Account 데이터를 가져오는 쿼리
                const string insertSql = "INSERT INTO Device (ShardId, State, AdditionalPlayerCount, ClientSecret, Flag, Name, Level) " +
                                          "VALUES (@ShardId, @State, @AdditionalPlayerCount, @ClientSecret, @Flag, @Name, @Level); " +
                                          "SELECT * FROM Account WHERE Id = CAST(SCOPE_IDENTITY() AS int);";

                // Dapper의 QuerySingleOrDefault 메서드를 사용하여 결과를 AccountModel로 변환
                newSession = sqlConnection.QuerySingleOrDefault<SessionModel>(insertSql, (object)inSession);
            }));

            return newSession; // 새로 생성된 계정 모델 반환
        }

        public SessionModel GetSession(string key)
        {
            SessionModel mdlSession = null;

            _executor.Excute((sqlConnection) =>
            {
                const string selectSql = "SELECT * FROM Account WHERE Id = @Id;";
                mdlSession = sqlConnection.QuerySingleOrDefault<SessionModel>(selectSql, new { Key = key});
            });

            return mdlSession;
        }

        public SessionModel GetSessionByAccountId(ulong accountId)
        {
            SessionModel mdlSession = null;

            _executor.Excute((sqlConnection) =>
            {
                const string selectSql = "SELECT * FROM Account WHERE Id = @Id;";
                mdlSession = sqlConnection.QuerySingleOrDefault<SessionModel>(selectSql, new { AccountId = accountId});
            });

            return mdlSession;
        }

        public void UpdateSession(SessionModel mdlSession)
        {

            // SQL 쿼리를 사용하여 Account 정보를 업데이트합니다.
            const string updateSql = @"
                    UPDATE Account
                    SET ShardId = @ShardId,
                        State = @State,
                        AdditionalPlayerCount = @AdditionalPlayerCount,
                        ClientSecret = @ClientSecret,
                        Flag = @Flag,
                        Name = @Name,
                        Level = @Level
                    WHERE Id = @Id;";

            _executor.Excute((sqlConnection) =>
            {
                sqlConnection.Execute(updateSql, mdlSession);
            });
        }
        #endregion


    }
}
