using Microsoft.AspNetCore.Mvc.Rendering;
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
        public List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> Clinics { get; set; }
        public int[]? SelectedClinicIds { get; set; }
        public List<SelectListItem> LstProcedures { get; set; }
        public bool? IsChecked { get; set; }
    }
}
