using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMSS.Domain.Entities;
using TMSS.Domain.Interfaces;
using TMSS.Services.Interfaces;

namespace TMSS.Services.Services
{
    public class SurgeonService : ISurgeonService
    {
        public ISurgeonRepository _surgeonRepository { get; set; }
        private readonly IMapper _mapper;
        public SurgeonService(IMapper mapper, ISurgeonRepository surgeonRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _surgeonRepository = surgeonRepository;
        }

        public async Task<IEnumerable<Surgeon>> GetSurgeon()
        {
            return _mapper.Map<List<Surgeon>>(await _surgeonRepository.GetSurgeon());

        }
        public Surgeon CreateSurgeon(Surgeon surgeon)
        {
            return _mapper.Map<Surgeon>(_surgeonRepository.CreateSurgeon(surgeon));
        }
        public Surgeon ModifySurgeon(Surgeon surgeon)
        {
            return _mapper.Map<Surgeon>(_surgeonRepository.ModifySurgeon(surgeon));
        }

    }
}
