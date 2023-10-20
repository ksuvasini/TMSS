using AutoMapper;
using TMSS.DataAccess.DataContext;
using TMSS.Domain.DTO;
using TMSS.Domain.Entities;
using TMSS.Domain.Interfaces;

namespace TMSS.Infrastructure.Persistance.Repositories
{
    public class ClinicRepository : BaseRepository, IClinicRepository
    {
        public TMSSDbContext _tMSSDbContext { get; set; }
        private readonly IMapper _mapper;
        public ClinicRepository(TMSSDbContext tMSSDbContext, IMapper mapper)
        {
            _tMSSDbContext = tMSSDbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClinicDto>> GetClinic()
        {
            return _mapper.Map<IEnumerable<ClinicDto>>(_tMSSDbContext.Clinic.ToList());
            //  throw new NotImplementedException();
        }
        public Task<ClinicDto> SaveClinic(ClinicDto clinicDto)
        {
            Clinic clinic = _mapper.Map<Clinic>(clinicDto);
            if (clinic.ClinicId > 0)
            {
                var exisitingClinic = _tMSSDbContext.Clinic.FirstOrDefault(j => j.ClinicId == clinic.ClinicId);
                exisitingClinic.ClinicName = clinic.ClinicName;
                exisitingClinic.ClinicLocation = clinic.ClinicLocation;
            }
            else
            {
                _tMSSDbContext.Clinic.Add(clinic);
            }
            var result = _tMSSDbContext.SaveChanges();
            throw new NotImplementedException();
        }
    }
}
