using System.ComponentModel.DataAnnotations;

namespace TMSS.Web.Models
{
	public class ClinicViewModel
	{
		[Key]
		public int ClinicId { get; set; }

		[Required(ErrorMessage = "Clinic Name is required!")]
		public string ClinicName { get; set; }

		[Required(ErrorMessage = "Clinic Location  is required!")]
		public string ClinicLocation { get; set; }
	}
}
