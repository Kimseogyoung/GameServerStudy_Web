using MySqlConnector;
using System.Data;
using System.Data.Common;

namespace WebStudyServer.Repo.Database
{
    public class DBSqlExecutor 
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;
        
        public DBSqlExecutor(string connectionStr, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            _connection = new MySqlConnection(connectionStr);
            _connection.Open();
            _transaction = _connection.BeginTransaction(isolationLevel);
        }

        public static DBSqlExecutor Create(string connectionStr, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            var excutor = new DBSqlExecutor(connectionStr, isolationLevel);
            return excutor;
        }

        public void Excute(Action<IDbConnection, IDbTransaction> func)
        {
            func.Invoke(_connection, _transaction);
        }

        public T Excute<T>(Func<IDbConnection, IDbTransaction, T> func)
        {
            return func.Invoke(_connection, _transaction);
        }

        public void Commit()
        {
            if (_transaction != null)
            {
                _transaction.Commit();
                _transaction.Dispose();
            }

            Close();
        }

        public void Rollback()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
                _transaction.Dispose();
            }

            Close();
        }

        private void Close()
        {
            if (_connection.Database != null)
            {
                _connection.Close();
                _connection.Dispose();
            }
        }
    }
}
