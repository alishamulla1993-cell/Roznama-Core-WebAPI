// NoticeSummaryInitResponse.cs
namespace Roznama.Models.Notice.Models
{
    public class NoticeSummaryInitResponse
    {
        // dropdowns
        public IEnumerable<dynamic> Entities { get; set; }
        public IEnumerable<dynamic> Units { get; set; }
        public IEnumerable<dynamic> Zones { get; set; }
        public IEnumerable<dynamic> Regions { get; set; }
        public IEnumerable<dynamic> Classifications { get; set; }
        public IEnumerable<dynamic> Categories { get; set; }
        public IEnumerable<dynamic> SubCategories { get; set; }
        public IEnumerable<dynamic> Statuses { get; set; }
        public IEnumerable<dynamic> Risks { get; set; }
        public IEnumerable<dynamic> NoticeTypes { get; set; }
        public IEnumerable<dynamic> Rlms { get; set; }

        // summary
        public int TotalRecords { get; set; }
        public IEnumerable<dynamic> Summary { get; set; }
    }
}