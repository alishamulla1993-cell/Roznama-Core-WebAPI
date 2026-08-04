using Microsoft.AspNetCore.Mvc;
using Roznama.Common.Constants;
using Roznama.Models.Dashboard.Models;
using System.Threading.Tasks;

namespace Roznama.Models.Dashboard
{
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly DashboardService _service;

        public DashboardController(DashboardService service)
        {
            _service = service;
        }

        [HttpGet(ApiRoutes.Dashboard.DashboardCount)]
        public async Task<ActionResult<DashboardCountDto>> GetDashboardCount([FromQuery] int userOID = 0)
        {
            var result = await _service.GetDashboardCount(userOID);
            return Ok(result);
        }
    }
}