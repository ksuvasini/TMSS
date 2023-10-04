using Microsoft.AspNetCore.Mvc;

namespace TMSSDemo.Controllers
{
    public class ClinicController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //public IActionResult AddClinic() 
        //{
        //    return View();
        //}
    }
}
