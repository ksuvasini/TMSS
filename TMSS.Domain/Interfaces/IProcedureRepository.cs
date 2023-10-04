using TMSS.Domain.Entities;

namespace TMSS.Domain.Interfaces
{
    public interface IProcedureRepository
    {
        Task<IEnumerable<Procedure>> GetProcedures();
    }
}
