using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Templating.Compilation;
using TMSS.Domain.DTO;
using TMSS.Services.Interfaces;
using TMSS.Web.Models;

namespace TMSSDemo.Controllers
{
    public class ComplicationController : Controller
    {
        public TMSS.Services.Interfaces.ICompilationService _complicationService { get; set; }
        private readonly IMapper _mapper;
        public ComplicationController(IMapper mapper, TMSS.Services.Interfaces.ICompilationService complicationService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _complicationService = complicationService;
        }
        public IActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(_complicationService.GetComplications());
        }

        [HttpPost]
        public IActionResult Create(ComplicationViewModel complicationViewModel)
        {
            var result = _complicationService.SaveComplication(_mapper.Map<ComplicationDto>(complicationViewModel));
            return Json(result);
        }
    }
}
