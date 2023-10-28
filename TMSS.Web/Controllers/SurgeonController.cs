using AutoMapper;
using AutoMapper;
using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using TMSS.DataAccess.DataContext;
using TMSS.Domain.Entities;
using TMSS.Services.Interfaces;
using TMSS.Services.Services;
using TMSS.Web.Models;
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
        public IProcedureService _ProcedureService { get; set; }
        private readonly IMapper _mapper;
        public SurgeonController(ISurgeonService surgeonService, IProcedureService procedureService, IMapper mapper)
        {
            _surgeonService = surgeonService;
            _ProcedureService = procedureService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            SurgeonViewModel surgeonViewModel = new();
            surgeonViewModel.LstProcedures = new();
            surgeonViewModel.Clinics = new();
            IList<ProcedureDto> procedureclinic = _mapper.Map<List<ProcedureDto>>(await _ProcedureService.GetProcedures(string.Empty, string.Empty));

           // IList<ProcedureDto> procedureclinic = _ProcedureService.GetProcedures(string.Empty, string.Empty);
            var results = procedureclinic.GroupBy(
p => p.ProcedureName,
p => p.ProcedureId,
(key, g) => new { ProcedureName = key.ToString(), ProcedureId = g.FirstOrDefault() }).ToList();


            List<SelectListItem> selectListItems = results.Select(p => new SelectListItem
            {
                Value = p.ProcedureId.ToString(),
                Text = p.ProcedureName.ToString()
            }).Distinct().ToList();

            surgeonViewModel.LstProcedures = selectListItems;
            ViewBag.lstProcedures = selectListItems;

            //SurgeonViewModel surgeonViewModel = new SurgeonViewModel();
            //surgeonViewModel.Procedures = new List<SelectListItem>();
            //surgeonViewModel.Clinics = new List<SelectListItem>();
            //surgeonViewModel.Procedures.Add(new SelectListItem
            //{
            //    Text = "Ortho",
            //    Value = "1",
            //});
            //surgeonViewModel.Clinics.Add(new SelectListItem
            //{
            //    Text = "General",
            //    Value = "1",
            //});
            return View(surgeonViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Get(int? page, int? limit, string sortBy, string direction, string? surgeonName)
        {
            try
            {
                List<SurgeonViewModel> records;

                int total;
                var result = _mapper.Map<List<SurgeonViewModel>>(await _surgeonService.GetSurgeon(surgeonName));
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
                // return Json(_mapper.Map<List<SurgeonViewModel>>(_surgeonService.GetSurgeon(surgeonName)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            //var result = _surgeonService.GetSurgeon(surgeonName);
            //return Json(result.Result);
        }

        [HttpPost]
        public IActionResult Create(SurgeonViewModel surgeonViewModel)
        {
            var result = _surgeonService.SaveSurgeon(_mapper.Map<SurgeonDto>(surgeonViewModel));
            return Json(result);
        }
    }
}
