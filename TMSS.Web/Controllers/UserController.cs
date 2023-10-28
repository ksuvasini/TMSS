using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TMSS.Domain.DTO;
using TMSS.Services.Interfaces;
using TMSS.Web.Models;

namespace TMSSDemo.Controllers
{
    public class UserController : Controller
    {
        public ISurgeryService _isurgeryInterface { get; set; }
        private readonly IMapper _mapper;
        public UserController(ISurgeryService isurgeryInterface, IMapper mapper)
        {
            _mapper = mapper;
            _isurgeryInterface = isurgeryInterface;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetPatientsByRegistrationDate(string registrationDate)
        {
            return Json(_isurgeryInterface.GetPatientsByRegistrationDate(registrationDate));
        }

        public IActionResult SavePatientSurgery(string type, int patientId)
        {
            return Json(_isurgeryInterface.SavePatientSurgery(type, patientId));
        }
        public IActionResult SavePatientDetails(PatientViewModel patientViewModel)
        {
            PatientDto patientDto = _mapper.Map<PatientDto>(patientViewModel);
            SurgeryDto surgeryDto = _mapper.Map<SurgeryDto>(patientViewModel);
            return Json(_isurgeryInterface.SavePatientDetails(patientDto, surgeryDto));
        }

    }
}
