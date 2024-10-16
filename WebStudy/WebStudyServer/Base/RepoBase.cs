using WebStudyServer.Repo.Database;

namespace WebStudyServer.Base
{
    public abstract class RepoBase
    {
        public int ShardId { get; private set; }

        protected int _shardCnt => _dbConnStrList.Count;
        protected DBSqlExecutor _executor { get; private set; } = null!;
        protected abstract List<string> _dbConnStrList { get; }

        public void Init(int shardId)
        {
            var dbConnectionStr = GetDbConnectionStr();
            ShardId = shardId;
            _executor = DBSqlExecutor.Create(dbConnectionStr, System.Data.IsolationLevel.ReadCommitted);
        }

        public void Commit()
        {
            _executor.Commit();
        }

        public void Rollback()
        {
            _executor.Rollback();
        }

        private string GetDbConnectionStr()
        {
            if(_shardCnt >= ShardId)
            {
                throw new Exception("dd");
            }

            return _dbConnStrList[ShardId];
        }
    }
}
