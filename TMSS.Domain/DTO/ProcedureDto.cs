namespace TMSS.Domain.DTO
{
    public class ProcedureDto : BaseDto
    {
        public int ProcedureId { get; set; }
        public string ProcedureName { get; set; }
        public string ProcedureType { get; }
    }
}
