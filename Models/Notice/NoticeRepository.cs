using Dapper;
using Roznama.Infrastructure.Database;
using Roznama.Models.Litigation;
using Roznama.Models.Litigation.Models;
using Roznama.Models.Notice.Models;
using System.Data;

namespace Roznama.Modules.Notice
{
    public class NoticeRepository : RepositoryBase
    {
        public NoticeRepository(DbConnectionFactory dbFactory, DapperHelper dapper) : base(dbFactory, dapper) { }

        public async Task<NoticeDetailDto?> GetNoticeDetailAsync(int noticeOID)
        {
            using var conn = CreateConnection();

            var p = new DynamicParameters();
            p.Add("@NoticeOID", noticeOID);

            return await conn.QueryFirstOrDefaultAsync<NoticeDetailDto>(
                "GetNoticeDetailbyNoticeOID",
                p,
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<dynamic>> GetNoticeSummaryAsync(NoticeFilterDto f)
        {
            using var conn = CreateConnection();

            var p = new DynamicParameters();

            // Map all filter fields
            p.Add("@ClassificationTypeOID", f.ClassificationTypeOID);
            p.Add("@CategoryTypeOID", f.CategoryTypeOID);
            p.Add("@DeptOID", f.DeptOID);
            p.Add("@EntityOID", f.EntityOID);
            p.Add("@UnitOID", f.UnitOID);
            p.Add("@StatusOID", f.StatusOID);
            p.Add("@txtsearch", f.txtsearch);
            p.Add("@UserOID", f.UserOID);
            p.Add("@Role", f.Role);
            p.Add("@SubClassificationTypeOID", f.SubClassificationTypeOID);
            p.Add("@SubCategoryTypeOID", f.SubCategoryTypeOID);
            p.Add("@RiskOID", f.RiskOID);
            p.Add("@MybucketList", f.MybucketList);
            p.Add("@SubUnitOID", f.SubUnitOID);
            p.Add("@SubStatusOID", f.SubStatusOID);
            p.Add("@NoticeDeliveryStatusOID", f.NoticeDeliveryStatusOID);
            p.Add("@ConfidentialType", f.ConfidentialType);
            p.Add("@StateOID", f.StateOID);
            p.Add("@DistrictOID", f.DistrictOID);
            p.Add("@NoticeType", f.NoticeType);
            p.Add("@ZoneOID", f.ZoneOID);
            p.Add("@ZoneName", f.ZoneName);
            p.Add("@RegionOID", f.RegionOID);
            p.Add("@RegionName", f.RegionName);
            p.Add("@MatterHandledByOID", f.MatterHandledByOID);
            p.Add("@NoticeTypeOID", f.NoticeTypeOID);
            p.Add("@RLMOID", f.RLMOID);
            p.Add("@FromDt", f.FromDt);
            p.Add("@ToDt", f.ToDt);
            p.Add("@IsFilterOnCreatedDate", f.IsFilterOnCreatedDate);
            p.Add("@PageNumber", f.PageNumber);
            p.Add("@PageSize", f.PageSize);

            return await conn.QueryAsync<dynamic>(
                "GetNoticeSummarry_CTE_Optimized",
                p,
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<IEnumerable<dynamic>> GetNoticeSummaryTotalCount(NoticeFilterDto f)
        {
            using var conn = CreateConnection();

            var p = new DynamicParameters();

            // Map all filter fields
            p.Add("@ClassificationTypeOID", f.ClassificationTypeOID);
            p.Add("@CategoryTypeOID", f.CategoryTypeOID);
            p.Add("@DeptOID", f.DeptOID);
            p.Add("@EntityOID", f.EntityOID);
            p.Add("@UnitOID", f.UnitOID);
            p.Add("@StatusOID", f.StatusOID);
            p.Add("@txtsearch", f.txtsearch);
            p.Add("@UserOID", f.UserOID);
            p.Add("@Role", f.Role);
            p.Add("@SubClassificationTypeOID", f.SubClassificationTypeOID);
            p.Add("@SubCategoryTypeOID", f.SubCategoryTypeOID);
            p.Add("@RiskOID", f.RiskOID);
            p.Add("@MybucketList", f.MybucketList);
            p.Add("@SubUnitOID", f.SubUnitOID);
            p.Add("@SubStatusOID", f.SubStatusOID);
            p.Add("@NoticeDeliveryStatusOID", f.NoticeDeliveryStatusOID);
            p.Add("@ConfidentialType", f.ConfidentialType);
            p.Add("@StateOID", f.StateOID);
            p.Add("@DistrictOID", f.DistrictOID);
            p.Add("@NoticeType", f.NoticeType);
            p.Add("@ZoneOID", f.ZoneOID);
            p.Add("@ZoneName", f.ZoneName);
            p.Add("@RegionOID", f.RegionOID);
            p.Add("@RegionName", f.RegionName);
            p.Add("@MatterHandledByOID", f.MatterHandledByOID);
            p.Add("@NoticeTypeOID", f.NoticeTypeOID);
            p.Add("@RLMOID", f.RLMOID);
            p.Add("@FromDt", f.FromDt);
            p.Add("@ToDt", f.ToDt);
            p.Add("@IsFilterOnCreatedDate", f.IsFilterOnCreatedDate);
            p.Add("@PageNumber", f.PageNumber);
            p.Add("@PageSize", f.PageSize);

            return await conn.QueryAsync<dynamic>(
                "GetNoticeSummarry_TotalCount",
                p,
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<List<UnitMemberDto>> GenerateUnitMembersAsync(GenerateUnitMemberRequest request)
        {
            // 👉 Later: SQL / Dapper / Stored Procedure here
            return await Task.FromResult(new List<UnitMemberDto>());
        }

        public async Task<List<MatterHandledByDto>> GenerateMatterHandledByAsync(GenerateMatterHandledByRequest request)
        {
            // 🔸 Future: DB / Stored Procedure logic if required
            return await Task.FromResult(new List<MatterHandledByDto>());
        }

        public async Task<List<PartyDto>> GeneratePartiesAsync(GeneratePartyRequest request)
        {
            // 🔸 Future DB / SP logic
            return await Task.FromResult(new List<PartyDto>());
        }

        public async Task<List<OppositePartyDto>> GenerateOppositePartiesAsync(GenerateOppositePartyRequest request)
        {
            // 🔸 DB / Stored Procedure can be added later
            return await Task.FromResult(new List<OppositePartyDto>());
        }

        public async Task<List<LawFirmAdvocateDto>> GenerateAsync(GenerateLawFirmAdvocateRequest request)
        {
            // DB / SP integration can be added later
            return await Task.FromResult(new List<LawFirmAdvocateDto>());
        }
        public async Task<List<LawFirmAdvocateCommonDto>> GenerateAsync(GenerateCounterLawFirmAdvocateRequest request)
        {
            // DB / SP logic can be added later
            return await Task.FromResult(new List<LawFirmAdvocateCommonDto>());
        }
    }




}
