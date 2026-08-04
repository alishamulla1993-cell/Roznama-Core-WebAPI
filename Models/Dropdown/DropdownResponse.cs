namespace Roznama.Models.Dropdown
{
    public class DropdownResponse
    {
        public IEnumerable<dynamic>? Entities { get; set; }
        public IEnumerable<dynamic>? Units { get; set; }
        public IEnumerable<dynamic>? Zones { get; set; }
        public IEnumerable<dynamic>? Regions { get; set; }
        public IEnumerable<dynamic>? Departments { get; set; }
        public IEnumerable<dynamic>? ClassificationTypes { get; set; }
        public IEnumerable<dynamic>? CategoryTypes { get; set; }
        public IEnumerable<dynamic>? SubCategoryTypes { get; set; }
        public IEnumerable<dynamic>? Statuses { get; set; }
        public IEnumerable<dynamic>? SubStatuses { get; set; }
        public IEnumerable<dynamic>? Risks { get; set; }
        public IEnumerable<dynamic>? TeamMembers { get; set; }
        public IEnumerable<dynamic>? SubUnits { get; set; }
        public IEnumerable<dynamic>? NoticeTypes { get; set; }
        public IEnumerable<dynamic>? Rlms { get; set; }
        public IEnumerable<dynamic>? States { get; set; }
        public IEnumerable<dynamic>? Cities { get; set; }
    }
}