using TMSS.Domain.DTO;
using TMSS.Domain.Entities;

namespace TMSS.Services.Interfaces
{
    public interface IProcedureService
    {
        Task<IEnumerable<ProceduresClinic>> GetProcedures();
        ProceduresClinic CreateProcedure(List<ProceduresClinic> procedure);
        ProceduresClinic ModifyProcedure(List<ProceduresClinic> procedureclinic);

    }
}
