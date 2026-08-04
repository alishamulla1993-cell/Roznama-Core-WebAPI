using Microsoft.AspNetCore.Mvc;
using Roznama.Models.Litigation.Models;
using Roznama.Modules.Notice;
using System.Threading.Tasks;

namespace Roznama.Models.Litigation
{
    [ApiController]
    [Route("api/v1/litigation")]
    public class LitigationController: ControllerBase
    {
        private readonly LitigationService _service;

        public LitigationController(LitigationService service)
        {
            _service = service;
        }
        #region Add Litigation API's

        #region Get Methods
        [HttpGet("GetNoticeDetailsByNoticeOID")]
        public async Task<IActionResult> GetNoticeDetailsByNoticeOID([FromQuery] int NoticeOID = 0)
        {
            var result = await _service.GetNoticeDetailsByNoticeOID(NoticeOID);
            return Ok(result);
        }
        [HttpGet("GetLitigationID")]
        public async Task<IActionResult> GetLitigationID([FromQuery] int LitigationOID = 0)
        {
            var result = await _service.GetLitigationID(LitigationOID);
            return Ok(result);
        }
        [HttpGet("GetMSILFileNo")]
        public async Task<IActionResult> GetMSILFileNo([FromQuery] string LitigationID = "")
        {
            var result = await _service.GetMSILFileNo(LitigationID);
            return Ok(result);
        }
        [HttpGet("BindCaseTitle")]
        public async Task<IActionResult> BindCaseTitle([FromQuery] int LitigationOID = 0)
        {
            var result = await _service.GetCourtCaseTitle(LitigationOID);
            return Ok(result);
        }

        [HttpGet("GetLitigationAllDetailbyLitigationOID")]
        public async Task<IActionResult> GetLitigationAllDetailbyLitigationOID([FromQuery] int LitigationOID = 0)
        {
            var result = await _service.GetLitigationAllDetailbyLitigationOID(LitigationOID);
            return Ok(result);
        }

        [HttpGet("GetCompanyAdvocateDetails")]
        public async Task<IActionResult> GetCompanyAdvocateDetails([FromQuery] int LitigationOID = 0)
        {
            var result = await _service.GetCompanyAdvocateDetails(LitigationOID);
            return Ok(result);
        }
        [HttpGet("GetSubcourt")]
        public async Task<IActionResult> GetSubcourt([FromQuery] int Courttype = 0)
        {
            var result = await _service.GetSubcourt(Courttype);
            return Ok(result);
        }

        [HttpGet("GetAllCourtType")]
        public async Task<IActionResult> GetAllCourtType([FromQuery] string DigitizedOrNonDigitized = "")
        {
            var result = await _service.GetAllCourtType(DigitizedOrNonDigitized);
            return Ok(result);
        }
        [HttpGet("BindState")]
        public async Task<IActionResult> GetStates(
        int courtTypeOID)
        {
            var result = await _service.GetStatesAsync(courtTypeOID);
            return Ok(result);
        }
        [HttpGet("GetCasewiseCrawlerSpGetConsumerState")]
        public async Task<IActionResult> GetCasewiseCrawlerSpGetConsumerState()
        {
            var result = await _service.GetCasewiseCrawlerSpGetConsumerState();
            return Ok(result);
        }
        [HttpGet("BindDistrict")]
        public async Task<IActionResult> GetAllDistrict([FromQuery] int StateOID=0)
        {
            var result = await _service.GetAllDistrict(StateOID);
            return Ok(result);
        }
        [HttpGet("BindBench")]
        public async Task<IActionResult> GetBench([FromQuery] int intCourtType=0, string CourtSubType="", int state=0, int district=0, int CourtComplex=0)
        {
            var result = await _service.GetBench( intCourtType,  CourtSubType,  state,  district,  CourtComplex);
            return Ok(result);
        }
        [HttpGet("GetCaseTypeData")]
        public async Task<IActionResult> GetCaseTypeData([FromQuery] int intCourtType = 0, string CourtSubType = "", int state = 0, int district = 0, int CourtComplex = 0, string CourtValueField="")
        {
            var result = await _service.GetCaseTypeData(intCourtType, CourtSubType, state, district, CourtComplex, CourtValueField);
            return Ok(result);
        }
        [HttpGet("BindNonDigitizeBench")]
        public async Task<IActionResult> GetNonDigitizeCourtMaster()
        {
            var result = await _service.GetNonDigitizeCourtMaster();
            return Ok(result);
        }
        [HttpGet("BindNonDigitizeCaseTypeMaster")]
        public async Task<IActionResult> GetNonDigitizeCaseTypeMaster()
        {
            var result = await _service.GetNonDigitizeCaseTypeMaster();
            return Ok(result);
        }
        [HttpGet("BindUnderAct")]
        public async Task<IActionResult> GetAllUnderAct()
        {
            var result = await _service.GetAllUnderAct();
            return Ok(result);
        }
        [HttpGet("BindSubjectMatter")]
        public async Task<IActionResult> GetAllSubjectMatter()
        {
            var result = await _service.GetAllSubjectMatter();
            return Ok(result);
        }
        [HttpGet("GetAllCaseTypeTribunal")]
        public async Task<IActionResult> GetAllCaseTypeTribunal([FromQuery] int courttypeoid=0, int stateoid=0, int TribunalOID=0)
        {
            var result = await _service.GetAllCaseTypeTribunal( courttypeoid, stateoid, TribunalOID);
            return Ok(result);
        }
        [HttpGet("GetAllCaseType")]
        public async Task<IActionResult> GetAllCaseType([FromQuery] int courttypeoid = 0, int stateoid = 0)
        {
            var result = await _service.GetAllCaseType(courttypeoid, stateoid);
            return Ok(result);
        }
        [HttpGet("GetAllCaseTypeConsumer")]
        public async Task<IActionResult> GetAllCaseTypeConsumer([FromQuery] int courttypeoid = 0, int stateoid = 0,int ConsumerOID=0)
        {
            var result = await _service.GetAllCaseTypeConsumer(courttypeoid, stateoid, ConsumerOID);
            return Ok(result);
        }
        [HttpGet("BindNameoftheConsumer")]
        public async Task<IActionResult> GetNameoftheConsumer()
        {
            var result = await _service.GetNameoftheConsumer();
            return Ok(result);
        }
        [HttpGet("BindNameofLabourCourt")]
        public async Task<IActionResult> GetNameoftheLabourCourt()
        {
            var result = await _service.GetNameoftheLabourCourt();
            return Ok(result);
        }
        [HttpGet("BindNameoftheTribunal")]
        public async Task<IActionResult> GetNameoftheTribunal()
        {
            var result = await _service.GetNameoftheTribunal();
            return Ok(result);
        }
        [HttpGet("BindMSILCaseType")]
        public async Task<IActionResult> GetMSILCaseType()
        {
            var result = await _service.GetMSILCaseType();
            return Ok(result);
        }
        [HttpGet("BindConnectedLitigation")]
        public async Task<IActionResult> GetLinkedLitigation(
    int litigationOID)
        {
            var data = await _service.GetLinkedLitigation(litigationOID);
            return Ok(data);
        }
        [HttpGet("BindArbitrationOID")]
        public async Task<IActionResult> GetArbitrationOID()
        {
            var result = await _service.GetArbitrationOID();
            return Ok(result);
        }
        [HttpGet("BindModel")]
        public async Task<IActionResult> BindModel([FromQuery] string Type="")
        {
            var result = await _service.GetMasterDetailData(Type);
            return Ok(result);
        }
        [HttpGet("BindDealersName")]
        public async Task<IActionResult> BindDealersName()
        {
            var result = await _service.GetMasterDetailDataDealer();
            return Ok(result);
        }
        [HttpGet("BindStage")]
        public async Task<IActionResult> BindStage()
        {
            var result = await _service.GetAllStages();
            return Ok(result);
        }
        [HttpGet("BindCourtForumDDL")]
        public async Task<IActionResult> GetCourtName(int intCourtType, int intState, int intDistrictOID, int intTribunalOID)
        {
            var result = await _service.GetCourtName(intCourtType,intState, intDistrictOID, intTribunalOID);
            return Ok(result);
        }
        [HttpGet("CheckDuplicateCaseNumber")]
        public async Task<IActionResult> CheckDuplicateCaseNumber(
        [FromQuery] DuplicateCaseCheckRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.CaseNumber))
                return BadRequest("Case Number is required");

