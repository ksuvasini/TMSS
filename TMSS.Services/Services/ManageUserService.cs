using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMSS.Domain.DTO;
using TMSS.Domain.Entities;
using TMSS.Domain.Interfaces;
using TMSS.Services.Interfaces;

namespace TMSS.Services.Services
{
    public class ManageUserService : IManageUserService
    {
        public IManageUserRepository _manageuserRepository { get; set; }
        private readonly IMapper _mapper;
        public ManageUserService(IMapper mapper, IManageUserRepository manageuserRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _manageuserRepository = manageuserRepository;
        }

        public async Task<IEnumerable<User>> GetManageUsers()
        {
            return _mapper.Map<List<User>>(await _manageuserRepository.GetManageUsers());

        }
        public User CreateUsers(User user)
        {
            return _mapper.Map<User>(_manageuserRepository.CreateUsers(user));
        }
        public User ModifyUsers(User user)
        {
            return _mapper.Map<User>(_manageuserRepository.ModifyUsers(user));
        }

    }
}

