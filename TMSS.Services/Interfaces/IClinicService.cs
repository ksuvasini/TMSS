using TMSS.Domain.DTO;

namespace TMSS.Services.Interfaces
{
    public interface IClinicService
    {
        Task<IEnumerable<ClinicDto>> GetClinic();

        Task<IEnumerable<ClinicDto>> SaveClinic(ClinicDto clinic);
    }
}
