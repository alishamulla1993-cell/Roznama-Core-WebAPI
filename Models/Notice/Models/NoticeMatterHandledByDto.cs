namespace Roznama.Models.Notice.Models
{
    public class NoticeMatterHandledByDto
    {
        public int? SN { get; set; }
        public int? MatterHandledByOID { get; set; }
        public string? MatterHandledBy { get; set; }
    }

    public class NoticeGenerateMatterHandledByRequest
    {
        public int MatterHandledByOID { get; set; }
        public string? MatterHandledBy { get; set; }
        public List<NoticeMatterHandledByDto>? ExistingHandlers { get; set; }
    }
}
