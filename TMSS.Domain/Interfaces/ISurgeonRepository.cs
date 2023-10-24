using TMSS.Domain.DTO;


namespace TMSS.Domain.Interfaces
{
    public interface ISurgeonRepository
    {
        Task<IEnumerable<SurgeonDto>> GetSurgeons(string? surgeonName);

        Task<SurgeonDto> SaveSurgeon(SurgeonDto clinic);
    }
}
