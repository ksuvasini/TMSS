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

        public async Task<IEnumerable<ClinicDto>> GetClinic(string? clinicName,
                                                      string? clinicLocation)
        {
            return await _clinicRepository.GetClinic(clinicName, clinicLocation);
        }

        public int SaveClinic(ClinicDto clinic)
        {
            return _clinicRepository.SaveClinic(clinic);

        }
    }
}
