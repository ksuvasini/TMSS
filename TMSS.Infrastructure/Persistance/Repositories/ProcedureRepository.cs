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
            Procedure procedure = _mapper.Map<Procedure>(procedureDto);
            if (procedure.ProcedureId > 0)
            {
                var exisitingProcedure = _tMSSDbContext.Procedure.FirstOrDefault(j => j.ProcedureId == procedure.ProcedureId);
                exisitingProcedure.ProcedureName = procedure.ProcedureName;
                exisitingProcedure.ProcedureType = procedure.ProcedureType;
            }
            else
            {
                _tMSSDbContext.Procedure.Add(procedure);
            }
            var result = _tMSSDbContext.SaveChanges();
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProcedureDto>> GetProcedures()
        {
            List<ProcedureDto> procedures = new List<ProcedureDto>();
            procedures.Add(new ProcedureDto() { ProcedureId = 1, ProcedureName = "Test", CreatedBy = "Admin", CreatedDate = DateTime.Now });
            // return await _tmssDbContext.Procedure.ToListAsync();
            return (Task<IEnumerable<ProcedureDto>>)_mapper.Map<IEnumerable<ProcedureDto>>(procedures);
        }
    }
}
