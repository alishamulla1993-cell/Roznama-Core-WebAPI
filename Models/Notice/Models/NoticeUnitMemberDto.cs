namespace Roznama.Models.Notice
{
    public class NoticeUnitMemberDto
    {
        public int? SN { get; set; }
        public int? UnitMemberOID { get; set; }
        public string? UnitMember { get; set; }
    }
    public class NoticeGenerateUnitMemberRequest
    {
        public int UnitMemberOID { get; set; }
        public string? UnitMember { get; set; }
        public List<NoticeUnitMemberDto>? ExistingMembers { get; set; }
    }
}
