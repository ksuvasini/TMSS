using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSS.Domain.DTO
{
    public class UserDto : BaseDto
    {
        public int UserId { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }


        public string EmailID { get; set; }
        public bool IsAuthenticated { get; set; }

        public List<UserRoleDto> UserRoles { get; set; }
    }
}
