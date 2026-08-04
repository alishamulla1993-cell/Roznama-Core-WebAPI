using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Roznama.Config;
using System.Data;

namespace Roznama.Infrastructure.Database
{
    public class DbConnectionFactory
    {
        private readonly string _connectionString;

        public DbConnectionFactory(IOptions<AppSettings> settings)
        {
            _connectionString = settings.Value.ConnectionStrings.DefaultConnection;
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}