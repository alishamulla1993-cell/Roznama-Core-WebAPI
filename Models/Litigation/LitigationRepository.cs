using Dapper;
using Microsoft.AspNetCore.Connections;
using Microsoft.Data.SqlClient;
using Roznama.Infrastructure.Database;
using Roznama.Models.Litigation.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Threading.Tasks;

namespace Roznama.Models.Litigation
{
    public class LitigationRepository : RepositoryBase
    {
        public LitigationRepository(DbConnectionFactory dbFactory, DapperHelper dapper) : base(dbFactory, dapper) { }

        #region Add Litigation Page API's
        public async Task<IEnumerable<dynamic>> GetNoticeDetailsByNoticeOID(int NoticeOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetNoticeDetailbyNoticeOID", new
            {
                NoticeOID = NoticeOID


            });
        }
        public async Task<IEnumerable<dynamic>> GetLitigationID(int LitigationOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetLitigationIDBYLitigationOID", new
            {
                LitigationOID = LitigationOID


            });
        }

        public async Task<IEnumerable<dynamic>> GetMSILFileNo(string LitigationID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetMSILFileByLitigationID", new
            {
                LitigationID = LitigationID


            });
        }

        public async Task<IEnumerable<dynamic>> GetCourtCaseTitle(int LitigationOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetCourtCaseTitle", new
            {
                LitigationOID = LitigationOID


            });
        }

        public async Task<IEnumerable<dynamic>> GetLitigationAllDetailbyLitigationOID(int LitigationOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetLitigationAllDetailbyLitigationOID", new
            {
                LitigationOID = LitigationOID


            });
        }

        public async Task<IEnumerable<dynamic>> GetCompanyAdvocateDetails(int LitigationOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetCompanyAdvocateDetails", new
            {
                LitigationOID = LitigationOID


            });
        }
        public async Task<IEnumerable<dynamic>> GetSubcourt(int Courttype)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "CasewiseCrawlerGetSubCourt", new
            {
                Courttype = Courttype


            });
        }
        public async Task<IEnumerable<dynamic>> GetAllCourtType(string DigitizedOrNonDigitized)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "CasewiseCrawlerGetCourtType", new
            {
                DigitizedOrNonDigitized = DigitizedOrNonDigitized


            });
        }

        public async Task<IEnumerable<StateDto>> GetStatesByCourtTypeAsync(
       int courtTypeOID)
        {
            using var conn = CreateConnection();

            // CourtType = 5 → All States
            if (courtTypeOID == 5)
            {
                return await _dapper.QueryAsync<StateDto>(
                    conn,
                    "CasewiseCrawlerSpGetAllStateByCourtType",
                    new { }
                );
            }
            // Other Court Types → Consumer States
            else
            {
                return await _dapper.QueryAsync<StateDto>(
                    conn,
                    "CasewiseCrawlerSpGetConsumerState",
                    new { }
                );
            }
        }
        //public async Task<IEnumerable<dynamic>> GetAllStateByCourtType()
        //{
        //    using var conn = CreateConnection();
        //    return await _dapper.QueryAsync<dynamic>(conn, "CasewiseCrawlerSpGetAllStateByCourtType", new
        //    {
        //    });
        //}
        public async Task<IEnumerable<dynamic>> GetCasewiseCrawlerSpGetConsumerState()
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "CasewiseCrawlerSpGetConsumerState", new
            {
            });
        }
        public async Task<IEnumerable<dynamic>> GetAllDistrict(int StateOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "CasewiseCrawlerGetAllDistrict", new
            {
                STATEOID = StateOID
            });
        }
        public async Task<IEnumerable<dynamic>> GetBench(int intCourtType, string CourtSubType, int state, int district, int CourtComplex)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "CasewiseCrawlerGetbench", new
            {
                CourtTypeOID = intCourtType,
                SubCourtValuefield = CourtSubType,
                StateOID = state,
                DistrictOID = district,
                CourtComplex = CourtComplex
            });
        }
        public async Task<IEnumerable<dynamic>> GetCaseTypeData(int intCourtType, string CourtSubType, int state, int district, int CourtComplex, string CourtValueField)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "CasewiseCrawlerGetcasetypedata", new
            {
                CourtTypeOID = intCourtType,
                SubCourtValuefield = CourtSubType,
                StateOID = state,
                DistrictOID = district,
                CourtComplex = CourtComplex,
                CourtValueField = CourtValueField
            });
        }

        public async Task<IEnumerable<dynamic>> GetNonDigitizeCourtMaster()
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetNonDigitizeCourtMaster", new
            {

            });
        }
        public async Task<IEnumerable<dynamic>> GetNonDigitizeCaseTypeMaster()
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetNonDigitizeCaseTypeMaster", new
            {

            });
        }
        public async Task<IEnumerable<dynamic>> GetAllUnderAct()
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetAllUnderAct", new
            {

            });
        }
        public async Task<IEnumerable<dynamic>> GetAllSubjectMatter()
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetAllSubjectMatter", new
            {

            });
        }
        public async Task<IEnumerable<dynamic>> GetAllCaseTypeTribunal(int courttypeoid, int stateoid, int TribunalOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetAllCaseTypeTribunal", new
            {
                courttypeOID = courttypeoid,
                stateoid = stateoid,
                TribunalOID = TribunalOID
            });
        }

        public async Task<IEnumerable<dynamic>> GetAllCaseType(int courttypeoid, int stateoid)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetCaseTypestatewise", new
            {
                courttypeOID = courttypeoid,
                stateoid = stateoid

            });
        }
        public async Task<IEnumerable<dynamic>> GetAllCaseTypeConsumer(int courttypeoid, int stateoid, int ConsumerOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetAllCaseTypeConsumer", new
            {
                courttypeOID = courttypeoid,
                stateoid = stateoid,
                ConsumerOID = ConsumerOID
            });
        }
        public async Task<IEnumerable<dynamic>> GetNameoftheConsumer()
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetNameoftheConsumer", new
            {
            });
        }
        public async Task<IEnumerable<dynamic>> GetNameoftheLabourCourt()
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetNameoftheLabourCourt", new
            {
            });
        }
        public async Task<IEnumerable<dynamic>> GetNameoftheTribunal()
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetNameoftheTribunal", new
            {
            });
        }
        public async Task<IEnumerable<dynamic>> GetMSILCaseType()
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetMSILCaseType", new
            {
            });
        }
        public async Task<IEnumerable<dynamic>> GetLinkedLitigation(int LitigationOID, int userOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetLinkedLitigation", new
            {
                LitigationOID = LitigationOID,
                UserOID = userOID
            });
        }
        public async Task<IEnumerable<dynamic>> GetArbitrationOID()
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetArbitrationOID", new
            {
            });
        }
        public async Task<IEnumerable<dynamic>> GetMasterDetailData(string Type)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetMasterDetailData", new { Type = Type });
        }
        public async Task<IEnumerable<dynamic>> GetMasterDetailDataDealer()
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetMasterDetailData", new { Type = "DealersName" });
        }
        public async Task<IEnumerable<dynamic>> GetAllStages()
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetAllStages", new
            {
            });
        }
        public async Task<IEnumerable<dynamic>> GetCourtName(int intCourtType, int intState, int intDistrictOID, int intTribunalOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetCourtName", new
            {
                CourtTypeOID = intCourtType,
                StateOID = intState,
                DistrictOID = intDistrictOID,
                TribunalOID = intTribunalOID
            });
        }
        public async Task<int> CheckDuplicateCaseNumberAsync(
       int litigationOID,
       string caseNumber,
       int courtOID,
       int caseTypeOID)
        {
            using var conn = CreateConnection();

            return await _dapper.QuerySingleAsync<int>(
                conn,
                "CheckDuplicateCaseNumberNew",
                new
                {
                    LitigationOID = litigationOID,
                    CaseNumber = caseNumber,
                    CourtOID = courtOID,
                    CaseTypeOID = caseTypeOID
                }
            );
        }
        public async Task<IEnumerable<dynamic>> GetDirectorPromoterName(int UnitOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetDirectorPromoterName", new
            {
                UnitOID = UnitOID,

            });
        }
        public async Task<IEnumerable<PartyDetailsDto>> GetPartySummaryAsync(
        int partyTypeOID)
        {
            using var conn = CreateConnection();

            return await _dapper.QueryAsync<PartyDetailsDto>(
                conn,
                "GetPartyMaster",
                new { PartyTypeOID = partyTypeOID }
            );
        }
        public async Task<IEnumerable<PartyContactDto>> GetPartyContactsAsync(
        int partyMasterOID)
        {
            using var conn = CreateConnection();

            return await _dapper.QueryAsync<PartyContactDto>(
                conn,
                "GetClientContactDetails",
                new { PartyMasterOID = partyMasterOID }
            );
        }
        public async Task<IEnumerable<dynamic>> GetSubUnitDetail()
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetSubUnitDetail", new
            {
            });
        }
        public async Task<IEnumerable<PartyOtherDetailsDto>> GetPartySummaryOtherDetailAsync(
        int partyTypeOID)
        {
            using var conn = CreateConnection();

            return await _dapper.QueryAsync<PartyOtherDetailsDto>(
                conn,
                "GetPartyMaster",
                new { PartyTypeOID = partyTypeOID }
            );
        }
        public async Task<IEnumerable<dynamic>> GetCounterType(string companyType, int classificationTypeOID,
        int litigationCategoryOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetCounterType", new
            {
                ClassificationType = classificationTypeOID,
                LitigationCategoryOID = litigationCategoryOID,
                CompanyType = companyType
            });
        }
        public async Task<IEnumerable<dynamic>> GetSubCategory(int litigationCategoryOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetSubCategory", new
            {

                LitigationCategoryOID = litigationCategoryOID
            });
        }
        public async Task<IEnumerable<dynamic>> GetBombayCaseTypeData(int intCourtType, string CourtSubType, string CourtValueField, string stamp, string side)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "CasewiseCrawlerGetBombaycasetypedata", new
            {
                CourtTypeOID = intCourtType,
                subcourtvaluefield = CourtSubType,
                CourtValueField = CourtValueField,
                Side = side,
                Stamp_Regn = stamp
            });
        }
        public async Task<int> GetPartyMasterOIDAsync(
        int partyTypeOID,
        string partyName)
        {
            using var conn = CreateConnection();
            const string sql = @"
            SELECT ISNULL(PartyMasterOID, 0)
            FROM PartyMaster
            WHERE PartyTypeOID = @PartyTypeOID
              AND PartyName = @PartyName";

            return await conn.ExecuteScalarAsync<int>(
                sql,
                new
                {
                    PartyTypeOID = partyTypeOID,
                    PartyName = partyName
                });
        }
        public async Task<IEnumerable<dynamic>> GetLitigationforOppositeParty(string PartyName)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetLitigationforOppositeParty", new
            {

                PartyName = PartyName
            });
        }
        public async Task<IEnumerable<dynamic>> GetRiskDetail()
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetRiskDetail", new
            {
            });
        }
        public async Task<IEnumerable<dynamic>> GetClientDetails(int LitigationOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetClientDetails", new
            {
                LitigationOID=LitigationOID
            });
        }
        public async Task<string> GetUserEmailID(int preparatoryOID)
        {
            
                using var conn = CreateConnection();

                var result = await _dapper.QueryAsync<dynamic>(
                    conn,
                    "SELECT ISNULL(EMAIL_ID,'') AS EMAIL_ID FROM dbo.UserDetail WHERE USER_OID = @UserOID",
                    new { UserOID = preparatoryOID }
                );

                var data = result.FirstOrDefault();

                return data?.EMAIL_ID?.ToString() ?? "";
            
        }
        public async Task<string> GetUserName(int preparatoryOID)
        {
            using var conn = CreateConnection();

            var result = await conn.QueryFirstOrDefaultAsync<string>(
                "SELECT FIRST_NAME FROM dbo.UserDetail WHERE USER_OID = @UserOID",
                new { UserOID = preparatoryOID }
            );

            return result ?? "";
        }
        /// <summary>
        /// Post Method Start
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<List<UnitMemberDto>> GenerateUnitMembersAsync(
            GenerateUnitMemberRequest request)
        {
            // 👉 Later: SQL / Dapper / Stored Procedure here
            return await Task.FromResult(new List<UnitMemberDto>());
        }

        public async Task<List<MatterHandledByDto>> GenerateMatterHandledByAsync(
            GenerateMatterHandledByRequest request)
        {
            // 🔸 Future: DB / Stored Procedure logic if required
            return await Task.FromResult(new List<MatterHandledByDto>());
        }

        public async Task<List<PartyDto>> GeneratePartiesAsync(
           GeneratePartyRequest request)
        {
            // 🔸 Future DB / SP logic
            return await Task.FromResult(new List<PartyDto>());
        }

        public async Task<List<OppositePartyDto>> GenerateOppositePartiesAsync(
           GenerateOppositePartyRequest request)
        {
            // 🔸 DB / Stored Procedure can be added later
            return await Task.FromResult(new List<OppositePartyDto>());
        }

        public async Task<List<LawFirmAdvocateDto>> GenerateAsync(
          GenerateLawFirmAdvocateRequest request)
        {
            // DB / SP integration can be added later
            return await Task.FromResult(new List<LawFirmAdvocateDto>());
        }
        public async Task<List<LawFirmAdvocateCommonDto>> GenerateAsync(
            GenerateCounterLawFirmAdvocateRequest request)
        {
            // DB / SP logic can be added later
            return await Task.FromResult(new List<LawFirmAdvocateCommonDto>());
        }

        public async Task<List<SubCategoryDto>> GenerateSubCategoryAsync(
        GenerateSubCategoryRequest request)
        {
            var result = new List<SubCategoryDto>();
            int count = 0;

            // 🔹 Keep existing rows except deleted/duplicate one
            if (request.ExistingSubCategories != null &&
                request.ExistingSubCategories.Count > 0)
            {
                foreach (var item in request.ExistingSubCategories)
                {
                    if (item.SubCategoryOID != request.SubCategoryOID &&
                        !string.Equals(item.SubCategory,
                                       request.SubCategory,
                                       StringComparison.OrdinalIgnoreCase))
                    {
                        count++;
                        result.Add(new SubCategoryDto
                        {
                            SN = count.ToString(),
                            SubCategoryOID = item.SubCategoryOID,
                            SubCategory = item.SubCategory
                        });
                    }
                }
            }

            // 🔹 Add new SubCategory
            if (request.SubCategoryOID > 0 &&
                !string.IsNullOrWhiteSpace(request.SubCategory))
            {
                count++;
                result.Add(new SubCategoryDto
                {
                    SN = count.ToString(),
                    SubCategoryOID = request.SubCategoryOID,
                    SubCategory = request.SubCategory
                });
            }

            return await Task.FromResult(result);
        }

        //Add Under ACt
        public async Task<int> InsertNewUnderActAsync(string underAct)
        {
            using var conn = CreateConnection();

            return await _dapper.QuerySingleAsync<int>(
                conn,
                "InsertNewUnderAct",
                new { UnderAct = underAct }
            );
        }
        public async Task<int> InsertOtherUnderAct(string underAct)
        {
            using var conn = CreateConnection();

            return await _dapper.QuerySingleAsync<int>(
                conn,
                "InsertNewUnderAct",
                new { UnderAct = underAct }
            );
        }
        public async Task<int> InsertSubjectMatterAsync(string subjectMatterName)
        {
            using var conn = CreateConnection();

            // Stored procedure returns SubjectMatterOID
            return await _dapper.QuerySingleAsync<int>(
                conn,
                "InsertNewSubjectMatter",
                new { SubjectMatter = subjectMatterName }
            );
        }
        public async Task<int> InsertStageAsync(string stageName)
        {
            using var conn = CreateConnection();

            return await _dapper.QuerySingleAsync<int>(
                conn,
                "InsertStageNew",
                new
                {
                    StageName = stageName
                }
            );
        }

        public async Task<int> SaveDiscoveryAsync(DiscoverySelectionRequest req)
        {
            using var conn = CreateConnection();
            var p = new DynamicParameters();

            p.Add("@LitigationOID", req.LitigationOID);
            p.Add("@CoutTypeOID", req.CourtTypeOID);
            p.Add("@CourtName", req.CourtName);

            p.Add("@StateOID", req.StateOID);
            p.Add("@StateName", req.StateName);
            p.Add("@DistrictOID", req.DistrictOID);
            p.Add("@DistrictName", req.DistrictName);

            p.Add("@CaseNumber", req.CaseNumber);
            p.Add("@CaseYear", req.CaseYear);
            p.Add("@TypeOfCourtValue", req.TypeOfCourtValue);

            p.Add("@BenchValue", req.BenchValue);
            p.Add("@BenchName", req.BenchName);

            p.Add("@CaseTypeOID", req.CaseTypeOID);
            p.Add("@CaseTypeVal", req.CaseTypeOID);
            p.Add("@CaseTypeName", req.CaseTypeName);

            p.Add("@CourtComplexOID", req.CourtComplexOID);
            p.Add("@CourtComplexName", req.CourtComplexName);

            p.Add("@HighCourtOIDValue", req.HighCourtOIDValue);
            p.Add("@HighCourtName", req.HighCourtName);

            p.Add("@TribunalCourtOIDValue", req.TribunalCourtOIDValue);
            p.Add("@TribunalCourtName", req.TribunalCourtName);

            p.Add("@ConsumerCourtOIDValue", req.ConsumerCourtOIDValue);
            p.Add("@ConsumerCourtName", req.ConsumerCourtName);

            p.Add("@InsertUpdateFlag", req.InsertUpdateFlag);

            p.Add("@CaseWiseOID", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await conn.ExecuteAsync(
                "InsertDiscoverySelections",
                p,
                commandType: CommandType.StoredProcedure
            );

            return p.Get<int>("@CaseWiseOID");
        }
        public async Task<int> InsertLitigationPartyAsync(
        int partyMasterOID,
        int litigationOID)
        {
            using var conn = CreateConnection();

            return await conn.ExecuteAsync(
                "InsertLitigationParties",
                new
                {
                    PartyMasterOID = partyMasterOID,
                    LitigationOID = litigationOID
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> InsertCompanyLawyerContactAsync(
        CompanyLawFirmAdvocateDto dto,
        int litigationOID)
        {
            using var conn = CreateConnection();

            return await conn.ExecuteAsync(
                "InsertLawyersContactDetail",
                new
                {
                    PartyMasterOID = dto.PartyMasterOID,
                    LitigationOID = litigationOID,
                    NoticeOID = 0,
                    ContactPerson = dto.ContactPerson?.Trim() ?? "",
                    Address = dto.CompanyAdvocateAddress?.Trim() ?? "",
                    Email = dto.CompanyAdvocateEmail?.Trim() ?? "",
                    Phone = dto.CompanyAdvocatePhone?.Trim() ?? "",
                    CompanyLawFirmStateOID = dto.CompanyLawFirmStateOID,
                    CompanyLawFirmCityOID = dto.CompanyLawFirmCityOID,
                    BarCouncilNo = dto.BarCouncilNo?.Trim() ?? "",
                    RingiNo = dto.RingiNo?.Trim() ?? ""
                },
                commandType: CommandType.StoredProcedure
            );
        }

        // 🔹 Insert Opposite Party Contact Detail
        public async Task<int> InsertOppositePartyContactAsync(
            GenerateOppositePartyRequest dto,
            int litigationOID)
        {
            using var conn = CreateConnection();

            return await conn.ExecuteAsync(
                "InsertLawyersContactDetail",
                new
                {
                    PartyMasterOID = dto.PartyMasterOID,
                    LitigationOID = litigationOID,
                    NoticeOID = 0,
                    ContactPerson = dto.OtherPartiesContactPerson?.Trim() ?? "",
                    Address = dto.OtherPartiesAddress?.Trim() ?? "",
                    Email = dto.OtherPartiesEmail?.Trim() ?? "",
                    Phone = dto.OtherPartiesPhone?.Trim() ?? "",
                    PanCard = dto.OtherPartiesPanCard?.Trim() ?? "",
                    AadhaarNo = dto.OtherPartiesAadhaarNo?.Trim() ?? ""
                },
                commandType: CommandType.StoredProcedure
            );
        }
        // 🔹 Insert Counter Lawyers Contact Detail
        public async Task<int> InsertCounterLawyerContactAsync(
            CounterLawFirmDto dto,
            int litigationOID)
        {
            using var conn = CreateConnection();

            return await conn.ExecuteAsync(
                "InsertLawyersContactDetail",
                new
                {
                    PartyMasterOID = dto.PartyMasterOID,
                    LitigationOID = litigationOID,
                    NoticeOID = 0,
                    ContactPerson = dto.ContactPerson?.Trim() ?? "",
                    Address = dto.CounterAdvocateAddress?.Trim() ?? "",
                    Email = dto.CounterAdvocateEmail?.Trim() ?? "",
                    Phone = dto.CounterAdvocatePhone?.Trim() ?? ""
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<InsertLitigationOrgResponse> InsertLitigationOrgDetailAsync(
  InsertLitigationOrgRequest req)
        {
            using var conn = CreateConnection();

            var param = new DynamicParameters();

            param.Add("@ClassifactionOID", req.ClassificationOID);
            param.Add("@LitigationCategoryOID", req.CategoryOID);
            param.Add("@UnitOID", req.UnitOID);
            param.Add("@AuthorityOID", req.AuthorityOID);
            param.Add("@CreatedBy", req.CreatedBy);

            param.Add("@CompanyType", req.CompanyType);
            param.Add("@CounterType", req.CounterType);
            param.Add("@AuthorityNominee", req.AuthorityNominee);
            param.Add("@POAAvailable", req.POA);
            param.Add("@DirectorInvolved", req.DirectorInvolved);
            param.Add("@POABRLOA", req.POABRLOA);
            param.Add("@ByagainstStatutoryauthority", req.ByagainstStatutoryauthority);
            param.Add("@CircleZoneRegion", req.CircleZoneRegion);
            param.Add("@ConfidentialityType", req.ConfidentialityType);

            param.Add("@ContractNo", req.ContractNo);
            param.Add("@CustomerID", req.CustomerID);
            param.Add("@SubUnitOID", req.SubUnitOID);
            param.Add("@IsStaffOrExStaffInvolved", req.IsStaffOrExStaffInvolved);
            param.Add("@StaffOrExStaffDetails", req.StaffOrExStaffDetails);

            param.Add("@IsWilfulDefaulter", req.IsWilfulDefaulter);
            param.Add("@WilfulDefaulterDetails", req.WilfulDefaulterDetails);
            param.Add("@IsFraud", req.IsFraud);
            param.Add("@FraudDetails", req.FraudDetails);

            param.Add("@IsStaffAccountability", req.IsStaffAccountability);
            param.Add("@StaffAccountabilityDetails", req.StaffAccountabilityDetails);
            param.Add("@ValuerForFraud", req.ValuerForFraud);
            param.Add("@AdvocateForFraud", req.AdvocateForFraud);
            param.Add("@ApprovedValuerOID", req.ApprovedValuerOID);

            param.Add("@IsCustomerInvolved", req.IsCustomerInvolved);
            param.Add("@ATMRelated", req.ATMRelated);

            param.Add("@Channel", req.Channel);
            param.Add("@SubBroker", req.SubBroker);
            param.Add("@PolicyNumber", req.PolicyNumber);
            param.Add("@StartDatePolicy", req.StartDatePolicy);
            param.Add("@EndDatePolicy", req.EndDatePolicy);
            param.Add("@DepartmentClaim", req.DepartmentClaim);

            param.Add("@RiskOID", req.RiskOID);
            param.Add("@BreifParticulars", req.Breifparticulars);
            param.Add("@SubjectMasterDescription", req.SubjectmatterDescription);
            param.Add("@ReliefClaims", req.ReliefClaims);

            param.Add("@DetailsofDepositsPaid", req.DetailsofDepositsPaid);
            param.Add("@SubCategory1OID", req.SubCategory1OID);
            param.Add("@DealerActingAsOID", req.DealerActingAsOID);
            param.Add("@CaseReferenceNumber", req.CaseReferenceNumber);

            // OUTPUT parameters
            param.Add("@LitigationOID", dbType: DbType.Int32, direction: ParameterDirection.Output);
            param.Add("@LitigationSerialID", dbType: DbType.String, size: 7, direction: ParameterDirection.Output);

            await conn.ExecuteAsync(
                "InsertLitigationOrgDetail",
                param,
                commandType: CommandType.StoredProcedure
            );

            return new InsertLitigationOrgResponse
            {
                LitigationOID = param.Get<int>("@LitigationOID"),
                LitigationID = param.Get<string>("@LitigationSerialID")
            };
        }
        public async Task<int> InsertLitigationHandledByAsync(
        int userOID,
        int litigationOID)
        {
            using var conn = CreateConnection();
            return await conn.ExecuteAsync(
                "InsertLitigationHandledBy",
                new
                {
                    UserOID = userOID,
                    LitigationOID = litigationOID
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<int> InsertUnitMemberAsync(
        int userOID,
        int litigationOID)
        {
            using var conn = CreateConnection();
            return await conn.ExecuteAsync(
                "InsertLitigationManager",
                new
                {
                    UserOID = userOID,
                    LitigationOID = litigationOID
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<int> InsertPoaDocumentAsync(int litigationOID, int userId, byte[] fileBytes, string fileName, long fileSize, string docType, string description, string referenceOwnerName)
        {
            using var conn = CreateConnection();
            return await conn.ExecuteAsync(
                "InsertLitigationDocumentPOA",
                new
                {
                    LitigationOID = litigationOID,
                    CreatedBy = userId,
                    Filebyte = fileBytes,
                    FileName = fileName,
                    FileSize = fileSize,
                    DocType = docType,
                    Description = description,
                    ReferenceOwnerName = referenceOwnerName
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<dynamic> InsertSubCategoryAsync(
       int litigationOID,
       int subCategoryOID)
        {
            using var conn = CreateConnection();

            return await conn.ExecuteAsync(
                "SpInsertLitigationSubCategory",
                new
                {
                    SubCategoryOID = subCategoryOID,
                    LitigationOID = litigationOID
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<dynamic> InsertDirectorName(
     string PartyName)
        {
            using var conn = CreateConnection();

            return await conn.ExecuteAsync(
                "InsertDirectorName",
                new
                {
                    PartyName = PartyName
                   
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> InsertLitigationCaseDetailsAsync(
     LitigationEntity_Roznama e,
     int litigationOID)
        {
            using var conn = CreateConnection();

            return await conn.ExecuteAsync(
                "InsertLitigationCaseDetails",
                new
                {
                    CaseNumber = e.Casenumber,
                    LegalNatureOID = e.LegalNature,
                    LegalNatureSubOID = e.LegalSubNature,
                    CaseTypeOID = e.CaseTypeOID,
                    PoliceStation = e.PoliceStation,
                    FIRNo = e.FirNo,
                    SubjectMasterOID = e.SubjectmatterOID,
                    LitigationOID = litigationOID,
                    CaseFileDt = e.CaseFileDate,
                    EstimatedCost = e.EstimatedCost,
                    HearingDate = e.HearingDate,
                    CaseTypeStageOID = e.CaseStageOID,
                    BankGuarantee = e.BankGuarantee,
                    ContingentLiability = e.ContingentLiability,
                    ProvisionMade = e.ProvisionMade,
                    CaseBackground = e.CaseBackground,
                    Connected_LitigationOID = e.Connected_LitigationOID,
                    DateOfNotice = e.DateOfNotice,
                    RelatedPeriod = e.RelatedPeriod,
                    FileNumber = e.FileNumber,
                    DateofFirstHearing = e.DateofFirstHearing,
                    NameofJudges = e.NameofJudges,
                    CaseYear = e.CaseYear,
                    StateOID = e.StateOID,
                    DistrictOID = e.DistrictOID,
                    TargetDisposalDate = e.TargetDisposalDate
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<dynamic> InsertConnectedNotice(
     int LitigationOID, int NoticeOID)
        {
            using var conn = CreateConnection();

            return await conn.ExecuteAsync(
                "InsertConnectedNotice",
                new
                {
                    NoticeOID = NoticeOID,
                    LitigationOID = LitigationOID
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> InsertConnectedLitigation(
        int litigationOID,
        int connectedLitigationOID)
        {
            using var conn = CreateConnection();

            return await conn.ExecuteAsync(
                "InsertConnectedLitigation",
                new
                {
                    LitigationOID = litigationOID,
                    Connected_LitigationOID = connectedLitigationOID
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> InsertConnectedArbitrationAsync(
        int litigationOID,
        int arbitrationOID,
        int isConnected)
        {
            using var conn = CreateConnection();

            return await conn.ExecuteAsync(
                "InsertConnectedArbitration",
                new
                {
                    LitigationOID = litigationOID,
                    ArbitrationOID = arbitrationOID,
                    IsConnected = isConnected
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> InsertOtherPartyLawFirmAsync(int PartyTypeOID, string PartyName)
        {
            using var conn = CreateConnection();
            var result = await conn.QueryFirstOrDefaultAsync<int>(
                "InsertOtherPartyLawFirm",
                new
                {
                    PartyName = PartyName,
                    PartyPhone = "",
                    PartyEmail = "",
                    PartyAddress = "",
                    PartyTypeOID = PartyTypeOID
                },
                commandType: CommandType.StoredProcedure
            );

            return result; // PartyMasterOID
        }
        public async Task<int> InsertNewCompanyLawFirmAsync(
    LawFirmAdvocateDto dto)
        {
            using var conn = CreateConnection();

            return await conn.ExecuteScalarAsync<int>(
        "InsertNewCompanyLawFirm",
        new
        {
            CompanyLawFirm = dto.CompanyLawFirm,
            CompanyLawFirmEmailID = dto.Email,
            CompanyLawFirmPhoneNo = dto.Phone,
            CompanyLawFirmAddress = dto.Address,
            BarCouncilNo = dto.BarCouncilNo
        },
        commandType: CommandType.StoredProcedure
    );
        }

        public async Task<int> InsertPartiesAsync(
        string partyName,
        string? clientCode,
        string? isClient)
        {
            using var conn = CreateConnection();
          

            // SP returns DataTable with column "result"
            var result = await conn.QueryFirstOrDefaultAsync<int>(
                "InsertParties",
                new
                {
                    PartyName = partyName,
                    ClientCode = clientCode,
                    IsClient = isClient
                },
                commandType: CommandType.StoredProcedure
            );

            return result; // PartyMasterOID
        }

        public async Task<bool> InsertMailLogAsync(InsertMailLogRequest request)
        {
            using var conn = CreateConnection();
            var rows = await conn.ExecuteAsync(
                "SP_InsertMailLog",
                new
                {
                    vcrApplicationName = request.ApplicationName,
                    vcrToEmailID = request.ToEmailID,
                    vcrCCEmailID = request.CCEmailID ?? string.Empty,
                    vcrBCCemailID = request.BCCemailID ?? string.Empty,
                    vcrFromEmailID = request.FromEmailID,
                    vcrSubject = request.Subject,
                    vcrMessage = request.Message,
                    vcrContentType = request.ContentType,
                    chrStatus = request.Status
                },
                commandType: CommandType.StoredProcedure
            );

            return rows > 0;
        }
        public async Task<int> InsertConnectedLitigationToTaxAsync( int litigationOID,int taxOID, string taxType)
        {
            using var conn = CreateConnection();
            

            return await conn.ExecuteAsync(
                "InsertConnectedLitigationToTax",
                new
                {
                    LitigationOID = litigationOID,
                    TaxOID = taxOID,
                    TaxType = taxType
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<int> InsertTransactionLogAsync(
        string logType,
        string logDesc,
        int userId,
        int masterOID)
        {
            using var conn = CreateConnection();

            return await conn.ExecuteAsync(
                "InsertTransactionlog",
                new
                {
                    LogType = logType,
                    LogDesc = logDesc,
                    UserId = userId,
                    MasterOID = masterOID
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> InsertWitnessMaster(WitnessDto model)
        {
                using var conn = CreateConnection();

                return await conn.ExecuteAsync(
                    "[dbo].[InsertWitnessMaster]",
                    new
                    {
                        LitigationOID = model.LitigationOID,
                        WitnessName = model.WitnessName,
                        WitnessEmailID = model.WitnessEmailID,
                        WitnessPhone = model.WitnessPhone,
                        WitnessAddress = model.WitnessAddress
                    },
                    commandType: CommandType.StoredProcedure
                );
        }
        /// <summary>
        /// Delete Method Start
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<int> DeleteCompanyPartiesAsync(int litigationOID)
        {
            using var conn = CreateConnection();

            return await conn.ExecuteAsync(
                "DeleteCompanyParties",
                new { LitigationOID = litigationOID },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<int> DeleteMatterHandledByAsync(int litigationOID)
        {
            using var conn = CreateConnection();

            return await conn.ExecuteAsync(
                "DeleteLitigationHandledBy",
                new
                {
                    LitigationOID = litigationOID
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<int> DeleteUnitMembersAsync(int litigationOID)
        {
            using var conn = CreateConnection();

            return await conn.ExecuteAsync(
                "DeleteLitigationManager",
                new { LitigationOID = litigationOID },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<int> DeleteUnderAct(int litigationOID)
        {
            using var conn = CreateConnection();

            return await conn.ExecuteAsync(
                "DeleteLitigationUnderAct",
                new { LitigationOID = litigationOID },
                commandType: CommandType.StoredProcedure
            );
        }

        public List<LawFirmAdvocateDto> DeleteLawFirmAdvocate(
        int companyLawFirmOID,
        string? companyLawFirm,
        List<LawFirmAdvocateDto> existingList)
        {
            var result = new List<LawFirmAdvocateDto>();
            int count = 0;

            if (existingList == null || existingList.Count == 0)
                return result;

            foreach (var item in existingList)
            {
                // SAME CONDITION AS WEB FORMS
                if (companyLawFirmOID != item.CompanyLawFirmOID &&
                    companyLawFirm != item.CompanyLawFirm)
                {
                    count++;
                    item.SN = count.ToString();
                    result.Add(item);
                }
            }

            return result;
        }

        public List<LawFirmAdvocateDto> DeleteCounterLawFirm(
        int counterLawFirmOID,
        string? counterLawFirm,
        List<LawFirmAdvocateDto>? existingList)
        {
            var result = new List<LawFirmAdvocateDto>();
            int count = 0;

            if (existingList == null || existingList.Count == 0)
                return result;

            foreach (var item in existingList)
            {
                // SAME condition as GridView
                if (counterLawFirmOID != item.CompanyLawFirmOID &&
                    counterLawFirm != item.CompanyLawFirm)
                {
                    count++;
                    item.SN = count.ToString();
                    result.Add(item);
                }
            }

            return result;
        }

        public async Task<List<SubCategoryDto>> DeleteSubCategoryAsync(
        DeleteSubCategoryRequest request)
        {
            var result = new List<SubCategoryDto>();
            int count = 0;

            if (request.ExistingSubCategories != null &&
                request.ExistingSubCategories.Count > 0)
            {
                foreach (var item in request.ExistingSubCategories)
                {
                    if (item.SubCategoryOID != request.SubCategoryOID &&
                        !string.Equals(item.SubCategory,
                                       request.SubCategory,
                                       StringComparison.OrdinalIgnoreCase))
                    {
                        count++;

                        result.Add(new SubCategoryDto
                        {
                            SN = count.ToString(),
                            SubCategoryOID = item.SubCategoryOID,
                            SubCategory = item.SubCategory
                        });
                    }
                }
            }

            return await Task.FromResult(result);
        }
        public async Task<IEnumerable<dynamic>> DeleteLitigationHearing(int LitigationHearingOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "DeleteLitigationHearing", new
            {
                LitigationStageHearingOID = LitigationHearingOID
            });
        }
        public async Task<IEnumerable<dynamic>> DeletePowerOfAttorneyDocument(int DocOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "DeletePowerOfAttorneyDocumentByDocID", new
            {
                DocOID = DocOID
            });
        }
        /// <summary>
        /// Update Method Start
        /// </summary>
        /// <param name="partyMasterOID"></param>
        /// <param name="litigationOID"></param>
        /// <returns></returns>
        public async Task<int> UpdateClientContactAsync(
    int partyMasterOID,
    int litigationOID)
        {
            using var conn = CreateConnection();

            return await conn.ExecuteAsync(
                "UpdateClientContact",
                new
                {
                    PartyMasterOID = partyMasterOID,
                    LitigationOID = litigationOID
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<int> UpdateLitigationDetailsAsync(UpdateLitigationDetailsRequest r)
        {
            using var conn = CreateConnection();
            return await conn.ExecuteAsync(
                "UpdateLitigationDetails1",
                new
                {
                    r.ClassificationOID,
                    r.CategoryOID,
                    r.AuthorityOID,
                    r.UnitOID,
                    r.CompanyType,
                    r.CounterType,
                    CaseNumber = r.CaseNumber,
                    r.CaseTypeOID,
                    r.CourtOID,
                    r.CourtName,
                    BreifParticulars = r.Breifparticulars,
                    SubjectMasterDescription = r.SubjectmatterDescription,
                    r.ReliefClaims,
                    r.RiskOID,
                    r.ConfidentialityType,
                    dateoffirsthearing = r.DateofFirstHearing,
                    LitigationOID = r.LitigationOID
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> UpdateFinalStatus(
   string Status,
   int litigationOID)
        {
            using var conn = CreateConnection();

            return await conn.ExecuteAsync(
                "FinalCompleteStatus",
                new
                {
                    LitigationOID = litigationOID,
                     Status = Status
                },
                commandType: CommandType.StoredProcedure
            );
        }

        #endregion
        #region Litigation Details Page API's

        #region Get Litigation Details Method
        public async Task<IEnumerable<dynamic>> GetLitigationDetailbyLitigationOID(int LitigationOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetLitigationInCompleteDetailbyLitigationOID", new
            {
                LitigationOID = LitigationOID


            });
        }
        public async Task<IEnumerable<dynamic>> GetConfidentialTypeApplicable(int unitOID)
        {
            using var conn = CreateConnection();

            var query = @"SELECT ConfidentialTypeApplicable 
                  FROM Units 
                  WHERE UnitOID = @UnitOID";

            var result = await _dapper.QueryAsync<dynamic>(
                conn,
                query,
                new { UnitOID = unitOID }
            );

            var data = result.FirstOrDefault();

            return data?.ConfidentialTypeApplicable?.ToString() ?? "";
        }
        public async Task<IEnumerable<dynamic>> GetLitigationVehicleDealerDetails(int LitigationOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetLitigationVehicleDealerDetails", new
            {
                LitigationOID = LitigationOID
            });
        }
        public async Task<IEnumerable<dynamic>> GetLitigationLabourDetails(int LitigationOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetLitigationLabourDetails", new
            {
                LitigationOID = LitigationOID
            });
        }
        public async Task<IEnumerable<dynamic>> CheckBucketListForLitigation(int UserOID, int intLitigationOID, int intEntity, int intUnit)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "CheckBucketListForLitigation", new
            {
                LitigationOID = intLitigationOID,
                UserOID= UserOID,
                EntityOID= intEntity,
                UnitOID=intUnit
            });
        }
        public async Task<IEnumerable<dynamic>> GetLitigationStageSummary(int LitigationOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetStageSummary", new
            {
                LitigationOID = LitigationOID
            });
        }

        public async Task<IEnumerable<dynamic>> GetPartiesByLitigationAndPartyType(int LitigationOID,int PartyTypeOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetPartiesByLitigationAndPartyType", new
            {
                LitigationOID = LitigationOID,
                PartyTypeOID = PartyTypeOID
            });
        }
        public async Task<IEnumerable<dynamic>> GetBillTypesForLitigation()
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetBillTypesForLitigation", new
            {
            });
        }
        public async Task<IEnumerable<dynamic>> GetLitigationStageHearingDates(int LitigationOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetLitigationStageHearingDates", new
            {
                LitigationOID = LitigationOID
            });
        }

        public async Task<IEnumerable<dynamic>> GetLitigationBillingSummary(int LitigationOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetBillingSummary", new
            {
                LitigationOID = LitigationOID
            });
        }
        public async Task<IEnumerable<dynamic>> GetWitness(int LitigationOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetWitnessMaster", new
            {
                LitigationOID = LitigationOID
            });
        }
        public async Task<LitigationAlertDto> GetAlertforLitigation(int litigationOID)
        {
           
                using var conn = CreateConnection();

                var result = await conn.QueryAsync<dynamic>(
     "GetAlertDataForLitigation",
     new { LitigationOID = litigationOID },
     commandType: CommandType.StoredProcedure
 );

                var data = result.FirstOrDefault();

                if (data == null)
                    return new LitigationAlertDto();

                return new LitigationAlertDto
                {
                    LitigationID = data.LitigationID,
                    EntityName = data.EntityUnit,
                    ToEmailID = data.ToEmailID,
                    CaseTitle = data.Title,
                    CaseNumber = data.CaseNumber,
                    Breifparticulars = data.BreifParticulars,
                    HearingDt = data.NextHearingDate != null
                                ? Convert.ToDateTime(data.NextHearingDate)
                                : (DateTime?)null,
                    RiskOID = data.RiskOID != null ? Convert.ToInt32(data.RiskOID) : 0,
                    NameofJudges = data.NameofJudges,
                    CourtName = data.CourtName,
                    CompanyType = data.ActingAs
                };
           
        }

        public async Task<string> GetApplicationLink()
        {
           
                using var conn = CreateConnection();

                var result = await _dapper.QueryAsync<dynamic>(
                    conn,
                    "SELECT Link FROM ApplicationLink",
                    null
                );

                var data = result.FirstOrDefault();

                return data?.Link?.ToString() ?? "";
        }
        public async Task<string> GetFromMailID()
        {
            
                using var conn = CreateConnection();

                var result = await _dapper.QueryAsync<dynamic>(
                    conn,
                    "SELECT smtp_from_user FROM smtp_config",
                    null
                );

                var data = result.FirstOrDefault();

                return data?.smtp_from_user?.ToString() ?? "";
           
        }
        public async Task<IEnumerable<dynamic>> GetLitigationResultMaster()
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetLitigationResultMaster", new
            {
            });
        }
        public async Task<IEnumerable<dynamic>> GetNoticesforConnectedLitigation(int LitigationOID, int CurrentLitigaionOID,int UserOID, string txtsearch)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetNoticesforConnectedLitigation", new
            {
                LitigationOID = LitigationOID,
               CurrentLitigaionOID=CurrentLitigaionOID,
               UserOID=UserOID,
               txtsearch=txtsearch
            });
        }
        public async Task<IEnumerable<dynamic>> GetLitigationforConnectedLitigation(int LitigationOID, int CurrentLitigaionOID, int UserOID, string txtsearch)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetLitigationforConnectedLitigation", new
            {
                LitigationOID = LitigationOID,
                CurrentLitigaionOID = CurrentLitigaionOID,
                UserOID = UserOID,
                strsearch = txtsearch
            });
        }
        public async Task<IEnumerable<dynamic>> GetArbitrationsforConnectedLitigation(int LitigationOID, int CurrentLitigaionOID, int UserOID, string txtsearch)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetArbitrationsforConnectedLitigation", new
            {
                LitigationOID = LitigationOID,
                CurrentLitigaionOID = CurrentLitigaionOID,
                UserOID = UserOID,
                StrSearch = txtsearch
            });
        }
        public async Task<IEnumerable<dynamic>> GetLitigationDocuments(int MasterOID, string DocType)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetDocumentsForLitigation", new
            {
                MasterOID = MasterOID,
                DocType= DocType
            });
        }
        public async Task<LitigationEntity_Roznama> GetPowerOfAttorneyDocumentByDOCOID(int docID)
        {
            using var conn = CreateConnection();

            var result = await _dapper.QueryAsync<dynamic>(
                conn,
                "GetLitigationDocumentsByDocOID",
                new
                {
                    DOCID = docID
                }
            );

            var data = result.FirstOrDefault();

            if (data == null)
                return new LitigationEntity_Roznama();

            return new LitigationEntity_Roznama
            {
                DocumentName = data.DocumentName,
                Filebyte = data.FileData,   // IMPORTANT: DB column name
                FileSize = data.FileSize
            };
        }

        public async Task<IEnumerable<dynamic>> BindPartyEmail(int LitigationOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetPartyEmail", new
            {

                LitigationOID = LitigationOID
            });
        }
        public async Task<IEnumerable<dynamic>> GetResponsiblePerson(int LitigationOID, int ArbitrationOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetResponsiblePerson", new
            {

                LitigationOID = LitigationOID,
                ArbitrationOID= ArbitrationOID
            });
        }
        public async Task<IEnumerable<dynamic>> GetLitigationDocumentsforDetails(int GeneralHearingOID, string DocType)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetDocumentsForLitigationDetails", new { GeneralHearingOID = GeneralHearingOID, DocType= DocType });
        }
        public async Task<IEnumerable<dynamic>> GetLitigationActivityLog(int LitigationOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetLitigationActivityLog", new
            {

                LitigationOID = LitigationOID
            });
        }
        public async Task<IEnumerable<dynamic>> GetLibraryTypes()
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetLibraryTypes", new
            {
            });
        }
        public async Task<IEnumerable<dynamic>> GetAllEntitiesByUser(int UserOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetAllEntitiesByUser", new
            {

                UserOID = UserOID
            });
        }
        public async Task<IEnumerable<dynamic>> GetCaseBackground(int LitigationOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetCaseBackground", new
            {

                LitigationOID = LitigationOID
            });
        }
        public async Task<IEnumerable<dynamic>> GetAllInterimProceeding(int LitigationOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "spGetAllInterimProceeding", new
            {

                LitigationOID = LitigationOID
            });
        }
        public async Task<IEnumerable<dynamic>> GetAllInterimAppeal(int LitigationOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "spGetAllInterimAppeal", new
            {

                LitigationOID = LitigationOID
            });
        }
        public async Task<IEnumerable<dynamic>> GeteReferenceLibraryForLitigations(int LitigationOID, int CurrentLitigaionOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetReferenceLibraryForLitigations", new
            {

                LitigationOID = LitigationOID,
                CurrentLitigationOID= CurrentLitigaionOID
            });
        }
        public async Task<BillingDetailsDto> GetLitigationBillingDetailsForUpdate(int billingOID)
        {
            
                using var conn = CreateConnection();

                var result = await _dapper.QueryAsync<dynamic>(
                    conn,
                    "GetLitigationBillingDetailsForUpdate",
                    new { BillingOID = billingOID }
                );

                var data = result.FirstOrDefault();

                if (data == null)
                    return new BillingDetailsDto();

                return new BillingDetailsDto
                {
                    BillingTypeOID = data.BillingTypeOID ?? 0,
                    LitigationStageHearingOID = data.LitigationStageHearingOID ?? 0,
                    Amount = data.BillingAmount ?? 0,
                    RaisedBy = data.BillRaisedBy,

                    BillDate = data.BillDate != null ? Convert.ToDateTime(data.BillDate) : (DateTime?)null,
                    Comments = data.Comment,
                    PartyMasterOID = data.PartyMasterOID ?? 0,
                    BillStatus = data.BillStatus ?? 0,
                    PaymentReceived = data.PaymentReceived,
                    ChequeNo = data.ChequeNo,

                    ChequeDate = data.ChequeDate != null ? Convert.ToDateTime(data.ChequeDate) : (DateTime?)null,

                    TransactionID = data.TransactionID,
                    TDScertificateattached = data.TDScertificateattached,

                    AmountPaid = data.AmountPaid ?? 0,
                    AmountBalance = data.BalanceAmount ?? 0,
                    StatutoryDepositAmount = data.StatutoryDepositAmount ?? 0,

                    DateofStatutoryDeposit = data.DateofStatutoryDeposit != null ? Convert.ToDateTime(data.DateofStatutoryDeposit) : (DateTime?)null,

                    OtherDepositAmount = data.OtherDepositAmount ?? 0,

                    DateofOtherDeposit = data.DateofOtherDeposit != null ? Convert.ToDateTime(data.DateofOtherDeposit) : (DateTime?)null,

                    DepositRefundStatus = data.DepositRefundStatus,

                    RefundDate = data.RefundDate != null ? Convert.ToDateTime(data.RefundDate) : (DateTime?)null,

                    RefundReferenceNo = data.RefundReferenceNo,
                    BillingDepositRefundStatus = data.BillingDepositRefundStatus,
                    DetailsofDepositsPaid = data.DetailsofDepositsPaid,

                    RefundAmount = data.RefundAmount ?? 0,
                    InstrumentType = data.InstrumentType,
                    InstrumentNo = data.InstrumentNo,

                    InstrumentDate = data.InstrumentDate != null ? Convert.ToDateTime(data.InstrumentDate) : (DateTime?)null,

                    RefundRefNo = data.RefundRefNo
                };
            
        }

        public async Task<List<PartyContactDto>> GetPartyContacts(int partyMasterOID)
        {
            
                using var conn = CreateConnection();

                var result = await _dapper.QueryAsync<dynamic>(
                    conn,
                    "GetClientContactDetails",
                    new { PartyMasterOID = partyMasterOID }
                );

                var list = result.Select(data => new PartyContactDto
                {
                    ContactName = data.ContactPerson,
                    Phone = data.Phone,
                    Email = data.Email,
                    Address = data.Address
                }).ToList();

                return list;
            
            
        }
        public async Task<IEnumerable<dynamic>> GetChequeforConnectedLitigation(int LitigationOID, int CurrentLitigaionOID,int UserOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetChequeforConnectedLitigation", new
            {

                LitigationOID = LitigationOID,
                CurrentLitigationOID = CurrentLitigaionOID,
                UserOID=UserOID
            });
        }
        public async Task<LitigationAlertEmailDto> GetLitigationForAlertEmailbyLitigationOID(int litigationOID)
        {
          
                using var conn = CreateConnection();

                var result = await _dapper.QueryAsync<dynamic>(
                    conn,
                    "GetLitigationForAlertEmailbyLitigationOID",
                    new { LitigationOID = litigationOID }
                );

                var data = result.FirstOrDefault();

                if (data == null)
                    return new LitigationAlertEmailDto();

                return new LitigationAlertEmailDto
                {
                    LitigationID = data.LitigationID,
                    UnitName = data.UnitName,
                    EntityName = data.EntityName,
                    DeptName = data.DeptName,
                    ClasificationTypeName = data.TypeName,
                    CaseTypeName = data.CaseTypeName,
                    CourtTypeName = data.CourtType,
                    CourtName = data.CourtName,
                    PoliceStation = data.PoliceStation,
                    FirNo = data.FIRNo,
                    AuthorityName = data.Authority,
                    LegalNatureName = data.LegalNatureName,
                    LegalSubNatureName = data.LegalSubNatureName,
                    CaseNumber = data.CaseNumber,
                    Breifparticulars = data.BreifParticulars,
                    SubjectMatter = data.SubjectMasterName,
                    SubjectMatterDescription = data.SubjectMasterDescription,
                    ReliefClaims = data.ReliefClaims,

                    BankGuarantee = data.BankGuarantee,
                    ContingentLiability = data.ContingentLiability,
                    ProvisionMade = data.ProvisionMade,

                    CreatedByName = data.CreatedName,

                    HearingDate = data.Hearingdate != null ? Convert.ToDateTime(data.Hearingdate) : (DateTime?)null,

                    CompanyType = data.CompanyType,
                    CounterType = data.CounterType,
                    CoParties = data.CoParties,
                    CounterParties = data.CounterParties,
                    CompanyAdvocate = data.CompanyAdvocate,
                    CounterAdvocate = data.CounterAdvocate,
                    UnderActsName = data.UnderActName,

                    EstimatedCost = data.EstimatedCost ?? 0,
                    CompleteStatus = data.CompleteStatus,
                    CompletionComment = data.CompletionComment,
                    Result = data.Result,
                    CategoryName = data.CategoryName,

                    CaseFileDate = data.CaseFillingDate != null ? Convert.ToDateTime(data.CaseFillingDate) : (DateTime?)null,
                    FirstHearingDate = data.FirstHearingDate != null ? Convert.ToDateTime(data.FirstHearingDate) : (DateTime?)null,

                    CaseTypeOID = data.CaseTypeOID,
                    UnderactOID = data.UnderActOID,

                    AuthorityNominee = data.AuthorityNominee,
                    POA = data.POAAvailable,
                    DirectorInvolved = data.DirectorInvolved,
                    DirectorName = data.DirectorName,

                    DateOfNotice = data.DateofNotice != null ? Convert.ToDateTime(data.DateofNotice) : (DateTime?)null,

                    ByagainstStatutoryauthority = data.ByagainstStatutoryauthority,
                    RelatedPeriod = data.RelatedPeriod,
                    CircleZoneRegion = data.ZoneCircleRegion,

                    AmountClaimAmount = data.AmountInvolvedClaimAmount ?? 0,
                    AmountInterest = data.AmountInvolvedInterest ?? 0,
                    AmountPenalty = data.AmountInvolvedPenalty ?? 0,

                    ContingentClaimAmount = data.ContingentLiabilityClaimAmount ?? 0,
                    ContingentInterest = data.ContingentLiabilityInterest ?? 0,
                    ContingentPenalty = data.ContingentLiabilityPenalty ?? 0,

                    ProvisionClaimAmount = data.ProvisionClaimAmount ?? 0,
                    ProvisionInterest = data.ProvisionInterest ?? 0,
                    ProvisionPenalty = data.ProvisionPenalty ?? 0,

                    POABRLOA = data.POABRLOA,

                    MatterHandledByOID = data.HandledByOID,
                    MatterHandledbyName = data.HandledByName,

                    UnitMemberOID = data.ManagerOID,
                    UnitMemberName = data.ManagerName,

                    Synopsis = data.Synopsis,

                    AppealFilingDt = data.AppealFilingDt != null ? Convert.ToDateTime(data.AppealFilingDt) : (DateTime?)null,
                    Disposeddt = data.DisposedDt != null ? Convert.ToDateTime(data.DisposedDt) : (DateTime?)null,

                    StageName = data.StageName,

                    MatterHandledByEmailID = data.MattterHandledByEmailID,
                    ManagerEmailID = data.ManagerEmailID,

                    EntityUnitName = data.EntityUnit,
                    CaseTitle = data.Title,
                    StageDescription = data.StageDescription
                };
           
        }
        public async Task<IEnumerable<dynamic>> GetMaterialChangeCommunication(int LitigationOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetMaterialChangeCommunication", new
            {

                UnitOID = LitigationOID
            });
        }
        public async Task<IEnumerable<dynamic>> GetREMforConnectedLitigation(int LitigationOID, int CurrentLitigaionOID,int UserOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetREMforConnectedLitigation", new
            {

                LitigationOID = LitigationOID,
                CurrentLitigaionOID= CurrentLitigaionOID,
                UserOID= UserOID
            });
        }
        public async Task<IEnumerable<dynamic>> Ifalreadytaskowner(int litigationOID, int useroid)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "Ifalreadytaskowner", new
            {

                litigationOid = litigationOID,
                useroid = useroid
            });
        }
        public async Task<string> GetLawFirmAdvocateUserEmailID(int preparatoryOID)
        {
          
                using var conn = CreateConnection();

                var result = await _dapper.QueryAsync<dynamic>(
                    conn,
                    "SELECT ISNULL(EMAIL,'') AS EMAIL FROM dbo.PartyMaster WHERE PartyMasterOID = @PartyMasterOID",
                    new { PartyMasterOID = preparatoryOID }
                );

                var data = result.FirstOrDefault();

                return data?.EMAIL?.ToString() ?? "";
           
        }
        public async Task<IEnumerable<dynamic>> GetLitigationTaskBylitigationid(int litigationOID, int useroid)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetLitigationTaskByLitigationId", new
            {

                litigationoid = litigationOID,
                useroid = useroid
            });
        }
        #endregion
        /// <summary>
        /// Post Litigation Details page Method 
        /// </summary>
        /// <returns></returns>
        #region Post Litigation Details Page Method
        public async Task<bool> CheckValidHearingDateAsync(
       int litigationOID,
       DateTime nextHearingDate)
        {
            using var conn = CreateConnection();

            return await conn.ExecuteScalarAsync<bool>(
                "[dbo].[CheckHearingDateGreateOrNot]",
                new
                {
                    LitigationOID = litigationOID,
                    NextHearingDate = nextHearingDate
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<(int rowsAffected, int hearingStageOID)>
       InsertCaseTypeStageAsync(InsertCaseTypeStageRequest r)
        {
            using var conn = CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add("@CaseTypeStageOID", r.CaseStageOID);
            parameters.Add("@LitigationOID", r.LitigationOID);
            parameters.Add("@StageDescription", r.StageDescription);
            parameters.Add("@HearingDate", r.HearingDt);

            parameters.Add("@LigationHearingStageOID",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            parameters.Add("@FirstAlertDate", r.FirstAlertDt);
            parameters.Add("@SecondAlertDate", r.SecondAlertDt);
            parameters.Add("@ThirdAlertDate", r.ThirdAlertDt);
            parameters.Add("@AdditionalEmailID", r.AdditionalEmailID);
            parameters.Add("@NonHearingCases", r.NonHearingCases);

            parameters.Add("@ConsumerDemographics", r.ConsumerDemographics);
            parameters.Add("@ControlNumber", r.ControlNumber);
            parameters.Add("@AccountNumber", r.AccountNumber);
            parameters.Add("@IssueDescription", r.IssueDescription);
            parameters.Add("@ClientServiceTeamdecision", r.ClientServiceTeamDecision);
            parameters.Add("@DisputeCategory", r.DisputeCategory);
            parameters.Add("@Memberresponsedate", r.MemberResponseDate);
            parameters.Add("@Memberdecision", r.MemberDecision);
            parameters.Add("@Memberresponse", r.MemberResponse);
            parameters.Add("@TUDFDetails", r.TUDFDetails);
            parameters.Add("@MemberNameOID", r.MemberOID);
            parameters.Add("@Penalty", r.Penalty);
            parameters.Add("@IsOrderReserved", r.IsOrderReserved);
            parameters.Add("@DateofReserved", r.DateOfReserved);
            parameters.Add("@IsOrderPronounced", r.IsOrderPronounced);
            parameters.Add("@DateofPronounced", r.DateOfPronounced);

            int result = await conn.ExecuteAsync(
                "[dbo].[InsertLitigationStage]",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            int hearingStageOID =
                parameters.Get<int>("@LigationHearingStageOID");

            return (result, hearingStageOID);
        }
        public async Task<int> InsertLitigationActionItemsAsync(
       List<LitigationActionItemDto> items,
       int ligationHearingStageOID,
       int createdByOID)
        {
            using var conn = CreateConnection();
            int rows = 0;

            foreach (var item in items)
            {
                rows += await conn.ExecuteAsync(
                    "InsertLitigationActionItem",
                    new
                    {
                        LigationHearingStageOID = ligationHearingStageOID,
                        ActionItem = item.ActionItem,
                        ResponsiblePersonOID = item.ResponsiblePersonOID,
                        DueDate = item.DueDate,
                        CreatedByOID = createdByOID,
                        LitigationOID = item.LitigationOID,
                        ActionItemFor = item.ActionItemFor,
                        AdditionalEmailID = item.AdditionalEmailID,
                        SecondAlertDate = item.SecondAlertDt,
                        ThirdAlertDate = item.ThirdAlertDt,
                        FirstAlertDate = item.FirstAlertDt
                    },
                    commandType: CommandType.StoredProcedure
                );
            }

            return rows;
        }
        public async Task<int> InsertLitigationStageDocumentsAsync(
       List<LitigationStageDocumentDto> documents,
       int ligationStageHearingOID,
       int userId)
        {
            using var conn = CreateConnection();
            int rows = 0;

            foreach (var doc in documents)
            {
                rows += await conn.ExecuteAsync(
                    "InsertLitgationDocuments",
                    new
                    {
                        OID = ligationStageHearingOID,
                        createdBy = userId,
                        Filebyte = doc.Filebyte,
                        fileName = doc.FileName,
                        Description = doc.Description,
                        fileSize = doc.FileSize,
                        DocType = doc.DocType,
                        ReferenceOwnerName = doc.ReferenceOwnerName,
                        DocCategory = doc.DocCategory,
                        LitigationDraftOID = doc.LitigationDraftOID,
                        S3UniqueDocumentName = doc.S3UniqueDocumentName
                    },
                    commandType: CommandType.StoredProcedure
                );
            }

            return rows;
        }

        public async Task<int> InsertLibraryDocumentAsync(
        InsertLibraryDocumentRequest entity)
        {
            using var conn = CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@DocumentTitle", entity.DocumentTitle);
            parameters.Add("@createdBy", entity.UserId);
            parameters.Add("@Filebyte", entity.Filebyte, DbType.Binary);
            parameters.Add("@fileName", entity.FileName);
            parameters.Add("@Comment", entity.Comment);
            parameters.Add("@fileSize", entity.FileSize);
            parameters.Add("@LibraryType", entity.LibraryTypeOID);
            parameters.Add("@EntityOID", entity.EntityOID);
            parameters.Add("@SubjectMatterDesc", entity.SubjectMatterDesc);
            parameters.Add("@DocOID", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await conn.ExecuteAsync(
                "InsertLibraryDocuments",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return parameters.Get<int>("@DocOID");
        }

        public async Task InsertLitigationReferenceAsync(
            int litigationOID,
            int docOID)
        {
            using var conn = CreateConnection();

            await conn.ExecuteAsync(
                "InsertLitigationReferenceDoc",
                new
                {
                    LitigationOID = litigationOID,
                    DocOID = docOID
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<int> InsertBillingDetailsAsync(
        BillingDetailsRequest request)
        {
            using var conn = CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add("@BillingTypeOID", request.BillingTypeOID);
            parameters.Add("@LitigationStageHearingOIDOID", request.LitigationStageHearingOID);
            parameters.Add("@Amount", request.Amount);
            parameters.Add("@BillDate", request.BillDate);
            parameters.Add("@Comments", request.Comments);
            parameters.Add("@UserOID", request.UserId);
            parameters.Add("@LitigationOID", request.LitigationOID);
            parameters.Add("@BillRaisedBy", request.RaisedBy);
            parameters.Add("@PartyMasterOID", request.PartyMasterOID);
            parameters.Add("@BillStatus", request.BillStatus);
            parameters.Add("@PaymentReceived", request.PaymentReceived);
            parameters.Add("@ChequeNo", request.ChequeNo);
            parameters.Add("@ChequeDate", request.ChequeDate);
            parameters.Add("@TransactionID", request.TransactionID);
            parameters.Add("@TDScertificateattached", request.TDScertificateattached);
            parameters.Add("@AmountPaid", request.AmountPaid);

            parameters.Add("@StatutoryDepositAmount", request.StatutoryDepositAmount);
            parameters.Add("@DateofStatutoryDeposit", request.DateofStatutoryDeposit);
            parameters.Add("@OtherDepositAmount", request.OtherDepositAmount);
            parameters.Add("@DateofOtherDeposit", request.DateofOtherDeposit);
            parameters.Add("@DepositRefundStatus", request.DepositRefundStatus);
            parameters.Add("@RefundDate", request.RefundDate);
            parameters.Add("@RefundReferenceNo", request.RefundReferenceNo);
            parameters.Add("@BillingDepositRefundStatus", request.BillingDepositRefundStatus);
            parameters.Add("@DetailsofDepositsPaid", request.DetailsofDepositsPaid);

            parameters.Add("@RefundAmount", request.RefundAmount);
            parameters.Add("@InstrumentType", request.InstrumentType);
            parameters.Add("@InstrumentNo", request.InstrumentNo);
            parameters.Add("@InstrumentDate", request.InstrumentDate);
            parameters.Add("@RefundRefNo", request.RefundRefNo);

            parameters.Add(
                "@BillingOID",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output
            );

            await conn.ExecuteAsync(
                "InsertBillingDetails",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return parameters.Get<int>("@BillingOID");
        }

        public async Task<int> UpdateBillingDetailsAsync(BillingDetailsRequest dto)
        {
            using var conn = CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add("@BillingTypeOID", dto.BillingTypeOID);
            parameters.Add("@LitigationStageHearingOIDOID", dto.LitigationStageHearingOID);
            parameters.Add("@Amount", dto.Amount);
            parameters.Add("@BillDate", dto.BillDate);
            parameters.Add("@Comments", dto.Comments);
            parameters.Add("@UserOID", dto.UserId);
            parameters.Add("@BillingOID", dto.BillingOID);
            parameters.Add("@BillRaisedBy", dto.RaisedBy);
            parameters.Add("@PartyMasterOID", dto.PartyMasterOID);
            parameters.Add("@BillStatus", dto.BillStatus);
            parameters.Add("@PaymentReceived", dto.PaymentReceived);
            parameters.Add("@ChequeNo", dto.ChequeNo);
            parameters.Add("@ChequeDate", dto.ChequeDate);
            parameters.Add("@TransactionID", dto.TransactionID);
            parameters.Add("@TDScertificateattached", dto.TDScertificateattached);
            parameters.Add("@AmountPaid", dto.AmountPaid);

            parameters.Add("@StatutoryDepositAmount", dto.StatutoryDepositAmount);
            parameters.Add("@DateofStatutoryDeposit", dto.DateofStatutoryDeposit);
            parameters.Add("@OtherDepositAmount", dto.OtherDepositAmount);
            parameters.Add("@DateofOtherDeposit", dto.DateofOtherDeposit);
            parameters.Add("@DepositRefundStatus", dto.DepositRefundStatus);
            parameters.Add("@RefundDate", dto.RefundDate);
            parameters.Add("@RefundReferenceNo", dto.RefundReferenceNo);
            parameters.Add("@BillingDepositRefundStatus", dto.BillingDepositRefundStatus);
            parameters.Add("@DetailsofDepositsPaid", dto.DetailsofDepositsPaid);

            parameters.Add("@RefundAmount", dto.RefundAmount);
            parameters.Add("@InstrumentType", dto.InstrumentType);
            parameters.Add("@InstrumentNo", dto.InstrumentNo);
            parameters.Add("@InstrumentDate", dto.InstrumentDate);
            parameters.Add("@RefundRefNo", dto.RefundRefNo);

            return await conn.ExecuteAsync(
                "UpdateBillingDetails",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<int> InsertConnectedCheque(int litigationOID, int chequeOID, int isConnected)
        {
          
                using var conn = CreateConnection();

                var result = await _dapper.ExecuteAsync(
                    conn,
                    "[dbo].[InsertConnectedCheque]",
                    new
                    {
                        LitigationOID = litigationOID,
                        ChequeOID = chequeOID,
                        IsConnected = isConnected
                    }
                );

                return result; // rows affected
         
        }
        #endregion

        #region Update Litigation Details Page API
        public async Task<int> UpdateLitigationLastModifiedDate(int litigationOID)
        {
            using var conn = CreateConnection();

            return await conn.ExecuteAsync(
                "UpdateLitigationLastModifiedDate",
                new
                {
                    LitigationOID = litigationOID
                   
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> UpdateCompletionDetails(CompletionDetailsDto model)
        {
            
                using var conn = CreateConnection();

            return await conn.ExecuteAsync(
                  
                    "UpdateCompletionDetails",
                    new
                    {
                        LitigationOID = model.LitigationOID,
                        ResultOID = model.ResultOID,
                        DisposedDate = model.DisposedDate,
                        Comment = model.Comment,
                        Synopsis = model.Synopsis,
                        AppealFlag = model.AppealFlag,
                        AppealFiled = model.AppealFiled,
                        AppealFilingDt = model.AppealFilingDt,
                        FirstAlertDate = model.FirstAlertDate,
                        SecondAlertDate = model.SecondAlertDate,
                        ThirdAlertDate = model.ThirdAlertDate,
                        DateofReceiptofOrder = model.DateofReceiptofOrder,
                        ComplianceAppeal = model.ComplianceAppeal,
                        Dateofcomplinace = model.Dateofcomplinace,
                        ComplianceRingiNo = model.ComplianceRingiNo,
                        MonetaryAward = model.MonetaryAward,
                        TotalInterest = model.TotalInterest,
                        NonMonetaryAward = model.NonMonetaryAward,
                        TotalAward = model.TotalAward,
                        FinalCloserDate = model.FinalCloserDate,
                        FromDate = model.FromDate,
                        ToDate = model.ToDate,
                        Interest = model.Interest
                    },
                    commandType: CommandType.StoredProcedure
                );

        }

        public async Task<int> UpdateLitigationActionItem(ActionItemUpdateDto model)
        {
            using var conn = CreateConnection();

            return await _dapper.ExecuteAsync(
                conn,
                "UpdateLitigationActionItem",
                new
                {
                    ActionItemOID = model.ActionItemOID,
                    StatusOID = model.StatusOID,
                    Comments = model.Comments
                }
            );
        }
        public async Task<int> InsertConnectedREM(int litigationOID, int realEstateOID, int isConnected)
        {
           
                using var conn = CreateConnection();

                var result = await _dapper.ExecuteAsync(
                    conn,
                    "[dbo].[InsertConnectedREM]",
                    new
                    {
                        LitigationOID = litigationOID,
                        RealEstateOID = realEstateOID,
                        IsConnected = isConnected
                    }
                );

                return result; // rows affected
           
        }
        public async Task<int> UpdateDocUploadStatusfornotices(int litigationDraftOID, int draftStatusOID)
        {
           
                using var conn = CreateConnection();

                var result = await _dapper.ExecuteAsync(
                    conn,
                    "[dbo].[UpdateDocUploadStatusfornotices]",
                    new
                    {
                        NoticeDraftOID = litigationDraftOID,
                        DraftStatusOID = draftStatusOID
                    }
                );

                return result;
            
        }
        public async Task<int> UpdateDraftstatusNotices(int noticeDraftOID,int draftStatusOID,string assigneeComment,string reviewerComment)
        {
            
                using var conn = CreateConnection();

                var result = await _dapper.ExecuteAsync(
                    conn,
                    "[dbo].[UpdateDraftstatusNotices]",
                    new
                    {
                        NoticeDraftOID = noticeDraftOID,
                        DraftStatusOID = draftStatusOID,
                        PreparatoryComment = assigneeComment,
                        ReviewerComment = reviewerComment
                    }
                );

                return result;
            
        }
        public async Task<int> InsertLitigationForDrafting(List<LitigationDraftingDto> list)
        {
                using var conn = CreateConnection();

                int result = 0;

                foreach (var item in list)
                {
                    result += await _dapper.ExecuteAsync(
                        conn,
                        "InsertLitigationForDrafting",
                        new
                        {
                            LitigationOID = item.LitigationOID,
                            PreferenceID = item.PreferenceID,
                            Preparatory = item.PreparatoryOID,
                            PreparatoryDate = item.PreparatoryDate,
                            DraftStatusOID = item.DraftStatusOID,
                            Instruction = item.PreparatoryInstruction,
                            EmailID = item.PreparatoryEmailID,
                            ManagerOID = item.ManagerOID
                        }
                    );
                }

                return result;
            
        }
        public async Task<int> AssignMyBucketListForLitigationByDetails(int userOID,int litigationOID,int entityOID,int unitOID)
        {
           
                using var conn = CreateConnection();

                var result = await _dapper.ExecuteAsync(
                    conn,
                    "AssignMyBucketListForLitigationByDetails",
                    new
                    {
                        LitigationOID = litigationOID,
                        UserOID = userOID,
                        EntityOID = entityOID,
                        UnitOID = unitOID
                    }
                );

                return result;
            
        }
        #endregion

        #region Delete Litigation Details Page API's
        public async Task<IEnumerable<dynamic>> DeleteInterimRecord(int MasterOID, string Type)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "spDeleteInterimDocs", new
            {
                MasterOID = MasterOID,
                Type= Type
            });
        }
        public async Task<IEnumerable<dynamic>> DeleteConnectedNotice(int NoticeOID, int LitigationOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "DeleteConnectedNotice", new
            {
                NoticeOID = NoticeOID,
                LitigationOID = LitigationOID

            });
        }
        public async Task<IEnumerable<dynamic>> DeleteConnectedLitigationFromLitigation(int Connected_LitigationOID, int LitigationOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "DeleteConnectedLitigationFromLitigation", new
            {
                Connected_LitigationOID = Connected_LitigationOID,
                LitigationOID = LitigationOID

            });
        }

        public async Task<IEnumerable<dynamic>> DeleteConnectedCheque(int ChequeOID, int LitigationOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "DeleteConnectedCheque", new
            {
                ChequeOID = ChequeOID,
                LitigationOID = LitigationOID

            });
        }
        public async Task<IEnumerable<dynamic>> DeleteBilling(int BillingOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "DeleteBilling", new
            {
                BillingOID = BillingOID
            });
        }
        public async Task<IEnumerable<dynamic>> DeleteWitness(int WitnessOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "DeleteWitness", new
            {
                WitnessOID = WitnessOID
            });
        }
        public async Task<IEnumerable<dynamic>> deletelitigatiotaskdocument(int DocOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "deletelitigatiotaskdocument", new
            {
                DocOID = DocOID
            });
        }
        #endregion

        #endregion

        #region Litigation Summary Page API's

        public async Task<IEnumerable<dynamic>> BindGridViewLitigationSummary()
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "SP_LitigationSummaryTesting", new
            {// LitigationOID = LitigationOID


            });
        }

        public async Task<IEnumerable<dynamic>> BindLitigationDraftSummary(int UserOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetLitigationInComplete1", new
            {
                UserOID = UserOID
            });
        }

        public async Task<IEnumerable<dynamic>> DeleteLitigation(int LitigationOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "DeleteLitigation", new
            {
                LitigationOID = LitigationOID
            });
        }
       

        #endregion

        /// <summary>
        /// Update Litigation Page API
        /// </summary>
        /// <param name="litigationOID"></param>
        /// <returns></returns>

        #region Update Litigation Page API
        public async Task<IEnumerable<dynamic>> DeleteConnectedLitigation(int LitigationOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "DeleteConnectedLitigation", new
            {
                LitigationOID = LitigationOID
            });
        }

        public async Task<int> UpdateLitigationAsync(LitigationUpdateRequest e)
        {
            using var conn = CreateConnection();

            var parameters = new
            {
                // -------- BASIC DETAILS --------
                e.ClassificationOID,
                e.CategoryOID,
                e.AuthorityOID,
                e.UnitOID,
                e.CompanyType,
                e.CounterType,
                CaseNumber = e.Casenumber,
                LegalNatureOID = e.LegalNature,
                LegalNatureSubOID = e.LegalSubNature,
                e.CaseTypeOID,
                e.CourtOID,
                e.PoliceStation,
                FIRNo = e.FirNo,
                SubjectMasterOID = e.SubjectmatterOID,
                BreifParticulars = e.Breifparticulars,
                SubjectMasterDescription = e.SubjectmatterDescription,
                e.ReliefClaims,
                e.LitigationOID,
                e.CourtName,
                CaseFileDt = e.CaseFileDate,

                // -------- FINANCIAL --------
                e.EstimatedCost,
                e.BankGuarantee,
                e.ContingentLiability,
                e.ProvisionMade,
                e.AuthorityNominee,
                e.POA,
                e.DirectorInvolved,
                e.POABRLOA,
                DateofNotice = e.DateOfNotice,
                e.ByagainstStatutoryauthority,
                e.RelatedPeriod,
                e.CircleZoneRegion,

                e.AmountClaimAmount,
                e.AmountInterest,
                e.AmountPenalty,
                e.ContingentClaimAmount,
                e.ContingentInterest,
                e.ContingentPenalty,
                e.ProvisionClaimAmount,
                e.ProvisionInterest,
                e.ProvisionPenalty,

                // -------- RISK --------
                e.RiskOID,
                e.FileNumber,
                e.CaseBackground,
                connected_LitigationOID = e.Connected_LitigationOID,
                e.ConfidentialityType,
                dateoffirsthearing = e.DateofFirstHearing,
                e.NameofJudges,

                // -------- AMOUNT INVOLVED --------
                e.AmountInvolvedByCompanyInterestRate,
                e.AmountInvolvedByCompanyDateofInterest,
                e.AmountInvolvedAgainstCompanyClaim,
                e.AmountInvolvedAgainstCompanyInterest,
                e.AmountInvolvedAgainstCompanyPenalty,
                e.AmountInvolvedAgainstCompanyTotal,
                e.AmountInvolvedAgainstCompanyInterestRate,
                e.AmountInvolvedAgainstCompanyDateofInterest,
                e.ContingentLiabilityInterestRate,
                e.ContingentLiabilityDateofInterest,
                e.ProvisioninthebooksofCompanyInterestRate,
                e.ProvisioninthebooksofCompanyDateofInterest,

                // -------- CUSTOMER / CONTRACT --------
                e.ContractNo,
                e.AmountRecovered,
                e.CustomerID,
                e.InternalCustomer,
                e.DateOfReference,
                e.DateOfRecovery,
                e.ActionPlan,
                e.AmountofDeposit,
                e.SubUnitOID,

                // -------- COMPLIANCE --------
                e.IsStaffOrExStaffInvolved,
                e.StaffOrExStaffDetails,
                e.IsWilfulDefaulter,
                e.WilfulDefaulterDetails,
                e.IsFraud,
                e.FraudDetails,
                e.IsStaffAccountability,
                e.StaffAccountabilityDetails,
                e.ValuerForFraud,
                e.AdvocateForFraud,

                // -------- STAY --------
                e.Stay,
                e.StayDate,
                e.StayDescription,
                e.OfficialLiquidators,
                e.ApprovedValuerOID,

                // -------- LOCATION --------
                StateOID = e.StateLitigationOID,
                DistrictOID = e.DistrictLitigationOID,
                e.IsCustomerInvolved,
                e.ATMRelated,

                // -------- INSOLVENCY --------
                e.DateofAdmission,
                e.NameofInterimResolutionProfessional,
                e.NameofResolutionProfessional,
                e.OBCClaimFiled,
                e.ClaimFilingDate,
                e.AmountofClaim,
                e.CIRPExpiringDate,
                e.ExtensionofCIRPifAny,
                e.CIRPExtensionDate,
                e.AmountInvolvedType,

                // -------- OUTLOOK --------
                e.Outlook,
                e.ReserveRecorder,
                e.Duty,
                e.Penalty,
                e.AmountPaidReport,
                e.AnticipatedResolution,
                e.FutureAction,

                // -------- ADDITIONAL --------
                e.MaximumExposure,
                e.Interest,
                e.PeriodInvolved,
                e.BankGuaranteeABG,
                e.ProcessOwner,
                e.SupportPerson,
                e.FileNo,
                e.ModelOID,
                e.DealerNameOID,
                e.VIN,
                e.EngineNo,
                e.VerticalOID,
                e.AmountInvolvedComments,
                e.GLAccountDetails,
                e.Channel,
                e.SubBroker,
                e.PolicyNumber,
                StartDatePolicy = e.dtStartDatePolicy,
                EndDatePolicy = e.dtEndDatePolicy,
                e.DepartmentClaim,
                e.TypeofTax,
                e.RevisedCaseNo,
                e.CollectionofMoney,

                // -------- COURT --------
                e.CNRNumber,
                e.NatureofDisposal,
                e.RegistrationNumber,
                e.FilingNumber,
                e.DecisionDate,
                e.RegistrationDate,
                e.Nameofaccused,
                e.Dateofcomplinace,
                e.MSILFileNo,
                e.DetailsofDepositsPaid,
                e.UnderSection,
                e.MSILCaseTypeOID,
                e.NonMonetary,
                e.SubCategory1OID,
                e.DealerActingAsOID,
                e.CaseReferenceNumber,
                e.AmountType,
                e.TargetDisposalDate,

                // -------- DATE RANGE --------
                AmountInvolvedInterestRate = e.AmountInterestRate,
                AmountInvolvedFromDate = e.AmountFromDate,
                AmountInvolvedToDate = e.AmountToDate,
                ProvisioninthebooksofCompanyFromDate = e.ProvisionFromDate,
                ProvisioninthebooksofCompanyToDate = e.ProvisionToDate,
                ContingentLiabilityFromDate = e.ContingentFromDate,
                ContingentLiabilityToDate = e.ContingentToDate
            };

            return await conn.ExecuteAsync(
                "UpdateLitigationDetails1",
                parameters,
                commandType: CommandType.StoredProcedure
              
            );
        }
        public async Task<IEnumerable<dynamic>> GetLitigationDocumentsPOABRLOA(int LitigationOID, string DocType)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetLitigationDocumentsPOABRLOA", new
            {
                LitigationOID = LitigationOID,
                DocType = DocType

            });
        }
        #endregion

        #region Litigation Report
        public async Task<IEnumerable<dynamic>> GetLitigationIDforReport(int UserOID,int UnitOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetALLLitigationID", new
            {
                UnitOID=UnitOID,
                UserOID = UserOID
            });
        }
        public async Task<IEnumerable<dynamic>> GetLitigationDetailforReport(int LitigationOID,int UserOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetLitigationReport", new
            {
                LitigationOID = LitigationOID,
                UserOID = UserOID
            });
        }

        public async Task<IEnumerable<dynamic>> GetLitigationActionItemSummary(int LitigationOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetActionItemSummary", new
            {
                LitigationOID = LitigationOID               
            });
        }

        public async Task<IEnumerable<dynamic>> GetLitigationMetricsReport(LitigationMetricsFilterDto filter)
        {
          
                using var conn = CreateConnection();

                var result = await _dapper.QueryAsync<dynamic>(
                    conn,
                    "GetLitigationMatricsReport",
                    new
                    {
                        FromDate = filter.FromDate,
                        ToDate = filter.ToDate,
                        UserOID = filter.UserOID,
                        Entity = filter.Entity,
                        Unit = filter.Unit,
                        CaseType = filter.CaseType,
                        ClasificationType = filter.ClasificationType,
                        CourtType = filter.CourtTypeOID,
                        CourtName = filter.CourtName,
                        CategoryType = filter.CategoryType,
                        StatusOID = filter.StatusOID,
                        CompanyLawFirmAdvocate = filter.PartyMasterOID,
                        LegalNatureOID = filter.LegalNature,
                        LegalSubNatureOID = filter.LegalSubNature,
                        SubjectMatterOID = filter.SubjectmatterOID,
                        UnderActOID = filter.UnderActs,
                        minamt = filter.MinAmount,
                        maxamt = filter.MaxAmount,
                        DirectorInvolved = filter.DirectorInvolved,
                        ByagainstStatutoryauthority = filter.ByagainstStatutoryauthority,
                        ContractNo = filter.ContractNo,
                        RiskOID = filter.RiskOID,
                        CustomerID = filter.CustomerID,
                        Region = filter.Region,
                        DateCriteria = filter.DateCriteria,
                        LawFirmClient = filter.LawFirmClient,
                        IsStaffOrExStaffInvolved = filter.IsStaffOrExStaffInvolved,
                        IsCustomerInvolved = filter.IsCustomerInvolved,
                        LitigationStatus = filter.LitigationStatus,
                        CourtTypeOID = filter.CourtTypeOID,
                        StateOID = filter.StateOID,
                        DistrictOID = filter.DistrictOID,
                        CaseNumber = filter.CaseNumber,
                        CaseYear = filter.CaseYear,
                        TypeOfCourtValue = filter.TypeOfCourtValue,
                        BenchValue = filter.BenchValue,
                        CaseTypeOID = filter.CaseTypeOID,
                        CourtComplexOID = filter.CourtComplexOID,
                        StampValue = filter.StampValue,
                        SideValue = filter.SideValue,
                        Textsearch = filter.TextSearch,
                        MatterHandledByOID = filter.MatterHandledByOID
                    }
                );

                return result;
           
        }
        public async Task<IEnumerable<dynamic>> GetMISReport(MISReportFilterDto filter)
        {
            
                using var conn = CreateConnection();

                var result = await _dapper.QueryAsync<dynamic>(
                    conn,
                    "GETMISReport",
                    new
                    {
                        MonthFirstDate = filter.MonthFirstDate,
                        MonthLastDate = filter.MonthLastDate,
                        LastMonthLastDate = filter.LastMonthLastDate,
                        UserOID = filter.UserOID,
                        Entity = filter.Entity
                    }
                );

                return result;
            
        }
        public async Task<IEnumerable<dynamic>> GetMISReportUnitWise(MISReportUnitWiseFilterDto filter)
        {
            
                using var conn = CreateConnection();

                var result = await _dapper.QueryAsync<dynamic>(
                    conn,
                    "GETMISReportUnitWise",
                    new
                    {
                        MonthFirstDate = filter.MonthFirstDate,
                        MonthLastDate = filter.MonthLastDate,
                        LastMonthLastDate = filter.LastMonthLastDate,
                        UserOID = filter.UserOID,
                        Entity = filter.Entity
                    }
                );

                return result;
           
        }
        public async Task<IEnumerable<BillTypeDto>> GetBillTypes()
        {
            using var conn = CreateConnection();

            return await conn.QueryAsync<BillTypeDto>(
                "GetBillTypesForNotice",
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<IEnumerable<dynamic>> GetCompanyLawFirmByLitigationAndPartyType(int LitigationOID, int PartyTypeOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetCompanyLawFirmByLitigationAndPartyType", new
            {
                LitigationOID = LitigationOID,
                PartyTypeOID= PartyTypeOID
            });
        }
        public async Task<IEnumerable<LitigationBillingReportDto>> GetLitigationBillingReport(LitigationBillingReportFilterDto filter)
        {
            using var conn = CreateConnection();

            return await conn.QueryAsync<LitigationBillingReportDto>(
                "GetLitigationBillingReport",
                new
                {
                    UserOID = filter.UserOID,
                    BillingType = filter.BillingTypeOID,
                    LitigationOID = filter.LitigationOID,
                    Entity = filter.Entity,
                    Unit = filter.Unit,
                    PartyMasterOID = filter.PartyMasterOID,
                    BillStatus = filter.BillStatus,
                    FromDate = filter.FromDate,
                    ToDate = filter.ToDate,
                    TextSearch = filter.TextSearch
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<IEnumerable<CauseListDto>> GetCauseListReport(CauseListFilterDto filter)
        {
          
                using var conn = CreateConnection();

            return await conn.QueryAsync<CauseListDto>(
                "GetCauseList",
                    new
                    {
                        FromDate = filter.FromDate,
                        ToDate = filter.ToDate,
                        UserOID = filter.UserOID,
                        Entity = filter.Entity,
                        Unit = filter.Unit,
                        CaseType = filter.CaseType,
                        ClasificationType = filter.ClasificationType,
                        CourtType = filter.CourtType,
                        CategoryType = filter.CategoryType,
                        StatusOID = filter.StatusOID,
                        CompanyLawFirmAdvocate = filter.PartyMasterOID,
                        SubjectMatterOID = filter.SubjectMatterOID,
                        UnderActOID = filter.UnderActOID,
                        minamt = filter.MinAmount,
                        maxamt = filter.MaxAmount,
                        DirectorInvolved = filter.DirectorInvolved,
                        ByagainstStatutoryauthority = filter.ByagainstStatutoryauthority,
                        Region = filter.Region,
                        TextSearch = filter.TextSearch
                    },
                      commandType: CommandType.StoredProcedure
                );

               // return result;
            
        }
        //public async Task<int> InsertLitigationFromImport(LitigationEntity_Roznama dto)
        //{
        //    using var conn = CreateConnection();

        //    var result = await conn.QueryFirstOrDefaultAsync<int>(
        //        "Check_InsertLitigation",
        //        new
        //        {
        //            CourtName = dto.CourtName,
        //            CourtTypeOID = dto.CourtTypeOID,
        //            BenchName = dto.BenchName,
        //            CaseNumber = dto.CaseNumber,
        //            CaseTypeName = dto.CaseTypeName,
        //            CaseYear = dto.CaseYear,
        //            StageName = dto.StageName,
        //            UnderActsName = dto.UnderActsName,
        //            SubjectMatter = dto.SubjectMatter,
        //            CaseFileDate = dto.CaseFileDate,
        //            NextHearingDate = dto.NextHearingDate,
        //            BankGuarantee = dto.BankGuarantee,
        //            CategoryName = dto.CategoryName,
        //            SubCategory = dto.SubCategory,
        //            AuthorityNominee = dto.AuthorityNominee,
        //            POABRLOA = dto.POABRLOA,
        //            RiskName = dto.RiskName,
        //            Breifparticulars = dto.Breifparticulars,
        //            SubjectmatterDescription = dto.SubjectmatterDescription,
        //            ReliefClaims = dto.ReliefClaims,
        //            CaseReferenceNumber = dto.CaseReferenceNumber,

        //            AmountClaimAmount = dto.AmountClaimAmount,
        //            AmountInterest = dto.AmountInterest,
        //            AmountPenalty = dto.AmountPenalty,

        //            ContingentClaimAmount = dto.ContingentClaimAmount,
        //            ContingentInterest = dto.ContingentInterest,
        //            ContingentPenalty = dto.ContingentPenalty,

        //            ProvisionClaimAmount = dto.ProvisionClaimAmount,
        //            ProvisionInterest = dto.ProvisionInterest,
        //            ProvisionPenalty = dto.ProvisionPenalty,

        //            MatterHandledbyName = dto.MatterHandledbyName,
        //            UnitMemberName = dto.UnitMemberName,
        //            ClasificationTypeName = dto.ClasificationTypeName,
        //            EntityName = dto.EntityName,
        //            UnitName = dto.UnitName,

        //            CoParties = dto.CoParties,
        //            DirectorInvolved = dto.DirectorInvolved,
        //            CounterParties = dto.CounterParties,
        //            CompanyAdvocate = dto.CompanyAdvocate,
        //            CounterAdvocate = dto.CounterAdvocate,

        //            CNRNumber = dto.CNRNumber,
        //            FilingNumber = dto.FilingNumber,
        //            RegistrationNumber = dto.RegistrationNumber,
        //            DecisionDate = dto.DecisionDate,
        //            RegistrationDate = dto.RegistrationDate,

        //            StateName = dto.StateName,
        //            DistrictName = dto.DistrictName,
        //            HighCourtName = dto.HighCourtName,
        //            TribunalCourtName = dto.TribunalCourtName,
        //            ConsumerCourtName = dto.ConsumerCourtName,
        //            CourtComplexName = dto.CourtComplexName,

        //            CompanyType = dto.CompanyType,
        //            EstimatedCost = dto.EstimatedCost,
        //            HearingDate = dto.HearingDate,

        //            ByagainstStatutoryauthority = dto.ByagainstStatutoryauthority,
        //            DirectorPromoter = dto.DirectorName,
        //            CompanyAdvocateDetails = dto.CompanyAdvocate,
        //            POAAvailable = dto.POA,

        //            CounterPartiesDetails = dto.CounterParties,
        //            CounterAdvocateDetails = dto.CounterAdvocate,

        //            CaseBackground = dto.CaseBackground,
        //            PoliceStation = dto.PoliceStation,
        //            FirNo = dto.FirNo,

        //            ContingentLiability = dto.ContingentLiability,
        //            DateofNoticeSummons = dto.DateofNoticeSummons,
        //            DetailsofDeposit = dto.DetailsofDepositsPaid,

        //            RelatedPeriod = dto.RelatedPeriod,

        //            AmountInvolvedClaimAmount = dto.AmountClaimAmount,
        //            AmountInvolvedInterest = dto.AmountInterest,
        //            AmountInvolvedPenalty = dto.AmountPenalty,

        //            ContingentLiabilityClaimAmount = dto.ContingentClaimAmount,
        //            ContingentLiabilityInterest = dto.ContingentInterest,
        //            ContingentLiabilityPenalty = dto.ContingentPenalty,

        //            CoPartiesNew = dto.CoParties,
        //            NameofCourtType = dto.NameofCourtType
        //        },
        //        commandType: CommandType.StoredProcedure
        //    );

        //    return result;
        //}
        #endregion

        //end-alisha chnages on 05-08-2026
        // to check the status
    }
}

