using WebStudyServer.Repo.Database;

namespace WebStudyServer.Base
{
    public abstract class RepoBase
    {
        public int ShardId { get; private set; }
        protected int ShardCnt => DbConnStrList.Count;
        protected DBSqlExecutor Excutor { get; private set; } = null!;
        protected abstract List<string> DbConnStrList { get; }

        public void Init(int shardId)
        {
            var dbConnectionStr = GetDbConnectionStr();
            ShardId = shardId;
            Excutor = DBSqlExecutor.Create(dbConnectionStr, System.Data.IsolationLevel.ReadCommitted);
        }

        public void Commit()
        {
            Excutor.Commit();
        }

        public void Rollback()
        {
            Excutor.Rollback();
        }

        private string GetDbConnectionStr()
        {
            if(ShardCnt >= ShardId)
            {
                throw new Exception("dd");
            }

            return DbConnStrList[ShardId];
        }
    }
}
