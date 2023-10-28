using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TMSS.Domain.DTO;
using TMSS.Services.Interfaces;
using TMSS.Services.Services;
using TMSS.Web.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

        public async Task<IActionResult> Get(int? page, int? limit, string sortBy, string direction,string? complicationName)
        {
            List<ComplicationViewModel> records;

            int total;
            var result = _mapper.Map<List<ComplicationViewModel>>(await _complicationService.GetComplications(complicationName));
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

           // return Json(result);
        }
        [HttpPost]
        public IActionResult Create(ComplicationViewModel complicationViewModel)
        {
            var result = _complicationService.SaveComplication(_mapper.Map<ComplicationDto>(complicationViewModel));
            return Json(result);
        }
    }
}