            bool isDuplicate =
                await _service.IsDuplicateCaseNumberAsync(request);

            return Ok(new DuplicateCaseCheckResponse
            {
                IsDuplicate = isDuplicate
            });
        }
        [HttpGet("BindDirectorPromoterName")]
        public async Task<IActionResult> BindDirectorPromoterName([FromQuery] int UnitOID=0)
        {
            var result = await _service.GetDirectorPromoterName(UnitOID);
            return Ok(result);
        }
        [HttpGet("BindPartyDetails")]
        public async Task<IActionResult> BindPartyDetails(
        int partyTypeOID,
        string partyName)
        {
            var result =
                await _service.GetPartyDetailsAsync(
                    partyTypeOID, partyName);

            if (result == null)
                return NotFound("Party not found");

            return Ok(result);
        }
        [HttpGet("BindSubUnitDDL")]
        public async Task<IActionResult> BindSubUnitDDL()
        {
            var result = await _service.GetSubUnitDetail();
            return Ok(result);
        }
        [HttpGet("BindPartyDetailsOther")]
        public async Task<IActionResult> BindPartyDetailsOther(
        int partyTypeOID,
        string partyName)
        {
            var result =
                await _service.GetOtherPartyDetailsAsync(
                    partyTypeOID, partyName);

            if (result == null)
                return NotFound("Party not found");

            return Ok(result);
        }
        [HttpGet("BindCounterTypeDDL")]
        public async Task<IActionResult> BindCounterTypeDDL([FromQuery] string CompanyType="", int ClassificationTypeOID=0, int LitigationCategoryOID=0)
        {
            var result = await _service.GetCounterType(CompanyType,ClassificationTypeOID, LitigationCategoryOID);
            return Ok(result);
        }
        [HttpGet("BindSubCategory")]
        public async Task<IActionResult> BindSubCategory([FromQuery] int LitigationCategoryOID = 0)
        {
            var result = await _service.GetSubCategory(LitigationCategoryOID);
            return Ok(result);
        }
        [HttpGet("GetBombayCaseTypeData")]
        public async Task<IActionResult> GetBombayCaseTypeData([FromQuery] int intCourtType = 0, string CourtSubType = "",  string CourtValueField = "",string stamp="",string side="")
        {
            var result = await _service.GetBombayCaseTypeData(intCourtType, CourtSubType,  CourtValueField,stamp,side);
            return Ok(result);
        }
        [HttpGet("GetPartyMasterOIDByPartyTypeOID_Name")]
        public async Task<IActionResult> GetPartyMasterOIDByPartyTypeOID_Name(
     [FromQuery] int PartyTypeOID,string PartyName)
        {
            try
            {
                int partyMasterOID =
                    await _service.GetPartyMasterOIDAsync(PartyTypeOID,PartyName);

                return Ok(new
                {
                    Success = true,
                    PartyMasterOID = partyMasterOID
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }
        [HttpGet("GetLitigationforOppositeParty")]
        public async Task<IActionResult> GetLitigationforOppositeParty([FromQuery] string PartyName = "")
        {
            var result = await _service.GetLitigationforOppositeParty(PartyName);
            return Ok(result);
        }
        [HttpGet("BindRiskDDL")]
        public async Task<IActionResult> GetRiskDetail()
        {
            var result = await _service.GetRiskDetail();
            return Ok(result);
        }

        [HttpGet("GetClientDetails")]
        public async Task<IActionResult> GetClientDetails([FromQuery] int LitigationOID=0)
        {
            var result = await _service.GetClientDetails(LitigationOID);
            return Ok(result);
        }
        #endregion
        /// <summary>
        /// Post APIs Start Here
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
#region post method
        [HttpPost("unitmembers/generate")]
        public async Task<IActionResult> Generate([FromBody] GenerateUnitMemberRequest request)
        {
            var result = await _service.GenerateUnitMembersAsync(request);
            return Ok(result);
        }

        [HttpPost("matterhandledby/generate")]
        public async Task<IActionResult> Generate(
            [FromBody] GenerateMatterHandledByRequest request)
        {
            var result = await _service.GenerateMatterHandledByAsync(request);
            return Ok(result);
        }

        [HttpPost("parties/generate")]
        public async Task<IActionResult> Generate(
            [FromBody] GeneratePartyRequest request)
        {
            var result = await _service.GeneratePartiesAsync(request);
            return Ok(result);
        }

        [HttpPost("oppositeparties/generate")]
        public async Task<IActionResult> Generate(
           [FromBody] GenerateOppositePartyRequest request)
        {
            var result = await _service.GenerateOppositePartiesAsync(request);
            return Ok(result);
        }

        [HttpPost("lawfirmadvocates/generate")]
        public async Task<IActionResult> Generate(
           [FromBody] GenerateLawFirmAdvocateRequest request)
        {
            var result = await _service.GenerateAsync(request);
            return Ok(result);
        }

        [HttpPost("counterlawfirmadvocates/generate")]
        public async Task<IActionResult> Generate(
            [FromBody] GenerateCounterLawFirmAdvocateRequest request)
        {
            var result = await _service.GenerateAsync(request);
            return Ok(result);
        }
        [HttpPost("generateTable_SubCategory")]
        public async Task<IActionResult> GenerateSubCategory(
        [FromBody] GenerateSubCategoryRequest request)
        {
            var data = await _service.GenerateSubCategoryAsync(request);

            return Ok(new
            {
                Success = true,
                Data = data
            });
        }

        [HttpPost("AddUnderAct")]
        public async Task<IActionResult> AddUnderAct(
        [FromBody] AddUnderActRequest request)
        {
            var result = await _service.AddUnderActAsync(request);
            return Ok(result);
        }
        [HttpPost("InsertNewUnderAct")]
       
        public async Task<IActionResult> InsertNewUnderAct(
    [FromBody] InsertUnderActRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.UnderAct))
                return BadRequest("Under Act Name is required");

            int underActOID = await _service.InsertOtherUnderAct(request.UnderAct);

            return Ok(new { UnderActOID = underActOID });
        }
        [HttpPost("InsertOtherSubjectMatter")]
        public async Task<IActionResult> InsertOtherSubjectMatter(
        [FromBody] InsertSubjectMatter request)
        {
            if (string.IsNullOrWhiteSpace(request.SubjectMatter))
                return BadRequest("Subject Matter Name is required");

            int subjectMatterOID =
         await _service.AddSubjectMatterAsync(
             request.SubjectMatter);

            return Ok(subjectMatterOID);
        }
        [HttpPost("InsertStageNew")]
        public async Task<IActionResult> InsertStageNew(
        [FromBody] InsertStageRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.StageName))
                return BadRequest("Stage Name is required");

            int stageOID =
                await _service.AddStageAsync(request.StageName);

            return Ok(stageOID);
        }
        [HttpPost("InsertDiscoverySelections")]
        public async Task<IActionResult> InsertDiscoverySelections(
        [FromBody] DiscoverySelectionRequest request)
        {
            var result = await _service.SaveDiscoveryAsync(request);

            if (!result.Success)
                return BadRequest("Insert/Update failed");

            return Ok(result);
        }
        [HttpPost("InsertLitigationParties")]
        public async Task<IActionResult> InsertLitigationParties(
        [FromBody] List<UpdateClientContactRequest> request)
        {
            var result =
                await _service.InsertLitigationPartiesAsync(request);

            if (!result.Success)
                return BadRequest("No parties inserted");

            return Ok(result);
        }
        [HttpPost("InsertCompanyLawyersContactDetail")]
        public async Task<IActionResult> InsertCompanyLawFirmAdvocate(
        [FromBody] CompanyLawFirmAdvocateRequest request)
        {
            if (request == null || request.Advocates == null || request.Advocates.Count == 0)
                return BadRequest("No company law firm advocate data provided");

            int result = await _service.SaveCompanyLawFirmAdvocatesAsync(request);

            return Ok(new
            {
                Success = true,
                Message = "Company Law Firm / Advocate saved successfully",
                Result = result
            });
        }
        [HttpPost("InsertOppositePartiesLawyersContactDetail")]
        public async Task<IActionResult> InsertOppositePartiesLawyersContactDetail(
        [FromBody] OppositePartiesRequest request)
        {
            if (request == null || request.Parties == null || request.Parties.Count == 0)
                return BadRequest("Opposite parties data is required");

            int result = await _service.SaveOppositePartiesAsync(request);

            return Ok(new
            {
                Success = true,
                Message = "Opposite parties saved successfully",
                Result = result
            });
        }
        [HttpPost("Other Party Law Firm/Advocate")]
        public async Task<IActionResult> SaveCounterLawFirms(
        [FromBody] CounterLawFirmRequest request)
        {
            if (request == null || request.CounterLawFirms == null || request.CounterLawFirms.Count == 0)
                return BadRequest("Counter law firm data is required");

            int result = await _service.SaveCounterLawFirmsAsync(request);

            return Ok(new
            {
                Success = true,
                Message = "Counter law firm advocates saved successfully",
                Result = result
            });
        }
        [HttpPost("InsertLitigationOrgDetail")]
        public async Task<IActionResult> InsertLitigationOrgDetail(
       [FromBody] InsertLitigationOrgRequest request)
        {
            var result = await _service.CreateLitigationAsync(request);

            if (result.LitigationOID <= 0)
                return BadRequest("Failed to create litigation");

            return Ok(result);
        }
        [HttpPost("InsertMatterHandledBy")]
        public async Task<IActionResult> InsertMatterHandledBy(
        [FromBody] LitigationHandledByRequest request)
        {
            if (request == null || request.UserOIDs == null || !request.UserOIDs.Any())
                return BadRequest("No users provided");

            int result = await _service.InsertHandledByAsync(request);

            if (result <= 0)
                return BadRequest("Insert failed");

            return Ok(new
            {
                message = "Matter handled by users saved successfully",
                litigationOID = request.LitigationOID,
                totalUsers = request.UserOIDs.Count
            });
        }
        [HttpPost("InsertLitigationUnitMembers")]
        public async Task<IActionResult> InsertUnitMembers(
        [FromBody] LitigationHandledByRequest request)
        {
            if (request == null)
                return BadRequest("Request is null");

            if (request.LitigationOID <= 0)
                return BadRequest("Invalid LitigationOID");

            if (request.UserOIDs == null || !request.UserOIDs.Any())
                return BadRequest("No unit members provided");

            int result = await _service.InsertUnitMembersAsync(request);

            return Ok(new
            {
                message = "Unit members added successfully",
                litigationOID = request.LitigationOID,
                totalMembers = request.UserOIDs.Count
            });
        }
        [HttpPost("InsertLitigationPOADocument")]
        public async Task<IActionResult> InsertLitigationPOADocument(
    [FromBody] LitigationPoaDocumentsRequest request)
        {
            if (request.Documents == null || request.Documents.Count == 0)
                return BadRequest("Document list is empty");

            int result = await _service.SavePoaDocumentsAsync(request);

            return result > 0
                ? Ok("POABRLOA documents saved successfully")
                : BadRequest("Failed to save documents");
        }
        [HttpPost("InsertSubCategory")]
        public async Task<IActionResult> InsertSubCategory(
    [FromQuery] int litigationOID, int subCategoryOID)
        {
            if (litigationOID <= 0 || subCategoryOID <= 0)
                return BadRequest("Invalid LitigationOID or SubCategoryOID");

            int result = await _service.AddSubCategoryAsync(
                litigationOID,
                subCategoryOID);

            if (result <= 0)
                return BadRequest("SubCategory insertion failed");

            return Ok(new
            {
                Success = true,
                Message = "SubCategory inserted successfully",
                Result = result
            });
        }

        [HttpPost("InsertDirectorName")]
        public async Task<IActionResult> InsertDirectorName(
   [FromQuery] string PartyName)
        {
            if (PartyName == null )
                return BadRequest("Empty Director Name");

            int result = await _service.InsertDirectorName(PartyName);
          

            if (result <= 0)
                return BadRequest("insertion failed");

            return Ok(new
            {
                Success = true,
                Message = "Director inserted successfully",
                Result = result
            });
        }

        [HttpPost("InsertLitigationCaseDetails")]
        public async Task<IActionResult> InsertLitigationCaseDetails(
    [FromBody] LitigationCaseDetailsRequest request)
        {
            if (request == null ||
                request.LitigationOID <= 0 ||
                request.CaseDetails == null)
                return BadRequest("Invalid request data");

            int result = await _service.InsertLitigationCaseDetailsAsync(
                request.CaseDetails,
                request.LitigationOID);

            if (result <= 0)
                return BadRequest("Case details insertion failed");

            return Ok(new
            {
                Success = true,
                Message = "Litigation case details inserted successfully",
                Result = result
            });
        }
        [HttpPost("InsertConnectedNotice")]
        public async Task<IActionResult> InsertConnectedNotice(
   [FromQuery] int litigationOID, int NoticeOID)
        {
            //if (litigationOID <= 0 || NoticeOID <= 0)
            //    return BadRequest("Invalid LitigationOID or SubCategoryOID");

            int result = await _service.InsertConnectedNotice(
                litigationOID,
                NoticeOID);

            if (result <= 0)
                return BadRequest("insertion failed");

            return Ok(new
            {
                Success = true,
               // Message = "SubCategory inserted successfully",
                Result = result
            });
        }

        [HttpPost("InsertConnectedLitigation")]
        public async Task<IActionResult> InsertConnectedLitigation(
        [FromBody] InsertConnectedLitigationRequest request)
        {
            await _service.InsertConnectedLitigationAsync(request);

            return Ok(new
            {
                Success = true,
                Message = "Connected litigation added successfully"
            });
        }

        [HttpPost("InsertConnectedArbitration")]
        public async Task<IActionResult> InsertConnectedArbitration(
        [FromBody] InsertConnectedArbitrationRequest request)
        {
            await _service.InsertConnectedArbitrationAsync(request);

            return Ok(new
            {
                Success = true,
                Message = "Connected arbitration added successfully"
            });
        }

        [HttpPost("InsertOtherPartyLawFirm")]
        public async Task<IActionResult> InsertOtherPartyLawFirm(
        [FromQuery] int partyTypeOID,string partyName)
        {
           

            int partyMasterOID =
                await _service.InsertOtherPartyLawFirmAsync(partyTypeOID, partyName);

            return Ok(new
            {
                Success = true,
                Message = "Party / Law Firm inserted successfully",
                PartyMasterOID = partyMasterOID
            });
        }
        [HttpPost("InsertOtherCompanyLawFirm")]
        public async Task<IActionResult> InsertOtherCompanyLawFirm(
    [FromBody] LawFirmAdvocateDto dto)
        {
            int oid = await _service.InsertNewCompanyLawFirmAsync(dto);

            return Ok(new
            {
                Success = true,
                CompanyLawFirmOID = oid,
                Message = "Company Law Firm inserted successfully"
            });
        }
        [HttpPost("InsertParties")]
        public async Task<IActionResult> InsertParties(
        [FromBody] InsertPartyRequest request)
        {
            if (request == null)
                return BadRequest("Invalid request");

            int partyMasterOID = await _service.InsertPartiesAsync(request);

            return Ok(new
            {
                Success = true,
                Message = "Party inserted successfully",
                PartyMasterOID = partyMasterOID
            });
        }

        [HttpPost("InsertMailLog")]
        public async Task<IActionResult> InsertMailLog(
        [FromBody] InsertMailLogRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                bool isInserted = await _service.InsertMailLogAsync(request);

                if (!isInserted)
                {
                    return BadRequest(new
                    {
                        Success = false,
                        Message = "Mail log insert failed"
                    });
                }

                return Ok(new
                {
                    Success = true,
                    Message = "Mail log inserted successfully"
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new
                {
                    Success = false,
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Success = false,
                    Message = "Internal server error",
                    Error = ex.Message
                });
            }
        }

        [HttpPost("InsertConnectedLitigationToTax")]
        public async Task<IActionResult> InsertConnectedLitigationToTax(
        [FromBody] InsertConnectedLitigationToTaxRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                bool success =
                    await _service.InsertConnectedLitigationToTaxAsync(request);

                if (!success)
                {
                    return BadRequest(new
                    {
                        Success = false,
                        Message = "Failed to connect litigation with tax"
                    });
                }

                return Ok(new
                {
                    Success = true,
                    Message = "Litigation connected to tax successfully"
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new
                {
                    Success = false,
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Success = false,
                    Message = "Internal server error",
                    Error = ex.Message
                });
            }
        }

        [HttpPost("InsertTransactionLog")]
        public async Task<IActionResult> InsertTransactionLog(
        [FromBody] InsertTransactionLogRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                bool success =
                    await _service.InsertTransactionLogAsync(request);

                if (!success)
                {
                    return BadRequest(new
                    {
                        Success = false,
                        Message = "Failed to insert transaction log"
                    });
                }

                return Ok(new
                {
                    Success = true,
                    Message = "Transaction log inserted successfully"
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new
                {
                    Success = false,
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Success = false,
                    Message = "Internal server error",
                    Error = ex.Message
                });
            }
        }

        [HttpPost("InsertWitnessMaster")]
        public async Task<IActionResult> InsertWitness([FromBody]  WitnessDto model)
        {
            var result = await _service.InsertWitnessMaster(model);

            if (result > 0)
                return Ok(new { success = true, message = "Witness added successfully" });

            return BadRequest(new { success = false, message = "Insert failed" });
        }
        #endregion
        /// <summary>
        /// Delete Merhod Start
        /// </summary>
        /// <param name="litigationOID"></param>
        /// <returns></returns>
        #region Delete Methd
        [HttpDelete("DeleteCompanyParties")]
        public async Task<IActionResult> DeleteCompanyParties(int litigationOID)
        {
            if (litigationOID <= 0)
                return BadRequest("Invalid LitigationOID");

            var result = await _service.DeleteCompanyPartiesAsync(litigationOID);

            if (!result.Success)
                return NotFound("No company parties found to delete");

            return Ok(result);
        }
        [HttpDelete("DeleteMatterHandledBy")]
        public async Task<IActionResult> DeleteMatterHandledBy(int litigationOID)
        {
            if (litigationOID <= 0)
                return BadRequest("Invalid LitigationOID");

            bool isDeleted = await _service.DeleteMatterHandledByAsync(litigationOID);

            if (!isDeleted)
                return NotFound("No Matter Handled records found");

            return Ok(new
            {
                message = "Matter handled records deleted successfully",
                litigationOID = litigationOID
            });
        }
        [HttpDelete("DeleteUnitMembers")]
        public async Task<IActionResult> DeleteUnitMembers(int litigationOID)
        {
            if (litigationOID <= 0)
                return BadRequest("Invalid LitigationOID");

            int result = await _service.DeleteUnitMembersAsync(litigationOID);

            if (result <= 0)
                return NotFound("No unit members found to delete");

            return Ok(new
            {
                message = "Unit members deleted successfully",
                litigationOID,
                rowsAffected = result
            });
        }

        [HttpDelete("DeleteUnderAct")]
        public async Task<IActionResult> DeleteUnderAct([FromQuery]  int litigationOID=0)
        {
            if (litigationOID <= 0)
                return BadRequest("Invalid LitigationOID");

            int result = await _service.DeleteUnderAct(litigationOID);

           

            return Ok(new
            {
                message = "Under Act deleted successfully",
                litigationOID,
                rowsAffected = result
            });
        }

        [HttpDelete("DeleteRow_CompanyLawFirmAdvocate")]
        public async Task<IActionResult> DeleteLawFirmAdvocate(
    [FromBody] DeleteLawFirmAdvocateRequest request)
        {
            if (request == null)
                return BadRequest("Invalid request");

            var data = await _service.DeleteLawFirmAdvocateAsync(request);

            return Ok(new
            {
                Success = true,
                Message = "Law Firm Advocate deleted successfully",
                Data = data
            });
        }

        [HttpDelete("DeleteRow_CounterPartiesLawFirm")]
        public async Task<IActionResult> DeleteCounterLawFirm(
        [FromBody] DeleteCounterLawFirmRequest request)
        {
            if (request == null)
                return BadRequest("Invalid request");

            var data = await _service.DeleteCounterLawFirmAsync(request);

            return Ok(new
            {
                Success = true,
                Message = "Counter Party Law Firm deleted successfully",
                Data = data
            });
        }
        [HttpDelete("DeleteRow_SubCategory")]
        public async Task<IActionResult> DeleteSubCategory(
        [FromBody] DeleteSubCategoryRequest request)
        {
            var data = await _service.DeleteSubCategoryAsync(request);

            return Ok(new
            {
                Success = true,
                Message = "SubCategory deleted successfully",
                Data = data
            });
        }
        [HttpDelete("DeleteLitigationHearinDate")]
        public async Task<IActionResult> DeleteLitigationHearinDate([FromQuery] int LitigationHearingOID = 0)
        {
            var result = await _service.DeleteLitigationHearing(LitigationHearingOID);
            return Ok(result);
        }
        [HttpDelete("DeletePowerOfAttorneyDocument")]
        public async Task<IActionResult> DeletePowerOfAttorneyDocument([FromQuery] int DocOID = 0)
        {
            var result = await _service.DeletePowerOfAttorneyDocument(DocOID);
            return Ok(result);
        }
        [HttpDelete("DeleteBilling")]
        public async Task<IActionResult> DeleteBilling([FromQuery] int BillingOID = 0)
        {
            var result = await _service.DeleteBilling(BillingOID);
            return Ok(result);
        }

        [HttpDelete("DeleteWitness")]
        public async Task<IActionResult> DeleteWitness([FromQuery] int WitnessOID = 0)
        {
            var result = await _service.DeleteWitness(WitnessOID);
            return Ok(result);
        }
        [HttpDelete("deletelitigatiotaskdocument")]
        public async Task<IActionResult> deletelitigatiotaskdocument([FromQuery] int DocOID = 0)
        {
            var result = await _service.deletelitigatiotaskdocument(DocOID);
            return Ok(result);
        }
        #endregion
        /// <summary>
        /// Update Method Start
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
#region Update Method
        [HttpPut("UpdateClientContact")]
        public async Task<IActionResult> UpdateClientContact(
       [FromBody] UpdateClientContactRequest request)
        {
            var result = await _service.UpdateClientContactAsync(request);

            if (result.RowsAffected == 0)
                return NotFound("No matching client contact found");

            return Ok(result);
        }
       
        [HttpPut("UpdateLitigationDetails1")]
        public async Task<IActionResult> UpdateLitigationDetails1(
        [FromBody] UpdateLitigationDetailsRequest request)
        {
            if (request == null || request.LitigationOID <= 0)
                return BadRequest("Invalid litigation data");

            bool success = await _service.UpdateLitigationDetailsAsync(request);

            if (!success)
                return BadRequest("Litigation update failed");

            return Ok(new
            {
                message = "Litigation details updated successfully",
                litigationOID = request.LitigationOID
            });
        }

        [HttpPut("UpdateFinalStatus")]
        public async Task<IActionResult> UpdateFinalStatus(
      [FromQuery] string Status, int LitigationOID)
        {
            var result = await _service.UpdateFinalStatus(Status, LitigationOID);

            if (result == false)
                return NotFound("No matching client contact found");

            return Ok(result);
        }
        #endregion
        #endregion

        #region Litigation Details Page API's
        #region Get Litigation Details Page API's
        [HttpGet("ShowLitigationDetails")]
        public async Task<IActionResult> GetLitigationDetailbyLitigationOID([FromQuery] int LitigationOID = 0)
        {
            var result = await _service.GetLitigationDetailbyLitigationOID(LitigationOID);
            return Ok(result);
        }
        [HttpGet("GetConfidentialTypeApplicable")]
        public async Task<IActionResult> GetConfidentialTypeApplicable([FromQuery] int UnitOID = 0)
        {
            var result = await _service.GetConfidentialTypeApplicable(UnitOID);
            return Ok(result);
        }
        [HttpGet("GetLitigationVehicleDealerDetails")]
        public async Task<IActionResult> GetLitigationVehicleDealerDetails([FromQuery] int LitigationOID = 0)
        {
            var result = await _service.GetLitigationVehicleDealerDetails(LitigationOID);
            return Ok(result);
        }
        [HttpGet("GetLitigationLabourDetails")]
        public async Task<IActionResult> GetLitigationLabourDetails([FromQuery] int LitigationOID = 0)
        {
            var result = await _service.GetLitigationLabourDetails(LitigationOID);
            return Ok(result);
        }
        [HttpGet("CheckBucketListForLitigation")]
        public async Task<IActionResult> CheckBucketListForLitigation([FromQuery] int UserOID=0, int intLitigationOID=0, int intEntity=0, int intUnit=0)
        {
            var result = await _service.CheckBucketListForLitigation( UserOID,  intLitigationOID,  intEntity,  intUnit);
            return Ok(result);
        }
        [HttpGet("GetLitigationDocumentsByDocOID")]
        public async Task<IActionResult> GetLitigationDocumentsByDocOID(int docID)
        {
            var result = await _service.GetPowerOfAttorneyDocumentByDOCOID(docID);

            if (result == null || result.Filebyte == null)
                return NotFound();

            return File(result.Filebyte, "application/octet-stream", result.DocumentName);
        }
        [HttpGet("GetLitigationStages")]
        public async Task<IActionResult> GetLitigationStageSummary([FromQuery] int LitigationOID = 0)
        {
            var result = await _service.GetLitigationStageSummary(LitigationOID);
            return Ok(result);
        }
        [HttpGet("BindCompanyLawFirm")]
        public async Task<IActionResult> GetPartiesByLitigationAndPartyType([FromQuery] int LitigationOID = 0,int PartyTypeOID=0)
        {
            var result = await _service.GetPartiesByLitigationAndPartyType(LitigationOID,PartyTypeOID);
            return Ok(result);
        }
        [HttpGet("BindBillingTypeDDL")]
        public async Task<IActionResult> GetBillTypesForLitigation()
        {
            var result = await _service.GetBillTypesForLitigation();
            return Ok(result);
        }
        [HttpGet("BindHearingDateDDL")]
        public async Task<IActionResult> GetLitigationStageHearingDates([FromQuery] int LitigationOID = 0)
        {
            var result = await _service.GetLitigationStageHearingDates(LitigationOID);
            return Ok(result);
        }
        [HttpGet("GetLitigationBillingDetails")]
        public async Task<IActionResult> GetLitigationBillingSummary([FromQuery] int LitigationOID = 0)
        {
            var result = await _service.GetLitigationBillingSummary(LitigationOID);
            return Ok(result);
        }
        [HttpGet("ShowLitigationWithness")]
        public async Task<IActionResult> GetWitness([FromQuery] int LitigationOID = 0)
        {
            var result = await _service.GetWitness(LitigationOID);
            return Ok(result);
        }
        [HttpGet("GetAlertDataForLitigation")]
        public async Task<IActionResult> GetAlertforLitigation([FromQuery] int litigationOID)
        {
            var result = await _service.GetAlertforLitigation(litigationOID);
            return Ok(result);
        }
        [HttpGet("GetFromMailID")]
        public async Task<IActionResult> GetFromMailID()
        {
            var result = await _service.GetFromMailID();
            return Ok(result);
        }
        [HttpGet("GetApplicationLink")]
        public async Task<IActionResult> GetApplicationLink()
        {
            var result = await _service.GetApplicationLink();
            return Ok(result);
        }
        [HttpGet("BindResultDDL")]
        public async Task<IActionResult> GetLitigationResultMaster()
        {
            var result = await _service.GetLitigationResultMaster();
            return Ok(result);
        }
        [HttpGet("GetConnectedNotices")]
        public async Task<IActionResult> GetNoticesforConnectedLitigation([FromQuery] int LitigationOID = 0, int CurrentLitigaionOID=0,int UserOID=0, string txtsearch="")
        {
            
            var result = await _service.GetNoticesforConnectedLitigation(LitigationOID,CurrentLitigaionOID,UserOID,txtsearch);
            return Ok(result);
        }
        [HttpGet("GetConnectedLitigations")]
        public async Task<IActionResult> GetLitigationforConnectedLitigation([FromQuery] int LitigationOID = 0, int CurrentLitigaionOID = 0, int UserOID = 0, string txtsearch = "")
        {

            var result = await _service.GetLitigationforConnectedLitigation(LitigationOID, CurrentLitigaionOID, UserOID, txtsearch);
            return Ok(result);
        }
        [HttpGet("GetConnectedArbitrations")]
        public async Task<IActionResult> GetArbitrationsforConnectedLitigation([FromQuery] int LitigationOID = 0, int CurrentLitigaionOID = 0, int UserOID = 0, string txtsearch = "")
        {

            var result = await _service.GetArbitrationsforConnectedLitigation(LitigationOID, CurrentLitigaionOID, UserOID, txtsearch);
            return Ok(result);
        }
        [HttpGet("GetLitigationDocuments")]
        public async Task<IActionResult> GetLitigationDocuments([FromQuery] int MasterOID = 0,string DocType="")
        {
            var result = await _service.GetLitigationDocuments(MasterOID, DocType);
            return Ok(result);
        }
        [HttpGet("BindPartyEmail")]
        public async Task<IActionResult> BindPartyEmail([FromQuery] int LitigationOID = 0)
        {
            var result = await _service.BindPartyEmail(LitigationOID);
            return Ok(result);
        }
        [HttpGet("BindResponsiblePerson")]
        public async Task<IActionResult> GetResponsiblePerson([FromQuery] int LitigationOID = 0,int ArbtrationOID=0)
        {
            var result = await _service.GetResponsiblePerson(LitigationOID, ArbtrationOID);
            return Ok(result);
        }
        [HttpGet("GetLitigationDocumentsforDetails")]
        public async Task<IActionResult> GetLitigationDocumentsforDetails([FromQuery] int GeneralHearingOID=0, string DocType="")
        {
            var result = await _service.GetLitigationDocumentsforDetails(GeneralHearingOID,DocType);
            return Ok(result);
        }
        [HttpGet("BindActivityLog")]
        public async Task<IActionResult> GetLitigationActivityLog([FromQuery] int LitigationOID = 0)
        {
            var result = await _service.GetLitigationActivityLog(LitigationOID);
            return Ok(result);
        }

        [HttpGet("BindLibraryType")]
        public async Task<IActionResult> GetLibraryTypes()
        {
            var result = await _service.GetLibraryTypes();
            return Ok(result);
        }
        [HttpGet("BindEntityDDL")]
        public async Task<IActionResult> GetAllEntitiesByUser([FromQuery] int UserOID = 0)
        {
            var result = await _service.GetAllEntitiesByUser(UserOID);
            return Ok(result);
        }
        [HttpGet("GetCaseBackground")]
        public async Task<IActionResult> GetCaseBackground([FromQuery] int LitigationOID = 0)
        {
            var result = await _service.GetCaseBackground(LitigationOID);
            return Ok(result);
        }
        [HttpGet("GetAllInterimProceeding")]
        public async Task<IActionResult> GetAllInterimProceeding([FromQuery] int LitigationOID = 0)
        {
            var result = await _service.GetAllInterimProceeding(LitigationOID);
            return Ok(result);
        }
        [HttpGet("GetAllInterimAppeal")]
        public async Task<IActionResult> GetAllInterimAppeal([FromQuery] int LitigationOID = 0)
        {
            var result = await _service.GetAllInterimAppeal(LitigationOID);
            return Ok(result);
        }
        [HttpGet("GeteReferenceLibraryForLitigations")]
        public async Task<IActionResult> GeteReferenceLibraryForLitigations([FromQuery] int LitigationOID=0, int CurrentLitigaionOID=0)
        {
            var result = await _service.GeteReferenceLibraryForLitigations(LitigationOID, CurrentLitigaionOID);
            return Ok(result);
        }
        [HttpGet("GetBillingDetails")]
        public async Task<IActionResult> GetLitigationBillingDetailsForUpdate([FromQuery] int billingOID)
        {
            var result = await _service.GetLitigationBillingDetailsForUpdate(billingOID);
            return Ok(result);
        }
        [HttpGet("GetPartyContacts")]
        public async Task<IActionResult> GetPartyContacts([FromQuery] int partyMasterOID)
        {
            var result = await _service.GetPartyContacts(partyMasterOID);
            return Ok(result);
        }
        [HttpGet("GetChequeforConnectedLitigation")]
        public async Task<IActionResult> GetChequeforConnectedLitigation([FromQuery] int LitigationOID = 0, int CurrentLitigaionOID = 0,int UserOID=0)
        {
            var result = await _service.GetChequeforConnectedLitigation(LitigationOID, CurrentLitigaionOID,UserOID);
            return Ok(result);
        }
        [HttpGet("GetLitigationAlertEmail")]
        public async Task<IActionResult> GetLitigationForAlertEmailbyLitigationOID([FromQuery] int litigationOID)
        {
            var result = await _service.GetLitigationForAlertEmailbyLitigationOID(litigationOID);
            return Ok(result);
        }
        [HttpGet("GetUserEmailID")]
        public async Task<IActionResult> GetUserEmailID([FromQuery] int preparatoryOID)
        {
            var result = await _service.GetUserEmailID(preparatoryOID);
            return Ok(result);
        }
        [HttpGet("GetUserName")]
        public async Task<IActionResult> GetUserName([FromQuery] int preparatoryOID)
        {
            var result = await _service.GetUserName(preparatoryOID);
            return Ok(result);
        }
        [HttpGet("GetMaterialChangeCommunication")]
        public async Task<IActionResult> GetMaterialChangeCommunication([FromQuery] int litigationOID)
        {
            var result = await _service.GetMaterialChangeCommunication(litigationOID);
            return Ok(result);
        }
        [HttpGet("GetREMforConnectedLitigation")]
        public async Task<IActionResult> GetREMforConnectedLitigation([FromQuery]int LitigationOID, int CurrentLitigaionOID, int UserOID)
        {
            var result = await _service.GetREMforConnectedLitigation(LitigationOID,CurrentLitigaionOID, UserOID);
            return Ok(result);
        }
        [HttpGet("Ifalreadytaskowner")]
        public async Task<IActionResult> Ifalreadytaskowner([FromQuery] int LitigationOID,  int UserOID)
        {
            var result = await _service.Ifalreadytaskowner(LitigationOID, UserOID);
            return Ok(result);
        }
        [HttpGet("GetAdvocateEmail")]
        public async Task<IActionResult> GetLawFirmAdvocateUserEmailID([FromQuery] int preparatoryOID)
        {
            var result = await _service.GetLawFirmAdvocateUserEmailID(preparatoryOID);
            return Ok(result);
        }
        [HttpGet("GetLitigationTaskBylitigationId")]
        public async Task<IActionResult> GetLitigationTaskBylitigationid([FromQuery] int LitigationOID, int UserOID)
        {
            var result = await _service.GetLitigationTaskBylitigationid(LitigationOID, UserOID);
            return Ok(result);
        }
        #endregion
        #region Post Litigation Details Page API's
        [HttpPost("CheckValidHearingDate")]
        public async Task<IActionResult> CheckValidHearingDate(
        [FromBody] CheckHearingDateRequest request)
        {
            if (request == null)
                return BadRequest("Invalid request");

            bool isValid = await _service.CheckValidHearingDateAsync(request);

            return Ok(new
            {
                Success = true,
                IsValid = isValid
            });
        }
        [HttpPost("InsertCaseTypeStage")]
        public async Task<IActionResult> InsertCaseTypeStage(
        [FromBody] InsertCaseTypeStageRequest request)
        {
            var (result, hearingStageOID) =
                await _service.InsertCaseTypeStageAsync(request);

            return Ok(new
            {
                Success = true,
                RowsAffected = result,
                LigationHearingStageOID = hearingStageOID
            });
        }

        [HttpPost("InsertLitigationActionItem")]
        public async Task<IActionResult> InsertLitigationActionItem(
        [FromBody] InsertLitigationActionItemsRequest request)
        {
            int result =
                await _service.InsertLitigationActionItemsAsync(request);

            return Ok(new
            {
                Success = true,
                Message = "Action items inserted successfully",
                RowsAffected = result
            });
        }

        [HttpPost("InsertLitigationDocument")]
        public async Task<IActionResult> InsertLitigationDocument(
       [FromBody] InsertLitigationStageDocumentsRequest request)
        {
            int result =
                await _service.InsertLitigationStageDocumentsAsync(request);

            return Ok(new
            {
                Success = true,
                Message = "Litigation stage documents saved successfully",
                DocumentsInserted = result
            });
        }

        [HttpPost("LibraryDocAdd_Click")]
        public async Task<IActionResult> Upload(
    [FromBody] InsertLibraryDocumentRequest request)
        {
            int docOID = await _service.UploadLibraryDocumentAsync(request);

            return Ok(new
            {
                Success = true,
                Message = "Document uploaded successfully",
                DocOID = docOID
            });
        }

        [HttpPost("InsertBillingDetails")]
        public async Task<IActionResult> InsertBillingDetails(
        [FromBody] BillingDetailsRequest request)
        {
            int billingOID = await _service.InsertBillingAsync(request);

            return Ok(new
            {
                Success = true,
                BillingOID = billingOID,
                Message = "Billing details inserted successfully"
            });
        }
        [HttpPost("InsertConnectedCheque")]
        public async Task<IActionResult> InsertConnectedCheque(int litigationOID, int chequeOID,int isConnected)
        {
            var result = await _service.InsertConnectedCheque(litigationOID, chequeOID, isConnected);

            if (result > 0)
                return Ok(new { success = true, message = "Inserted successfully" });

            return BadRequest(new { success = false, message = "Insert failed" });
        }
        
        #endregion

        #region Update Litigation Details Page API
        [HttpPut("UpdateLitigationLastModifiedDate")]
        public async Task<IActionResult> UpdateLitigationLastModifiedDate(
      [FromBody] int LitigationOID=0)
        {
            var result = await _service.UpdateLitigationLastModifiedDate(LitigationOID);

            if (result == false)
                return NotFound("No matching client contact found");

            return Ok(result);
        }
        [HttpPut("UpdateBillingDetails")]
        public async Task<IActionResult> UpdateBillingDetails(
        [FromBody] BillingDetailsRequest request)
        {
            int result = await _service.UpdateBillingAsync(request);

            return Ok(new
            {
                Success = true,
                Message = "Billing details updated successfully"
            });
        }

        [HttpPost("UpdateCompletionDetails")]
        public async Task<IActionResult> UpdateCompletionDetails([FromBody] CompletionDetailsDto model)
        {
            var result = await _service.UpdateCompletionDetails(model);

            if (result > 0)
                return Ok(new { success = true, message = "Updated successfully" });

            return BadRequest(new { success = false, message = "Update failed" });
        }
        [HttpPost("UpdateLitigationActionItem")]
        public async Task<IActionResult> UpdateLitigationActionItem([FromBody] ActionItemUpdateDto model)
        {
            var result = await _service.UpdateLitigationActionItem(model);

            if (result > 0)
                return Ok(new { success = true, message = "Updated successfully" });

            return BadRequest(new { success = false, message = "Update failed" });
        }
        [HttpPost("InsertConnectedREM")]
        public async Task<IActionResult> InsertConnectedREM(int litigationOID,int realEstateOID,int isConnected)
        {
            var result = await _service.InsertConnectedREM(litigationOID, realEstateOID, isConnected);

            if (result > 0)
                return Ok(new { success = true, message = "Inserted successfully" });

            return BadRequest(new { success = false, message = "Insert failed" });
        }
        [HttpPost("UpdateDocUploadStatus")]
        public async Task<IActionResult> UpdateDocUploadStatusfornotices(int litigationDraftOID,int draftStatusOID)
        {
            var result = await _service.UpdateDocUploadStatusfornotices(litigationDraftOID, draftStatusOID);

            if (result > 0)
                return Ok(new { success = true, message = "Status updated successfully" });

            return BadRequest(new { success = false, message = "Update failed" });
        }
        [HttpPost("UpdateDraftStatusNotices")]
        public async Task<IActionResult> UpdateDraftstatusNotices( int noticeDraftOID,int draftStatusOID,string assigneeComment, string reviewerComment)
        {
            var result = await _service.UpdateDraftstatusNotices(noticeDraftOID,draftStatusOID, assigneeComment,reviewerComment);

            if (result > 0)
                return Ok(new { success = true, message = "Status updated successfully" });

            return BadRequest(new { success = false, message = "Update failed" });
        }
        [HttpPost("InsertLitigationDrafting")]
        public async Task<IActionResult> InsertLitigationForDrafting([FromBody] List<LitigationDraftingDto> list)
        {
            var result = await _service.InsertLitigationForDrafting(list);

            return result > 0
                ? Ok(new { success = true })
                : BadRequest(new { success = false });
        }
        [HttpPost("AssignBucket")]
        public async Task<IActionResult> AssignMyBucketListForLitigationByDetails(int userOID, int litigationOID, int entityOID,int unitOID)
        {
            var result = await _service.AssignMyBucketListForLitigationByDetails( userOID,litigationOID,entityOID, unitOID
            );

            if (result > 0)
                return Ok(new { success = true, message = "Assigned successfully" });

            return BadRequest(new { success = false, message = "Assignment failed" });
        }
        #endregion

        #region Delete Litigation Details Page API's
        [HttpDelete("DeleteInterimRecord")]
        public async Task<IActionResult> DeleteInterimRecord([FromRoute] int MasterOID, string Type)
        {
           
            var result = await _service.DeleteInterimRecord(MasterOID, Type);
            return Ok(result);
        }
        [HttpDelete("DeleteConnectedNotice")]
        public async Task<IActionResult> DeleteConnectedNotice([FromRoute] int NoticeOID, int LitigationOID)
        {

            var result = await _service.DeleteConnectedNotice(NoticeOID, LitigationOID);
            return Ok(result);
        }
        [HttpDelete("DeleteConnectedLitigationFromLitigation")]
        public async Task<IActionResult> DeleteConnectedLitigationFromLitigation([FromRoute] int Connected_LitigationOID, int LitigationOID)
        {

            var result = await _service.DeleteConnectedLitigationFromLitigation(Connected_LitigationOID, LitigationOID);
            return Ok(result);
        }
        [HttpDelete("DeleteConnectedCheque")]
        public async Task<IActionResult> DeleteConnectedCheque([FromRoute] int ChequeOID, int LitigationOID)
        {

            var result = await _service.DeleteConnectedCheque(ChequeOID, LitigationOID);
            return Ok(result);
        }
        #endregion

        #endregion

        #region Litigation Summary API's

        [HttpGet("BindGridViewLitigationSummary")]
        public async Task<IActionResult> BindGridViewLitigationSummary()
        {
            var result = await _service.BindGridViewLitigationSummary();
            return Ok(result);
        }

        [HttpGet("BindLitigationDraftSummary")]
        public async Task<IActionResult> BindLitigationDraftSummary([FromRoute] int UserOID = 0)
        {
            var result = await _service.BindLitigationDraftSummary(UserOID);
            return Ok(result);
        }

        [HttpDelete("DeleteLitigation/{litigationOID}")]
        public async Task<IActionResult> DeleteLitigation([FromRoute] int litigationOID)
        {
            if (litigationOID <= 0)
                return BadRequest("Invalid LitigationOID");

            var result = await _service.DeleteLitigation(litigationOID);
            return Ok(result);
        }

        #endregion

        /// <summary>
        /// Update Litigation Page API 
        /// </summary>
        /// <param name="LitigationOID"></param>
        /// <returns></returns>

        #region Update Litigation Page API

        [HttpDelete("DeleteConnectedLitigation")]
        public async Task<IActionResult> DeleteConnectedLitigation([FromRoute] int litigationOID)
        {
            if (litigationOID <= 0)
                return BadRequest("Invalid LitigationOID");

            var result = await _service.DeleteConnectedLitigation(litigationOID);
            return Ok(result);
        }
        [HttpPut("UpdateLitigationDetails")]
        public async Task<IActionResult> UpdateLitigationDetails(
        [FromBody] LitigationUpdateRequest request)
        {
            if (request == null)
                return BadRequest("Request body cannot be null");

            try
            {
                bool isUpdated = await _service.UpdateLitigationAsync(request);

                if (!isUpdated)
                {
                    return Ok(new
                    {
                        Success = false,
                        Message = "No records were updated"
                    });
                }

                return Ok(new
                {
                    Success = true,
                    Message = "Litigation updated successfully"
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new
                {
                    Success = false,
                    Message = ex.Message
                });
            }
            catch (Exception)
            {
                // log exception here
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Success = false,
                    Message = "An unexpected error occurred"
                });
            }
        }
        [HttpGet("GetLitigationDocumentsPOABRLOA")]
        public async Task<IActionResult> GetLitigationDocumentsPOABRLOA([FromQuery] int LitigationOID=0, string DocType="")
        {
            var result = await _service.GetLitigationDocumentsPOABRLOA(LitigationOID, DocType);
            return Ok(result);
        }

        #endregion

        #region Litigation Report
        [HttpGet("GetLitigationIDforReport")]
        public async Task<IActionResult> GetLitigationIDforReport([FromQuery] int UserOID = 0, int UnitOID = 0)
        {
            var result = await _service.GetLitigationIDforReport(UserOID, UnitOID);
            return Ok(result);
        }

        [HttpGet("GetLitigationDetailforReport")]
        public async Task<IActionResult> GetLitigationDetailforReport([FromQuery] int LitigationOID = 0, int UserOID = 0)
        {
            var result = await _service.GetLitigationDetailforReport(LitigationOID,UserOID);
            return Ok(result);
        }

        [HttpGet("GetLitigationActionItemSummary")]
        public async Task<IActionResult> GetLitigationActionItemSummary([FromQuery] int LitigationOID = 0)
        {
            var result = await _service.GetLitigationActionItemSummary(LitigationOID);
            return Ok(result);
        }
        [HttpPost("GetLitigationMetrics")]
        public async Task<IActionResult> GetLitigationMetrics([FromBody] LitigationMetricsFilterDto filter)
        {
            var result = await _service.GetLitigationMetricsReport(filter);
            return Ok(result);
        }
        [HttpPost("GetMISReport")]
        public async Task<IActionResult> GetMISReport([FromBody] MISReportFilterDto filter)
        {
            var result = await _service.GetMISReport(filter);
            return Ok(result);
        }
        [HttpPost("GetMISReportUnitWise")]
        public async Task<IActionResult> GetMISReportUnitWise([FromBody] MISReportUnitWiseFilterDto filter)
        {
            var result = await _service.GetMISReportUnitWise(filter);
            return Ok(result);
        }
        [HttpGet("GetBillTypes")]
        public async Task<IActionResult> GetBillTypes()
        {
            var result = await _service.GetBillTypes();
            return Ok(result);
        }
        [HttpGet("GetCompanyLawFirmByLitigationAndPartyType")]
        public async Task<IActionResult> GetCompanyLawFirmByLitigationAndPartyType([FromQuery] int LitigationOID = 0, int PartyTypeOID=0)
        {
            var result = await _service.GetCompanyLawFirmByLitigationAndPartyType(LitigationOID, PartyTypeOID);
            return Ok(result);
        }
        [HttpPost("GetLitigationBillingReport")]
        public async Task<IActionResult> GetLitigationBillingReport([FromBody] LitigationBillingReportFilterDto filter)
        {
            var result = await _service.GetLitigationBillingReport(filter);
            return Ok(result);
        }
        [HttpPost("GetCauseList")]
        public async Task<IActionResult> GetCauseListReport([FromBody] CauseListFilterDto filter)
        {
            var result = await _service.GetCauseListReport(filter);
            return Ok(result);
        }
        //[HttpPost("ImportLitigation")]
        //public async Task<IActionResult> InsertLitigationFromImport([FromBody] SupremeCourtImportDto dto)
        //{
           

        //    var result = await _service.InsertLitigationFromImport(dto);

        //    return result > 0
        //        ? Ok(new { success = true, litigationOID = result })
        //        : BadRequest(new { success = false });
        //}
        #endregion
    }


}
