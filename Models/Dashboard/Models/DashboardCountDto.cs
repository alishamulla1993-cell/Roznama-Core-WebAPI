namespace Roznama.Models.Dashboard.Models
{
    public class DashboardCountDto
    {
        public int CasesCount { get; set; }
        public int ByCompany { get; set; }
        public int AgainstCompany { get; set; }
        public decimal receivable { get; set; }
        public decimal payable { get; set; }
        public int CloseCasesCount { get; set; }
    }
}