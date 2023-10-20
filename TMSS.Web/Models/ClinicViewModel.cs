using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Web.Mvc;
using TMSS.Domain.Entities;

namespace TMSS.Web.Models
{
	
	public class ClinicViewModel : BaseEntity
	{
		//public ClinicViewModel() {

		//	ClinicIds = new List<string>();
		//	ClinicIdobj = new object();

  //      }
		//[Key]
		//public int ClinicId { get; set; }

		//[Required(ErrorMessage = "clinic name is required!")]
		//public string? ClinicName { get; set; }

		//[Required(ErrorMessage = "clinic location  is required!")]
		//public string? ClinicLocation { get; set; }
        public List<Clinic> Clinics { get;  set; }
		[JsonProperty]
        public List<string> ClinicIds { get; set; }
        public string ClinicIdobj { get; set; }

        public string ProcedureName { get; set; }


    }
	public class Clinicdetails
	{
		public int Value { get; set; }
		public string Text { get; set; }
	}
}
