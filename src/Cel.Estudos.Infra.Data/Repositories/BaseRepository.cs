using Cel.Estudos.Infra.Data.Data;
using System.Data;
using Dapper;

namespace Cel.Estudos.Infra.Data.Repositories
{
    public class BaseRepository
    {
        protected readonly DbSession _session;

        public BaseRepository(DbSession session)
        {
            _session = session;
        }

        public async Task<int> ExecuteAsync(string sql, object parameters, CommandType? commandType)
        {
            return await RunCommand(() => _session.Connection.ExecuteAsync(sql, parameters, commandType: commandType), _session.Connection)
                        .ConfigureAwait(false);
        }

        private async Task<TResult> RunCommand<TResult>(Func<Task<TResult>> action, IDbConnection connection)
        {
            try
            {
                return await action().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Exception exception = new Exception("Error to executes sql command", ex);
                throw exception;
            }
            finally
            {
                Close(connection);
            }
        }

        public void Close(IDbConnection connection)
        {
            connection.Close();
            connection.Dispose();
        }
    }
}
