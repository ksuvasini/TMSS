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
            _dbcontext = context;
        }
        public IActionResult Index()
        {
            try
            {

                var procedures = _dbcontext.ProceduresClinic.ToList();

                ProcedureViewModel proceduremodel = new ProcedureViewModel();
                List<ProcedureViewModel> lstprocedure = new();
               foreach (var procedure in procedures)
                {
                    proceduremodel = new ProcedureViewModel();
                    proceduremodel.ClinicId = procedure.ClinicId;
                    proceduremodel.ClinicName = _dbcontext.Clinic.Where(x=>x.ClinicId == procedure.ClinicId).Select(x=>x.ClinicName).FirstOrDefault();

                    proceduremodel.ProcedureName = procedure.ProcedureName;
                    proceduremodel.ProcedureId = procedure.ProcedureId;
                    lstprocedure.Add(proceduremodel);


                }

                return View(lstprocedure.ToList());

            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log the error)
                return StatusCode(500, "An error occurred while fetching users.");
            }
        }

       
        public async Task<IActionResult> Create()
        {
            try
            {
                ProceduresClinic procedure = new ProceduresClinic();
                //  procedure.Clinics = new List<Clinic>();

                IEnumerable<Clinic> clinics = await _ClinicService.GetClinics();
                
                ViewBag.Clinics = clinics.ToList();
                return View(procedure);

            }
            catch (Exception ex)
            {

            }
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProceduresClinic procedure)
        {

            procedure.CreatedDate = DateTime.Now;
            procedure.CreatedBy = "admin";
            var _procedure = _ProcedureService.CreateProcedure(procedure);
            if (_procedure.ProcedureId > 0)
                return RedirectToAction("Index"); // Redirect to a success page or wherever you need.
            else
                return View();

            //  return Ok(clinic);
        }

        public async Task<IActionResult> Edit(int id)
        {
            IEnumerable<ProceduresClinic> procedureclinic = await _ProcedureService.GetProcedures();

            var _clinic = procedureclinic.Where(c => c.ProcedureId == id).FirstOrDefault();
            IEnumerable<Clinic> clinics = await _ClinicService.GetClinics();
            ViewBag.Clinics = clinics.ToList();
            return View(_clinic);

        }
        [HttpPost]
        public IActionResult Edit(ProceduresClinic editprocedure)
        {

            var _procedure = _ProcedureService.ModifyProcedure(editprocedure);
            return RedirectToAction("Index");


        }
    }
}
