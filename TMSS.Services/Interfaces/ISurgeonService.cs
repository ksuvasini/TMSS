using TMSS.Domain.DTO;
using TMSS.Web.Models;

namespace TMSS.Services.Interfaces
{
    public interface ISurgeonService
    {
        Task<IEnumerable<SurgeonDto>> GetSurgeon();

        Task<IEnumerable<SurgeonDto>> SaveSurgeon(SurgeonDto surgeon);
    }
}
