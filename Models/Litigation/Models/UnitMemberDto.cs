namespace Roznama.Models.Litigation
{
    public class UnitMemberDto
    {
        public int? SN { get; set; }
        public int? UnitMemberOID { get; set; }
        public string? UnitMember { get; set; }
    }
    public class GenerateUnitMemberRequest
    {
        public int UnitMemberOID { get; set; }
        public string? UnitMember { get; set; }
        public List<UnitMemberDto>? ExistingMembers { get; set; }
    }
}
