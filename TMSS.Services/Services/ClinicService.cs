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
    public class ClinicService : IClinicService
    {
        public IClinicRepository _clinicRepository { get; set; }
        private readonly IMapper _mapper;
        public ClinicService(IMapper mapper, IClinicRepository clinicRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _clinicRepository = clinicRepository;
        }

        public async Task<IEnumerable<Clinic>> GetClinics()
        {
            return _mapper.Map<List<Clinic>>(await _clinicRepository.GetClinics());

        }

        public Clinic CreateClinic(Clinic clinic)
        {
            return _mapper.Map<Clinic>(_clinicRepository.CreateClinic(clinic));
        }
        public Clinic ModifyClinic(Clinic clinic)
        {
            return _mapper.Map<Clinic>(_clinicRepository.ModifyClinic(clinic));
        }
    }
}
