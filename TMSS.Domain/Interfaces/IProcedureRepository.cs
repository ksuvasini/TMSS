using TMSS.Domain.DTO;
using TMSS.Domain.Entities;

namespace TMSS.Domain.Interfaces
{
    public interface IProcedureRepository
    {
        Task<IEnumerable<ProcedureDto>> GetProcedures();

        ProcedureDto SaveProcedure(ProcedureDto procedureDto);
    }
}
