using TMSS.Domain.Entities;

namespace TMSS.Domain.Interfaces
{
    public interface IProcedureRepository
    {
        Task<IEnumerable<ProceduresClinic>> GetProcedures();
        ProceduresClinic CreateProcedure(List<ProceduresClinic> procedure);
        ProceduresClinic ModifyProcedures(List<ProceduresClinic> procedureclinic);

    }
}
