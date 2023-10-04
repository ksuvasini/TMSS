using System.ComponentModel.DataAnnotations;

namespace TMSS.Web.Models
{
	public class LoginViewModel
	{
		[Key]
		public int UserId { get; set; }

		[Required(ErrorMessage = "Username is requried!")]
		public string? UserName { get; set; }

		[Required(ErrorMessage = "Password is requried!")]
		public string? Password { get; set; }
	}
}
