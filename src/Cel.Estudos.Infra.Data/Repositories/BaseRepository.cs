﻿using Cel.Estudos.Infra.Data.Data;
using System.Data;
using Dapper;
using Cel.Estudos.Lib;

namespace Cel.Estudos.Infra.Data.Repositories
{
    public class BaseRepository
    {
        protected readonly DbSession _session;

        public BaseRepository(DbSession session)
        {
            _session = session;
        }

        protected async Task<int> ExecuteAsync(string sql, object parameters, CommandType? commandType)
        {
            return await RunCommand(() => _session.Connection.ExecuteAsync(sql,
                                                                           parameters,
                                                                           commandType: commandType,
                                                                           transaction: _session.Transaction), _session.Connection)
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
                Close(connection);
                SqlException exception = new SqlException($"Error to execute sql command {ex.Message}", ex);
                throw exception;
            }
        }

        public void Close(IDbConnection connection)
        {
            connection.Close();
            connection.Dispose();
        }
    }
}
