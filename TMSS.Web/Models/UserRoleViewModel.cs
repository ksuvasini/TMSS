using System.ComponentModel.DataAnnotations;

namespace TMSS.Web.Models
{
	public class UserRoleViewModel
    {
        public int UserRoleId { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public string RoleName { get; set; }
    }
}
