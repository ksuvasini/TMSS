using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMSS.Domain.DTO;
using TMSS.Domain.Interfaces;
using TMSS.Services.Interfaces;

namespace TMSS.Services.Services
{
    public class LoginService : ILoginService
    {
        public ILoginRepository _loginRepository { get; set; }
        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public UserDto IsAuthenticated(UserDto userDto)
        {
            UserDto userDetails = _loginRepository.IsAuthenticated(userDto);
            userDetails.UserRoles = new List<UserRoleDto>();
            userDetails.UserRoles =  _loginRepository.GetUserRoles(userDto);
            return userDetails;
        }
    }
}
