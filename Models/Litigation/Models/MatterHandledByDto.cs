namespace Roznama.Models.Litigation.Models
{
    public class MatterHandledByDto
    {
        public int? SN { get; set; }
        public int? MatterHandledByOID { get; set; }
        public string? MatterHandledBy { get; set; }
    }

    public class GenerateMatterHandledByRequest
    {
        public int MatterHandledByOID { get; set; }
        public string? MatterHandledBy { get; set; }
        public List<MatterHandledByDto>? ExistingHandlers { get; set; }
    }
}
