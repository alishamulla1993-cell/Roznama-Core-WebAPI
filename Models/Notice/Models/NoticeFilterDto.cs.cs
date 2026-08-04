namespace Roznama.Models.Notice.Models
{
    public class NoticeFilterDto
    {
        public int? ClassificationTypeOID { get; set; } = 0;
        public int? CategoryTypeOID { get; set; } = 0;
        public int? DeptOID { get; set; } = 0;
        public int? EntityOID { get; set; } = 0;
        public int? UnitOID { get; set; } = 0;
        public int? StatusOID { get; set; } = 0;
        public string txtsearch { get; set; } = "";

        public int UserOID { get; set; }      // REQUIRED
        public string Role { get; set; } = "";

        public int? SubClassificationTypeOID { get; set; } = 0;
        public int? SubCategoryTypeOID { get; set; } = 0;
        public int? RiskOID { get; set; } = 0;
        public string MybucketList { get; set; } = "";

        public int? SubUnitOID { get; set; } = 0;
        public int? SubStatusOID { get; set; } = 0;
        public int? NoticeDeliveryStatusOID { get; set; } = 0;
        public int? ConfidentialType { get; set; } = 0;

        public int? StateOID { get; set; } = 0;
        public int? DistrictOID { get; set; } = 0;
        public string NoticeType { get; set; } = "";

        public int? ZoneOID { get; set; } = 0;
        public string ZoneName { get; set; } = "";

        public int? RegionOID { get; set; } = 0;
        public string RegionName { get; set; } = "";

        public string MatterHandledByOID { get; set; } = "";
        public string NoticeTypeOID { get; set; } = "";
        public string RLMOID { get; set; } = "";

        public string FromDt { get; set; } = "08/01/2024";
        public string ToDt { get; set; } = "08/31/2024";
        public string IsFilterOnCreatedDate { get; set; } = "N";

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 25;
    }
}