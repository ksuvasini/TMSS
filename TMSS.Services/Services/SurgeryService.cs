using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMSS.Domain.DTO;
using TMSS.Domain.Entities;
using TMSS.Domain.Interfaces;
using TMSS.Services.Interfaces;

namespace TMSS.Services.Services
{
    public class SurgeryService : ISurgeryService
    {
        public ISurgeryRepository _surgeryRespository { get; set; }
        public SurgeryService(ISurgeryRepository surgeryRespository)
        {
            _surgeryRespository = surgeryRespository;
        }
        public List<PatientDto> GetPatientsByRegistrationDate(string registrationDate)
        {
            return _surgeryRespository.GetPatientsByRegistrationDate(registrationDate);
        }

        public int SavePatientSurgery(string type,int patientId)
        {
            return _surgeryRespository.SavePatientSurgery(type, patientId);
        }

        public int SavePatientDetails(PatientDto patientDto, SurgeryDto surgeryDto)
        {
            return _surgeryRespository.SavePatientDetails(patientDto, surgeryDto);
        }
    }
}
