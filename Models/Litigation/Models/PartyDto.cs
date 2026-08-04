namespace Roznama.Models.Litigation.Models
{
    public class PartyDto
    {
        public string? SN { get; set; }          // "Party 1", "Party 2"
        public int? PartyMasterOID { get; set; }
        public string? CompanyName { get; set; }
        public string? Address { get; set; }
    }

    public class GeneratePartyRequest
    {
        public int PartyMasterOID { get; set; }
        public string? CompanyName { get; set; }
        public string? Address { get; set; }
        public List<PartyDto>? ExistingParties { get; set; }
    }
    public class OppositePartyDto
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

    public class GenerateOppositePartyRequest
    {
        public int PartyMasterOID { get; set; }
        public string? PartyMaster { get; set; }
        public string? OtherPartiesEmail { get; set; }
        public string? OtherPartiesPhone { get; set; }
        public string? OtherPartiesAddress { get; set; }
        public string? OtherPartiesContactPerson { get; set; }
        public string? OtherPartiesPanCard { get; set; }
        public string? OtherPartiesAadhaarNo { get; set; }

        public List<OppositePartyDto>? ExistingOppositeParties { get; set; }
    }
    public class LawFirmAdvocateDto
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
    public class GenerateLawFirmAdvocateRequest
    {
        public int CompanyLawFirmOID { get; set; }
        public string? CompanyLawFirm { get; set; }
        public string? CompanyLawFirmEmailID { get; set; }
        public string? CompanyLawFirmPhoneNo { get; set; }
        public string? CompanyLawFirmAddress { get; set; }
        public string? ContactPerson { get; set; }
        public string? BarCouncilNo { get; set; }
        public string? RingiNo { get; set; }

        public List<LawFirmAdvocateDto>? ExistingLawFirmAdvocates { get; set; }
    }
    public class LawFirmAdvocateCommonDto
    {
        public string? SN { get; set; }
        public int? LawFirmOID { get; set; }
        public string? LawFirmName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? ContactPerson { get; set; }
    }
    public class GenerateCounterLawFirmAdvocateRequest
    {
        public int CounterLawFirmOID { get; set; }
        public string? CounterLawFirm { get; set; }
        public string? CounterLawFirmEmailID { get; set; }
        public string? CounterLawFirmPhoneNo { get; set; }
        public string? CounterLawFirmAddress { get; set; }
        public string? CounterLawFirmContactPerson { get; set; }

        public List<LawFirmAdvocateCommonDto>? ExistingCounterLawFirms { get; set; }
    }
    public class PartyContactDto
    {
        public string? ContactName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
    }
    public class PartyDetailsDto
    {
        public int PartyMasterOID { get; set; }
        public string? PartyName { get; set; }
        public string? ClientCode { get; set; }
        public string? Address { get; set; }
        public List<PartyContactDto>? Contacts { get; set; }
    }
    public class PartyOtherDetailsDto
    {
        public int PartyTypeOID { get; set; }
        public string? PartyName { get; set; }

        public string? ContactName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }

        // Only for Company Law Firm Advocate (partyTypeOID = 3)
        public string? BarCouncilNo { get; set; }
    }
    public class CompanyLawFirmAdvocateRequest
    {
        public int LitigationOID { get; set; }
        public List<CompanyLawFirmAdvocateDto>? Advocates { get; set; }
    }

    public class CompanyLawFirmAdvocateDto
    {
        public int PartyMasterOID { get; set; }
        public string?  ContactPerson { get; set; }
        public string? CompanyAdvocatePhone { get; set; }
        public string? CompanyAdvocateEmail { get; set; }
        public string? CompanyAdvocateAddress { get; set; }
        public int? CompanyLawFirmStateOID { get; set; }
        public int? CompanyLawFirmCityOID { get; set; }
        public string? BarCouncilNo { get; set; }
        public string? RingiNo { get; set; }
    }
    public class OppositePartiesRequest
    {
        public int LitigationOID { get; set; }
        public List<GenerateOppositePartyRequest>? Parties { get; set; }
    }
    public class CounterLawFirmRequest
    {
        public int LitigationOID { get; set; }
        public List<CounterLawFirmDto>? CounterLawFirms { get; set; }
    }

    public class CounterLawFirmDto
    {
        public int PartyMasterOID { get; set; }
        public string? ContactPerson { get; set; }
        public string? CounterAdvocatePhone { get; set; }
        public string? CounterAdvocateEmail { get; set; }
        public string? CounterAdvocateAddress { get; set; }
    }
    public class DeleteLawFirmAdvocateRequest
    {
        public int CompanyLawFirmOID { get; set; }
        public string? CompanyLawFirm { get; set; }

        // Current grid data sent from UI
        public List<LawFirmAdvocateDto> ExistingLawFirmAdvocates { get; set; }
            = new();
    }
    public class DeleteCounterLawFirmRequest
    {
        public int CounterLawFirmOID { get; set; }
        public string? CounterLawFirm { get; set; }

        public List<LawFirmAdvocateDto>? ExistingCounterLawFirms { get; set; }
    }
    public class InsertPartyRequest
    {
        public string PartyName { get; set; } = string.Empty;
        public string? ClientCode { get; set; }
        public string? IsClient { get; set; }
    }


}
