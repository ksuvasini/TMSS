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
        public ProceduresClinic CreateProcedure(List<ProceduresClinic> procedure)
        {

            int res = 0;
            foreach (var item in procedure)
            {
                var _procedure = this._tMSSDbContext.ProceduresClinic.Add(item);
                res = _procedure.Context.SaveChanges();
            }
            if (res == 1)
                return new ProceduresClinic();
            else
                return new();

        }
        public ProceduresClinic ModifyProcedures(List<ProceduresClinic> procedureclinic)
        {

            foreach (var item in procedureclinic)
            {
                var existingProcedure = _tMSSDbContext.ProceduresClinic.FirstOrDefault(u => u.ProcedureId == item.ProcedureId);
                if (existingProcedure != null)
                {
                    existingProcedure.ProcedureName = item.ProcedureName;
                    existingProcedure.ClinicId = item.ClinicId;
                    existingProcedure.ModifiedDate = DateTime.Now;
                    existingProcedure.ModifiedBy = "admin";

                    var _proclinic = _tMSSDbContext.ProceduresClinic.Update(existingProcedure);
                    if (_proclinic.Context.SaveChanges() == 1)
                        return _proclinic.Entity;
                }
            }

            return new ProceduresClinic();
        }

    }
}
