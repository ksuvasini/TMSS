using System.ComponentModel.DataAnnotations;

namespace TMSS.Domain.DTO
{
    public class RoleDto : BaseDto
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }    

    }
}
