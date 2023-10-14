using System.ComponentModel.DataAnnotations;

namespace TMSS.Web.Models
{
    public class SurgeonViewModel
    {
        [Key]
        public int SurgeonId { get; set; }
        public string? SurgeonFirstName { get; set; }
        public string? SurgeonLastName { get; set; }
        public string? Speciality { get; set; }
        public DateTime? DatePPGranted { get; set; }
        public DateTime? DateStartedFirstCase { get; set; }
        public DateTime? ALSDate { get; set; }
        public int ProcedureId { get; set; }
        public int ClinicId { get; set; }
        public string ProcedureName { get; set; }

        public string ClinicName { get; set; }

    }
}
