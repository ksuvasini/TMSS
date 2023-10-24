using TMSS.Domain.DTO;
using TMSS.Domain.Entities;

namespace TMSS.Domain.Interfaces
{
    public interface IProcedureRepository
    {
        Task<IEnumerable<ProcedureDto>> GetProcedures(string? procedureName, string? clinicName);

        ProcedureDto SaveProcedure(ProcedureDto procedureDto);
    }
}
