using TMSS.Domain.DTO;
using TMSS.Domain.Entities;

namespace TMSS.Services.Interfaces
{
    public interface IProcedureService
    {
        Task<IEnumerable<ProceduresClinic>> GetProcedures();
        ProceduresClinic CreateProcedure(ProceduresClinic procedure);
        ProceduresClinic ModifyProcedure(ProceduresClinic procedureclinic);

    }
}
