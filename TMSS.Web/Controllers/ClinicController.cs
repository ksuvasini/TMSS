using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TMSS.Domain.DTO;
using TMSS.Services.Interfaces;
using TMSS.Services.Services;
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
            //if (!ModelState.IsValid)
            //{
            //  return View(clinicViewModel);
            // }
            var result = _clinicService.SaveClinic(_mapper.Map<ClinicDto>(clinicViewModel));
            return Json(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get(int? page, int? limit, string sortBy, string direction,string? clinicName, string? clinicLocation)
        {
            List<ClinicViewModel> records;

            int total;
            var result = _mapper.Map<List<ClinicViewModel>>(await _clinicService.GetClinic(clinicName, clinicLocation));
            total = result.Count();
            if (page.HasValue && limit.HasValue)
            {
                int start = (page.Value - 1) * limit.Value;
                records = result.Skip(start).Take(limit.Value).ToList();
            }
            else
            {
                records = result.ToList();
            }
            return this.Json(new { records, total });
            // var list = _mapper.Map<List<ClinicViewModel>>(await _clinicService.GetClinic(clinicName, clinicLocation));
           // return Json(_mapper.Map<List<ClinicViewModel>>(await _clinicService.GetClinic(clinicName, clinicLocation)));
        }

        [HttpGet]
        public IActionResult List()
        {
            return View();
        }
    }
}
