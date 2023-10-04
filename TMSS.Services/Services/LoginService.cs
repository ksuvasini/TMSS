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
        public List<UserDto> IsAuthenticated(UserDto userDto)
        {
            return _loginRepository.IsAuthenticated(userDto);
        }
    }
}
