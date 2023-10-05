using System.ComponentModel.DataAnnotations;

namespace TMSS.Domain.Entities
{
    public class Role : BaseEntity
    {
        [Key]
        public int RoleId { get; set; }

        [Required]
        public string RoleName { get; set; }    

    }
}
