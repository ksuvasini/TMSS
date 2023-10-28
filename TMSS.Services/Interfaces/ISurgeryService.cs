using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMSS.Domain.DTO;

namespace TMSS.Services.Interfaces
{
    public interface ISurgeryService
    {
        public List<PatientDto> GetPatientsByRegistrationDate(string registrationDate);
        int SavePatientDetails(PatientDto patientDto , SurgeryDto surgeryDto);
        int SavePatientSurgery(string type, int patientId);
    }
}
