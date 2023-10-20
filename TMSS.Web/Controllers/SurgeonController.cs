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
        public IActionResult Index(string searchstring)
        {
            try
            {
                if (!String.IsNullOrEmpty(searchstring))
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

                    searchstring = searchstring.ToLower(); // Convert the search keyword to lowercase
                    lstsurgeon = lstsurgeon
               .Where(s => s.SurgeonFirstName.ToLower().Contains(searchstring)
                         || s.SurgeonLastName.ToLower().Contains(searchstring) || s.Speciality.ToLower().Contains(searchstring) || s.ClinicName.ToLower().Contains(searchstring) || s.ProcedureName.ToLower().Contains(searchstring)).ToList();

                    return View(lstsurgeon.ToList());
                }
                else
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

            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log the error)
                return StatusCode(500, "An error occurred while fetching users.");
            }
        }
        public async Task<IActionResult> Create()
        {
            SurgeonViewModel surgeonViewModel = new();
            try
            {

                surgeonViewModel.LstProcedures = new();
                surgeonViewModel.Clinics = new();

                IEnumerable<ProceduresClinic> procedureclinic = await _ProcedureService.GetProcedures();
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




                //var getClinics = _ClinicService.GetClinics();

                //foreach (var clinic in getClinics)
                //{
                //    surgeonViewModel.Clinics.Add(new SelectListItem
                //   {
                //       Value = clinic.ClinicId.ToString(),
                //        Text = clinic.ClinicName
                //    });
                //}

                //ViewBag.Clinics = getClinics.ToList();

            }
            catch (Exception ex)
            {

            }
            return View(surgeonViewModel);

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
            SurgeonViewModel surgeonViewModel = new();
            surgeonViewModel.Clinics = new();


            var getClinics = _ClinicService.GetClinics();

            foreach (var clinic in getClinics)
            {
                surgeonViewModel.Clinics.Add(new SelectListItem
                {
                    Value = clinic.ClinicId.ToString(),
                    Text = clinic.ClinicName
                });
            }


           // ViewBag.Clinics = getClinics.ToList();
           // return Json(surgeonViewModel);

            var procedures = (from p in _dbcontext.ProceduresClinic
                              join c in _dbcontext.Clinic on p.ClinicId equals c.ClinicId
                              where (p.ProcedureName == ProcedureName)
                              select (new { ClinicId = c.ClinicId, ClinicName = c.ClinicName })

                 ).ToList();

            List<SelectListItem> lstClincsDetails = new List<SelectListItem>();
            foreach (var item in procedures)
            {
                lstClincsDetails.Add(new SelectListItem
                {
                    Value = item.ClinicId.ToString(),
                    Text = item.ClinicName
                });
            }
            ViewBag.Clinics = lstClincsDetails;


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


            IEnumerable<Clinic> clinics = _ClinicService.GetClinics();
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
