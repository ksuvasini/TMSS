using System.ComponentModel.DataAnnotations;

namespace TMSS.Web.Models
{
	public class IncidentViewModel
	{
		[Required(ErrorMessage = "patient name is required!")]
		public string? PatientName { get; set; }
		public int PatientId { get; set; }
		public int ProcedureId { get; set; }

		[Required(ErrorMessage = "procedure name is required!")]
		public string? ProcedureName { get; set; }
		public int ClinicId { get; set; }

		[Required(ErrorMessage = "clinic name is required!")]
		public string? ClinicName { get; set; }
		public int SurgeonId { get; set; }

		[Required(ErrorMessage = "surgeon name is required!")]
		public string? SurgeonName { get; set; }

		public string? Complication { get; set; }

		public int ComplicationId { get; set; }

		public string? IncidentDetails { get; set; }
	}
}
