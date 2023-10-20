using AutoMapper;
using TMSS.DataAccess.DataContext;
using TMSS.Domain.DTO;
using TMSS.Domain.Interfaces;

namespace TMSS.Infrastructure.Persistance.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        public TMSSDbContext _tMSSDbContext { get; set; }
        private readonly IMapper _mapper;
        public LoginRepository(TMSSDbContext tMSSDbContext, IMapper mapper)
        {
            _tMSSDbContext = tMSSDbContext;
            _mapper = mapper;
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
            UserDto userDetails = new UserDto()
            {
                UserName = "Admin",
                Password = "Test"
            };
            //UserDto userDetails = _mapper.Map<UserDto>(_tMSSDbContext.User.Where(jj => jj.UserName == userDto.UserName && userDto.Password == jj.Password).FirstOrDefault());
            //if (userDetails != null)
            //{
            //    userDetails.IsAuthenticated = true;
            //}
            return userDetails;
        }

    }
}
