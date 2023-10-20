using TMSS.Domain.Entities;

namespace TMSS.Services.Interfaces
{
    public interface IClinicService
    {
        IEnumerable<Clinic> GetClinics();
        Clinic CreateClinic(Clinic clinic);
        Clinic ModifyClinic(Clinic clinic);
    }
}
