using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TMSS.DataAccess.DataContext;
using TMSS.Domain.Entities;
using TMSS.Domain.Interfaces;

namespace TMSS.Infrastructure.Persistance.Repositories
{
    public class ProcedureRepository : IProcedureRepository
    {
        public TMSSDbContext _tMSSDbContext { get; set; }
        private readonly IMapper _mapper;
        public ProcedureRepository(TMSSDbContext tMSSDbContext, IMapper mapper)
        {
            _tMSSDbContext = tMSSDbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProceduresClinic>> GetProcedures()
        {
            
          return await _tMSSDbContext.ProceduresClinic.ToListAsync();
        }
        public ProceduresClinic CreateProcedure(ProceduresClinic procedure)
        {
            var _procedure = _tMSSDbContext.ProceduresClinic.Add(procedure);
            if (_procedure.Context.SaveChanges() == 1)
                return _procedure.Entity;
            else
                return new ProceduresClinic();

        }
        public ProceduresClinic ModifyProcedures(ProceduresClinic procedureclinic)
        {
            var existingProcedure = _tMSSDbContext.ProceduresClinic.FirstOrDefault(u => u.ProcedureId == procedureclinic.ProcedureId);
            if (existingProcedure != null)
            {
                existingProcedure.ProcedureName = procedureclinic.ProcedureName;
                existingProcedure.ClinicId = procedureclinic.ClinicId;
                existingProcedure.ModifiedDate = DateTime.Now;
                existingProcedure.ModifiedBy = "admin";
                var _proclinic = _tMSSDbContext.ProceduresClinic.Update(existingProcedure);
                if (_proclinic.Context.SaveChanges() == 1)
                    return _proclinic.Entity;
            }

            return new ProceduresClinic();
        }

    }
}
