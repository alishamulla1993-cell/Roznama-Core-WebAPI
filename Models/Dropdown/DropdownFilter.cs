namespace Roznama.Models.Dropdown
{
    public class DropdownFilter
    {
        public int UserOID { get; set; }
        public string Role { get; set; }

        public int EntityOID { get; set; }
        public int UnitOID { get; set; }
        public int ZoneOID { get; set; }
        public int ClassificationTypeOID { get; set; }
        public int CategoryTypeOID { get; set; }
        public int StatusOID { get; set; }
        public int StateOID { get; set; }
    }
}