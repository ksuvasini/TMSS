using TMSS.DataAccess.DataContext;
using TMSS.Domain.DTO;
using TMSS.Domain.Interfaces;

namespace TMSS.Infrastructure.Persistance.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        public TMSSDbContext _tMSSDbContext { get; set; }
        public LoginRepository(TMSSDbContext tMSSDbContext)
        {
            _tMSSDbContext = tMSSDbContext;
        }
        public List<UserRoleDto> GetUserRoles(UserDto userDto)
        {
            List<UserRoleDto> roles = new List<UserRoleDto>
            {
                new UserRoleDto { UserId = 1, RoleId = 1, RoleName = "Admin" },
                new UserRoleDto { UserId = 2, RoleId = 2, RoleName = "User" }
            };
            return roles;
        }


        public UserDto IsAuthenticated(UserDto userDto)
        {
            return new UserDto()
            {
                IsAuthenticated = true,
                RoleName = "Admin"
            };
        }

    }
}
