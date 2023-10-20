using AutoMapper;
using TMSS.Domain.DTO;
using TMSS.Domain.Entities;
using TMSS.Domain.Interfaces;
using TMSS.Services.Interfaces;
using TMSS.Web.Models;

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

        public Task<IEnumerable<SurgeonDto>> GetSurgeon()
        {
            return _surgeonRepository.GetSurgeons();
            // throw new NotImplementedException();
        }

        public Task<IEnumerable<SurgeonDto>> SaveSurgeon(SurgeonDto Surgeon)
        {
            var result = _surgeonRepository.SaveSurgeon(Surgeon);
            throw new NotImplementedException();
        }
    }
}
