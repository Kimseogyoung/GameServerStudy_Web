/*using Microsoft.Extensions.Options;
using MySqlConnector;
using System.Data;

namespace WebStudyServer.Repo.Database
{
    public class UserDbContext
    {
        public int ShardId { get; private set; }

        public UserDbContext()
        {
            _excutor = new DBSqlExecutor(CONFIG.UserDbConnStr, IsolationLevel.ReadCommitted);
        }

        public void Init(int shardId)
        {

        }


        private DBSqlExecutor _excutor;
    }
}
*/