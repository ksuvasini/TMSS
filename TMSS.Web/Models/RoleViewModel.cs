using System.ComponentModel.DataAnnotations;

namespace TMSS.Web.Models
{
    public class RoleViewModel
    {
        public int RoleId { get; set; }
        [Required]
        public string RoleName { get; set; }
    }
}
