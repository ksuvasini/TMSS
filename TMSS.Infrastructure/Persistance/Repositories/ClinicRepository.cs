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

        public async Task<IEnumerable<ClinicDto>> GetClinic(string? clinicName, string? clinicLocation)
        {
            List<ClinicDto> clinis = new List<ClinicDto>();
            if (!string.IsNullOrEmpty(clinicName) || !string.IsNullOrEmpty(clinicLocation))
            {
                if(!string.IsNullOrEmpty(clinicName) && !string.IsNullOrEmpty(clinicLocation))
                    clinis = _mapper.Map<List<ClinicDto>>(_tMSSDbContext.Clinic.Where(jj => jj.ClinicName.ToLower().Contains(clinicName.ToLower()) && jj.ClinicLocation.ToLower().Contains(clinicLocation.ToLower())).ToList());
                else if (!string.IsNullOrEmpty(clinicName))
                    clinis = _mapper.Map<List<ClinicDto>>(_tMSSDbContext.Clinic.Where(jj => jj.ClinicName.ToLower().Contains(clinicName.ToLower())).ToList());
                else if (!string.IsNullOrEmpty(clinicLocation))
                    clinis = _mapper.Map<List<ClinicDto>>(_tMSSDbContext.Clinic.Where(jj => jj.ClinicLocation.ToLower().Contains(clinicLocation.ToLower())).ToList());
               

            }
            else
            {
                clinis = _mapper.Map<List<ClinicDto>>(_tMSSDbContext.Clinic.ToList());
            }
            // List<ClinicDto> clinis = new List<ClinicDto> { new ClinicDto { ClinicId = 1, ClinicLocation = "Pune", ClinicName = "CPU" },
            // new ClinicDto { ClinicId = 2, ClinicLocation = "Noida", ClinicName = "Radiology" }};
            return clinis;
        }
        public int SaveClinic(ClinicDto clinicDto)
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
                clinic.CreatedBy = "Admin";
                clinic.CreatedDate = DateTime.Now;
                _tMSSDbContext.Clinic.Add(clinic);
            }
            return  _tMSSDbContext.SaveChanges();

        }
    }
}
