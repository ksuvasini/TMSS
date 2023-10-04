using AutoMapper;
using TMSS.Domain.DTO;
using TMSS.Domain.Entities;
using TMSS.Web.Models;

namespace TMSS.Web.Profiles
{
    public class UserViewModelProfile :  Profile
    {
        public UserViewModelProfile()
        {
         //   CreateMap<User, UserDto>();
            CreateMap<UserDto, LoginViewModel>();
            CreateMap<LoginViewModel,UserDto> ();
        }
      
    }
}
