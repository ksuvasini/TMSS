using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TMSS.Domain.DTO;
using TMSS.Domain.Interfaces;
using TMSS.Services.Interfaces;
using TMSS.Web.Models;

namespace TMSSDemo.Controllers
{
    public class ProcedureController : Controller
    {
        public IProcedureService _procedureService { get; set; }
        private readonly IMapper _mapper;
        public ProcedureController(IMapper mapper, IProcedureService procedureService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _procedureService = procedureService;
        }
        public IActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(_procedureService.GetProcedures());
        }

        [HttpPost]
        public IActionResult Create(ProcedureViewModel procedureViewModel)
        {
            var result = _procedureService.SaveProcedure(_mapper.Map<ProcedureDto>(procedureViewModel));
            return Json(result);
        }

    }
}
