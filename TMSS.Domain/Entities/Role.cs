using System.ComponentModel.DataAnnotations;

namespace TMSS.Domain.Entities
{
    public class RoleDto : BaseEntity
    {
        [Key]
        public int RoleId { get; set; }

        [Required]
        public string RoleName { get; set; }    

    }
}
