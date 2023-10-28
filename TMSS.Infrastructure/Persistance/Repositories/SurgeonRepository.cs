using AutoMapper;
using TMSS.DataAccess.DataContext;
using TMSS.Domain.DTO;
using TMSS.Domain.Entities;
using TMSS.Domain.Interfaces;

namespace TMSS.Infrastructure.Persistance.Repositories
{
    public class SurgeonRepository : BaseRepository, ISurgeonRepository
    {
        public TMSSDbContext _tMSSDbContext { get; set; }
        private readonly IMapper _mapper;
        public SurgeonRepository(TMSSDbContext tMSSDbContext, IMapper mapper)
        {
            _tMSSDbContext = tMSSDbContext;
            _mapper = mapper;
        }

        public Task<SurgeonDto> SaveSurgeon(SurgeonDto surgeonDto)
        {
            Surgeon surgeon = _mapper.Map<Surgeon>(surgeonDto);
            if (surgeon.SurgeonId > 0)
            {
                var exisitingProcedure = _tMSSDbContext.Surgeon.FirstOrDefault(j => j.SurgeonId == surgeon.SurgeonId);
                exisitingProcedure.SurgeonFirstName = surgeon.SurgeonFirstName;
                //exisitingProcedure.
                exisitingProcedure.ModifiedBy = surgeon.ModifiedBy;
                exisitingProcedure.ModifiedDate = DateTime.Now;
            }
            else
            {
                surgeon.CreatedBy = "";
                surgeon.CreatedDate = DateTime.Now;
                _tMSSDbContext.Surgeon.Add(surgeon);
            }
            var result = _tMSSDbContext.SaveChanges();
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SurgeonDto>> GetSurgeons(string? surgeonName)
        {
            List<SurgeonDto> surgeon = new List<SurgeonDto>();
            //surgeon.Add(new SurgeonDto() { SurgeonId = 1, SurgeonFirstName = "dr carlo debbas", Speciality= "speciality1", DatePPGranted= DateTime.Now, DateStartedFirstCase= DateTime.Now, ALSDate= DateTime.Now, ProcedureName="Procedure1", ClinicName="Wellness", CreatedBy = "Admin", CreatedDate = DateTime.Now });
            //surgeon.Add(new SurgeonDto() { SurgeonId = 2, SurgeonFirstName = "dr carlo debbas", Speciality = "speciality1", DatePPGranted = DateTime.Now, DateStartedFirstCase = DateTime.Now, ALSDate = DateTime.Now, ProcedureName = "Procedure1", ClinicName = "Phoenix", CreatedBy = "Admin", CreatedDate = DateTime.Now });

            //return await _tmssDbContext.Surgeon.ToListAsync();
            // return (Task<IEnumerable<SurgeonDto>>)_mapper.Map<IEnumerable<SurgeonDto>>(_tMSSDbContext.Surgeon.ToList());
            surgeon = _mapper.Map<List<SurgeonDto>>(_tMSSDbContext.Surgeon.ToList());
            // procedures = _mapper.Map<List<ProcedureDto>>(_tMSSDbContext.ProceduresClinic.ToList());
            SurgeonDto _surgeon = new();
            List<SurgeonDto> lstsurgeons = new List<SurgeonDto>();
            foreach (var procli in surgeon)
            {
                _surgeon = new SurgeonDto();
                _surgeon.SurgeonFirstName = procli.SurgeonFirstName;
                _surgeon.SurgeonLastName = procli.SurgeonLastName;
                _surgeon.Speciality = procli.Speciality;
                _surgeon.DatePPGranted = procli.DatePPGranted;
                _surgeon.DateStartedFirstCase = procli.DateStartedFirstCase;
                _surgeon.ALSDate = procli.ALSDate;
                _surgeon.ClinicId = procli.ClinicId;
                _surgeon.ClinicName = _tMSSDbContext.Clinic.Where(x => x.ClinicId == procli.ClinicId).Select(x => x.ClinicName).FirstOrDefault();
                _surgeon.ProcedureName = _tMSSDbContext.ProceduresClinic.Where(x => x.ProcedureId == procli.ProcedureId).Select(x => x.ProcedureName).FirstOrDefault();
                _surgeon.ProcedureId = procli.ProcedureId;
                lstsurgeons.Add(_surgeon);

            }
            
            surgeon = _mapper.Map<List<SurgeonDto>>(lstsurgeons.ToList());
            return surgeon;
        }
    }
}
