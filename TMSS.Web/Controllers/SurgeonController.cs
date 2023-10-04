using Microsoft.AspNetCore.Mvc;

namespace TMSSDemo.Controllers
{
    public class SurgeonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
