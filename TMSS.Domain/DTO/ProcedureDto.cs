using System.ComponentModel.DataAnnotations;

namespace TMSS.Domain.DTO
{
    public class ProcedureDto : BaseDto
    {
        [Key]
        public int ProcedureId {  get; set; }
        public string ProcedureName { get; set; }
        public int ClinicId { get; set; }
        public string ClinicName { get; set; }


    }
}
