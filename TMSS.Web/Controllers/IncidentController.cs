using Microsoft.AspNetCore.Mvc;
using TMSS.Web.Models;

namespace TMSSDemo.Controllers
{
	public class IncidentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(IncidentViewModel incident)
        {
          
            return Ok(incident);
        }
        [HttpGet]
        public IActionResult Get()
        {

            return View();
        }
    }
}
