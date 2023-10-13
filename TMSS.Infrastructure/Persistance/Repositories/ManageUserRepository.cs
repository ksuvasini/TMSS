using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMSS.DataAccess.DataContext;
using TMSS.Domain.Entities;
using TMSS.Domain.Interfaces;



namespace TMSS.Infrastructure.Persistance.Repositories
{
    public class ManageUserRepository : IManageUserRepository
    {
        public TMSSDbContext _tMSSDbContext { get; set; }
        private readonly IMapper _mapper;
        public ManageUserRepository(TMSSDbContext tMSSDbContext, IMapper mapper)
        {
            _tMSSDbContext = tMSSDbContext;
            _mapper = mapper;
        }


        public async Task<IEnumerable<User>> GetManageUsers()
        {
            return await _tMSSDbContext.User.ToListAsync();
        }

        public User CreateUsers(User user)
        {
            var _user = _tMSSDbContext.User.Add(user);
            if (_user.Context.SaveChanges() == 1)
                return _user.Entity;
            else
                return new User();

        }

        public User ModifyUsers(User user)
        {
            var existingUser = _tMSSDbContext.User.FirstOrDefault(u => u.UserId == user.UserId);
            if (existingUser != null)
            {
                existingUser.UserName = user.UserName;
                existingUser.Password = user.Password;
                existingUser.EmailID = user.EmailID;
                existingUser.ModifiedDate = DateTime.Now;
                existingUser.ModifiedBy = "admin";
                var _user = _tMSSDbContext.User.Update(existingUser);
                if (_user.Context.SaveChanges() == 1)
                    return _user.Entity;
            }

            return new User();
        }


    }
}
