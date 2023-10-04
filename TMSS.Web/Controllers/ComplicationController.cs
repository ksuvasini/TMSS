using Microsoft.AspNetCore.Mvc;

namespace TMSSDemo.Controllers
{
    public class ComplicationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
