namespace TMSS.Web.Models
{
	public class ReportViewModel
	{

        public int ProcedureId { get; set; }

        public string? ProcedureName { get; set; }
        public int ClinicId { get; set; }

        public string? ClinicName { get; set; }
        public int SurgeonId { get; set; }


        public string? SurgeonName { get; set; }

        public string? Complication { get; set; }

        public int ComplicationId { get; set; }
    }
}
