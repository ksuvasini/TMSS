using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TMSS.Domain.DTO;
using TMSS.Domain.Entities;
using TMSS.Domain.Interfaces;
using TMSS.Services.Interfaces;
using TMSS.Web.Models;

namespace TMSSDemo.Controllers
{
    public class ProcedureController : Controller
    {
        public IProcedureService _procedureService { get; set; }
        public IClinicService _clinicService { get; set; }
        private readonly IMapper _mapper;
        public ProcedureController(IMapper mapper, IProcedureService procedureService, IClinicService clinicService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _procedureService = procedureService;
            _clinicService = clinicService;
        }
        public async Task<IActionResult> Index()
        {
            ProcedureViewModel procedureViewModel = new ProcedureViewModel();
            var clinicList = await _clinicService.GetClinic(string.Empty, string.Empty);
            if (clinicList.Any())
            {
                procedureViewModel.Clinics = new List<SelectListItem>();
                foreach (var clinic in clinicList)
                {
                    procedureViewModel.Clinics.Add(new SelectListItem
                    {
                        Value = clinic.ClinicId.ToString(),
                        Text = clinic.ClinicName
                    });
                }
                ViewBag.Clinics = clinicList.ToList();
            }
            return View(procedureViewModel);
        }

        [HttpGet]
        public IActionResult Get(string? procedureName, string? clinicName)
        {
            return Json(new List<ProcedureDto>{
                new ProcedureDto { ProcedureName = "Radiology", ClinicName = "CPU" },
                  new ProcedureDto { ProcedureName = "Radiology2", ClinicName = "Radiology" }
               });
            return Json(_procedureService.GetProcedures(procedureName, clinicName));
        }

        [HttpPost]
        public IActionResult Create(ProcedureViewModel procedureViewModel)
        {
            var result = _procedureService.SaveProcedure(_mapper.Map<ProcedureDto>(procedureViewModel));
            return Json(result);
        }

    }
}
