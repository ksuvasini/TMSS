using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using TMSS.Domain.Entities;

namespace TMSS.Web.Models
{
    public class ProcedureViewModel
    {
        public int ProcedureId { get; set; }
        public string ProcedureName { get; set; }
        public int ClinicId { get; set; }

        public string ClinicName { get; set; }
        public List<SelectListItem> Clinics { get; set; }
        //public List<int> SelectedClinicIds { get; set; }
        public int[] SelectedClinics { get; set; }
        //public int[]? selectedClinicIds { get; set; }


    }
}
