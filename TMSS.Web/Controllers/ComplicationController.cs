using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TMSS.Domain.DTO;
using TMSS.Services.Interfaces;
using TMSS.Web.Models;

namespace TMSSDemo.Controllers
{
    public class ComplicationController : Controller
    {
        public IComplicationService _complicationService { get; set; }
        private readonly IMapper _mapper;
        public ComplicationController(IMapper mapper, IComplicationService complicationService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _complicationService = complicationService;
        }
        public IActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public IActionResult Get(string? complicationName)
        {
            List<ComplicationViewModel> complicationViewModels = new List<ComplicationViewModel>();

            return Json(new List<ComplicationViewModel> {
                new ComplicationViewModel { ComplicationName = "Testnew" },
                new ComplicationViewModel { ComplicationName = "Test" }});
            //return Json(_complicationService.GetComplications());
        }

        [HttpPost]
        public IActionResult Create(ComplicationViewModel complicationViewModel)
        {
            var result = _complicationService.SaveComplication(_mapper.Map<ComplicationDto>(complicationViewModel));
            return Json(result);
        }
    }
}
