using Roznama.Models.Dropdown;

namespace Roznama.Modules.Common
{
    public class DropdownService
    {
        private readonly DropdownRepository _repo;

        public DropdownService(DropdownRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<dynamic>> GetEntities(int entityOID, int userOID, string role)
            => _repo.GetEntities(entityOID, userOID, role);

        public Task<IEnumerable<dynamic>> GetUnits(int entityOID, int userOID)
            => _repo.GetUnits(entityOID, userOID);

        public Task<IEnumerable<dynamic>> GetZones(int entityOID, int unitOID, int userOID)
            => _repo.GetZones(entityOID, unitOID, userOID);

        public Task<IEnumerable<dynamic>> GetRegions(int entityOID, int unitOID, int zoneOID, int userOID)
            => _repo.GetRegions(entityOID, unitOID, zoneOID, userOID);

        public Task<IEnumerable<dynamic>> GetDepartments(int userOID, string role)
            => _repo.GetDepartments(userOID, role);

        public Task<IEnumerable<dynamic>> GetClassification()
            => _repo.GetClassificationTypes();

        public Task<IEnumerable<dynamic>> GetCategory(int classificationOID)
            => _repo.GetCategoryTypes(classificationOID);

        public Task<IEnumerable<dynamic>> GetSubCategory(int categoryOID)
            => _repo.GetSubCategoryTypes(categoryOID);

        public Task<IEnumerable<dynamic>> GetStatus(int noticeOID)
            => _repo.GetStatuses(noticeOID);

        public Task<IEnumerable<dynamic>> GetSubStatus(int statusOID)
            => _repo.GetSubStatuses(statusOID);

        public Task<IEnumerable<dynamic>> GetRisk()
            => _repo.GetRiskDetails();

        public Task<IEnumerable<dynamic>> GetTeamMembers(int unitOID)
            => _repo.GetTeamMembers(unitOID);

        public Task<IEnumerable<dynamic>> GetSubUnits()
            => _repo.GetSubUnits();

        public Task<IEnumerable<dynamic>> GetNoticeTypes()
            => _repo.GetNoticeTypes();

        public Task<IEnumerable<dynamic>> GetRLM()
            => _repo.GetRLMs();

        public Task<IEnumerable<dynamic>> GetStates()
            => _repo.GetStates();

        public Task<IEnumerable<dynamic>> GetCities(int stateOID)
            => _repo.GetCities(stateOID);

        public Task<IEnumerable<dynamic>> GetAllCourtType(string DigitizedOrNonDigitized ="", string CNRCaseNumber ="")
           => _repo.GetAllCourtType(DigitizedOrNonDigitized, CNRCaseNumber);
        public Task<IEnumerable<dynamic>> GetAllLitigationCategory()
           => _repo.GetAllLitigationCategory();

        public Task<IEnumerable<dynamic>> GetPOABRLOA()
          => _repo.GetPOABRLOA();

        public Task<IEnumerable<dynamic>> GetCompanyType(int ClassificationTypeOID, int LitigationCategoryOID)
         => _repo.GetCompanyType(ClassificationTypeOID, LitigationCategoryOID);

        public Task<IEnumerable<dynamic>> GetCounterType(string CompanyType,int ClassificationTypeOID, int LitigationCategoryOID)
       => _repo.GetCounterType(CompanyType,ClassificationTypeOID, LitigationCategoryOID);

        public Task<IEnumerable<dynamic>> GetPartySummary(int PartyTypeOID)
     => _repo.GetPartySummary(PartyTypeOID);

        public Task<IEnumerable<dynamic>> GetAuthority()
         => _repo.GetPOABRLOA();

        public Task<IEnumerable<dynamic>> GetNonDegitizeBench()
        => _repo.GetNonDigitizeBench();

        public Task<IEnumerable<dynamic>> GetNonDigitizeCaseTypeMaster()
       => _repo.GetNonDigitizeCaseTypeMaster();

        public Task<IEnumerable<dynamic>> GetMatterHandledby(int UnitOID)
     => _repo.GetMatterHandledby(UnitOID);

        public Task<IEnumerable<dynamic>> GetUnitMember(int UnitOID)
   => _repo.GetUnitMember(UnitOID);

        public Task<IEnumerable<dynamic>> GetAllStages()
=> _repo.GetAllStages();
        public Task<IEnumerable<dynamic>> GetDirectorPromoterName(int UnitOID)
   => _repo.GetDirectorPromoterName(UnitOID);
        public Task<IEnumerable<dynamic>> GetLitigationSubCategoryMaster()
=> _repo.GetLitigationSubCategoryMaster();
        public Task<IEnumerable<dynamic>> GetSubCategory1(int SubCategoryOID)
=> _repo.GetSubCategory1(SubCategoryOID);

        public Task<IEnumerable<dynamic>> GetSubUnitDetail()
=> _repo.GetSubUnitDetail();

    }
}