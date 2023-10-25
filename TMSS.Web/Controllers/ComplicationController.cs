using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TMSS.Domain.DTO;
using TMSS.Services.Interfaces;
using TMSS.Services.Services;
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

        public async Task<IActionResult> Get(string? complicationName)
        {
            return Json(_mapper.Map<List<ComplicationViewModel>>(await _complicationService.GetComplications(complicationName)));
        }
        [HttpPost]
        public IActionResult Create(ComplicationViewModel complicationViewModel)
        {
            var result = _complicationService.SaveComplication(_mapper.Map<ComplicationDto>(complicationViewModel));
            return Json(result);
        }
    }
}
