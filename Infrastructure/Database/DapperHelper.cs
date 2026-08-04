using Dapper;
using System.Data;

namespace Roznama.Infrastructure.Database
{
    public class DapperHelper
    {
        public async Task<T?> QuerySingleAsync<T>(IDbConnection conn, string sp, object? param = null)
        {
            return await conn.QueryFirstOrDefaultAsync<T>(sp, param, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(IDbConnection conn, string sp, object? param = null)
        {
            return await conn.QueryAsync<T>(sp, param, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> ExecuteAsync(IDbConnection conn, string sp, object? param = null)
        {
            return await conn.ExecuteAsync(sp, param, commandType: CommandType.StoredProcedure);
        }
    }
}