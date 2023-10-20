using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Web.Razor.Generator;
using TMSS.DataAccess.DataContext;
using TMSS.Domain.DTO;
using TMSS.Domain.Entities;
using TMSS.Services.Interfaces;
using TMSS.Web.Models;

namespace TMSSDemo.Controllers
{
    public class ProcedureController : Controller
    {
        private readonly ILogger<ProcedureController> _logger;
        public IProcedureService _ProcedureService { get; set; }
        public IClinicService _ClinicService { get; set; }
        private readonly IMapper _mapper;
        public TMSSDbContext? _dbcontext;

        public ProcedureController(IProcedureService procedureservice, IClinicService clinicservice, ILogger<ProcedureController> logger, IMapper mapper, TMSSDbContext context)
        {
            _logger = logger;
            _ProcedureService = procedureservice;
            _ClinicService = clinicservice;

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));


            if (_dbcontext == null)
            {
                _dbcontext = context;
            }
        }
        public IActionResult Index(string searchstring)
        {
            try
            {
                if (!String.IsNullOrEmpty(searchstring))
                {
                    var procedures = _dbcontext.ProceduresClinic.ToList();
                    ProcedureViewModel proceduremodel = new ProcedureViewModel();
                    List<ProcedureViewModel> lstprocedure = new();
                    foreach (var procedure in procedures)
                    {
                        proceduremodel = new ProcedureViewModel();
                        proceduremodel.ClinicId = procedure.ClinicId;
                        proceduremodel.ClinicName = _dbcontext.Clinic.Where(x => x.ClinicId == procedure.ClinicId).Select(x => x.ClinicName).FirstOrDefault();

                        proceduremodel.ProcedureName = procedure.ProcedureName;
                        proceduremodel.ProcedureId = procedure.ProcedureId;
                        lstprocedure.Add(proceduremodel);


                    }
                  
                    searchstring = searchstring.ToLower(); // Convert the search keyword to lowercase

                    lstprocedure = lstprocedure
               .Where(s => s.ProcedureName.ToLower().Contains(searchstring)
                         || s.ClinicName.ToLower().Contains(searchstring)).ToList();

                        return View(lstprocedure.ToList());

                    
                }
                else
                {
                    var procedures = _dbcontext.ProceduresClinic.ToList();

                    ProcedureViewModel proceduremodel = new ProcedureViewModel();
                    List<ProcedureViewModel> lstprocedure = new();
                    foreach (var procedure in procedures)
                    {
                        proceduremodel = new ProcedureViewModel();
                        proceduremodel.ClinicId = procedure.ClinicId;
                        proceduremodel.ClinicName = _dbcontext.Clinic.Where(x => x.ClinicId == procedure.ClinicId).Select(x => x.ClinicName).FirstOrDefault();

                        proceduremodel.ProcedureName = procedure.ProcedureName;
                        proceduremodel.ProcedureId = procedure.ProcedureId;
                        lstprocedure.Add(proceduremodel);


                    }
                    return View(lstprocedure.ToList());

                }


            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log the error)
                return StatusCode(500, "An error occurred while fetching users.");
            }
        }


        public  IActionResult Create()
        {
            try
            {
               
                    ProcedureAndClinicDetails procedure = new();
                    procedure.Clinics = new();
                    var clinics = _ClinicService.GetClinics();

                    foreach (var clinic in clinics)
                    {
                        procedure.Clinics.Add(new SelectListItem
                        {
                            Value = clinic.ClinicId.ToString(),
                            Text = clinic.ClinicName
                        });
                    }
                    ViewBag.Clinics = clinics.ToList();

                return View(procedure);

            }
            catch (Exception ex)
            {

            }
            return View();
        }


        [HttpPost]
        public ActionResult Create(ProcedureAndClinicDetails procedureAndClinicDetails)
        {

            List<ProceduresClinic> lstProcClinic = new();

            List<int> lstSelectedClinics = new();

            //for (int i = 0; i < procedureAndClinicDetails.selectedClinicIds.Length; i++)
            //{
            //    lstSelectedClinics.Add(procedureAndClinicDetails.selectedClinicIds[i]);
            //}
            

            foreach (var item in procedureAndClinicDetails.selectedClinicIds)
            {
                lstProcClinic.Add(new ProceduresClinic
                {
                 CreatedDate = DateTime.Now,
                CreatedBy = "admin",
                ClinicId = item,
                ProcedureName = procedureAndClinicDetails.ProcedureName,
                });                                   
            }

            var res = _ProcedureService.CreateProcedure(lstProcClinic);

            return RedirectToAction("Index");
            //if (res != null)
            //    return RedirectToAction("Index"); // Redirect to a success page or wherever you need.
            //else
            //    return Json(false);

            //  return Ok(clinic);
        }
         

        public async Task<IActionResult> Edit(int id)
        {
            var procedures = _dbcontext.ProceduresClinic.ToList();
            var _procedures = procedures.Where(c => c.ProcedureId == id).FirstOrDefault();
            var clinics = _ClinicService.GetClinics();
            ProcedureAndClinicDetails procedure = new();
            procedure.Clinics = new();
            procedure.ProcedureName = _procedures.ProcedureName;
            procedure.ClinicName = clinics.Where(x => x.ClinicId == _procedures.ClinicId).Select(x => x.ClinicName).FirstOrDefault();
            procedure.ProcedureId = _procedures.ProcedureId;
            foreach (var clinic in clinics)
            {
                procedure.Clinics.Add(new SelectListItem
                {
                    Value = clinic.ClinicId.ToString(),
                    Text = clinic.ClinicName
                });
            }
            ViewBag.Clinics = clinics.ToList();

            return View(procedure);

        }
        [HttpPost]
        public JsonResult Edit(ProcedureAndClinicDetails procedureAndClinicDetails)
        {
            List<ProceduresClinic> lstProcClinic = new();
            List<int> lstSelectedClinics = new();
            foreach (var item in procedureAndClinicDetails?.selectedClinicIds)
            {
                lstProcClinic.Add(new ProceduresClinic
                {
                    CreatedDate = DateTime.Now,
                    CreatedBy = "admin",
                    ClinicId = item,
                    ProcedureId = procedureAndClinicDetails.ProcedureId,
                    ProcedureName = procedureAndClinicDetails.ProcedureName,
                });
            }
            var _procedure = _ProcedureService.ModifyProcedure(lstProcClinic);
            return Json(true);
        }
    }
}
