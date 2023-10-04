using Microsoft.AspNetCore.Mvc;
using TMSS.Web.Models;

namespace TMSSDemo.Controllers
{
    public class GenerateReportController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ReportViewModel report)
        {

            return Ok(report);
        }

        [HttpGet]
        public IActionResult Get()
        {

            return View();
        }

    }
}
