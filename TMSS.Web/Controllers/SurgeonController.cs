using AutoMapper;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using TMSS.DataAccess.DataContext;
using TMSS.Domain.Entities;
using TMSS.Services.Interfaces;
using TMSS.Services.Services;
using TMSS.Web.Models;

namespace TMSSDemo.Controllers
{
    public class SurgeonController : Controller
    {
        private readonly ILogger<SurgeonController> _logger;
        public ISurgeonService _SurgeonService { get; set; }
        public IProcedureService _ProcedureService { get; set; }
        public IClinicService _ClinicService { get; set; }

        private readonly IMapper _mapper;
        public TMSSDbContext? _dbcontext;

        public SurgeonController(IClinicService ClinicService, ISurgeonService SurgeonService, IProcedureService ProcedureService, ILogger<SurgeonController> logger, IMapper mapper, TMSSDbContext context)
        {
            _logger = logger;
            _SurgeonService = SurgeonService;
            _ProcedureService = ProcedureService;
            _ClinicService = ClinicService;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _dbcontext = context;
        }
        public IActionResult Index()
        {
            try
            {
                var surgeon = _dbcontext.Surgeon.ToList();
                SurgeonViewModel surgeonmodel = new SurgeonViewModel();
                List<SurgeonViewModel> lstsurgeon = new();
                foreach (var _surgeon in surgeon)
                {
                    surgeonmodel = new SurgeonViewModel();
                    surgeonmodel.SurgeonId = _surgeon.SurgeonId;
                    surgeonmodel.ProcedureName = _dbcontext.ProceduresClinic.Where(x => x.ProcedureId == _surgeon.ProcedureId).Select(x => x.ProcedureName).FirstOrDefault();
                    surgeonmodel.ProcedureId = _surgeon.ProcedureId;
                    surgeonmodel.ClinicId = _surgeon.ClinicId;
                    surgeonmodel.ClinicName = _dbcontext.Clinic.Where(x => x.ClinicId == _surgeon.ClinicId).Select(x => x.ClinicName).FirstOrDefault();
                    surgeonmodel.SurgeonFirstName = _surgeon.SurgeonFirstName;
                    surgeonmodel.SurgeonLastName = _surgeon.SurgeonLastName;
                    surgeonmodel.Speciality = _surgeon.Speciality;
                    surgeonmodel.ALSDate = _surgeon.ALSDate;
                    surgeonmodel.DatePPGranted = _surgeon.DatePPGranted;
                    surgeonmodel.DateStartedFirstCase = _surgeon.DateStartedFirstCase;

                    lstsurgeon.Add(surgeonmodel);

                }

                return View(lstsurgeon.ToList());

            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log the error)
                return StatusCode(500, "An error occurred while fetching users.");
            }
        }
        public async Task<IActionResult> CreateAsync()
        {
            try
            {
                Surgeon surgeon = new Surgeon();

                IEnumerable<ProceduresClinic> procedureclinic = await _ProcedureService.GetProcedures();
                var results = procedureclinic.GroupBy(
    p => p.ProcedureName,
    p => p.ProcedureId,
    (key, g) => new { ProcedureName = key.ToString(), ProcedureId = g.FirstOrDefault() }).ToList();

                List<SelectListItem> selectListItems = results
   .Select(p => new SelectListItem
   {
       Value = p.ProcedureId.ToString(),
       Text = p.ProcedureName.ToString()
   }).Distinct().ToList();

                ViewBag.ProceduresClinic = selectListItems;

                IEnumerable<Clinic> clinics = await _ClinicService.GetClinics();
                List<SelectListItem> selectClinicItems = clinics
.Select(p => new SelectListItem
{
    Value = p.ClinicId.ToString(),
    Text = p.ClinicName
})
.ToList();
                ViewBag.Clinic = selectClinicItems;


            }
            catch (Exception ex)
            {

            }
            return View();

        }
        [HttpGet]
        public JsonResult GetProcedures(int clinicId)
        {

            var procedures = _dbcontext.ProceduresClinic
                .Where(p => p.ClinicId == clinicId)
                .Select(p => new { Value = p.ProcedureId, Text = p.ProcedureName })
                .ToList();

            return Json(procedures);

        }

        [HttpGet]
        public JsonResult GetClinicbyProcedure(string ProcedureName)
        {

            var procedures = (from p in _dbcontext.ProceduresClinic
                              join c in _dbcontext.Clinic on p.ClinicId equals c.ClinicId
                              where (p.ProcedureName == ProcedureName)
                              select (new { ClinicId = c.ClinicId, ClinicName = c.ClinicName })

                 ).ToList();

            return Json(procedures);
        }
        [HttpPost]
        public IActionResult Create(Surgeon surgeon)
        {
            surgeon.CreatedDate = DateTime.Now;
            surgeon.CreatedBy = "admin";
            var _user = _SurgeonService.CreateSurgeon(surgeon);
            if (_user.ClinicId > 0)
                return RedirectToAction("Index"); // Redirect to a success page or wherever you need.
            else
                return View();

            //  return Ok(clinic);
        }
        public async Task<IActionResult> Edit(int id)
        {
            IEnumerable<Surgeon> surgeon = await _SurgeonService.GetSurgeon();

            var _surgeon = surgeon.Where(c => c.SurgeonId == id).FirstOrDefault();

            //IEnumerable<Clinic> clinics = await _ClinicService.GetClinics();
            //ViewBag.Clinics = clinics.ToList();
            IEnumerable<ProceduresClinic> procedureclinic = await _ProcedureService.GetProcedures();
            var results = procedureclinic.GroupBy(
p => p.ProcedureName,
p => p.ProcedureId,
(key, g) => new { ProcedureName = key.ToString(), ProcedureId = g.FirstOrDefault() }).ToList();

            List<SelectListItem> selectListItems = results
.Select(p => new SelectListItem
{
    Value = p.ProcedureId.ToString(),
    Text = p.ProcedureName.ToString()
}).Distinct().ToList();
         //   surgeonmodel.ProcedureName = _dbcontext.ProceduresClinic.Where(x => x.ProcedureId == _surgeon.ProcedureId).Select(x => x.ProcedureName).FirstOrDefault();


            ViewBag.ProceduresClinic = selectListItems;

            IEnumerable<Clinic> clinics = await _ClinicService.GetClinics();
            List<SelectListItem> selectClinicItems = clinics
.Select(p => new SelectListItem
{
    Value = p.ClinicId.ToString(),
    Text = p.ClinicName
})
.ToList();
            ViewBag.Clinic = selectClinicItems;

            return View(_surgeon);

        }
        [HttpPost]
        public IActionResult Edit(Surgeon editsurgeon)
        {

            var _surgeon = _SurgeonService.ModifySurgeon(editsurgeon);
            return RedirectToAction("Index");


        }
    }
}
