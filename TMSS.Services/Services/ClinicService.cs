using AutoMapper;
using TMSS.Domain.DTO;
using TMSS.Domain.Entities;
using TMSS.Domain.Interfaces;
using TMSS.Services.Interfaces;

namespace TMSS.Services.Services
{
    public class ClinicService : IClinicService
    {
        public IClinicRepository _clinicRepository { get; set; }
        private readonly IMapper _mapper;
        public ClinicService(IMapper mapper, IClinicRepository clinicRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _clinicRepository = clinicRepository;
        }

        public Task<IEnumerable<ClinicDto>> GetClinic()
        {
            return _clinicRepository.GetClinic();
            // throw new NotImplementedException();
        }

        public Task<IEnumerable<ClinicDto>> SaveClinic(ClinicDto clinic)
        {
            var result = _clinicRepository.SaveClinic(clinic);
            throw new NotImplementedException();
        }
    }
}
