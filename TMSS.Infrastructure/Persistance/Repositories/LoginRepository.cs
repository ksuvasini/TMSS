using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMSS.DataAccess.DataContext;
using TMSS.Domain.DTO;
using TMSS.Domain.Interfaces;

namespace TMSS.Infrastructure.Persistance.Repositories
{
    public class LoginRepository : ILoginRepository
    {
       // public TMSSDbContext _tMSSDbContext { get; set; }
        //public LoginRepository(TMSSDbContext tMSSDbContext) {
        //    _tMSSDbContext = tMSSDbContext; 
        //}    
        public List<UserDto> IsAuthenticated(UserDto userDto)
        {
            List<UserDto> userDtos = new List<UserDto>();
            userDtos.Add(new UserDto()
            {
                IsAuthenticated = true,
                RoleName = "Admin"
            });
            return userDtos;
        }
    }
}
