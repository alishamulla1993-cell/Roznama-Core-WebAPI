namespace Roznama.Common.Constants
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class Auth
        {
            public const string Login = Base + "/auth/login";
            public const string Logout = Base + "/auth/logout";
            public const string RefreshToken = Base + "/auth/refresh";
        }
        public static class Dashboard
        {
            public const string DashboardCount = Base + "/DashboardCount";
        }
        public static class Notice
        {
            public const string Summary = Base + "/notice/summary";
            public const string SummaryTotalCount = Base + "/notice/summary-total";
            public const string SummaryInit = Base + "/notice/summary-init";
            public const string Detail = Base + "/notice/detail/{NoticeOID}";
            public const string Add = Base + "/notice/add";
            public const string Update = Base + "/notice/update";
            public const string Delete = Base + "/notice/delete/{NoticeOID}";
            public const string Dropdowns = Base + "/notice/dropdowns";
        }

        public static class Litigation
        {
            public const string Summary = Base + "/litigation/summary";
            public const string Detail = Base + "/litigation/detail/{LitigationOID}";
            public const string Add = Base + "/litigation/add";
            public const string Update = Base + "/litigation/update";
        }

        public static class Arbitration
        {
            public const string Summary = Base + "/arbitration/summary";
            public const string Detail = Base + "/arbitration/detail/{ArbitrationOID}";
            public const string Add = Base + "/arbitration/add";
        }

        public static class Masters
        {
            public const string Entities = Base + "/masters/entities";
            public const string Units = Base + "/masters/units/{EntityOID}";
            public const string Zones = Base + "/masters/zones/{EntityOID}/{UnitOID}";
            public const string Regions = Base + "/masters/regions/{EntityOID}/{UnitOID}/{ZoneOID}";
        }
    }
}