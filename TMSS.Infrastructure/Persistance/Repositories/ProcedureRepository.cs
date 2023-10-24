using AutoMapper;
using TMSS.DataAccess.DataContext;
using TMSS.Domain.DTO;
using TMSS.Domain.Entities;
using TMSS.Domain.Interfaces;

namespace TMSS.Infrastructure.Persistance.Repositories
{
    public class ProcedureRepository : BaseRepository, IProcedureRepository
    {
        public TMSSDbContext _tMSSDbContext { get; set; }
        private readonly IMapper _mapper;
        public ProcedureRepository(TMSSDbContext tMSSDbContext, IMapper mapper)
        {
            _tMSSDbContext = tMSSDbContext;
            _mapper = mapper;
        }

        public ProcedureDto SaveProcedure(ProcedureDto procedureDto)
        {
            //Procedure procedure = _mapper.Map<Procedure>(procedureDto);
            if (procedureDto.ProcedureId > 0)
            {
                // making the exisiting record IsActive = false
                var exisitingProcedure = _tMSSDbContext.Procedure.FirstOrDefault(j => j.ProcedureId == procedureDto.ProcedureId);
                if (exisitingProcedure != null && exisitingProcedure.ProcedureId > 0)
                {
                    exisitingProcedure.IsActive = false;
                    //   _tMSSDbContext.SaveChanges();
                }
                //List<Procedure> procedures = new();
                AddProcedureToContext(procedureDto);

            }
            else
            {
                AddProcedureToContext(procedureDto);
            }
            var result = _tMSSDbContext.SaveChanges();
            throw new NotImplementedException();
        }

        private void AddProcedureToContext(ProcedureDto procedureDto)
        {
            foreach (var clinicId in procedureDto.SelectedClinics)
            {
                //procedures.Add(
                var procedureEntity = new Procedure
                {
                    CreatedDate = DateTime.Now,
                    CreatedBy = "admin",
                    ClinicId = clinicId,
                    ProcedureName = procedureDto.ProcedureName,
                };
                _tMSSDbContext.Procedure.Add(procedureEntity);
            }
        }

        public Task<IEnumerable<ProcedureDto>> GetProcedures(string? procedureName, string? clinicName)
        {
            List<ProcedureDto> procedures = new List<ProcedureDto>();
            if (!string.IsNullOrEmpty(procedureName) || !string.IsNullOrEmpty(clinicName))
            {
                var proceduresList = _tMSSDbContext.Procedure.Where(j => j.ProcedureName == procedureName && j.ClinicId == Convert.ToInt16(clinicName)).ToList();
            }
            procedures.Add(new ProcedureDto() { ProcedureId = 1, ProcedureName = "Test", CreatedBy = "Admin", CreatedDate = DateTime.Now });
            // return await _tmssDbContext.Procedure.ToListAsync();
            return (Task<IEnumerable<ProcedureDto>>)_mapper.Map<IEnumerable<ProcedureDto>>(procedures);
        }
    }
}
