using Dapper;
using Roznama.Infrastructure.Database;
using Roznama.Models.Dashboard.Models;
using System.Data;
using System.Threading.Tasks;

namespace Roznama.Models.Dashboard
{
    public class DashboardRepository : RepositoryBase
    {
        public DashboardRepository(DbConnectionFactory dbFactory, DapperHelper dapper)
            : base(dbFactory, dapper)
        {
        }

        public async Task<DashboardCountDto> GetDashboardCount(int userOID)
        {
            using var conn = CreateConnection();

            var result = await conn.QueryFirstOrDefaultAsync<DashboardCountDto>(
                "GetCountForDispaly",
                new { UserOID = userOID },
                commandType: CommandType.StoredProcedure
            );

            return result ?? new DashboardCountDto();
        }
    }
}