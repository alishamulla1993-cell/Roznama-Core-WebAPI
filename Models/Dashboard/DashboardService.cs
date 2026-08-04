using Roznama.Models.Dashboard.Models;
using System.Threading.Tasks;

namespace Roznama.Models.Dashboard
{
    public class DashboardService
    {
        private readonly DashboardRepository _repo;

        public DashboardService(DashboardRepository repo)
        {
            _repo = repo;
        }

        public Task<DashboardCountDto> GetDashboardCount(int userOID)
        {
            return _repo.GetDashboardCount(userOID);
        }
    }
}