using TMSS.Domain.DTO;

namespace TMSS.Services.Interfaces
{
    public interface IProcedureService
    {
        Task<IEnumerable<ProcedureDto>> GetProcedures(string? procedureName, string? clinicName);

        ProcedureDto SaveProcedure(ProcedureDto procedureDto);
    }
}
