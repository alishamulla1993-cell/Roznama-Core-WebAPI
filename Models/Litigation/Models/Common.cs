namespace Roznama.Models.Litigation.Models
{
    public class StateDto
    {
        public int STATE_OID { get; set; }
        public string? STATE_NAME { get; set; }
    }
    public class SubjectMatterDto
    {
        public int SubjectMatterOID { get; set; }
        public string? SubjectMatterName { get; set; }
    }
    public class AddSubjectMatterRequest
    {
        public string? SubjectMatterName { get; set; }
    }
    public class DuplicateCaseCheckRequest
    {
        public int LitigationOID { get; set; }
        public string? CaseNumber { get; set; }
        public int CourtOID { get; set; }
        public int CaseTypeOID { get; set; }
    }
    public class DuplicateCaseCheckResponse
    {
        public bool IsDuplicate { get; set; }
    }
    public class AddStageRequest
    {
        public string? StageName { get; set; }
    }
    public class DiscoverySelectionRequest
    {
        public int LitigationOID { get; set; }

        public int CourtTypeOID { get; set; }
        public string? CourtName { get; set; }

        public int StateOID { get; set; }
        public string? StateName { get; set; }

        public int DistrictOID { get; set; }
        public string? DistrictName { get; set; }

        public string? CaseNumber { get; set; }
        public string? CaseYear { get; set; }

        public string? TypeOfCourtValue { get; set; }

        public string? BenchValue { get; set; }
        public string? BenchName { get; set; }

        public int CaseTypeOID { get; set; }
        public string? CaseTypeName { get; set; }

        public int CourtComplexOID { get; set; }
        public string? CourtComplexName { get; set; }

        public int HighCourtOIDValue { get; set; }
        public string? HighCourtName { get; set; }

        public int TribunalCourtOIDValue { get; set; }
        public string? TribunalCourtName { get; set; }

        public int ConsumerCourtOIDValue { get; set; }
        public string? ConsumerCourtName { get; set; }

        public string? InsertUpdateFlag { get; set; } // Insert / Update
    }
    public class DiscoverySelectionResponse
    {
        public int CaseWiseOID { get; set; }
        public bool Success { get; set; }
    }
    public class DeleteCompanyPartiesRequest
    {
        public int LitigationOID { get; set; }
    }
    public class ResponseDto
    {
        public bool Success { get; set; }
        public int RowsAffected { get; set; }
    }
    public class UpdateClientContactRequest
    {
        public int PartyMasterOID { get; set; }
        public int LitigationOID { get; set; }
    }
    public class InsertLitigationOrgResponse
    {
        public int LitigationOID { get; set; }
        public string? LitigationID { get; set; }
    }
    public class InsertLitigationOrgRequest
    {
        public int ClassificationOID { get; set; }
        public int CategoryOID { get; set; }
        public int UnitOID { get; set; }
        public int AuthorityOID { get; set; }
        public int CreatedBy { get; set; }

        public string? CompanyType { get; set; }
        public string? CounterType { get; set; }
        public string? AuthorityNominee { get; set; }
        public string? POA { get; set; }
        public string? DirectorInvolved { get; set; }
        public string? POABRLOA { get; set; }
        public string? ByagainstStatutoryauthority { get; set; }
        public string? CircleZoneRegion { get; set; }
        public string? ConfidentialityType { get; set; }

        public string? ContractNo { get; set; }
        public string? CustomerID { get; set; }
        public int SubUnitOID { get; set; }

        public string? IsStaffOrExStaffInvolved { get; set; }
        public string? StaffOrExStaffDetails { get; set; }

        public string? IsWilfulDefaulter { get; set; }
        public string? WilfulDefaulterDetails { get; set; }
        public string? IsFraud { get; set; }
        public string? FraudDetails { get; set; }

        public string? IsStaffAccountability { get; set; }
        public string?   StaffAccountabilityDetails { get; set; }
        public string? ValuerForFraud { get; set; }
        public string? AdvocateForFraud { get; set; }
        public int ApprovedValuerOID { get; set; }

        public string? IsCustomerInvolved { get; set; }
        public string? ATMRelated { get; set; }

        public string? Channel { get; set; }
        public string? SubBroker { get; set; }
        public string? PolicyNumber { get; set; }
        public DateTime? StartDatePolicy { get; set; }
        public DateTime? EndDatePolicy { get; set; }
        public string? DepartmentClaim { get; set; }

        public int RiskOID { get; set; }
        public string? Breifparticulars { get; set; }
        public string? SubjectmatterDescription { get; set; }
        public string? ReliefClaims { get; set; }

        public string? DetailsofDepositsPaid { get; set; }
        public int SubCategory1OID { get; set; }
        public int DealerActingAsOID { get; set; }

        public string? CaseReferenceNumber { get; set; }
    }
    public class UpdateLitigationDetailsRequest
    {
        public int LitigationOID { get; set; }

        public int ClassificationOID { get; set; }
        public int CategoryOID { get; set; }
        public int AuthorityOID { get; set; }
        public int UnitOID { get; set; }

        public string? CompanyType { get; set; }
        public string? CounterType { get; set; }
        public string? CaseNumber { get; set; }

        public int CaseTypeOID { get; set; }
        public int CourtOID { get; set; }
        public string? CourtName { get; set; }

        public string? Breifparticulars { get; set; }
        public string? SubjectmatterDescription { get; set; }
        public string? ReliefClaims { get; set; }

        public int RiskOID { get; set; }
        public string? ConfidentialityType { get; set; }

        public DateTime? DateofFirstHearing { get; set; }

        // 👉 add remaining fields gradually (don’t rush all at once)
    }
    public class LitigationHandledByRequest
    {
        public int LitigationOID { get; set; }
        public List<int>? UserOIDs { get; set; }
    }
    public class DirectorPromoterRequest
    {
        public int LitigationOID { get; set; }
        public bool IsDirectorInvolved { get; set; }

        // Non-ABG
        public string? DirectorPromoterName { get; set; }

        // ABG
        public List<int>? PartyMasterOIDs { get; set; }
    }
    public class LitigationPoaDocumentsRequest
    {
        public int LitigationOID { get; set; }
        public int UserId { get; set; }   // RUSEROID
        public List<PoaDocumentDto>? Documents { get; set; }
    }
    public class PoaDocumentDto
    {
        public byte[]? Filebyte { get; set; }
        public string? FileName { get; set; }
        public long FileSize { get; set; }
        public string? ReferenceOwnerName { get; set; }
    }
    public class LitigationCaseDetailsRequest
    {
        public int LitigationOID { get; set; }
        public LitigationEntity_Roznama? CaseDetails { get; set; }
    }
    public class LitigationEntity_Roznama
    {
        public string? Casenumber { get; set; }
        public int LegalNature { get; set; }
        public int LegalSubNature { get; set; }
        public int CaseTypeOID { get; set; }

        public string? PoliceStation { get; set; }
        public string? FirNo { get; set; }

        public int SubjectmatterOID { get; set; }
        public DateTime? CaseFileDate { get; set; }

        public decimal? EstimatedCost { get; set; }
        public DateTime? HearingDate { get; set; }

        public int CaseStageOID { get; set; }
        public int CaseYear { get; set; }

        // Financials
        public decimal? AmountClaimAmount { get; set; }
        public decimal? AmountInterest { get; set; }
        public decimal? AmountPenalty { get; set; }

        // Dates
        public DateTime? DateOfNotice { get; set; }
        public DateTime? DateofFirstHearing { get; set; }

        // Status
        public string? CaseBackground { get; set; }
        public decimal? BankGuarantee { get; set; }
        public decimal? ContingentLiability { get; set; }
        public decimal? ProvisionMade { get; set; }
        public int Connected_LitigationOID { get; set; }
        public string? RelatedPeriod { get; set; }
        public string?    FileNumber { get; set; }
        public string? NameofJudges { get; set; }
        public int StateOID { get; set; }
        public int DistrictOID { get; set; }
        public DateTime? TargetDisposalDate { get; set; }

        public string? DocumentName { get; set; }
        public byte[]? Filebyte { get; set; }
        public int FileSize { get; set; }

    }
    public class SubCategoryDto
    {
        public string? SN { get; set; }
        public int SubCategoryOID { get; set; }
        public string? SubCategory { get; set; }
    }
    public class GenerateSubCategoryRequest
    {
        public int SubCategoryOID { get; set; }
        public string? SubCategory { get; set; }

        // Existing GridView rows
        public List<SubCategoryDto>? ExistingSubCategories { get; set; }
    }
    public class DeleteSubCategoryRequest
    {
        public int SubCategoryOID { get; set; }
        public string? SubCategory { get; set; }

        // Current Grid rows sent from UI
        public List<SubCategoryDto>? ExistingSubCategories { get; set; }
    }
    public class CheckHearingDateRequest
    {
        public int LitigationOID { get; set; }
        public DateTime NextHearingDate { get; set; }
    }
    public class InsertCaseTypeStageRequest
    {
        public int CaseStageOID { get; set; }
        public int LitigationOID { get; set; }
        public string? StageDescription { get; set; }
        public DateTime? HearingDt { get; set; }

        public DateTime? FirstAlertDt { get; set; }
        public DateTime? SecondAlertDt { get; set; }
        public DateTime? ThirdAlertDt { get; set; }

        public string? AdditionalEmailID { get; set; }
        public bool? NonHearingCases { get; set; }

        public string? ConsumerDemographics { get; set; }
        public string? ControlNumber { get; set; }
        public string? AccountNumber { get; set; }
        public string? IssueDescription { get; set; }
        public string? ClientServiceTeamDecision { get; set; }
        public string? DisputeCategory { get; set; }

        public DateTime? MemberResponseDate { get; set; }
        public string? MemberDecision { get; set; }
        public string? MemberResponse { get; set; }
        public string? TUDFDetails { get; set; }

        public int? MemberOID { get; set; }
        public string? Penalty { get; set; }

        public bool? IsOrderReserved { get; set; }
        public DateTime? DateOfReserved { get; set; }

        public bool? IsOrderPronounced { get; set; }
        public DateTime? DateOfPronounced { get; set; }
    }
    public class LitigationActionItemDto
    {
        public string ActionItem { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public int ResponsiblePersonOID { get; set; }
        public int LitigationOID { get; set; }

        public string ActionItemFor { get; set; } = "Stage";
        public string? AdditionalEmailID { get; set; }

        public DateTime? FirstAlertDt { get; set; }
        public DateTime? SecondAlertDt { get; set; }
        public DateTime? ThirdAlertDt { get; set; }
    }
    public class InsertLitigationActionItemsRequest
    {
        public int LigationHearingStageOID { get; set; }
        public int CreatedByOID { get; set; }

        public List<LitigationActionItemDto> ActionItems { get; set; }
            = new();
    }
    public class LitigationStageDocumentDto
    {
        public byte[]? Filebyte { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public long FileSize { get; set; }

        public string DocType { get; set; } = "LitigationStageHearing";
        public string? ReferenceOwnerName { get; set; }
        public string? DocCategory { get; set; }

        public int? LitigationDraftOID { get; set; }
        public string? S3UniqueDocumentName { get; set; }
    }
    public class InsertLitigationStageDocumentsRequest
    {
        public int LigationStageHearingOID { get; set; }
        public int UserId { get; set; }

        public List<LitigationStageDocumentDto> Documents { get; set; }
            = new();
    }
    public class InsertLibraryDocumentRequest
    {
        public string DocumentTitle { get; set; } = string.Empty;
        public string? Comment { get; set; }
        public string? SubjectMatterDesc { get; set; }

        public int LibraryTypeOID { get; set; }
        public int EntityOID { get; set; }
        public int LitigationOID { get; set; }
        public int UserId { get; set; }

        public IFormFile File { get; set; } = null!;

        // ✅ File details already provided by client
        public byte[] Filebyte { get; set; } = Array.Empty<byte>();
        public long FileSize { get; set; }
        public string FileName { get; set; } = string.Empty;
    }
    public class LitigationCompletionRequest
    {
        public int LitigationOID { get; set; }
        public int ResultOID { get; set; }

        public DateTime DisposedDate { get; set; }
        public string? Comments { get; set; }
        public string? Synopsis { get; set; }

        public DateTime? AppealFilingDt { get; set; }

        public DateTime? FirstAlertDt { get; set; }
        public DateTime? SecondAlertDt { get; set; }
        public DateTime? ThirdAlertDt { get; set; }

        public DateTime? DateofReceiptofOrder { get; set; }
        public string? ComplianceAppeal { get; set; }

        public DateTime? Dateofcomplinace { get; set; }
        public string? ComplianceRingiNo { get; set; }

        public string? MonetaryAward { get; set; }
        public string? TotalInterest { get; set; }
        public string? NonMonetaryAward { get; set; }
        public string? TotalAward { get; set; }

        public DateTime? FinalCloserDate { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public decimal? Interest { get; set; }

        public int UserId { get; set; }
    }
    public class InsertConnectedLitigationRequest
    {
        public int LitigationOID { get; set; }
        public int ConnectedLitigationOID { get; set; }
    }
    public class InsertConnectedArbitrationRequest
    {
        public int LitigationOID { get; set; }
        public int ArbitrationOID { get; set; }
        public int IsConnected { get; set; } // 1 = Yes, 0 = No
    }
    public class InsertMailLogRequest
    {
        public string? ApplicationName { get; set; }
        public string? ToEmailID { get; set; }
        public string? CCEmailID { get; set; }
        public string? BCCemailID { get; set; }
        public string? FromEmailID { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
        public string? ContentType { get; set; } // HTML / TEXT
        public char Status { get; set; }         // 'N', 'S', etc.
    }
    public class InsertConnectedLitigationToTaxRequest
    {
        public int LitigationOID { get; set; }
        public int TaxOID { get; set; }
        public string TaxType { get; set; } = string.Empty;
    }
    public class InsertTransactionLogRequest
    {
        public string LogType { get; set; } = string.Empty;
        public string LogDesc { get; set; } = string.Empty;
        public int UserId { get; set; }
        public int MasterOID { get; set; }
    }
    public class BillingDetailsRequest
    {
        // 🔑 Required ONLY for update
        public int BillingOID { get; set; }

        public int BillingTypeOID { get; set; }
        public int LitigationOID { get; set; }
        public int LitigationStageHearingOID { get; set; }
        public decimal Amount { get; set; }
        public DateTime BillDate { get; set; }
        public string? Comments { get; set; }
        public int UserId { get; set; }
        public int RaisedBy { get; set; }
        public int PartyMasterOID { get; set; }
        public string? BillStatus { get; set; }
        public bool PaymentReceived { get; set; }

        public string? ChequeNo { get; set; }
        public DateTime? ChequeDate { get; set; }
        public string? TransactionID { get; set; }
        public bool TDScertificateattached { get; set; }
        public decimal AmountPaid { get; set; }

        public decimal? StatutoryDepositAmount { get; set; }
        public DateTime? DateofStatutoryDeposit { get; set; }
        public decimal? OtherDepositAmount { get; set; }
        public DateTime? DateofOtherDeposit { get; set; }
        public string? DepositRefundStatus { get; set; }
        public DateTime? RefundDate { get; set; }
        public string? RefundReferenceNo { get; set; }
        public string? BillingDepositRefundStatus { get; set; }
        public string? DetailsofDepositsPaid { get; set; }

        public decimal? RefundAmount { get; set; }
        public string? InstrumentType { get; set; }
        public string? InstrumentNo { get; set; }
        public DateTime? InstrumentDate { get; set; }
        public string? RefundRefNo { get; set; }
    }
    public class LitigationUpdateRequest
    {
        // 🔑 Mandatory
        public int LitigationOID { get; set; }

        // 🔹 Basic classification
        public int? ClassificationOID { get; set; }
        public int? CategoryOID { get; set; }
        public int? AuthorityOID { get; set; }
        public int? UnitOID { get; set; }
        public string? CompanyType { get; set; }
        public string? CounterType { get; set; }

        // 🔹 Case details
        public string? Casenumber { get; set; }
        public int? LegalNature { get; set; }
        public int? LegalSubNature { get; set; }
        public int? CaseTypeOID { get; set; }
        public int? CourtOID { get; set; }
        public string? CourtName { get; set; }
        public string? PoliceStation { get; set; }
        public string? FirNo { get; set; }

        // 🔹 Subject & relief
        public int? SubjectmatterOID { get; set; }
        public string? SubjectmatterDescription { get; set; }
        public string? Breifparticulars { get; set; }
        public string? ReliefClaims { get; set; }

        // 🔹 Dates & filing
        public DateTime? CaseFileDate { get; set; }
        public DateTime? DateOfNotice { get; set; }
        public DateTime? DateofFirstHearing { get; set; }

        // 🔹 Financial exposure
        public decimal? EstimatedCost { get; set; }
        public decimal? BankGuarantee { get; set; }
        public decimal? ContingentLiability { get; set; }
        public decimal? ProvisionMade { get; set; }

        // 🔹 Amount involved
        public decimal? AmountClaimAmount { get; set; }
        public decimal? AmountInterest { get; set; }
        public decimal? AmountPenalty { get; set; }
        public decimal? ContingentClaimAmount { get; set; }
        public decimal? ContingentInterest { get; set; }
        public decimal? ContingentPenalty { get; set; }
        public decimal? ProvisionClaimAmount { get; set; }
        public decimal? ProvisionInterest { get; set; }
        public decimal? ProvisionPenalty { get; set; }

        // 🔹 Risk & file
        public int? RiskOID { get; set; }
        public string? FileNumber { get; set; }
        public string? FileNo { get; set; }

        // 🔹 Linked & confidentiality
        public int? Connected_LitigationOID { get; set; }
        public string? ConfidentialityType { get; set; }

        // 🔹 Judges & background
        public string? NameofJudges { get; set; }
        public string? CaseBackground { get; set; }

        // 🔹 Interest calculations
        public decimal? AmountInterestRate { get; set; }
        public DateTime? AmountFromDate { get; set; }
        public DateTime? AmountToDate { get; set; }

        public decimal? AmountInvolvedByCompanyInterestRate { get; set; }
        public DateTime? AmountInvolvedByCompanyDateofInterest { get; set; }

        public decimal? AmountInvolvedAgainstCompanyClaim { get; set; }
        public decimal? AmountInvolvedAgainstCompanyInterest { get; set; }
        public decimal? AmountInvolvedAgainstCompanyPenalty { get; set; }
        public decimal? AmountInvolvedAgainstCompanyTotal { get; set; }
        public decimal? AmountInvolvedAgainstCompanyInterestRate { get; set; }
        public DateTime? AmountInvolvedAgainstCompanyDateofInterest { get; set; }

        // 🔹 Contingent & provision dates
        public decimal? ContingentLiabilityInterestRate { get; set; }
        public DateTime? ContingentFromDate { get; set; }
        public DateTime? ContingentToDate { get; set; }

        public decimal? ProvisioninthebooksofCompanyInterestRate { get; set; }
        public DateTime? ProvisionFromDate { get; set; }
        public DateTime? ProvisionToDate { get; set; }

        // 🔹 Contract & recovery
        public string? ContractNo { get; set; }
        public decimal? AmountRecovered { get; set; }
        public string? CustomerID { get; set; }
        public bool? InternalCustomer { get; set; }

        // 🔹 Operational dates
        public DateTime? DateOfReference { get; set; }
        public DateTime? DateOfRecovery { get; set; }
        public string? ActionPlan { get; set; }
        public decimal? AmountofDeposit { get; set; }

        // 🔹 Organization
        public int? SubUnitOID { get; set; }
        public int? StateLitigationOID { get; set; }
        public int? DistrictLitigationOID { get; set; }

        // 🔹 Flags
        public bool? IsCustomerInvolved { get; set; }
        public bool? ATMRelated { get; set; }
        public bool? IsStaffOrExStaffInvolved { get; set; }
        public string? StaffOrExStaffDetails { get; set; }

        public bool? IsWilfulDefaulter { get; set; }
        public string? WilfulDefaulterDetails { get; set; }
        public bool? IsFraud { get; set; }
        public string? FraudDetails { get; set; }

        public bool? IsStaffAccountability { get; set; }
        public string? StaffAccountabilityDetails { get; set; }

        // 🔹 Fraud & professionals
        public string? ValuerForFraud { get; set; }
        public string? AdvocateForFraud { get; set; }

        // 🔹 Stay & liquidators
        public bool? Stay { get; set; }
        public DateTime? StayDate { get; set; }
        public string? StayDescription { get; set; }
        public string? OfficialLiquidators { get; set; }
        public int? ApprovedValuerOID { get; set; }

        // 🔹 Insolvency
        public DateTime? DateofAdmission { get; set; }
        public string? NameofInterimResolutionProfessional { get; set; }
        public string? NameofResolutionProfessional { get; set; }
        public bool? OBCClaimFiled { get; set; }
        public DateTime? ClaimFilingDate { get; set; }
        public decimal? AmountofClaim { get; set; }
        public DateTime? CIRPExpiringDate { get; set; }
        public bool? ExtensionofCIRPifAny { get; set; }
        public DateTime? CIRPExtensionDate { get; set; }

        // 🔹 Reporting
        public string? Outlook { get; set; }
        public string? ReserveRecorder { get; set; }
        public string? Duty { get; set; }
        public string? Penalty { get; set; }
        public decimal? AmountPaidReport { get; set; }
        public string? AnticipatedResolution { get; set; }
        public string? FutureAction { get; set; }

        // 🔹 Vehicle / policy
        public int? ModelOID { get; set; }
        public int? DealerNameOID { get; set; }
        public string? VIN { get; set; }
        public string? EngineNo { get; set; }
        public string? PolicyNumber { get; set; }
        public DateTime? dtStartDatePolicy { get; set; }
        public DateTime? dtEndDatePolicy { get; set; }

        // 🔹 Misc
        public string? Channel { get; set; }
        public string? SubBroker { get; set; }
        public string? TypeofTax { get; set; }
        public string? RevisedCaseNo { get; set; }
        public string? CollectionofMoney { get; set; }

        public string? CNRNumber { get; set; }
        public string? NatureofDisposal { get; set; }
        public string? RegistrationNumber { get; set; }
        public string? FilingNumber { get; set; }
        public DateTime? DecisionDate { get; set; }
        public DateTime? RegistrationDate { get; set; }

        public string? Nameofaccused { get; set; }
        public DateTime? Dateofcomplinace { get; set; }
        public string? MSILFileNo { get; set; }
        public string? DetailsofDepositsPaid { get; set; }
        public string? UnderSection { get; set; }
        public string? AmountInvolvedType { get; set; }
        public int? MSILCaseTypeOID { get; set; }
        public bool? NonMonetary { get; set; }

        public int? SubCategory1OID { get; set; }
        public int? DealerActingAsOID { get; set; }
        public string? CaseReferenceNumber { get; set; }
        public string? AmountType { get; set; }
        public DateTime? TargetDisposalDate { get; set; }
        // 🔹 Exposure & risk
        public decimal? MaximumExposure { get; set; }
        public decimal? Interest { get; set; }
        public string? PeriodInvolved { get; set; }

        // 🔹 Bank & guarantees
        public decimal? BankGuaranteeABG { get; set; }

        // 🔹 Ownership & responsibility
        public string? ProcessOwner { get; set; }
        public string? SupportPerson { get; set; }

        // 🔹 Vertical & accounting
        public int? VerticalOID { get; set; }
        public string? AmountInvolvedComments { get; set; }
        public string? GLAccountDetails { get; set; }
        public string? DepartmentClaim { get; set; }

        // 🔹 Authority & legal flags
        public string? AuthorityNominee { get; set; }
        public bool? POA { get; set; }
        public bool? DirectorInvolved { get; set; }
        public bool? POABRLOA { get; set; }

        // 🔹 Statutory / period details
        public bool? ByagainstStatutoryauthority { get; set; }
        public string? RelatedPeriod { get; set; }
        public string? CircleZoneRegion { get; set; }

        // 🔹 Interest date tracking
        public DateTime? ContingentLiabilityDateofInterest { get; set; }
        public DateTime? ProvisioninthebooksofCompanyDateofInterest { get; set; }

    }

    public class WitnessDto
    {
        public int LitigationOID { get; set; }
        public string? WitnessName { get; set; }
        public string?  WitnessEmailID { get; set; }
        public string? WitnessPhone { get; set; }
        public string? WitnessAddress { get; set; }
    }
    public class CompletionDetailsDto
    {
        public int LitigationOID { get; set; }
        public int? ResultOID { get; set; }
        public DateTime? DisposedDate { get; set; }
        public string? Comment { get; set; }
        public string? Synopsis { get; set; }
        public bool? AppealFlag { get; set; }
        public bool? AppealFiled { get; set; }
        public DateTime? AppealFilingDt { get; set; }
        public DateTime? FirstAlertDate { get; set; }
        public DateTime? SecondAlertDate { get; set; }
        public DateTime? ThirdAlertDate { get; set; }
        public DateTime? DateofReceiptofOrder { get; set; }
        public string? ComplianceAppeal { get; set; }
        public DateTime? Dateofcomplinace { get; set; }
        public string? ComplianceRingiNo { get; set; }
        public decimal? MonetaryAward { get; set; }
        public decimal? TotalInterest { get; set; }
        public decimal? NonMonetaryAward { get; set; }
        public decimal? TotalAward { get; set; }
        public DateTime? FinalCloserDate { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public decimal? Interest { get; set; }
    }
    public class LitigationAlertDto
    {
        public string? LitigationID { get; set; }
        public string? EntityName { get; set; }
        public string? ToEmailID { get; set; }
        public string? CaseTitle { get; set; }
        public string? CaseNumber { get; set; }
        public string? Breifparticulars { get; set; }
        public DateTime? HearingDt { get; set; }
        public int RiskOID { get; set; }
        public string? NameofJudges { get; set; }
        public string? CourtName { get; set; }
        public string? CompanyType { get; set; }
    }
    public class BillingDetailsDto
    {
        // 🔹 Basic Billing Info
        public int BillingTypeOID { get; set; }
        public int LitigationStageHearingOID { get; set; }
        public decimal Amount { get; set; }
        public string? RaisedBy { get; set; }

        // 🔹 Bill Details
        public DateTime? BillDate { get; set; }
        public string? Comments { get; set; }
        public int PartyMasterOID { get; set; }
        public int BillStatus { get; set; }
        public string? PaymentReceived { get; set; }
        public string? ChequeNo { get; set; }
        public DateTime? ChequeDate { get; set; }

        // 🔹 Transaction Info
        public string? TransactionID { get; set; }
        public string? TDScertificateattached { get; set; }

        // 🔹 Payment Info
        public decimal AmountPaid { get; set; }
        public decimal AmountBalance { get; set; }

        // 🔹 Deposit Info
        public decimal StatutoryDepositAmount { get; set; }
        public DateTime? DateofStatutoryDeposit { get; set; }

        public decimal OtherDepositAmount { get; set; }
        public DateTime? DateofOtherDeposit { get; set; }

        // 🔹 Refund Info
        public string? DepositRefundStatus { get; set; }
        public DateTime? RefundDate { get; set; }
        public string? RefundReferenceNo { get; set; }
        public string? BillingDepositRefundStatus { get; set; }
        public string? DetailsofDepositsPaid { get; set; }
        public decimal RefundAmount { get; set; }

        // 🔹 Instrument Info
        public string? InstrumentType { get; set; }
        public string? InstrumentNo { get; set; }
        public DateTime? InstrumentDate { get; set; }

        // 🔹 Additional
        public string? RefundRefNo { get; set; }
    }
    public class ActionItemUpdateDto
    {
        public int ActionItemOID { get; set; }
        public int StatusOID { get; set; }
        public string? Comments { get; set; }
    }
    public class LitigationAlertEmailDto
    {
        // 🔹 Basic Info
        public string? LitigationID { get; set; }
        public string? UnitName { get; set; }
        public string? EntityName { get; set; }
        public string? DeptName { get; set; }
        public string? ClasificationTypeName { get; set; }
        public string? CaseTypeName { get; set; }
        public string? CourtTypeName { get; set; }
        public string? CourtName { get; set; }

        // 🔹 Police / Authority
        public string? PoliceStation { get; set; }
        public string? FirNo { get; set; }
        public string? AuthorityName { get; set; }

        // 🔹 Legal Details
        public string? LegalNatureName { get; set; }
        public string?  LegalSubNatureName { get; set; }
        public string?  CaseNumber { get; set; }
        public string? Breifparticulars { get; set; }
        public string? SubjectMatter { get; set; }
        public string? SubjectMatterDescription { get; set; }
        public string? ReliefClaims { get; set; }

        // 🔹 Financial Overview
        public string? BankGuarantee { get; set; }
        public string? ContingentLiability { get; set; }
        public string? ProvisionMade { get; set; }

        public decimal? EstimatedCost { get; set; }

        // 🔹 Created Info
        public string? CreatedByName { get; set; }

        // 🔹 Dates
        public DateTime? HearingDate { get; set; }
        public DateTime? CaseFileDate { get; set; }
        public DateTime? FirstHearingDate { get; set; }
        public DateTime? DateOfNotice { get; set; }
        public DateTime? AppealFilingDt { get; set; }
        public DateTime? Disposeddt { get; set; }

        // 🔹 Party Info
        public string? CompanyType { get; set; }
        public string? CounterType { get; set; }
        public string? CoParties { get; set; }
        public string? CounterParties { get; set; }

        public string? CompanyAdvocate { get; set; }
        public string? CounterAdvocate { get; set; }

        public string? UnderActsName { get; set; }

        // 🔹 Status
        public string? CompleteStatus { get; set; }
        public string? CompletionComment { get; set; }
        public string? Result { get; set; }
        public string? CategoryName { get; set; }

        // 🔹 IDs
        public string? CaseTypeOID { get; set; }
        public string? UnderactOID { get; set; }

        // 🔹 Authority / Director
        public string? AuthorityNominee { get; set; }
        public string? POA { get; set; }
        public string? DirectorInvolved { get; set; }
        public string? DirectorName { get; set; }

        // 🔹 Additional Info
        public string? ByagainstStatutoryauthority { get; set; }
        public string? RelatedPeriod { get; set; }
        public string? CircleZoneRegion { get; set; }

        // 🔹 Amount Details
        public decimal? AmountClaimAmount { get; set; }
        public decimal? AmountInterest { get; set; }
        public decimal? AmountPenalty { get; set; }

        public decimal? ContingentClaimAmount { get; set; }
        public decimal? ContingentInterest { get; set; }
        public decimal? ContingentPenalty { get; set; }

        public decimal? ProvisionClaimAmount { get; set; }
        public decimal? ProvisionInterest { get; set; }
        public decimal? ProvisionPenalty { get; set; }

        public string? POABRLOA { get; set; }

        // 🔹 Handling Info
        public string? MatterHandledByOID { get; set; }
        public string? MatterHandledbyName { get; set; }

        public string? UnitMemberOID { get; set; }
        public string? UnitMemberName { get; set; }

        public string? MatterHandledByEmailID { get; set; }
        public string? ManagerEmailID { get; set; }

        // 🔹 Case Info
        public string? EntityUnitName { get; set; }
        public string? CaseTitle { get; set; }
        public string? StageName { get; set; }
        public string? StageDescription { get; set; }

        // 🔹 Extra
        public string? Synopsis { get; set; }
    }
    public class DraftStatusUpdateDto
    {
        public int NoticeDraftOID { get; set; }
        public int DraftStatusOID { get; set; }
        public string? PreparatoryComment { get; set; }
        public string? ReviewerComment { get; set; }
    }
    public class LitigationDraftingDto
    {
        public int LitigationOID { get; set; }
        public int PreferenceID { get; set; }
        public int PreparatoryOID { get; set; }
        public DateTime? PreparatoryDate { get; set; }
        public int DraftStatusOID { get; set; }
        public string? PreparatoryInstruction { get; set; }
        public string? PreparatoryEmailID { get; set; }
        public int ManagerOID { get; set; }
    }
    public class LitigationMetricsFilterDto
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public int UserOID { get; set; }

        public int? Entity { get; set; }
        public int? Unit { get; set; }
        public int? CaseType { get; set; }
        public int? ClasificationType { get; set; }
        public int? CourtTypeOID { get; set; }
        public string? CourtName { get; set; }
        public int? CategoryType { get; set; }
        public int? StatusOID { get; set; }
        public int? PartyMasterOID { get; set; }

        public int? LegalNature { get; set; }
        public int? LegalSubNature { get; set; }
        public int? SubjectmatterOID { get; set; }
        public int? UnderActs { get; set; }

        public decimal? MinAmount { get; set; }
        public decimal? MaxAmount { get; set; }

        public string? DirectorInvolved { get; set; }
        public string? ByagainstStatutoryauthority { get; set; }
        public string? ContractNo { get; set; }

        public int? RiskOID { get; set; }
        public string? CustomerID { get; set; }
        public string? Region { get; set; }

        public string? DateCriteria { get; set; }
        public string? LawFirmClient { get; set; }

        public bool? IsStaffOrExStaffInvolved { get; set; }
        public bool? IsCustomerInvolved { get; set; }
        public string? LitigationStatus { get; set; }

        public int? StateOID { get; set; }
        public int? DistrictOID { get; set; }

        public string? CaseNumber { get; set; }
        public string? CaseYear { get; set; }

        public string? TypeOfCourtValue { get; set; }
        public string? BenchValue { get; set; }

        public int? CaseTypeOID { get; set; }
        public int? CourtComplexOID { get; set; }

        public string? StampValue { get; set; }
        public string? SideValue { get; set; }

        public string? TextSearch { get; set; }

        public int? MatterHandledByOID { get; set; }
    }
    public class MISReportFilterDto
    {
        public DateTime MonthFirstDate { get; set; }
        public DateTime MonthLastDate { get; set; }
        public DateTime LastMonthLastDate { get; set; }

        public int UserOID { get; set; }
        public int Entity { get; set; }
    }
    public class MISReportUnitWiseFilterDto
    {
        public DateTime MonthFirstDate { get; set; }
        public DateTime MonthLastDate { get; set; }
        public DateTime LastMonthLastDate { get; set; }

        public int UserOID { get; set; }
        public int Entity { get; set; }
    }
    public class MISReportUnitWiseDto
    {
        public string? UnitName { get; set; }
        public int OpeningBalance { get; set; }
        public int Additions { get; set; }
        public int Disposals { get; set; }
        public int ClosingBalance { get; set; }
    }
    public class MISReportDto
    {
        public string? EntityName { get; set; }
        public int OpeningBalance { get; set; }
        public int Additions { get; set; }
        public int Disposals { get; set; }
        public int ClosingBalance { get; set; }
    }
    public class BillTypeDto
    {
        public int BillTypeOID { get; set; }
        public string? BillTypeName { get; set; }
    }
    public class LitigationBillingReportFilterDto
    {
        public int UserOID { get; set; }

        public int? BillingTypeOID { get; set; }
        public int? LitigationOID { get; set; }
        public int? Entity { get; set; }
        public int? Unit { get; set; }
        public int? PartyMasterOID { get; set; }

        public string? BillStatus { get; set; }

        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public string? TextSearch { get; set; }
    }
    public class LitigationBillingReportDto
    {
        public int BillingOID { get; set; }
        public string? CaseNumber { get; set; }
        public string? PartyName { get; set; }
        public decimal Amount { get; set; }
        public string? BillStatus { get; set; }
        public DateTime? BillDate { get; set; }
    }
    public class CauseListFilterDto
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public int UserOID { get; set; }

        public int? Entity { get; set; }
        public int? Unit { get; set; }
        public int? CaseType { get; set; }
        public int? ClasificationType { get; set; }
        public int? CourtType { get; set; }

        public int? CategoryType { get; set; }
        public int? StatusOID { get; set; }
        public int? PartyMasterOID { get; set; }

        public int? SubjectMatterOID { get; set; }
        public int? UnderActOID { get; set; }

        public decimal? MinAmount { get; set; }
        public decimal? MaxAmount { get; set; }

        public string? DirectorInvolved { get; set; }
        public string? ByagainstStatutoryauthority { get; set; }
        public string? Region { get; set; }

        public string? TextSearch { get; set; }
    }
    public class CauseListDto
    {
        public string? LitigationID { get; set; }
        public string? CaseNumber { get; set; }
        public string? CourtName { get; set; }
        public string? CaseType { get; set; }
        public DateTime? HearingDate { get; set; }
        public string? PartyName { get; set; }
        public decimal? Amount { get; set; }
    }
    public class SupremeCourtImportDto
    {
        public string? CourtName { get; set; }
        public int? CourtTypeOID { get; set; }
        public string? BenchName { get; set; }

        public string? CaseNumber { get; set; }
        public string? CaseTypeName { get; set; }
        public string? CaseYear { get; set; }

        public string? StageName { get; set; }
        public string? UnderActsName { get; set; }
        public string? SubjectMatter { get; set; }

        public DateTime? CaseFileDate { get; set; }
        public DateTime? NextHearingDate { get; set; }

        public string? BankGuarantee { get; set; }
        public string? CategoryName { get; set; }
        public string? SubCategory { get; set; }

        public string? AuthorityNominee { get; set; }
        public string? POABRLOA { get; set; }
        public string? RiskName { get; set; }

        public string? Breifparticulars { get; set; }
        public string? SubjectmatterDescription { get; set; }
        public string? ReliefClaims { get; set; }

        public string? CaseReferenceNumber { get; set; }

        public decimal? AmountClaimAmount { get; set; }
        public decimal? AmountInterest { get; set; }
        public decimal? AmountPenalty { get; set; }

        public decimal? ContingentClaimAmount { get; set; }
        public decimal? ContingentInterest { get; set; }
        public decimal? ContingentPenalty { get; set; }

        public decimal? ProvisionClaimAmount { get; set; }
        public decimal? ProvisionInterest { get; set; }
        public decimal? ProvisionPenalty { get; set; }

        public string? MatterHandledbyName { get; set; }
        public string? UnitMemberName { get; set; }

        public string? ClasificationTypeName { get; set; }
        public string? EntityName { get; set; }
        public string? UnitName { get; set; }

        public string? CoParties { get; set; }
        public string? DirectorInvolved { get; set; }

        public string? CounterParties { get; set; }
        public string? CompanyAdvocate { get; set; }
        public string? CounterAdvocate { get; set; }
        
        public string? CNRNumber { get; set; }
        public string? FilingNumber { get; set; }
        public string? RegistrationNumber { get; set; }

        public DateTime? DecisionDate { get; set; }
        public DateTime? RegistrationDate { get; set; }

        public string? StateName { get; set; }
        public string? DistrictName { get; set; }

        public string? HighCourtName { get; set; }
        public string? TribunalCourtName { get; set; }
        public string? ConsumerCourtName { get; set; }
        public string? CourtComplexName { get; set; }

        public string? CompanyType { get; set; }

        public decimal? EstimatedCost { get; set; }
        public DateTime? HearingDate { get; set; }

        public string? ByagainstStatutoryauthority { get; set; }

        public string? DirectorName { get; set; }
        public string? POA { get; set; }

        public string? CaseBackground { get; set; }
        public string? PoliceStation { get; set; }
        public string? FirNo { get; set; }

        public string? ContingentLiability { get; set; }
        public DateTime? DateofNoticeSummons { get; set; }

        public string? DetailsofDepositsPaid { get; set; }

        public string? RelatedPeriod { get; set; }

        public string? NameofCourtType { get; set; }
    }
}
