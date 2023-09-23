namespace TMSS.WebAPI.Model
{
    public class ProcedureViewModel
    {
        public int ProcedureId { get; set; }
        public string ProcedureName { get; set; }
        public string ProcedureType { get; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
