using Dapper;
using Roznama.Infrastructure.Database;
using System.Data;

namespace Roznama.Modules.Common
{
    public class DropdownRepository : RepositoryBase
    {
        public DropdownRepository(DbConnectionFactory db, DapperHelper dapper)
            : base(db, dapper) { }

        public async Task<IEnumerable<dynamic>> GetEntities(int entityOID, int userOID, string role)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetEntities", new
            {
                EntityOID = entityOID,
                UserOID = userOID,
                Role = role
            });
        }

        public async Task<IEnumerable<dynamic>> GetUnits(int entityOID, int userOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetAllUnits", new
            {
                EntityOID = entityOID,
                UserOID = userOID
            });
        }

        public async Task<IEnumerable<dynamic>> GetZones(int entityOID, int unitOID, int userOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetZones", new
            {
                EntityOID = entityOID,
                UnitOID = unitOID,
                UserOID = userOID
            });
        }

        public async Task<IEnumerable<dynamic>> GetRegions(int entityOID, int unitOID, int zoneOID, int userOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetRegions", new
            {
                EntityOID = entityOID,
                UnitOID = unitOID,
                ZoneOIDs = zoneOID.ToString(),
                UserOID = userOID
            });
        }

        public async Task<IEnumerable<dynamic>> GetDepartments(int userOID, string role)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetDepartmentType", new
            {
                UserOID = userOID,
                Role = role
            });
        }

        public async Task<IEnumerable<dynamic>> GetClassificationTypes()
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetClassificationType");
        }

        public async Task<IEnumerable<dynamic>> GetCategoryTypes(int classificationTypeOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetCategoryType", new
            {
                ClassificationTypeOID = classificationTypeOID
            });
        }

        public async Task<IEnumerable<dynamic>> GetSubCategoryTypes(int categoryTypeOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetSubCategoryType", new
            {
                CategoryTypeOID = categoryTypeOID
            });
        }

        public async Task<IEnumerable<dynamic>> GetStatuses(int noticeOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetStatusDetail", new
            {
                NoticeOID = noticeOID
            });
        }

        public async Task<IEnumerable<dynamic>> GetSubStatuses(int statusOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetNoticeSubStatus", new
            {
                NoticeStatusOID = statusOID
            });
        }

        public async Task<IEnumerable<dynamic>> GetRiskDetails()
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetRiskDetail");
        }

        public async Task<IEnumerable<dynamic>> GetTeamMembers(int unitOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetMatterHandledBy", new
            {
                UnitOID = unitOID
            });
        }

        public async Task<IEnumerable<dynamic>> GetSubUnits()
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetSubUnitDetail");
        }

        public async Task<IEnumerable<dynamic>> GetNoticeTypes()
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetNoticeType");
        }

        public async Task<IEnumerable<dynamic>> GetRLMs()
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetRLM");
        }

        public async Task<IEnumerable<dynamic>> GetStates()
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "SpGetAllState", new
            {
                CourtTypeOID = 0
            });
        }

        public async Task<IEnumerable<dynamic>> GetCities(int stateOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetAllDistrict", new
            {
                STATEOID = stateOID
            });
        }

        //Get court type for digitized and non digitized
        public async Task<IEnumerable<dynamic>> GetAllCourtType(string DigitizedOrNonDigitized="" ,string CNRCaseNumber="")
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "CasewiseCrawlerGetCourtType", new
            {
                DigitizedOrNonDigitized = DigitizedOrNonDigitized
                //, CNRCaseNumber = CNRCaseNumber
            });
        }

        //Get Categories
        public async Task<IEnumerable<dynamic>> GetAllLitigationCategory()
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetAllLitigationCategory", new
            {
               // DigitizedOrNonDigitized = DigitizedOrNonDigitized
                //, CNRCaseNumber = CNRCaseNumber
            });
        }
        public async Task<IEnumerable<dynamic>> GetPOABRLOA()
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetPOABRLOA", new
            {
               
            });
        }
        public async Task<IEnumerable<dynamic>> GetCompanyType(int ClassificationTypeOID, int LitigationCategoryOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetCompanyType", new
            {
                ClassificationType = ClassificationTypeOID,
                LitigationCategoryOID= LitigationCategoryOID
            });
        }
        public async Task<IEnumerable<dynamic>> GetCounterType(string CompanyType,int ClassificationTypeOID, int LitigationCategoryOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetCounterType", new
            {
                ClassificationType = ClassificationTypeOID,
                LitigationCategoryOID = LitigationCategoryOID,
                CompanyType= CompanyType
            });
        }
        public async Task<IEnumerable<dynamic>> GetPartySummary(int PartyTypeOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetPartyMaster", new
            {
                PartyTypeOID = PartyTypeOID
              
               
            });
        }
        public async Task<IEnumerable<dynamic>> GetAuthority()
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetAuthority", new
            {

            });
        }

        public async Task<IEnumerable<dynamic>> GetNonDigitizeBench()
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
        public async Task<IEnumerable<dynamic>> GetMatterHandledby(int UnitOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetMatterHandledBy", new
            {
                UnitOID = UnitOID


            });
        }
        public async Task<IEnumerable<dynamic>> GetUnitMember(int UnitOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetUnitMembers", new
            {
                UnitOID = UnitOID


            });
        }
        public async Task<IEnumerable<dynamic>> GetAllStages()
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetAllStages", new
            {
            });
        }
        public async Task<IEnumerable<dynamic>> GetDirectorPromoterName(int UnitOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetDirectorPromoterName", new
            {
                UnitOID = UnitOID


            });
        }
        public async Task<IEnumerable<dynamic>> GetLitigationSubCategoryMaster()
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetLitigationSubCategoryMaster", new
            {
            });
        }
        public async Task<IEnumerable<dynamic>> GetSubCategory1(int SubCategoryOID)
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetSubCategory1", new
            {
                SubCategoryOID = SubCategoryOID


            });
        }

        public async Task<IEnumerable<dynamic>> GetSubUnitDetail()
        {
            using var conn = CreateConnection();
            return await _dapper.QueryAsync<dynamic>(conn, "GetSubUnitDetail", new
            {
            });
        }
    }
}