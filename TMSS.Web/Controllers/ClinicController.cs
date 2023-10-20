using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TMSS.DataAccess.DataContext;
using TMSS.Domain.Entities;
using TMSS.Services.Interfaces;
using TMSS.Web.Controllers;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TMSSDemo.Controllers
{
    public class ClinicController : Controller
    {
        private readonly ILogger<ClinicController> _logger;
        public IClinicService _Service { get; set; }
        private readonly IMapper _mapper;
        public TMSSDbContext? _dbcontext;

        public ClinicController(IClinicService Service, ILogger<ClinicController> logger, IMapper mapper, TMSSDbContext context)
        {
            _logger = logger;
            _Service = Service;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _dbcontext = context;
        }
        public async Task<IActionResult> Index(string searchstring)
        {
            try
            {
                if (!String.IsNullOrEmpty(searchstring))
                {
                    IEnumerable<Clinic> clinics =  _Service.GetClinics();
                    int pageSize = 3; // Number of items to display on each page


                    using (var context = new TMSSDbContext())
                    {
                        searchstring = searchstring.ToLower(); // Convert the search keyword to lowercase

                        clinics = clinics
               .Where(s => s.ClinicName.ToLower().Contains(searchstring)
                         || s.ClinicLocation.ToLower().Contains(searchstring));

                     return View(clinics);

                    }

                    //searchstring = searchstring.ToLower(); // Convert the search keyword to lowercase

                    //var products = context.Products
                    //    .Where(p => SqlFunctions.PatIndex("%" + keyword + "%", p.Name.ToLower()) > 0)
                    //    .ToList();

                    //return View(products);
                }
                else
                {

                    IEnumerable<Clinic> clinics =  _Service.GetClinics();
                    return View(clinics);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log the error)
                return StatusCode(500, "An error occurred while fetching clinics.");
            }
        }


        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Create(Clinic clinic)
        {
            clinic.CreatedDate = DateTime.Now;
            clinic.CreatedBy = "admin";
            var _user = _Service.CreateClinic(clinic);
            if (_user.ClinicId > 0)
                return RedirectToAction("Index"); // Redirect to a success page or wherever you need.
            else
                return View();

            //  return Ok(clinic);
        }
        public async Task<IActionResult> Edit(int id)
        {
            IEnumerable<Clinic> clinics =  _Service.GetClinics();

            var _clinics = clinics.Where(c => c.ClinicId == id).FirstOrDefault();
            return View(_clinics);

        }
        [HttpPost]
        public IActionResult Edit(Clinic editclinic)
        {

            var _clinics = _Service.ModifyClinic(editclinic);
            return RedirectToAction("Index");


        }


    }
}
