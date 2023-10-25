using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace TMSS.Web.Models
{
    public class SurgeonViewModel
    {
        [Key]
        public int SurgeonId { get; set; }

        [Required(ErrorMessage = "first name is required!")]
        public string? SurgeonFirstName { get; set; }

        [Required(ErrorMessage = "last name is required!")]
        public string? SurgeonLastName { get; set; }

        [Required(ErrorMessage = "speciality is required!")]
        public string? Speciality { get; set; }

        [Required(ErrorMessage = "DatePPGranted is required!")]
         public DateTime? DatePPGranted { get; set; }

        [Required(ErrorMessage = "DateFirstCase is required!")]
        public DateTime? DateStartedFirstCase { get; set; }

        [Required(ErrorMessage = "ALSDate is required!")]
         public DateTime? ALSDate { get; set; }

        public int ProcedureId { get; set; }

        public int ClinicId { get; set; }

        public List<SelectListItem> Procedures { get; set; }

        public List<SelectListItem> Clinics { get; set; }

    }
}
