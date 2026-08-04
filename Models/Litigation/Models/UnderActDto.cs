namespace Roznama.Models.Litigation.Models
{
    public class UnderActDto
    {
        public int SN { get; set; }
        public int UnderActOID { get; set; }
        public string? UnderAct { get; set; }
    }
    public class AddUnderActRequest
    {
        public int UnderActOID { get; set; }     // ddlUnderAct.SelectedValue
        public string? UnderActName { get; set; } // ddl text OR txtotherUnderAct
        public List<UnderActDto>? ExistingUnderActs { get; set; } // GridView data
    }
    public class InsertUnderActRequest
    {
        public string? UnderAct { get; set; }
    }
    public class InsertSubjectMatter
    {
        public string? SubjectMatter { get; set; }
    }
    public class InsertStageRequest
    {
        public string? StageName { get; set; }
    }
    

}
