using Microsoft.AspNetCore.Mvc;
using Roznama.Models.Litigation;
using Roznama.Modules.Common;
using System.Threading.Tasks;
//using System.Web.Http;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Roznama.Modules.Common
{
    [ApiController]
    [Route("api/v1/dropdowns")]
    public class DropdownController : ControllerBase
    {
        private readonly DropdownRepository _repo;

        public DropdownController(DropdownRepository repo)
        {
            _repo = repo;
        }

        // GET /api/v1/dropdowns/entities?entityOID=0&userOID=1&role=Support
        [HttpGet("entities")]
        public async Task<IActionResult> GetEntities([FromQuery] int entityOID = 0, [FromQuery] int userOID = 0, [FromQuery] string role = "")
        {
            var result = await _repo.GetEntities(entityOID, userOID, role);
            return Ok(result);
        }

        // GET /api/v1/dropdowns/units?entityOID=1&userOID=1
        [HttpGet("units")]
        public async Task<IActionResult> GetUnits([FromQuery] int entityOID = 0, [FromQuery] int userOID = 0)
        {
            var result = await _repo.GetUnits(entityOID, userOID);
            return Ok(result);
        }

        // GET /api/v1/dropdowns/zones?entityOID=0&unitOID=0&userOID=0
        [HttpGet("zones")]
        public async Task<IActionResult> GetZones([FromQuery] int entityOID = 0, [FromQuery] int unitOID = 0, [FromQuery] int userOID = 0)
        {
            var result = await _repo.GetZones(entityOID, unitOID, userOID);
            return Ok(result);
        }

        // GET /api/v1/dropdowns/regions?entityOID=0&unitOID=0&zoneOID=0&userOID=0
        [HttpGet("regions")]
        public async Task<IActionResult> GetRegions([FromQuery] int entityOID = 0, [FromQuery] int unitOID = 0, [FromQuery] int zoneOID = 0, [FromQuery] int userOID = 0)
        {
            var result = await _repo.GetRegions(entityOID, unitOID, zoneOID, userOID);
            return Ok(result);
        }

        [HttpGet("department")]
        public async Task<IActionResult> GetDepartments([FromQuery] int userOID = 0, [FromQuery] string role = "")
        {
            var result = await _repo.GetDepartments(userOID, role);
            return Ok(result);
        }

        [HttpGet("classification")]
        public async Task<IActionResult> GetClassificationTypes()
        {
            var result = await _repo.GetClassificationTypes();
            return Ok(result);
        }

        [HttpGet("category")]
        public async Task<IActionResult> GetCategoryTypes([FromQuery] int classificationTypeOID = 0)
        {
            var result = await _repo.GetCategoryTypes(classificationTypeOID);
            return Ok(result);
        }

        [HttpGet("subcategory")]
        public async Task<IActionResult> GetSubCategoryTypes([FromQuery] int categoryTypeOID = 0)
        {
            var result = await _repo.GetSubCategoryTypes(categoryTypeOID);
            return Ok(result);
        }

        [HttpGet("status")]
        public async Task<IActionResult> GetStatuses([FromQuery] int noticeOID = 0)
        {
            var result = await _repo.GetStatuses(noticeOID);
            return Ok(result);
        }

        [HttpGet("risk")]
        public async Task<IActionResult> GetRisks()
        {
            var result = await _repo.GetRiskDetails();
            return Ok(result);
        }

        [HttpGet("noticetype")]
        public async Task<IActionResult> GetNoticeTypes()
        {
            var result = await _repo.GetNoticeTypes();
            return Ok(result);
        }

        [HttpGet("rlm")]
        public async Task<IActionResult> GetRLMs()
        {
            var result = await _repo.GetRLMs();
            return Ok(result);
        }

        [HttpGet("GetAllCourtType")]
        public async Task<IActionResult> GetAllCourtType([FromQuery] string DigitizedOrNonDigitized = "", string CNRCaseNumber = "")
        {
            var result = await _repo.GetAllCourtType(DigitizedOrNonDigitized, CNRCaseNumber);
            return Ok(result);
        }

        [HttpGet("GetAllLitigationCategory")]
        public async Task<IActionResult> GetAllLitigationCategory()
        {
            var result = await _repo.GetAllLitigationCategory();
            return Ok(result);
        }

        [HttpGet("GetPOABRLOA")]
        public async Task<IActionResult> GetPOABRLOA()
        {
            var result = await _repo.GetPOABRLOA();
            return Ok(result);
        }
        [HttpGet("GetAllCompanycounterType")]
        public async Task<IActionResult> GetCompanyType([FromQuery] int ClassificationTypeOID = 0, [FromQuery] int LitigationCategoryOID = 0)
        {
            var result = await _repo.GetCompanyType(ClassificationTypeOID, LitigationCategoryOID);
            return Ok(result);
        }
        [HttpGet("GetCounterType")]
        public async Task<IActionResult> GetCounterType([FromQuery] string CompanyType = "",[FromQuery] int ClassificationTypeOID = 0, [FromQuery] int LitigationCategoryOID = 0)
        {
            var result = await _repo.GetCounterType(CompanyType,ClassificationTypeOID, LitigationCategoryOID);
            return Ok(result);
        }

        [HttpGet("GetCompanyLawFirmAdvocate")]
        public async Task<IActionResult> GetPartySummary([FromQuery] int PartyTypeOID = 0)
        {
            var result = await _repo.GetPartySummary(PartyTypeOID);
            return Ok(result);
        }
        [HttpGet("GetAuthority")]
        public async Task<IActionResult> GetAuthority()
        {
            var result = await _repo.GetAuthority();
            return Ok(result);
        }
        [HttpGet("GetNonDigitizeBench")]
        public async Task<IActionResult> GetNonDigitizeBench()
        {
            var result = await _repo.GetNonDigitizeBench();
            return Ok(result);
        }
        [HttpGet("GetNonDigitizeCaseTypeMaster")]
        public async Task<IActionResult> GetNonDigitizeCaseTypeMaster()
        {
            var result = await _repo.GetNonDigitizeCaseTypeMaster();
            return Ok(result);
        }
        [HttpGet("GetMatterHandledby")]
        public async Task<IActionResult> GetMatterHandledby([FromQuery] int UnitOID=0)
        {
            var result = await _repo.GetMatterHandledby(UnitOID);
            return Ok(result);
        }
        [HttpGet("GetUnitMember")]
        public async Task<IActionResult> GetUnitMember([FromQuery] int UnitOID = 0)
        {
            var result = await _repo.GetUnitMember(UnitOID);
            return Ok(result);
        }
        [HttpGet("GetAllStages")]
        public async Task<IActionResult> GetAllStages()
        {
            var result = await _repo.GetAllStages();
            return Ok(result);
        }
        [HttpGet("GetDirectorPromoterName")]
        public async Task<IActionResult> GetDirectorPromoterName([FromQuery] int UnitOID = 0)
        {
            var result = await _repo.GetDirectorPromoterName(UnitOID);
            return Ok(result);
        }
        [HttpGet("GetLitigationSubCategoryMaster")]
        public async Task<IActionResult> GetLitigationSubCategoryMaster()
        {
            var result = await _repo.GetLitigationSubCategoryMaster();
            return Ok(result);
        }
        [HttpGet("GetSubCategory1")]
        public async Task<IActionResult> GetSubCategory1([FromQuery] int SubCategoryOID = 0)
        {
            var result = await _repo.GetSubCategory1(SubCategoryOID);
            return Ok(result);
        }
        [HttpGet("GetSubUnitDetail")]
        public async Task<IActionResult> GetSubUnitDetail()
        {
            var result = await _repo.GetSubUnitDetail();
            return Ok(result);
        }



    }
}