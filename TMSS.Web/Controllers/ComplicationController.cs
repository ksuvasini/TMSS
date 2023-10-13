using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TMSS.DataAccess.DataContext;
using TMSS.Domain.Entities;
using TMSS.Services.Interfaces;

namespace TMSSDemo.Controllers
{
    public class ComplicationController : Controller
    {
        private readonly ILogger<ComplicationController> _logger;
        public IComplicationService _Service { get; set; }
        private readonly IMapper _mapper;
        public TMSSDbContext? _dbcontext;

        public ComplicationController(IComplicationService Service, ILogger<ComplicationController> logger, IMapper mapper, TMSSDbContext context)
        {
            _logger = logger;
            _Service = Service;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _dbcontext = context;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                IEnumerable<Complication> complications = await _Service.GetComplications();
                return View(complications);
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log the error)
                return StatusCode(500, "An error occurred while fetching users.");
            }
        }
        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Create(Complication complication)
        {
            complication.CreatedDate = DateTime.Now;
            complication.CreatedBy = "admin";
            var _user = _Service.CreateComplication(complication);
            if (_user.ComplicationId > 0)
                return RedirectToAction("Index"); // Redirect to a success page or wherever you need.
            else
                return View();

        }
        public async Task<IActionResult> Edit(int id)
        {
            IEnumerable<Complication> complication = await _Service.GetComplications();

            var _complication = complication.Where(c => c.ComplicationId == id).FirstOrDefault();
            return View(_complication);

        }
        [HttpPost]
        public IActionResult Edit(Complication editcomplication)
        {

            var _complication = _Service.ModifyComplication(editcomplication);
            return RedirectToAction("Index");


        }
    }
}
