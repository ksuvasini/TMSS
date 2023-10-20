using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TMSS.DataAccess.DataContext;
using TMSS.Domain.DTO;
using TMSS.Domain.Interfaces;
using TMSS.Services.Interfaces;
using TMSS.Web.Models;

namespace TMSSDemo.Controllers
{
    public class ClinicController : Controller
    {
        public IClinicService _clinicService { get; set; }
        private readonly IMapper _mapper;
        public ClinicController(IClinicService clinicService, IMapper mapper)
        {
            _clinicService = clinicService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ClinicViewModel clinicViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(clinicViewModel);
            }
            var result = _clinicService.SaveClinic(_mapper.Map<ClinicDto>(clinicViewModel));
            return View();
        }

        [HttpGet]
        public IActionResult Get(string? clinicName, string? clinicLocation)
        {
            List<ClinicViewModel> list = new();

            // list = _mapper.Map<List<ClinicViewModel>>(_clinicService.GetClinic());
            var clinicDetails = new ClinicViewModel()
            {
                ClinicId = 1,
                ClinicLocation = "Jquery",
                ClinicName = "Jquery"
            };
            var clinicDetails1 = new ClinicViewModel()
            {
                ClinicId = 2,
                ClinicLocation = "Jquery",
                ClinicName = "Jquery"
            };
            list.Add(clinicDetails);
            list.Add(clinicDetails1);
            if (!string.IsNullOrEmpty(clinicName))
            {
                list = list.Where(j => j.ClinicName == clinicName).ToList();
            }
            //list2 = 
            return Json(list);
        }

        [HttpGet]
        public IActionResult List()
        {
            return View();
        }
    }
}
