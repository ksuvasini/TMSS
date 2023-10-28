using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TMSS.DataAccess.DataContext;
using TMSS.Domain.DTO;
using TMSS.Domain.Entities;
using TMSS.Domain.Interfaces;

namespace TMSS.Infrastructure.Persistance.Repositories
{
    public class SurgeryRepository : ISurgeryRepository
    {
        public TMSSDbContext _tmssDbContext { get; set; }
        public SurgeryRepository(TMSSDbContext tmssDbContext)
        {
            _tmssDbContext = tmssDbContext;
        }
        public List<PatientDto> GetPatientsByRegistrationDate(string registrationDate)
        {
            List<PatientDto> patients = new List<PatientDto>
            {
                new PatientDto{ PatientId = 1, PatientName = "Patient1", RegistrationDate = DateTime.Now},
                new PatientDto{ PatientId = 2, PatientName = "Patient2", RegistrationDate = DateTime.Now}
            };
            return patients;
        }

        public int SavePatientSurgery(string type, int patientId)
        {
            int result;
            var surgeryDetails = _tmssDbContext.Surgery.Where(j => j.PatientId == patientId).FirstOrDefault();
            switch (type)
            {
                case "ArrivedInClinic":
                    surgeryDetails.ArrivedInClinic = DateTime.Now;
                    // result = _tmssDbContext.SaveChanges();
                    break;
                case "ArrivedInTheatre":
                    surgeryDetails.ArrivedInTheatre = DateTime.Now;
                    // result = _tmssDbContext.SaveChanges();
                    break;
                case "AnesthesiaStartTime":
                    surgeryDetails.AnesthesiaStartTime = DateTime.Now;
                    break;
                case "KnifeSkinTime":
                    surgeryDetails.KnifeSkinTime = DateTime.Now;
                    break;
                case "ProcedureFinishTime":
                    surgeryDetails.ProcedureFinishTime = DateTime.Now;
                    break;
                case "DepartureTime":
                    surgeryDetails.DepartureTime = DateTime.Now;
                    break;
                default:
                    // code block
                    break;
            }
            result = _tmssDbContext.SaveChanges();
            return result;
        }

        public int SavePatientDetails(PatientDto patientDto, SurgeryDto surgeryDto)
        {
            _tmssDbContext.Patient.Add(new Patient
            {
                PatientNo = GetPatientNumber(), // need to generate Number;
                LastName = patientDto.LastName,
                FirstName = patientDto.FirstName,
                Gender = patientDto.Gender,
                DateOfBirth = patientDto.DateOfBirth,
                PhoneNumber = patientDto.PhoneNumber,
                RegistrationDate = patientDto.RegistrationDate,
                Address = patientDto.Address,
                PatientName = patientDto.FirstName + " " + patientDto.LastName,
                CreatedDate = DateTime.Now,
                CreatedBy = "Admin"
            });
            var result = _tmssDbContext.SaveChanges();
            var patientId = _tmssDbContext.Patient.Where(p => p.PatientNo == 1).FirstOrDefault().PatientId;
            _tmssDbContext.Surgery.Add(new Surgery
            {
                SurgeonId = surgeryDto.SurgeonId,
                ProcedureId = surgeryDto.ProcedureId,
                ClinicID = surgeryDto.ClinicID,
                SurgeryDate = surgeryDto.SurgeryDate,
                PatientId = patientId
            });
            return _tmssDbContext.SaveChanges();
        }

        private int GetPatientNumber()
        {
            throw new NotImplementedException();
        }
    }
}
