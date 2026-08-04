using Roznama.Infrastructure.Database;
using System.Data;

namespace Roznama.Infrastructure.Database
{
    public abstract class RepositoryBase
    {
        protected readonly DbConnectionFactory _dbFactory;
        protected readonly DapperHelper _dapper;

        protected RepositoryBase(DbConnectionFactory dbFactory, DapperHelper dapper)
        {
            _dbFactory = dbFactory;
            _dapper = dapper;
        }

        protected IDbConnection CreateConnection() => _dbFactory.CreateConnection();
    }
}