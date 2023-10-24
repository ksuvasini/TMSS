//using Microsoft.AspNetCore.Mvc.Rendering;
//using Newtonsoft.Json;
//using System.Web.WebPages.Html;
//using TMSS.Domain.Entities;

namespace TMSS.Web.Models
{
    public class ProcedureAndClinicDetails 
    {
        public int ClinicId { get; set; }
        public string ClinicName { get; set; }
        public List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> Clinics { get; set; }
        public int[]? selectedClinicIds { get; set; }
        public string ProcedureName { get; set; }
        public int ProcedureId { get; set; }

    }
}
