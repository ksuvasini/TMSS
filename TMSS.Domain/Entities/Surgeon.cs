using System.ComponentModel.DataAnnotations;


namespace TMSS.Domain.Entities
{
    public class Surgeon : BaseEntity
    {
       
        [Key]
        public int SurgeonId { get; set; }

        [Required(ErrorMessage = "SurgeonFirstName is required!")]
        public string? SurgeonFirstName { get; set; }

        [Required(ErrorMessage = "SurgeonLastName is required!")]
        public string? SurgeonLastName { get; set; }

        [Required(ErrorMessage = "Speciality is required!")]
        public string? Speciality { get; set; }
      
        [Required(ErrorMessage = "DatePPGranted is required!")]
        public DateTime? DatePPGranted { get; set; }

        [Required(ErrorMessage = "DateStartedFirstCase is required!")]
        public DateTime? DateStartedFirstCase { get; set; }

        [Required(ErrorMessage = "ALSDate is required!")]
        public DateTime? ALSDate { get; set; }
        public int ProcedureId { get; set; }
        public int ClinicId { get; set; }
        //public string ProcedureName { get; set; }

        //public string ClinicName { get; set; }

    }
    
}
