using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TMSS.Domain.DTO;
using TMSS.Services.Interfaces;
using TMSS.Services.Services;
using TMSS.Web.Models;

namespace TMSSDemo.Controllers
{
    public class SurgeonController : Controller
    {
        public ISurgeonService _surgeonService { get; set; }
        private readonly IMapper _mapper;
        public SurgeonController(ISurgeonService surgeonService, IMapper mapper)
        {
            _surgeonService = surgeonService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            SurgeonViewModel surgeonViewModel = new SurgeonViewModel();
            surgeonViewModel.Procedures = new List<SelectListItem>();
            surgeonViewModel.Clinics = new List<SelectListItem>();
            surgeonViewModel.Procedures.Add(new SelectListItem
            {
                Text = "Ortho",
                Value = "1",
            });
            surgeonViewModel.Clinics.Add(new SelectListItem
            {
                Text = "General",
                Value = "1",
            });
            return View(surgeonViewModel);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(_surgeonService.GetSurgeon());
        }

        [HttpPost]
        public IActionResult Create(SurgeonViewModel surgeonViewModel)
        {
            var result = _surgeonService.SaveSurgeon(_mapper.Map<SurgeonDto>(surgeonViewModel));
            return Json(result);
        }
    }
}
