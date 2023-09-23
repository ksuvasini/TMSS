using Microsoft.EntityFrameworkCore;
using TMSS.DataAccess.Entities;
using TMSS.Domain.Interfaces;

namespace TMSS.Infrastructure.Persistance.Repositories
{
    public class ProcedureRepository : BaseRepository, IProcedureRepository
    {
        public ProcedureRepository()
        {

        }
        public async Task<IEnumerable<Procedure>> GetProcedures()
        {
            List<Procedure> procedures = new List<Procedure>();
            procedures.Add(new Procedure() { ProcedureId = 1, ProcedureName = "Test", CreatedBy = "Admin", CreatedDate = DateTime.Now });
           // return await _tmssDbContext.Procedure.ToListAsync();
           return procedures;
        }
    }
}
