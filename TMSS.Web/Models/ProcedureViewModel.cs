using System.ComponentModel.DataAnnotations;

namespace TMSS.Web.Models
{
    public class ProcedureViewModel
    {
        [Key]
        public int ProcedureId { get; set; }
        public string ProcedureName { get; set; }
        public int ClinicId { get; set; }

        public string ClinicName { get; set; }
    }
}
