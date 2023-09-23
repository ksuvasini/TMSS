using TMSS.Domain.DTO;

namespace TMSS.Services.Interfaces
{
    public interface IProcedureService
    {
        Task<IEnumerable<ProcedureDto>> GetProcedures();
    }
}
