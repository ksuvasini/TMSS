using Microsoft.AspNetCore.Mvc;

namespace TMSSDemo.Controllers
{
    public class ProcedureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
