namespace TMSS.Domain.DTO
{
    public class UserRoleDto : BaseDto
    {
        public int UserRoleId { get; set; }
        public int RoleId { get; set;}
        public int UserId { get; set; }
        public string RoleName { get; set; }
    }
}
