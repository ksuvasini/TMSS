namespace TMSS.Domain.Entities
{
    public class Procedure : BaseEntity
    {
        public int ProcedureId { get; set; }
        public string ProcedureName { get; set; }    
        public string ProcedureType { get; set; }
    }
}
