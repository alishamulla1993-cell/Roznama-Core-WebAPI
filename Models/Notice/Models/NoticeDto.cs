namespace Roznama.Modules.Notice.Models
{
    public class NoticeDto
    {
        public int NoticeOID { get; set; }
        public string NoticeID { get; set; } = string.Empty;

        public string ClientName { get; set; } = string.Empty;
        public DateTime NoticeDate { get; set; }

        public string StatusName { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public string DeptName { get; set; } = string.Empty;


        public int ClassificationTypeOID { get; set; }
        public int AuthorizedSignatoryOID { get; set; }
        public int CategoryTypeOID { get; set; }
        public string StatutoryAuthority { get; set; } = string.Empty;
        public int DeptOID { get; set; }
        public int StatusOID { get; set; }

        public int DraftStatusOID { get; set; }
        public int RiskOID { get; set; }

        public DateTime IssueDate { get; set; }
        public DateTime LastDateOfRecPayment { get; set; }
        public DateTime DateofNPA { get; set; }

        public int EntityOID { get; set; }
        public string NoticeNo { get; set; } = string.Empty;
        public string Legislation { get; set; } = string.Empty;
        public string ReleventCaseLaw { get; set; } = string.Empty;
        public string MakerCheckerStatus { get; set; } = string.Empty;
        public string Section { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;

        public int UnitOID { get; set; }
        public string EntityName { get; set; } = string.Empty;
        public string UnitName { get; set; } = string.Empty;

        public string IssueDateString { get; set; } = string.Empty;
        public string NoticeDealineDate { get; set; } = string.Empty;

        public string AuthorizedSignatoryName { get; set; } = string.Empty;
        public string StatutoryAuthorityName { get; set; } = string.Empty;
       

        public string TxtSearch { get; set; } = string.Empty;
        public int NoticeLogOID { get; set; }


        public string SubCategory { get; set; } = string.Empty;
        public string CategoryTypeName { get; set; } = string.Empty;
        public string ClassificationType { get; set; } = string.Empty;

        public DateTime DateofFilingApplication { get; set; }

        public string NameofBankOfficer { get; set; } = string.Empty;
        public string IsReductionOfReservePrice { get; set; } = string.Empty;
        public string RevisedReservePrice { get; set; } = string.Empty;

        public DateTime DateofReduction { get; set; }

        public string IsStaffAccountability { get; set; } = string.Empty;
        public string StaffAccountabilityDetails { get; set; } = string.Empty;

       // public string ClassificationType { get; set; } = string.Empty;

        public int OriginalNoticeId { get; set; }
        public string OriginalNoticeNo { get; set; } = string.Empty;

        public int ConfidentialityType { get; set; }

        public string DocCategory { get; set; } = string.Empty;

        public int StateOID { get; set; }
        public int DistrictOID { get; set; }

        public string StateName { get; set; } = string.Empty;
        public string DistrictName { get; set; } = string.Empty;

        public string ChequeNo { get; set; } = string.Empty;
        public DateTime ChequeDate { get; set; }
        public decimal ChequeAmount { get; set; }

        public string Endrosment { get; set; } = string.Empty;
        public string Division { get; set; } = string.Empty;

        public DateTime BankersAdviceDate { get; set; }

        public int MISMasterOID { get; set; }

        public string Status { get; set; } = string.Empty;
        public string NoticeType { get; set; } = string.Empty;

        public int ModelOID { get; set; }
        public int DealerNameOID { get; set; }

        public string VIN { get; set; } = string.Empty;
        public string EngineNo { get; set; } = string.Empty;
        public string Channel { get; set; } = string.Empty;
        public string SubBroker { get; set; } = string.Empty;
        public string PolicyNumber { get; set; } = string.Empty;
        public string CRU { get; set; } = string.Empty;
        public string MultipleDetails { get; set; } = string.Empty;
        public string DepartmentClaim { get; set; } = string.Empty;

        public string Model { get; set; } = string.Empty;
        public string DealerName { get; set; } = string.Empty;
        public string TypeofReliefSought { get; set; } = string.Empty;











        // Optional fields
        public int TotalRecords { get; set; }    // Used in pagination with CTE
    }
}