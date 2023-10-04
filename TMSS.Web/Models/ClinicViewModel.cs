using System.ComponentModel.DataAnnotations;

namespace TMSS.Web.Models
{
	public class ClinicViewModel
	{
		[Key]
		public int ClinicId { get; set; }

		[Required(ErrorMessage = "clinic name is required!")]
		public string? ClinicName { get; set; }

		[Required(ErrorMessage = "clinic location  is required!")]
		public string? ClinicLocation { get; set; }
	}
}
