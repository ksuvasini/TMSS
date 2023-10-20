using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMSS.Domain.DTO;

namespace TMSS.Services.Interfaces
{
    public interface IRoleManagementService
    {
        public RoleDto AddRole(RoleDto role);
        public RoleDto GetRoles();
        public UserRoleDto AssignRoles(RoleDto role);
        public List<UserRoleDto> GetUserRoles();
    }
}
