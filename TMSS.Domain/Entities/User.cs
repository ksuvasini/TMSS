using System.ComponentModel.DataAnnotations;

namespace TMSS.Domain.Entities
{
    public class User : BaseEntity
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]  
        public string Password { get; set; }

        [Required]
        public string EmailID { get; set; }

    }
}
