using TMSS.Domain.DTO;

namespace TMSS.Services.Interfaces
{
    public interface ISurgeonService
    {
        Task<IEnumerable<SurgeonDto>> GetSurgeon(string? surgeonName);

        Task<IEnumerable<SurgeonDto>> SaveSurgeon(SurgeonDto surgeon);
    }
}
