using TMSS.Domain.Entities;

namespace TMSS.Domain.Interfaces
{
    public interface IProcedureRepository
    {
        Task<IEnumerable<ProceduresClinic>> GetProcedures();
        ProceduresClinic CreateProcedure(ProceduresClinic procedure);
        ProceduresClinic ModifyProcedures(ProceduresClinic procedureclinic);

    }
}
