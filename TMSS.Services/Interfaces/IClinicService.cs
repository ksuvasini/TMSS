using TMSS.Domain.DTO;

namespace TMSS.Services.Interfaces
{
    public interface IClinicService
    {
        Task<IEnumerable<ClinicDto>> GetClinic(string? clinicName, string? clinicLocation);

        Task<IEnumerable<ClinicDto>> SaveClinic(ClinicDto clinic);
    }
}
