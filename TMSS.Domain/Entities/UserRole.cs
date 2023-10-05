using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TMSS.Domain.Entities
{
    public class UserRole : BaseEntity
    {
        [Key]
        public int UserRoleId { get; set; }
        [Required]
        [ForeignKey("RoleId")]
        public int RoleId { get; set;}
        [Required]
        [ForeignKey("RoleId")]
        public int UserId { get; set; }
        [Required]
        public string RoleName { get; set; }
    }
}
