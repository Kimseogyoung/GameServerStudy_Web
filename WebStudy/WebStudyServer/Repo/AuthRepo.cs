using Dapper;
using System.Numerics;
using WebStudyServer.Base;
using WebStudyServer.Model.Auth;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebStudyServer.Repo
{
    public class AuthRepo : RepoBase
    {
        protected override List<string> _dbConnStrList => CONFIG.AuthDbConnectionStrList;

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

        public bool TryGetAccount(ulong id, out AccountModel outAccountModel)
        {
            AccountModel mdlAccount = null;

            _executor.Excute((sqlConnection) =>
            {
                const string selectSql = "SELECT * FROM Account WHERE Id = @Id;";
                mdlAccount = sqlConnection.QuerySingleOrDefault<AccountModel>(selectSql, new { Id = id });
            });

            outAccountModel = mdlAccount;
            return outAccountModel != null;
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
    }
}
