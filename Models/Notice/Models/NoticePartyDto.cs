namespace Roznama.Models.Notice.Models
{
    public class NoticePartyDto
    {
        public string? SN { get; set; }          // "Party 1", "Party 2"
        public int? PartyMasterOID { get; set; }
        public string? CompanyName { get; set; }
        public string? Address { get; set; }
    }

    public class NoticeGeneratePartyRequest
    {
        public int PartyMasterOID { get; set; }
        public string? CompanyName { get; set; }
        public string? Address { get; set; }
        public List<NoticePartyDto>? ExistingParties { get; set; }
    }
    public class NoticeOppositePartyDto
    {
        public string? SN { get; set; }                 // "Party 1"
        public int? PartyMasterOID { get; set; }
        public string? CompanyName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? ContactPerson { get; set; }
        public string? PanCard { get; set; }
        public string? AadhaarNo { get; set; }
    }

    public class NoticeGenerateOppositePartyRequest
    {
        public int PartyMasterOID { get; set; }
        public string? PartyMaster { get; set; }
        public string? OtherPartiesEmail { get; set; }
        public string? OtherPartiesPhone { get; set; }
        public string? OtherPartiesAddress { get; set; }
        public string? OtherPartiesContactPerson { get; set; }
        public string? OtherPartiesPanCard { get; set; }
        public string? OtherPartiesAadhaarNo { get; set; }

        public List<NoticeOppositePartyDto>? ExistingOppositeParties { get; set; }
    }
    public class NoticeLawFirmAdvocateDto
    {
        public string? SN { get; set; }
        public int? CompanyLawFirmOID { get; set; }
        public string? CompanyLawFirm { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? ContactPerson { get; set; }
        public string? BarCouncilNo { get; set; }
        public string? RingiNo { get; set; }
    }
    public class NoticeGenerateLawFirmAdvocateRequest
    {
        public int CompanyLawFirmOID { get; set; }
        public string? CompanyLawFirm { get; set; }
        public string? CompanyLawFirmEmailID { get; set; }
        public string? CompanyLawFirmPhoneNo { get; set; }
        public string? CompanyLawFirmAddress { get; set; }
        public string? ContactPerson { get; set; }
        public string? BarCouncilNo { get; set; }
        public string? RingiNo { get; set; }

        public List<NoticeLawFirmAdvocateDto>? ExistingLawFirmAdvocates { get; set; }
    }
    public class NoticeLawFirmAdvocateCommonDto
    {
        public string? SN { get; set; }
        public int? LawFirmOID { get; set; }
        public string? LawFirmName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? ContactPerson { get; set; }
    }
    public class NoticeGenerateCounterLawFirmAdvocateRequest
    {
        public int CounterLawFirmOID { get; set; }
        public string? CounterLawFirm { get; set; }
        public string? CounterLawFirmEmailID { get; set; }
        public string? CounterLawFirmPhoneNo { get; set; }
        public string? CounterLawFirmAddress { get; set; }
        public string? CounterLawFirmContactPerson { get; set; }

        public List<NoticeLawFirmAdvocateCommonDto>? ExistingCounterLawFirms { get; set; }
    }
}
