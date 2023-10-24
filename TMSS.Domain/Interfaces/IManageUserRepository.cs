using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMSS.Domain.Entities;

namespace TMSS.Domain.Interfaces
{
    public interface IManageUserRepository
    {
        Task<IEnumerable<User>> GetManageUsers();
        User CreateUsers(User user);
        User ModifyUsers(User user);

    }
}
