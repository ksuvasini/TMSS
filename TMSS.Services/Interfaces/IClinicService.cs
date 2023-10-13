using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMSS.Domain.Entities;

namespace TMSS.Services.Interfaces
{
    public interface IClinicService
    {
        Task<IEnumerable<Clinic>> GetClinics();
        Clinic CreateClinic(Clinic clinic);
        Clinic ModifyClinic(Clinic clinic);
    }
}
